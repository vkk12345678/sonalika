using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.IO.Ports ;    

namespace Logger
{
    public partial class frmSysP : Form
    {
        String[] SyspArr = new string[75];
        string[] ports = SerialPort.GetPortNames();
        //OleDbConnection con; 
        public frmSysP()

        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBox7.Items.Add("COM");
            ComboBox18.Items.Add("COM");
            ComboBox19.Items.Add("COM");
            ComboBox21.Items.Add("COM");
            foreach (string port in ports)
            {
                ComboBox7.Items.Add(port);
                ComboBox18.Items.Add(port);
                ComboBox19.Items.Add(port);
                ComboBox21.Items.Add(port);
            }
            try
            {

                //////OleDbConnection con = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Global.PATH + "General.accdb");
                ////////OleDbConnection con = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source=" + Global.PATH + "General.accdb");
                Global.Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM TbSys WHERE FileName = 'SystemPara'";               
                int I = 0;
                MySqlDataAdapter Dap = new MySqlDataAdapter("SELECT * FROM TbSys WHERE FileName = 'SystemPara'", Global.con);
                DataSet ds = new DataSet();
                Dap.Fill(ds);

                for (I = 0; I < (ds.Tables[0].Columns.Count - 1); I++)
                {
                    SyspArr[I] = ds.Tables[0].Rows[0].ItemArray[I + 1].ToString();
                }


                ds.Dispose();
                Dap.Dispose();
                Global.con.Close();

                TextBox1.Text = SyspArr[0];
                TextBox2.Text = SyspArr[1];
                ComboBox1.Text = SyspArr[2];
                TextBox3.Text = SyspArr[3];
                TextBox4.Text = SyspArr[4];
                TextBox5.Text = SyspArr[5];
                TextBox6.Text = SyspArr[6];
                TextBox7.Text = SyspArr[7];
                TextBox8.Text = SyspArr[8];
                TextBox9.Text = SyspArr[9];
                ComboBox2.Text = SyspArr[10];
                ComboBox3.Text = SyspArr[11];
                if (SyspArr[12] == "TRUE") CheckBox1.Checked = true; else CheckBox1.Checked = false;
                if (SyspArr[13] == "TRUE") CheckBox2.Checked = true; else CheckBox2.Checked = false;
                if (SyspArr[14] == "TRUE") CheckBox3.Checked = true; else CheckBox3.Checked = false;
                ComboBox20.Text = SyspArr[15];
                ComboBox4.Text = SyspArr[16];
                ComboBox5.Text = SyspArr[17];
                ComboBox6.Text = SyspArr[18];
                // ComboBox7.Items.Add(SyspArr[19]);  
                ComboBox7.Text = SyspArr[19];

                TextBox10.Text = SyspArr[20];
                ComboBox8.Text = SyspArr[21];
                ComboBox9.Text = SyspArr[22];

                TextBox11.Text = SyspArr[23];
                ComboBox10.Text = SyspArr[24];
                ComboBox11.Text = SyspArr[25];

                TextBox12.Text = SyspArr[26];
                ComboBox12.Text = SyspArr[27];
                ComboBox13.Text = SyspArr[28];

                TextBox13.Text = SyspArr[29];
                ComboBox14.Text = SyspArr[30];
                ComboBox15.Text = SyspArr[31];

                TextBox14.Text = SyspArr[32];
                ComboBox16.Text = SyspArr[33];
                ComboBox17.Text = SyspArr[34];

                ComboBox18.Text = SyspArr[35];
                if (SyspArr[36] == "TRUE") RadioButton1.Checked = true;
                //if (SyspArr[37] == "true") RadioButton2.Checked = true;
                if (SyspArr[38] == "TRUE") RadioButton3.Checked = true;


                ComboBox19.Text = SyspArr[39];

                if (SyspArr[40] == "TRUE")
                {
                    CheckBox4.Checked = true;
                    TextBox15.Enabled = true;
                    TextBox16.Enabled = true;
                }
                else
                {
                    CheckBox4.Checked = false;
                    TextBox15.Enabled = false;
                    TextBox16.Enabled = false;
                }
                TextBox15.Text = SyspArr[41];
                TextBox16.Text = SyspArr[42];

                if (SyspArr[43] == "TRUE")
                {
                    CheckBox5.Checked = true;
                    TextBox17.Enabled = true;
                    TextBox18.Enabled = true;
                }
                else
                {
                    CheckBox5.Checked = false;
                    TextBox17.Enabled = false;
                    TextBox18.Enabled = false;
                }
                TextBox17.Text = SyspArr[44];
                TextBox18.Text = SyspArr[45];

                if (SyspArr[46] == "TRUE")
                {
                    CheckBox6.Checked = true;
                    TextBox19.Enabled = true;
                    TextBox20.Enabled = true;
                }
                else
                {
                    CheckBox6.Checked = false;
                    TextBox19.Enabled = false;
                    TextBox20.Enabled = false;
                }
                TextBox19.Text = SyspArr[47];
                TextBox20.Text = SyspArr[48];

                if (SyspArr[49] == "TRUE")
                {
                    CheckBox7.Checked = true;
                    TextBox21.Enabled = true;
                    TextBox22.Enabled = true;
                }
                else
                {
                    CheckBox7.Checked = false;
                    TextBox21.Enabled = false;
                    TextBox22.Enabled = false;
                }
                TextBox21.Text = SyspArr[50];
                TextBox22.Text = SyspArr[51];

                if (SyspArr[52] == "TRUE")
                {
                    CheckBox8.Checked = true;
                    TextBox23.Enabled = true;
                    TextBox24.Enabled = true;
                }
                else
                {
                    CheckBox8.Checked = false;
                    TextBox23.Enabled = false;
                    TextBox24.Enabled = false;
                }

                TextBox23.Text = SyspArr[53];
                TextBox24.Text = SyspArr[54];


                ComboBox21.Text = SyspArr[55];
                comboBox22.Text = SyspArr[56];
                comboBox23.Text = SyspArr[57];
                comboBox24.Text = SyspArr[58];
                comboBox25.Text = SyspArr[59];


                if (SyspArr[60] == "TRUE") checkBox10.Checked = true; else checkBox10.Checked = false;
                comboBox26.Text = SyspArr[61];
                comboBox27.Text = SyspArr[62];
               
                
                //if (SyspArr[63] == "TRUE") CheckBox1.Checked = true; else CheckBox1.Checked = false;
                //if (SyspArr[64] == "TRUE") CheckBox2.Checked = true; else CheckBox2.Checked = false;
                if (SyspArr[65] == "TRUE") checkBox9.Checked = true; else checkBox9.Checked = false;
                if (SyspArr[66] == "TRUE") checkBox13.Checked = true; else checkBox13.Checked = false;

                if (checkBox10.CheckState == CheckState.Checked)
                {
                    //groupBox7.Visible = true;
                    //groupBox7.Enabled = true;
                }
                else
                {
                    //groupBox7.Visible = false;
                    //groupBox7.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Code:- 14001 ", ex.Message);
                Global.Create_OnLog(ex.Message);
            }
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Global.flg_Log_service = false;
            this.Close();
        }

        private void Add_RangeList(String M_Type, int M_No)
        {
            try
            {
                String str = "";
                switch (M_Type)
                {
                    case "NONE":
                        str = "NONE";
                        break;
                    case "4018*8":
                        str = "K-Type,J-Type";
                        break;
                    case "4017*8":
                        str = "-10~+10V,4~20mA";
                        break;
                    case "4015*6":
                        str = "-50~150°C,0~200°C,0~400°C";
                        break;
                }

                string input = str;
                string pattern = @"(,)";
                Regex regex = new Regex(pattern);
                switch (M_No)
                {
                    case 1:
                        ComboBox9.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox9.Items.Add(result);
                        }
                        ComboBox9.SelectedIndex = 0;
                        break;
                    case 2:
                        ComboBox11.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox11.Items.Add(result);
                        }
                        ComboBox11.SelectedIndex = 0;
                        break;
                    case 3:
                        ComboBox13.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox13.Items.Add(result);
                        }
                        ComboBox13.SelectedIndex = 0;
                        break;
                    case 4:
                        ComboBox15.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox15.Items.Add(result);
                        }
                        ComboBox15.SelectedIndex = 0;
                        break;
                    case 5:
                        ComboBox17.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox17.Items.Add(result);
                        }
                        ComboBox17.SelectedIndex = 0;
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14002", ex.Message);
                Global.Create_OnLog(ex.Message);
            }

            
        }

       
        

        private void Save_File()
        {
            try
            {
                //String str;
                String[] SaveArr = new String[75];

                SaveArr[0] = TextBox1.Text;
                SaveArr[1] = TextBox2.Text;
                SaveArr[2] = ComboBox1.Text;
                SaveArr[3] = TextBox3.Text;
                SaveArr[4] = TextBox4.Text;
                SaveArr[5] = TextBox5.Text;
                SaveArr[6] = TextBox6.Text;
                SaveArr[7] = TextBox7.Text;
                SaveArr[8] = TextBox8.Text;
                SaveArr[9] = TextBox9.Text;
                SaveArr[10] = ComboBox2.Text;
                SaveArr[11] = ComboBox3.Text;

                if (CheckBox1.Checked == true) SaveArr[12] = "TRUE"; else SaveArr[12] = "FALSE";
                if (CheckBox2.Checked == true) SaveArr[13] = "TRUE"; else SaveArr[13] = "FALSE";
                if (CheckBox3.Checked == true) SaveArr[14] = "TRUE"; else SaveArr[14] = "FALSE";
                SaveArr[15] = ComboBox20.Text;
                SaveArr[16] = ComboBox4.Text;
                SaveArr[17] = ComboBox5.Text;
                SaveArr[18] = ComboBox6.Text;
                SaveArr[19] = ComboBox7.Text;

                SaveArr[20] = TextBox10.Text;
                SaveArr[21] = ComboBox8.Text;
                SaveArr[22] = ComboBox9.Text;

                SaveArr[23] = TextBox11.Text;
                SaveArr[24] = ComboBox10.Text;
                SaveArr[25] = ComboBox11.Text;

                SaveArr[26] = TextBox12.Text;
                SaveArr[27] = ComboBox12.Text;
                SaveArr[28] = ComboBox13.Text;

                SaveArr[29] = TextBox13.Text;
                SaveArr[30] = ComboBox14.Text;
                SaveArr[31] = ComboBox15.Text;

                SaveArr[32] = TextBox14.Text;
                SaveArr[33] = ComboBox16.Text;
                SaveArr[34] = ComboBox17.Text;
                SaveArr[35] = ComboBox18.Text;

                if (RadioButton1.Checked == true) SaveArr[36] = "TRUE"; else SaveArr[36] = "FALSE";
                SaveArr[37] = "FALSE";
                if (RadioButton3.Checked == true) SaveArr[38] = "TRUE"; else SaveArr[38] = "FALSE";
                SaveArr[39] = ComboBox19.Text;

                if (CheckBox4.Checked == true) SaveArr[40] = "TRUE"; else SaveArr[40] = "FALSE";
                SaveArr[41] = TextBox15.Text;
                SaveArr[42] = TextBox16.Text;

                if (CheckBox5.Checked == true) SaveArr[43] = "TRUE"; else SaveArr[43] = "FALSE";
                SaveArr[44] = TextBox17.Text;
                SaveArr[45] = TextBox18.Text;

                if (CheckBox6.Checked == true) SaveArr[46] = "TRUE"; else SaveArr[46] = "FALSE";
                SaveArr[47] = TextBox19.Text;
                SaveArr[48] = TextBox20.Text;

                if (CheckBox7.Checked == true) SaveArr[49] = "TRUE"; else SaveArr[49] = "FALSE";
                SaveArr[50] = TextBox21.Text;
                SaveArr[51] = TextBox22.Text;

                if (CheckBox8.Checked == true) SaveArr[52] = "TRUE"; else SaveArr[52] = "FALSE";


                SaveArr[53] = TextBox23.Text;
                SaveArr[54] = TextBox24.Text;

                SaveArr[55] = ComboBox21.Text;
                SaveArr[56] = comboBox22.Text;
                SaveArr[57] = comboBox23.Text;
                SaveArr[58] = comboBox24.Text;
                SaveArr[59] = comboBox25.Text;   
                if (checkBox10.Checked == true) SaveArr[60] = "TRUE"; else SaveArr[60] = "FALSE";
                SaveArr[61] = comboBox26.Text;
                SaveArr[62] = comboBox27.Text;
                SaveArr[63] = "1";
                SaveArr[64] = "1"; 
                //if (CheckBox1.Checked == true) SaveArr[63] = "TRUE"; else SaveArr[63] = "FALSE";
                //if (CheckBox2.Checked == true) SaveArr[64] = "TRUE"; else SaveArr[64] = "FALSE";
                if (checkBox9.Checked == true) SaveArr[65] = "TRUE"; else SaveArr[65] = "FALSE";
                if (checkBox13.Checked == true) SaveArr[66] = "TRUE"; else SaveArr[66] = "FALSE";


                SaveArr[67] = TextBox26.Text;
                SaveArr[68] = TextBox27.Text;
                SaveArr[69] = TextBox28.Text;
                SaveArr[70] = TextBox29.Text;
                SaveArr[71] = TextBox30.Text;
                SaveArr[72] = TextBox31.Text;
                SaveArr[73] = TextBox32.Text;

               
                String StrData = "";
                int i = 0;
                Global.Open_Connection("General", "con");               
                for (i = 0; i <= 65; i++)
                {
                    StrData = StrData + "CH" + (i + 1) + " = '" + SaveArr[i] + "', ";
                }
                StrData = StrData + "CH67 ='" + SaveArr[66] + "'";


                MySqlCommand cmdInst = new MySqlCommand();
                cmdInst.CommandText = "UPDATE TbSys SET " + StrData + "WHERE FileName = 'SystemPara'";
                cmdInst.Connection = Global.con;
                cmdInst.ExecuteNonQuery();
                MessageBox.Show("New Changes are saves .....");
                Global.con.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14003", ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ComboBox7.Text == "")
            {
                EP.SetError(ComboBox7, "Select the Comport first");
                GroupBox3.BringToFront();
                GroupBox2.SendToBack();
                Button3.Enabled = false;  
                return;
            }
            if (ComboBox18.Text == "")
            {
                EP.SetError(ComboBox18, "Select the Comport first");
                GroupBox3.BringToFront();
                GroupBox2.SendToBack();
                Button3.Enabled = false; 
                return;
            }
            if (ComboBox19.Text == "")
            {
                EP.SetError(ComboBox19, "Select the Comport first");
                GroupBox3.BringToFront();
                GroupBox2.SendToBack();
                Button3.Enabled = false; 
                return;
            }
            if (ComboBox21.Text == "")
            {
                EP.SetError(ComboBox21, "Select the Comport first");
                GroupBox3.BringToFront();
                GroupBox2.SendToBack();
                Button3.Enabled = false; 
                return;
            }
            
            Button3.Enabled = true ; 
            EP.Clear();
            Save_File();
            
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox3.Text)))
                {
                    EP.Clear();
                    char[] chars = TextBox3.Text.ToCharArray();
                    for (int i = 0; i < TextBox3.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox3.Text = TextBox3.Text.Remove(i, 1);
                           
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14004",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox4.Text)))
                {
                    EP.Clear();
                    char[] chars = TextBox4.Text.ToCharArray();
                    for (int i = 0; i < TextBox4.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox4.Text = TextBox4.Text.Remove(i, 1);
                            TextBox4.SelectionStart = TextBox4.Text.Length;
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14004",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox5.Text)))
                {
                    char[] chars = TextBox5.Text.ToCharArray();
                    for (int i = 0; i < TextBox5.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox5.Text = TextBox5.Text.Remove(i, 1);
                            TextBox5.SelectionStart = TextBox5.Text.Length;
                        }
                    }
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14005",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox6.Text)))
                {
                    char[] chars = TextBox6.Text.ToCharArray();
                    for (int i = 0; i < TextBox6.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox6.Text = TextBox6.Text.Remove(i, 1);
                            TextBox6.SelectionStart = TextBox6.Text.Length;
                        }
                    }
                }
             

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14005",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox7.Text)))
                {
                    char[] chars = TextBox7.Text.ToCharArray();
                    for (int i = 0; i < TextBox7.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox7.Text = TextBox7.Text.Remove(i, 1);
                            TextBox7.SelectionStart = TextBox7.Text.Length;
                        }
                    }
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14006",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox15.Text)))
                {
                    char[] chars = TextBox15.Text.ToCharArray();
                    for (int i = 0; i < TextBox15.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox15.Text = TextBox15.Text.Remove(i, 1);
                            TextBox15.SelectionStart = TextBox15.Text.Length;
                        }
                    }
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14007",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox16.Text)))
                {
                    char[] chars = TextBox16.Text.ToCharArray();
                    for (int i = 0; i < TextBox16.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox16.Text = TextBox16.Text.Remove(i, 1);
                            TextBox16.SelectionStart = TextBox16.Text.Length;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14008",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox17_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox17.Text)))
                {
                    char[] chars = TextBox17.Text.ToCharArray();
                    for (int i = 0; i < TextBox17.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox17.Text = TextBox17.Text.Remove(i, 1);
                            TextBox17.SelectionStart = TextBox17.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14009",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox18.Text)))
                {
                    char[] chars = TextBox18.Text.ToCharArray();
                    for (int i = 0; i < TextBox18.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox18.Text = TextBox18.Text.Remove(i, 1);
                            TextBox18.SelectionStart = TextBox18.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 1410",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox19_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox19.Text)))
                {
                    char[] chars = TextBox19.Text.ToCharArray();
                    for (int i = 0; i < TextBox19.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox19.Text = TextBox19.Text.Remove(i, 1);
                            TextBox19.SelectionStart = TextBox19.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14011",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox20_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox20.Text)))
                {
                    char[] chars = TextBox20.Text.ToCharArray();
                    for (int i = 0; i < TextBox20.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox20.Text = TextBox20.Text.Remove(i, 1);
                            TextBox20.SelectionStart = TextBox20.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14012",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox21_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox21.Text)))
                {
                    char[] chars = TextBox21.Text.ToCharArray();
                    for (int i = 0; i < TextBox21.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox21.Text = TextBox21.Text.Remove(i, 1);
                            TextBox21.SelectionStart = TextBox21.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14013",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox22_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox22.Text)))
                {
                    char[] chars = TextBox22.Text.ToCharArray();
                    for (int i = 0; i < TextBox22.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox22.Text = TextBox22.Text.Remove(i, 1);
                            TextBox22.SelectionStart = TextBox22.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14014",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox23_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox23.Text)))
                {
                    char[] chars = TextBox23.Text.ToCharArray();
                    for (int i = 0; i < TextBox23.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox23.Text = TextBox23.Text.Remove(i, 1);
                            TextBox23.SelectionStart = TextBox23.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14015", ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox24_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox24.Text)))
                {
                    char[] chars = TextBox24.Text.ToCharArray();
                    for (int i = 0; i < TextBox24.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox24.Text = TextBox24.Text.Remove(i, 1);
                            TextBox24.SelectionStart = TextBox24.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14016",ex.Message);
                Global.Create_OnLog(ex.Message);
            }
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(TextBox9.Text)))
                {
                    char[] chars = TextBox9.Text.ToCharArray();
                    for (int i = 0; i < TextBox9.Text.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);
                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            TextBox9.Text = TextBox9.Text.Remove(i, 1);
                            TextBox9.SelectionStart = TextBox9.Text.Length;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-14017",ex.Message);
                Global.Create_OnLog(ex.Message);
            }

        }

      
        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (TextBox3.Text == "")
            {
                EP.SetError(TextBox3, "Fill the Max Torque first");
                TextBox3.Focus();
            }
            else
            {
                EP.Clear();
            }
           
        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if (TextBox4.Text == "")
            {
                EP.SetError(TextBox4, "Fill the Max RPM first");
                TextBox4.Focus();
            }
            else
            {
                EP.Clear();
            }
           
        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {
            if (TextBox5.Text == "")
            {
                EP.SetError(TextBox5, "Fill the Blank text first");
                TextBox5.Focus();
            }
            else
            {
                EP.Clear();
            }
        }

        private void TextBox6_Leave(object sender, EventArgs e)
        {
            if (TextBox6.Text == "")
            {
                EP.SetError(TextBox6, "Fill the Blank Text first");
                TextBox6.Focus();
            }
            else
            {
                EP.Clear();
            }
        }

        private void TextBox7_Leave(object sender, EventArgs e)
        {
            if (TextBox7.Text == "")
            {
                EP.SetError(TextBox7, "Fill the first");
                TextBox7.Focus();
            }
            else
            {
                EP.Clear();
            }
        }

        private void TextBox8_Leave(object sender, EventArgs e)
        {
            if (TextBox8.Text == "")
            {
                EP.SetError(TextBox8, "Fill the Test Cell no. first");
                TextBox8.Focus();
            }
            else
            {
                EP.Clear();
            }
        }

        private void TextBox9_Leave(object sender, EventArgs e)
        {
            if (TextBox9.Text == "")
            {
                EP.SetError(TextBox9, "Fill the first start time first");
                TextBox9.Focus();
            }
            else
            {
                EP.Clear();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                EP.SetError(TextBox1, "Fill the Company name first");
                TextBox1.Focus();
            }
            else
            {
                EP.Clear();
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {
                EP.SetError(TextBox2, "Fill the Department first");
                TextBox2.Focus();
            }
            else
            {
                EP.Clear();
           }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GroupBox2.BringToFront();
            GroupBox3.SendToBack();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GroupBox2.BringToFront();
            GroupBox3.SendToBack();  
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GroupBox2.SendToBack();
            GroupBox3.BringToFront();  

        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox5.CheckState == CheckState.Checked)
            {
                TextBox17.Enabled = true;
                TextBox18.Enabled = true;
            }
            else
            {
                TextBox17.Enabled = false;
                TextBox18.Enabled = false;
            }
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox6.CheckState == CheckState.Checked)
            {
                TextBox19.Enabled = true;
                TextBox20.Enabled = true;
            }
            else
            {
                TextBox19.Enabled = false;
                TextBox20.Enabled = false;
            }
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox7.CheckState == CheckState.Checked)
            {
                TextBox21.Enabled = true;
                TextBox22.Enabled = true;
            }
            else
            {
                TextBox21.Enabled = false;
                TextBox22.Enabled = false;
            }
        }

        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox8.CheckState == CheckState.Checked)
            {
                TextBox23.Enabled = true;
                TextBox24.Enabled = true;
            }
            else
            {
                TextBox23.Enabled = false;
                TextBox24.Enabled = false;
            }

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox4.CheckState == CheckState.Checked)
            {
                TextBox15.Enabled = true;
                TextBox16.Enabled = true;
            }
            else
            {
                TextBox15.Enabled = false;
                TextBox16.Enabled = false;
            }

        }

        private void ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {        
           Add_RangeList(ComboBox8.Text, 1);        
        }

        private void ComboBox10_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox10.Text, 2);
        }

        private void ComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox12.Text, 3);
        }

        private void ComboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox14.Text, 4);
        }

        private void ComboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox16.Text, 5);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {           
                if (checkBox10.CheckState == CheckState.Checked)
                {
                    ComboBox21.Enabled = true;
                    comboBox22.Enabled = true;
                    comboBox23.Enabled = true;
                    comboBox24.Enabled = true;
                    comboBox25.Enabled = true;
                    comboBox26.Enabled = true;
                    comboBox27.Enabled = true;
                }
                else
                {
                    ComboBox21.Enabled = false;
                    comboBox22.Enabled = false;
                    comboBox23.Enabled = false;
                    comboBox24.Enabled = false;
                    comboBox25.Enabled = false;
                    comboBox26.Enabled = false;
                    comboBox27.Enabled = false;                    
                }
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        
       
        

        
       
    }
}
