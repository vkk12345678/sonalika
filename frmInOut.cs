using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization; 
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using Automation.BDaq; 



namespace Logger
{
    public partial class frmInOut : Form
    {
        public DataGridViewColumnSortMode SortMode { get; set; }
        #region GUI Delegate Declarations
        public delegate void GUIDelegate(string paramString);
        public delegate void GUIClear();
        public delegate void GUIStatus(string paramString);
        #endregion

        int pollCount;
        modbus mb = new modbus();
        public string comn;
        public int Bd = 9600;
        public int Addr;
        public int cnt = 0;
        public Parity p;
        public StopBits stopbt;        

       
        public frmInOut()
        {
            InitializeComponent(); 
        }

        private void frmInOut_Load(object sender, EventArgs e)
        {
            DGIn.RowCount = 16;

            tmrRead.Enabled = true;
            try
            {
                foreach (DataGridViewColumn colm in ViewGrid.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;  
                }
                foreach (DataGridViewColumn colm in DGIn.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn colm in DGOut.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

               Global.Rd_Confg();
                // 
                int Rn = 0;
                while (Rn < 125)
                {
                    ViewGrid.RowCount += 1;
                    ViewGrid[0, Rn].Value = Global.PNo[Rn].ToString();
                    ViewGrid[1, Rn].Value = Global.PSName[Rn].ToString();
                    ViewGrid.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    
                    ViewGrid[3, Rn].Value = Global.PMin[Rn].ToString() + "  :  " + Global.PMax[Rn].ToString();
                    ViewGrid[4, Rn].Value = Global.PUnit[Rn].ToString();
                    ViewGrid[5, Rn].Value = Global.PMark[Rn].ToString();
                    Rn += 1;
                }
                textBox1.Text = Global.Atp.ToString();
                textBox2.Text = Global.Drb.ToString();
                textBox3.Text = Global.Web.ToString(); 
                Global.Rd_System();
                Load_DigInOut();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-5001 " + ex.Message);
            }
        }
        private void Load_DigInOut()
        {
            try
            {
                // automatic
                DGIn.RowCount = 16;
                Global.Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = 'DigInPuts'", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {
                    for (x = 0; x <= 15; x++)
                    {
                        DGIn[1, x].Value = Rd.GetValue(x + 1).ToString();
                        DGIn[1, x].Style.BackColor = Color.Green;
                    }
                }

                DGOut.RowCount = 16;
                // 
                //Global.Open_Connection("General", "con");
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = 'DigOutPuts'", Global.con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();
                x = 0;
                while (Rd1.Read())
                {
                    for (x = 0; x <= 15; x++)
                    {
                        DGOut[1, x].Value = Rd1.GetValue(x + 1).ToString();
                        DGOut[1, x].Style.BackColor = Color.Green;
                    }
                } 
                Global.con.Close();   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code;-5002 " + ex.Message);
            }
        }
        // 
        private void btnClose_Click(object sender, EventArgs e)
        {
            tmrRead.Enabled = false; 
            this.Close();
        }        
        
        private void tmrRead_Tick(object sender, EventArgs e)
        {
            try
            {
                showDgIn();
                textBox1.Text = Global.GenData[34];
                textBox2.Text = Global.GenData[34];
                textBox3.Text = Global.GenData[34];
                double l = Convert.ToDouble(clsFun.Cal_Rel_Humid(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text)));
                textBox4.Text = l.ToString("00.0"); 
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void showDgIn()
        {

            for (int j = 0; j <= 15; j++)
            {
                if (Global.DigIn[j] == 1)
                {
                    DGIn[1, j].Style.BackColor = Color.Red;
                    DGIn[1, j].Style.ForeColor = Color.Yellow;
                    DGIn[0, j].Value = 1;

                }
                else
                {
                    DGIn[0, j].Value = 0;
                    DGIn[1, j].Style.BackColor = Color.Green;
                    DGIn[1, j].Style.ForeColor = Color.Yellow;

                }
            }
            label6.Text = string.Empty;
            for (int j = 0; j <= 15; j++)
            {
                if (Global.DigOut[j] == "1")
                {
                    DGOut[1, j].Style.BackColor = Color.Red;
                    DGOut[1, j].Style.ForeColor = Color.Yellow;
                    DGOut[0, j].Value = 1;
                }
                else
                {
                    DGOut[0, j].Value = 0;
                    DGOut[1, j].Style.BackColor = Color.Green;
                    DGOut[1, j].Style.ForeColor = Color.Yellow;

                }
                label6.Text = label6.Text + Global.DigOut[j]; 
            }
          
            for (int i = 0; i < 125; i++)
            {
                ViewGrid.RowCount = 130;
                for (int Chnl = 0; Chnl < 125; Chnl++)
                {
                    if ((Global.GenData[Chnl] == null) || (Global.PSName[Chnl] == "Not_Prog"))
                    {
                        ViewGrid[2, Chnl].Value = "0.0";                       
                    }
                    else
                    {
                        ViewGrid[2, Chnl].Value = Global.GenData[Chnl];                       
                    }
                }               
            }
        }                     
           
        private void DGOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int port = 0;
            int c = DGOut.CurrentRow.Index;
            if (c >= 8) port = 1; else port = 0;
            
            if (Convert.ToBoolean(DGOut[0, c].Value) == true )
            
            {
                DGOut[1, c].Style.BackColor = Color.Green; ;
                DGOut[1, c].Style.ForeColor = Color.Yellow;
                DGOut[0, c].Value = 0;
                Global.Dig_OutBit(port , c, false);
            }
            else
            {
                DGOut[1, c].Style.BackColor = Color.Red; ;
                DGOut[1, c].Style.ForeColor = Color.Yellow;
                DGOut[0, c].Value = 1;
                Global.Dig_OutBit(port, c, true);

            }
         }

        private void ViewGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        //***************************

    }
}

//*****************************






 

