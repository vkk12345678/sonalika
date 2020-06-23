using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logger
{
    public partial class EngDialog : Form
    {
        private Boolean f_Found = false;

        private frmMain main = new frmMain();

        public EngDialog(frmMain main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
           
            Erp1.Clear();
            Global.flg_prjOn = true; 
            this.Close();
        }


        private void EngDialog_Load(object sender, EventArgs e)
        {
            try
            {
                //Sn = 0;               
                tmrBarcode.Enabled = true;
                txtbarcode.Text = String.Empty;
                Global.Open_Connection("General", "con");
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = 'EngNo'", Global.con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();

                while (Rd1.Read())
                {

                    TextBox1.Text = DateTime.Now.ToString("dd_MM_yyyy"); //Rd1.GetValue(1).ToString();
                    TextBox2.Text = Rd1.GetValue(2).ToString();
                    //TextBox3.Text = Rd1.GetValue(3).ToString();
                  // TextBox4.Text = GRd1.GetValue(4).ToString();
                    textBox5.Text = Rd1.GetValue(4).ToString();
                    TextBox6.Text = Rd1.GetValue(6).ToString();
                   // PrjCombo.Text = Rd1.GetValue(7).ToString();
                    
                    if (Rd1.GetValue(8).ToString() == "True") checkBox1.CheckState = CheckState.Checked; else checkBox1.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(9).ToString() == "True") checkBox2.CheckState = CheckState.Checked; else checkBox2.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(10).ToString() == "True") checkBox3.CheckState = CheckState.Checked; else checkBox3.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(11).ToString() == "True") checkBox4.CheckState = CheckState.Checked; else checkBox4.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(12).ToString() == "True") checkBox5.CheckState = CheckState.Checked; else checkBox5.CheckState = CheckState.Unchecked;                       

                    TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    string ST = (Global.sysIn[10]);
                    long Mn = (Convert.ToInt32(ST.Substring(0, 1)) * 60) + Convert.ToInt32(ST.Substring(2));
                    long Tm;
                    Tm = (Convert.ToInt16(DateTime.Now.Hour.ToString()) * 60) + Convert.ToInt16(DateTime.Now.Minute.ToString());

                    if ((Tm > Mn) && (Tm <= (Mn + 480))) TextBox10.Text = "A";
                    else if ((Tm > (Mn + 480)) && (Tm <= (Mn + 960))) TextBox10.Text = "B";
                    else TextBox10.Text = "C";
                }
                Global.con.Close();
                //Fill_Combo();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - 1001",ex.Message); 
            }
        }

        private void Fill_Combo()
        {
            try
            {
                //Sn = 0;
                //PrjCombo.Enabled = true;
                PrjCombo.Items.Clear();
                PrjCombo.BackColor = Color.Green;
                PrjCombo.ForeColor = Color.Yellow;
                Global.Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject where ProjectFile = 'prj_" + TextBox3.Text + "'", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                while (Rd.Read())
                {
                    PrjCombo.Text = (Rd.GetValue(0).ToString());
                }
                Global.con.Close();
                if (PrjCombo.Text == "")
                {
                    MessageBox.Show("Create project file first  " );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Create project file first  " + ex.Message);
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    checkBox1.CheckState = CheckState.Checked;                   
                }
                else
                {
                    checkBox1.CheckState = CheckState.Unchecked;                   
                }
        }

      
       //private void Read_Project()
       //{
       //    try
       //    {
       //        Global.Open_Connection("General", "con");
       //        OleDbCommand cmd = new OleDbCommand("SELECT * FROM tblProject Where ProjectFile = '" + Global.PrjNm + "'", Global.con);
       //        OleDbDataReader Rd = cmd.ExecuteReader();
       //        while (Rd.Read())
       //        {
       //            frmMain.Prj[0] = Rd.GetValue(0).ToString();
       //            frmMain.Prj[1] = Rd.GetValue(1).ToString();
       //            frmMain.Prj[2] = Rd.GetValue(2).ToString();
       //            //frmMain.Prj[3] = Rd.GetValue(3).ToString();
       //            frmMain.Prj[4] = Rd.GetValue(4).ToString();
       //            Global.NCyl = Rd.GetValue(4).ToString();
       //            frmMain.Prj[5] = Rd.GetValue(5).ToString();
       //            frmMain.Prj[6] = Rd.GetValue(6).ToString();
       //            Global.EngMd = frmMain.Prj[6].Trim();
       //        }
       //        Global.con.Close();
       //    }
       //    catch (Exception ex)
       //    {
       //        MessageBox.Show("Error in Rd_Project : ", ex.Message);
       //        Global.Create_OnLog(ex.Message);
       //    }

       //}

       private void Check_File_Validation()
       {
           try
           {

               if (Global.EngNo == String.Empty)
                   MessageBox.Show("Engine No. Not Entered ......., ");
               else
               {
                   Global.Open_Connection("General", "con");
                   MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject WHERE ProjectFile = '" + Global.PrjNm + "'", Global.con);
                   MySqlDataReader Rd = cmd.ExecuteReader();
                   int x = 0;
                   while (Rd.Read())
                   {
                       for (x = 0; x < (Rd.FieldCount - 1); x++) Global.Prj[x] = Rd.GetValue(x).ToString();
                   }

                   Global.cumhours = "0000.00.00";
                   Global.Open_Connection("General", "con");
                   MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM tblEngine", Global.con);
                   MySqlDataReader Rd1 = cmd1.ExecuteReader();
                   x = 0;
                   while (Rd1.Read())
                   {
                       if (Global.Prj[1] == Rd1.GetValue(0).ToString())
                       {
                           f_Found = true;
                           break;
                       }
                       if (Convert.ToInt32(Global.Prj[12]) >= 1000)
                       {
                          Global.Dig_OutBit(0, 6, true);
                       }
                       else
                       {
                          Global.Dig_OutBit(0, 6, false);
                       }
                       x += 1;
                   }
                   if (f_Found == false)
                   {
                       MessageBox.Show("Engine File  Not Found ....... ");
                       return;
                   }
                   Global.con.Close(); 
                   //  **************************
                   Global.Open_Connection("Limit", "conLim");
                   DataTable dt = Global.conLim.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       if (Global.Prj[3] == dt.Rows[i]["TABLE_NAME"].ToString())
                       {
                           f_Found = true;
                           break;
                       }
                       x += 1;
                   }
                   if (f_Found == false)
                   {
                       MessageBox.Show("Limit File  Not Found ....... ");
                       return;
                   }
                   //    **************************

                   Global.Open_Connection("Sequence", "conSeq");
                   dt = Global.conSeq.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       if (Global.Prj[2] == dt.Rows[i]["TABLE_NAME"].ToString())
                       {
                           f_Found = true;
                           break;
                       }
                       x += 1;
                   }
                   if (f_Found == false)
                   {
                       MessageBox.Show("Sequence File  Not Found ....... ");
                       return;
                   }
                   //     **************************

               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error in Check File validation:" + ex.Message);
           }

       }

       private void btnMSave_Click(object sender, EventArgs e)
       {
           try
           {
               Global.JobOrdNo = "***";
               Process[] prs = Process.GetProcesses();
               foreach (Process pr in prs)
               {
                   //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                   if (pr.ProcessName == "Editors") pr.Kill();
                   if (pr.ProcessName == "Dataappliacation") pr.Kill();
               }
              Erp1.Clear();
              if (txtbarcode.Text == String.Empty) // "")
               {
                   //Erp1.SetError(TextBox1, "Please Type Engine No.....");
                   MessageBox.Show("Please Type Engine No. ...... ");
                   txtbarcode.Focus();
               }
               else if (PrjCombo.Text == String.Empty)
               {
                  Erp1.SetError(PrjCombo, "Please Select Project.....");
                   MessageBox.Show("Please Select Project. ...... ");
                   PrjCombo.Focus();
               }
               else if ((textBox7.Text == String.Empty) || (textBox8.Text == String.Empty) || (textBox11.Text == String.Empty) ||
                        (textBox12.Text == String.Empty) || (textBox13.Text == String.Empty) || (textBox14.Text == String.Empty))
               {
                   Erp1.SetError(panel2, "Some Input Value Is missing." + "\n\n" + " 1. Engine Idle RPM " + "\n" +
                                                                             " 2. Engine FlyUp RPM " + "\n" +
                                                                             " 3. Engine Max Power @ RPM " + "\n" +
                                                                             " 4. Engine Max Torque@ RPM ");

                   MessageBox.Show("Some Input Value Is missing." + "\n\n" + " 1. Engine Idle RPM " + "\n" +
                                                                             " 2. Engine FlyUp RPM " + "\n" +
                                                                             " 3. Engine Max Power @ RPM " + "\n" +
                                                                             " 4. Engine Max Torque@ RPM ");
                   panel2.Focus();  
               }
               else
               {

                   Global.EngNo = TextBox1.Text;    //TextBox1.Text;
                   Global.EngineNo = TextBox1.Text;
                   Global.FipNo = TextBox2.Text;
                   Global.EngMd = TextBox3.Text;
                   //Global.OperatorNm = TextBox4.Text;
                   Global.EnginerNm = textBox5.Text;
                   Global.TestRef = TextBox6.Text;
                   Global.PrjNm = PrjCombo.Text;
                   Global.T_Date = TextBox9.Text;
                   Global.Shift = TextBox10.Text;
                   if (checkBox1.CheckState == CheckState.Checked) Global.flg_smk = true; else Global.flg_smk = false;
                   if (checkBox2.CheckState == CheckState.Checked) Global.flg_Radiator = true; else Global.flg_Radiator = false;
                   if (checkBox3.CheckState == CheckState.Checked) Global.flg_Fan = true; else Global.flg_Fan = false;
                   if (checkBox4.CheckState == CheckState.Checked) Global.flg_AirCln = true; else Global.flg_AirCln = false;
                   if (checkBox5.CheckState == CheckState.Checked) Global.flg_Silincer = true; else Global.flg_Silincer = false;
                   if (rd_New.Checked == true) Global.flg_NewFile = true; else Global.flg_NewFile = false;
                   if (rd_Last.Checked == true) Global.flg_OldFile = true; else Global.flg_OldFile = false;

                   //Global.I_Rpm = int.Parse(textBox7.Text);
                   //Global.F_Rpm = int.Parse(textBox8.Text);
                   //Global.Max_Pow = Double.Parse(textBox11.Text);
                   //Global.Pow_RPM = Double.Parse(textBox12.Text);
                   //Double X = Double.Parse(textBox13.Text);
                   //Global.Max_Trq = X + (X / 5);
                   //Global.Trq_RPM = Double.Parse(textBox14.Text);  


                   Global.Open_Connection("General", "con");
                   MySqlCommand cmd = new MySqlCommand("UPDATE TbSys SET " +
                                " CH1 = '" + Global.EngNo + "'," +
                                " CH2 = '" + Global.FipNo + "'," +
                                " CH3 = '" + Global.EngMd + "'," +
                                " CH4 = '" + Global.OperatorNm + "'," +
                                " CH5 = '" + Global.TKnNo + "'," +
                                " CH6 = '" + Global.TestRef + "'," +
                                " CH7 = '" + Global.PrjNm + "'," +
                                " CH8 = '" + Global.flg_smk + "'," +
                                " CH9 = '" + Global.flg_Radiator + "'," +
                                " CH10 = '" + Global.flg_Fan + "'," +
                                " CH11 = '" + Global.flg_AirCln + "'," +
                                " CH12 = '" + Global.flg_Silincer + "'," +
                                " CH13 = '" + Global.flg_NewFile + "'," +
                                " CH14 = '" + Global.flg_OldFile + "'" +
                                " WHERE FileName = 'EngNo'", Global.con);
                   cmd.ExecuteNonQuery();
                   Global.con.Close();
                   if (rd_PIDAnalog.Checked == true)
                   {
                       Global.flg_Analog = true;
                       Global.flg_Digital = false;
                   }
                   else if (rd_PIDDigital.Checked == true)
                   {
                       Global.flg_Analog = false;
                       Global.flg_Digital = true;
                   }
                   else
                   {
                       Global.flg_Analog = false;
                       Global.flg_Digital = false;
                   }
                   Global.Rd_System();
                   Global.PrjNm = PrjCombo.Text;
                   Check_File_Validation();
                   Global.flg_Auto = false;
                   Global.flg_Manual = true;
                   Global.Read_Eng();
                   Global.Read_Limfl();
                   Global.Flg_Ready = true;
                  
                   Global.main.BtnSA.Enabled = true;
                   Global.main.Btn21.Enabled = false;

                   //Global.I_Rpm = int.Parse(textBox7.Text);
                   //Global.F_Rpm = int.Parse(textBox8.Text);
                   //Global.Max_Pow = Double.Parse(textBox11.Text);
                   //Global.Pow_RPM = Double.Parse(textBox12.Text);
                   //Double X = Double.Parse(textBox13.Text);
                   //Global.Max_Trq = X + (X / 10);
                   //Global.Trq_RPM = Double.Parse(textBox14.Text);  
                   
                   this.Close();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("ErrorCode- 1002", ex.Message);
           }
       }

      
       private void btnASave_Click(object sender, EventArgs e)
       {
           try
           {
               Global.JobOrdNo = "***";
               Process[] prs = Process.GetProcesses();
               foreach (Process pr in prs)
               {
                   //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                   if (pr.ProcessName == "Editors") pr.Kill();
                   if (pr.ProcessName == "Dataappliacation") pr.Kill();
               }
               Erp1.Clear();
               if (txtbarcode.Text == String.Empty) // "")
               {
                   Erp1.SetError(txtbarcode, "Please Type Engine No.....");
                   MessageBox.Show("Please Type Engine No. ...... ");
                   txtbarcode.Focus();
               }
               else if (TextBox1.Text == String.Empty) // "")
               {
                       Erp1.SetError(TextBox1, "Please Scan Engine No.....");
                       MessageBox.Show("Please Scan Engine No. ...... ");
                       TextBox1.Focus();
               }
               else if (PrjCombo.Text == String.Empty)
               {
                   Erp1.SetError(PrjCombo, "Please Select Project.....");
                   MessageBox.Show("Please Select Project. ...... ");
                   PrjCombo.Focus();
               }
               else if ((textBox7.Text == String.Empty) || (textBox8.Text == String.Empty) || (textBox11.Text == String.Empty) ||
                        (textBox12.Text == String.Empty) || (textBox13.Text == String.Empty) || (textBox14.Text == String.Empty))
               {
                   Erp1.SetError(panel2, "Some Input Value Is missing." + "\n\n" + " 1. Engine Idle RPM " + "\n" +
                                                                             " 2. Engine FlyUp RPM " + "\n" +
                                                                             " 3. Engine Max Power @ RPM " + "\n" +
                                                                             " 4. Engine Max Torque@ RPM ");

                   MessageBox.Show("Some Input Value Is missing." + "\n\n" + " 1. Engine Idle RPM " + "\n" +
                                                                             " 2. Engine FlyUp RPM " + "\n" +
                                                                             " 3. Engine Max Power @ RPM " + "\n" +
                                                                             " 4. Engine Max Torque@ RPM ");
                   panel2.Focus();  
               }
               else
               {
                   Global.EngNo = TextBox1.Text;
                   Global.EngineNo = TextBox1.Text;
                   Global.FipNo = TextBox2.Text;
                   Global.EngMd = TextBox3.Text;
                   Global.Chasis_N = TextBox4.Text;
                   Global.EnginerNm = textBox5.Text;
                   Global.TestRef = TextBox6.Text;//eng_reating
                   Global.PrjNm = PrjCombo.Text;
                   Global.T_Date = TextBox9.Text;
                   Global.Shift = TextBox10.Text;
                   if (checkBox1.CheckState == CheckState.Checked) Global.flg_smk = true; else Global.flg_smk = false;
                   if (checkBox2.CheckState == CheckState.Checked) Global.flg_Radiator = true; else Global.flg_Radiator = false;
                   if (checkBox3.CheckState == CheckState.Checked) Global.flg_Fan = true; else Global.flg_Fan = false;
                   if (checkBox4.CheckState == CheckState.Checked) Global.flg_AirCln = true; else Global.flg_AirCln = false;
                   if (checkBox5.CheckState == CheckState.Checked) Global.flg_Silincer = true; else Global.flg_Silincer = false;
                   if (rd_New.Checked == true) Global.flg_NewFile = true; else Global.flg_NewFile = false;
                   if (rd_Last.Checked == true) Global.flg_OldFile = true; else Global.flg_OldFile = false;
                  
                   //Global.I_Rpm = int.Parse(textBox7.Text);
                   //Global.F_Rpm = int.Parse(textBox8.Text);
                   //Global.Max_Pow = Double.Parse(textBox11.Text);
                   //Global.Pow_RPM = Double.Parse(textBox12.Text);
                   //Double X = Double.Parse(textBox13.Text);
                   //Global.Max_Trq = X + (X / 10);
                   //Global.Trq_RPM = Double.Parse(textBox14.Text);  
                 
                   Global.Open_Connection("General", "con");
                   MySqlCommand cmd = new MySqlCommand("UPDATE TbSys SET " +
                                " CH1 = '" + Global.EngNo + "'," +
                                " CH2 = '" + Global.FipNo + "'," +
                                " CH3 = '" + Global.EngMd + "'," +
                                " CH4 = '" + Global.EnginerNm + "'," +
                                " CH5 = '" + Global.TKnNo + "'," +
                                " CH6 = '" + Global.TestRef + "'," +
                                " CH7 = '" + Global.PrjNm + "'," +
                                " CH8 = '" + Global.flg_smk + "'," +
                                " CH9 = '" + Global.flg_Radiator + "'," +
                                " CH10 = '" + Global.flg_Fan + "'," +
                                " CH11 = '" + Global.flg_AirCln + "'," +
                                " CH12 = '" + Global.flg_Silincer + "'," +
                                " CH13 = '" + Global.flg_NewFile + "'," +
                                " CH14 = '" + Global.flg_OldFile + "'" +
                                " WHERE FileName = 'EngNo'", Global.con);
                   cmd.ExecuteNonQuery();
                   Global.con.Close();
                   Global.Rd_System();
                   Global.PrjNm = PrjCombo.Text;
                   Check_File_Validation();
                   Global.flg_Auto = true;
                   Global.flg_Manual = false;
                   Global.Read_Eng();
                   Global.Read_Limfl();
                   Global.Flg_Ready = true;
                   Global.main.BtnSA.Enabled = false;
                   Global.main.Btn21.Enabled = true;

                   //Global.I_Rpm = int.Parse(textBox7.Text);
                   //Global.F_Rpm = int.Parse(textBox8.Text);
                   //Global.Max_Pow = Double.Parse(textBox11.Text);
                   //Global.Pow_RPM  = Double.Parse(textBox12.Text);  
                   //Double X = Double.Parse(textBox13.Text);
                   //Global.Max_Trq = X + (X / 10);
                   //Global.Trq_RPM = Double.Parse(textBox14.Text);  


                   this.Close();
                   
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("ErrorCode- 1002", ex.Message);
           }
       }

       private void tmrBarcode_Tick(object sender, EventArgs e)
       {
           //if (Global.PLCIn[4] == 1)
           //{
           //    Global.PLCDig_OutBit(0, 4, true);
           //    Global.BarcodeNo = Global.BarcodePort.ReadExisting();
           //    TextBox1.Text = Global.BarcodeNo;
           //    tmrBarcode.Enabled = false;
           //}

           //if (Global.BarcodePort.IsOpen == false) Global.Init_BarcodePort();

           //Global.BarcodeNo = Global.BarcodePort.ReadExisting();
           //TextBox1.Text = Global.BarcodeNo;
           //Global.Dig_OutBit(0, 1, true);
           //if (Global.BarcodeNo != "")
           //{
           //    tmrBarcode.Enabled = false; //bhushan on dt    02/11
           //}
           //
       }    
 
        private void textBox12_TextChanged(object sender, EventArgs e)
       {

       }

       private void textBox15_TextChanged_1(object sender, EventArgs e)
       {
          
       }

       private void TextBox3_TextChanged(object sender, EventArgs e)
       {
           Fill_Combo();
       }

       private void TextBox4_TextChanged(object sender, EventArgs e)
       {
          
       }

       private void textBox15_Leave(object sender, EventArgs e)
       {
           //if (textBox15.Text == String.Empty) // "")
           //{
           //    Erp1.SetError(textBox15, "Please Scan Engine No.....");
           //    MessageBox.Show("Please Scan Engine No. ...... ");
           //    textBox15.Focus();
           //}
       }

       private void TextBox9_TextChanged(object sender, EventArgs e)
       {

       }


       private void txtbarcode_TextChanged(object sender, EventArgs e)
       {
           //try
           //{
           //    var myString = txtbarcode.Text;
           //    string ext = myString.Substring(0, myString.LastIndexOf("_") + -2);
           //    string ext1 = myString.Remove(0, myString.LastIndexOf("_") + 1);
           //    TextBox3.Text = ext;
           //    TextBox4.Text = ext1;
           //}
           //catch
           //{
           //    MessageBox.Show("Please scan barcode properly!!!!!!!!!");
           //    return;
           //}
       }

       private void txtbarcode_TabIndexChanged(object sender, EventArgs e)
       {
           //try
           //{
           //    var myString = txtbarcode.Text;//TextBox1.Text;
           //    string ext = myString.Substring(0, myString.LastIndexOf("_") + -2);
           //    string ext1 = myString.Remove(0, myString.LastIndexOf("_") + 1);
           //    TextBox3.Text = ext;
           //    TextBox4.Text = ext1;
           //}
           //catch
           //{
           //    MessageBox.Show("Please scan barcode properly!!!!!!!!!");
           //    return;
           //}
       }

       private void TextBox2_TextChanged(object sender, EventArgs e)
       {
          
       }

       private void TextBox2_Click(object sender, EventArgs e)
       {

           try
           {
               var myString = txtbarcode.Text;
               string ext = myString.Substring(0, myString.LastIndexOf("_") + -2);
               string ext1 = myString.Remove(0, myString.LastIndexOf("_") + 1);
               TextBox3.Text = ext;
               TextBox4.Text = ext1;
           }
           catch
           {
               MessageBox.Show("Please scan barcode properly!!!!!!!!!");
               return;
           }
       }

      
        
        //***************
    }
}
