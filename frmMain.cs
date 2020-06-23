using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Shapes;  
using System.Text;
using Automation.BDaq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.IO.Ports;
using System.Net;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;  

namespace Logger
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// /////socket declaration
        //public  Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //public  IPAddress clientIP = IPAddress.Parse("192.168.1.98");
        //public  IPEndPoint clientEP = new IPEndPoint(IPAddress.Parse("192.168.1.98"), 1001);
        /// </summary>

        public Process p = new Process();
        private int FixHeight = 1024, FixWidth = 1280; 
       // private int FixHeight = 1080, FixWidth = 1920; 
        System.Windows.Forms.Button[] ArrBut = new
        System.Windows.Forms.Button[50];
        System.Windows.Forms.TextBox[] ArrVal = new
        System.Windows.Forms.TextBox[50];
        System.Windows.Forms.Label[] ArrUnit = new
        System.Windows.Forms.Label[50];
        private InPutV.IPVal[] InV = new InPutV.IPVal[75];
        private String[] scrn = new String[75];
        private String[] view = new String[150];
        
        double[] dataScaled = new double[2];
        public double stopsec = 20;
        private String[] PmData = new String[20];
        private string[] ViewNo = new string[22];
        private String[] EngData = new String[20];

        private double Buf1 = 0;
        private double Buf2 = 0;
        private string OutBuf = "";
        private String TolT = "00:00:00";     //private int TolT = 0;
        private int R_Cnt = 0;
        private int M_Demand = 0;
       

        private String[] IData = new String[151];

        

        public Double minLp = 0;
        public Double maxVal = 10000;
        public int LimCnt = 0;
        private int SockT = 0;
        public int Gear = 0;


        string SFCType = "";

        private Double Lower1, Lower2, Lower3, Lower4, Lower5;
        private Double High1, High2, High3, High4, High5;
        private String Ds_Pos;
        private int cntDSafty = 0;
        private String AMSt = "1";

        public static Thread RINSTThread;
        public static Thread RINSTThread_RT;
      
        private Stopwatch st = new Stopwatch();

        public static  Boolean f_Found = false;

        private Boolean flg_ProgEnd = false;
        private Boolean flg_Showlim = false;

        private String MSt = "1";
        private Double RMP1 = 0;
        private Double RMP2 = 0;
        private Double RMP = 0;
        private Boolean flg_M_Ramp = false;
        private Point MouseDownLocation;
          
        private int wPCnt = 0;
        private int fPCnt = 0;
        private int lPCnt = 0;
        private int wTCnt = 0;
        private int lTCnt = 0;
        private int wrtCnt = 0;
        private int Srloop = 0;
        private int Erloop = 0;
        private int CntReset = 0;
        private int LogCnt = 0;
        private int Cnt = 0;
        public Boolean Auto_SmkRd = false;

       

        public static int RcNt = 0;
        public int Sn = 0;
        private Int16  C_Hours;
        private Int16 C_Minutes;
        private Int16 C_Seconds;
        public TimeSpan t;
        public  string answer;
        //SeqFile
        //private String SetPt1 = "0";

        private int TmR1 = 0;
        private int TmR = 1;
        //private String SetPt2 = "0";
        private int TmR2 = 0;
        private int Tstb = 0;
        private int Tstd = 0;
        private int Tstp = 0;
        private Boolean flg_PerStep = false;
        private Boolean flg_Instat = false;
        private Boolean flg_Avg = false;
        private Boolean flg_flyUp = false;
        private Boolean flg_Idle = false;
        private int LogT = 0;
        private int DataCnt = 5;
        private Boolean flg_Ramp = false;
        private Boolean flg_Stb = false;
        private Boolean flg_Std = false;
        private Boolean flg_ProgOut = false;
        private Boolean flg_AnaOut = false;       
        private Boolean flg_WtrTemp = false;
        private Boolean flg_WtrPress = false;
        private Boolean flg_OliTemp = false;
        private Boolean flg_OilPress = false;
        private Boolean flg_FuelPress = false;
        private Boolean flg_dynaSafety = false;
        private Boolean flg_addPlCAlarm = true;
        private Boolean flg_addwtrpres = true;
        private Boolean flg_addfuelpres = true;
        private Boolean flg_addLuboillpres = true;
        private Boolean flg_addwtrtemp = true;
        private Boolean flg_addLuboilTemp = true;
        private Boolean flg_EngRd = false;
        public TimeSpan s;
        
        public Boolean Auto_Hold = false;        
        public Double Baro = 1.005;
        public Double DryT = 31.2;

        private const int DO_portCountShow = 2;
        //private Label[] m_portNum;
        //private Label[] m_portHex;
        public TextBox[,] Do_TextBox;
        public SerialPort PIDPORT = new SerialPort();
       
        
        public frmMain()
        {
            InitializeComponent();

           
            Global.Rd_System();
            Global.ConfigDevice();
           
        }
        private void Rd_DCPL()
        {
            //string[] PIDArr = new string[5];
            
            //FileStream fs2 = new FileStream(Global.PATH + "DCPL.txt", FileMode.OpenOrCreate, FileAccess.Read);
            //StreamReader reader = new StreamReader(fs2);
            //String InPut = reader.ReadToEnd();
            //reader.Close();
            //string str =  Global.Processor_Id();
            //if (InPut != str)
            //{
            //    DialogResult result1 =
            //    MessageBox.Show("ERROR : ..." + "\n\n" +                               
            //                     "1.Invalid software copy ........!", "SYSTEM ERROR", MessageBoxButtons.OK);
            //    if (result1 == DialogResult.OK)
            //    {                   
            //        this.Close();
            //        mnuClose.PerformClick();
            //    }
            //}            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
               //
                    Resolution.CResolution ChangeRes = new Resolution.CResolution(FixWidth,FixHeight); //   = new Resolution.CResolution(FixWidth, FixHeight); 
                    Rd_DCPL();
                    lblLog.BringToFront();                   
                    Load_Arr();
                    PBar1.Value = 1;
                    PBar2.Value = 1;
                    PBar3.Value = 1;
                    Update_Tss1(0);                  
                    Process[] prs = Process.GetProcesses();
                    //Process pr = new Process();    
                    foreach (Process pr in prs)
                    {
                        //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                        if (pr.ProcessName == "Editors") pr.Kill();
                        if (pr.ProcessName == "EXCEL") pr.Kill();
                    }
                    tmrRead.Enabled = true;

                    //menuStrip1.mnu     mnuEditor.               
                    //Load_Gridseq_header();
                    Global.Rd_System();
                    Global.SFC_msg = "SFC Status .....";
                    this.Meter1.Range_Idx = 0;
                    this.Meter1.RangeEnabled = true;
                    this.Meter1.MinValue = 0;
                    this.Meter1.MaxValue = float.Parse(Global.sysIn[11]);
                    this.Meter1.RangeStartValue = 0;
                    this.Meter1.RangeEndValue = float.Parse(Global.sysIn[11]);
                    this.Meter1.ScaleLinesMajorStepValue = float.Parse(Global.sysIn[11]) / 8; 
                    this.Meter1.Range_Idx = 1;
                    this.Meter1.RangeEnabled = false;
                    this.Meter1.RangeStartValue = (float.Parse(Global.sysIn[11]) * 3)/4;
                    this.Meter1.RangeEndValue = float.Parse(Global.sysIn[11]);

                    this.Meter2.Range_Idx = 0;
                    this.Meter2.RangeEnabled = true;
                    this.Meter2.MinValue = 0;
                    this.Meter2.MaxValue = float.Parse(Global.sysIn[12]);
                    this.Meter2.RangeStartValue = 0;
                    this.Meter2.RangeEndValue = float.Parse(Global.sysIn[12]);
                    this.Meter2.ScaleLinesMajorStepValue = float.Parse(Global.sysIn[12]) / 8;
                    this.Meter2.Range_Idx = 1;
                    this.Meter2.RangeEnabled = false;
                    this.Meter2.RangeStartValue = (float.Parse(Global.sysIn[12]) * 7) / 8;
                    this.Meter2.RangeEndValue = float.Parse(Global.sysIn[12]);

                    Make_mdb(Global.DataPath);                                     
                    flg_AnaOut = true;
                 
                    //if (Global.flg_rdMod == true)
                    //{
                    //    p.StartInfo = new ProcessStartInfo(Global.PATH + "ModbusPollCS.exe");
                    //    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //    p.Start();
                    //}
                    //////
                    ////// 
                    if (Global.sysIn[17].ToString() == "TRUE") Ds_Pos = "1"; else Ds_Pos = "0";
                    Global.flg_prjOn = false;
                    Tss9.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    //Global.InstantAO.SelectedDevice = new Automation.BDaq.DeviceInformation(0);
                    //instantAoCtrl1.SelectedDevice = new Automation.BDaq.DeviceInformation(1);
                    //if (Global.msPort.IsOpen == false) Global.Init_SrPort();
                    if (Global.RTPort.IsOpen == false) Global.Init_RTPort();
                    Global.Mode_Out(1, 0, 0);
                    Global.AnaOut1 = 0.01;
                    Global.AnaOut2 = 0.01;

                    init_ReadyStatus();
                    //GridSeq.RowCount = 20;
                    //LoadDgView(); 
                    tmrWrite.Start(); 
                    ResetOutPut();
                    RINSTThread = new Thread(new ThreadStart(RINST_Thread));
                    RINSTThread.Start();
                    RINSTThread_RT = new Thread(new ThreadStart(RINST_RT_Thread));
                    RINSTThread_RT.Start();

                   
                   
                //**********************
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmmain _Load",ex.Message);

                Login frm = new Login();
                frm.ShowDialog();
                frm.Dispose();
                if (Global.flg_Log_service == true)
                {
                    frmSysP frm1 = new frmSysP();
                    frm1.ShowDialog();
                    frm1.Dispose();
                }
            }
        }

        private void Init_PIDPORT()
        {
            try
            {
                PIDPORT.PortName = "COM3";
                if (PIDPORT.IsOpen == true) PIDPORT.Dispose(); // .Close();
                PIDPORT.BaudRate = int.Parse("9600");
                PIDPORT.DataBits = int.Parse("8");
                PIDPORT.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                PIDPORT.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (PIDPORT.IsOpen == false)
                {
                    PIDPORT.Dispose();
                    PIDPORT.PortName = "COM3";   //sysIn[20];
                    PIDPORT.Open();
                }
            }
            catch
            {
                //MessageBox.Show("Error Code:- 15001 " + ex.Message);
                return;
            }
        }

        public void RINST_Thread()
        {
            //try
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(80);
            //        Global.Rd_SerialPort(); // Read_ECUValues();
            //        Tss4.Text = Global.bufftss4;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return;
            //}
        }
        public void RINST_RT_Thread()
        {
            //try
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(80);
            //        Global.Rd_SerialPort_RT(); // Read_ECUValues();
            //        Tss5.Text = Global.bufftss8;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return;
            //}
        }   //  

        private void Load_Arr()
        {
            int I = 0;
            InV[0] = ipVal1;
            InV[1] = ipVal2;
            InV[2] = ipVal3;
            InV[3] = ipVal4;
            InV[4] = ipVal5;
            InV[5] = ipVal6;
            InV[6] = ipVal7;
            InV[7] = ipVal8;
            InV[8] = ipVal9;
            InV[9] = ipVal10;
            InV[10] = ipVal11;
            InV[11] = ipVal12;
            InV[12] = ipVal13;
            InV[13] = ipVal14;
            InV[14] = ipVal15;
            InV[15] = ipVal16;
            InV[16] = ipVal17;
            InV[17] = ipVal18;
            InV[18] = ipVal19;
            InV[19] = ipVal20;
            InV[20] = ipVal21;
            InV[21] = ipVal22;
            InV[22] = ipVal23;
            InV[23] = ipVal24;
            InV[24] = ipVal25;
            InV[25] = ipVal26;
            InV[26] = ipVal27;
            InV[27] = ipVal28;
            InV[28] = ipVal29;
            InV[29] = ipVal30;
            InV[30] = ipVal31;
            InV[31] = ipVal32;
            InV[32] = ipVal33;
            InV[33] = ipVal34;
            InV[34] = ipVal35;
            InV[35] = ipVal36;
            InV[36] = ipVal37;
            InV[37] = ipVal38;
            InV[38] = ipVal39;
            InV[39] = ipVal40;
            InV[40] = ipVal41;
            InV[41] = ipVal42;
            InV[42] = ipVal43;
            InV[43] = ipVal44;
            InV[44] = ipVal45;
            InV[45] = ipVal46;
            InV[46] = ipVal47;
            InV[47] = ipVal48;
            InV[48] = ipVal49;
            InV[49] = ipVal50;
            InV[50] = ipVal38;
            InV[51] = ipVal39;
            InV[52] = ipVal40;
            InV[53] = ipVal41;
            InV[54] = ipVal42;
            InV[55] = ipVal56;
            InV[56] = ipVal57;
            InV[57] = ipVal58;
            InV[58] = ipVal59;
            InV[59] = ipVal60;
            //InV[60] = ipVal61;
            //InV[61] = ipVal62;
            //InV[62] = ipVal63;
            //InV[63] = ipVal64;

            try
            {
                Global.Rd_Confg();
                //Global.Configure_Gantner(); 
                Global.Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tb_Scrn", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();

                int x = 0;
                while (Rd.Read())
                {
                    if (x > 63) break;
                    scrn[x] = Rd.GetValue(1).ToString();
                    x += 1;
                }
                Global.con.Close();


                for (I = 0; I <= 59; I++)
                {
                    InV[I].BackColor = Color.Silver; // LightGray;
                    InV[I].P_Color = Color.Navy;
                    InV[I].U_Color = Color.Black;

                    InV[I].P_Name = Global.PSName[int.Parse(scrn[I])].ToString();
                    InV[I].P_Unit = Global.PUnit[int.Parse(scrn[I])].ToString();
                    InV[I].colFont = new System.Drawing.Font("Book Antiqua", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));    //new System.Drawing.Font("Calibri ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    InV[I].P_Font = new System.Drawing.Font("Book Antiqua ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));   //new System.Drawing.Font("Courier New, ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    InV[I].U_Font = new System.Drawing.Font("Book Antiqua ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                    if (InV[I].P_Name == "Not_Prog")
                    {
                        InV[I].P_Name = "";
                        InV[I].P_Unit = "";
                        InV[I].colFillColor = Color.LightGray;
                        InV[I].colForeColor = Color.LightGray; 
                    }
                    else
                    {
                        InV[I].P_Name = Global.PSName[int.Parse(scrn[I])].ToString();
                        InV[I].P_Unit = Global.PUnit[int.Parse(scrn[I])].ToString();
                        InV[I].colFillColor = Color.Black;
                        InV[I].colForeColor = Color.Yellow;
                           
                    }

                }
                cltBar1.C_Name = Global.PSName[int.Parse(scrn[60])].ToString() + "     " + Global.PUnit[int.Parse(scrn[60])].ToString(); ;
                cltBar2.C_Name = Global.PSName[int.Parse(scrn[61])].ToString() + "     " + Global.PUnit[int.Parse(scrn[61])].ToString(); ;
                cltBar3.C_Name = Global.PSName[int.Parse(scrn[62])].ToString() + "     " + Global.PUnit[int.Parse(scrn[62])].ToString(); ;
                cltBar4.C_Name = Global.PSName[int.Parse(scrn[63])].ToString() + "     " + Global.PUnit[int.Parse(scrn[63])].ToString(); ;
                cltBar1.Max = Double.Parse(Global.PMax[int.Parse(scrn[60])]) * 0.6;
                cltBar2.Max = Double.Parse(Global.PMax[int.Parse(scrn[61])]) * 0.6;
                cltBar3.Max = Double.Parse(Global.PMax[int.Parse(scrn[62])]) * 0.6;
                cltBar4.Max = Double.Parse(Global.PMax[int.Parse(scrn[63])]) * 0.6;
            
                if (Global.InstantDI.Initialized) tmrWrite.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Load_Arr():  " + ex.Message);
            }
        }
      
        
        
        public int randomvalue(int min,int max)
        {
            Random rnd = new Random();
            return rnd.Next(min,max);

        }
        private void Write_Values()
        {
            int i;
            String sg;
            try
            {
                String str;
                tmrRead.Interval = 100; 
                for (i = 0; i < 35; i++)
                {
                    sg = scrn[i].ToString();
                    if (InV[i].P_Name != "Not_Prog")
                    {
                        if ((Global.GenData[int.Parse(sg)] != null) && (Global.PSName[int.Parse(sg)] != "Not_Prog")) // && (int.Parse(sg) <= 120))
                        {  
                            str = Global.GenData[int.Parse(sg)];
                           
                            InV[i].P_Value = str;    // string.Format("{0:##0.0##}", str); 
                          
                            if (int.Parse(sg) <= 95)
                            {
                                if (Global.BufLim[int.Parse(sg)] == "O")
                                {
                                    InV[i].colFillColor = Color.Blue;
                                    Tss3.Text = "Engine Off : " + Global.PSName[i];
                                    Tss3.BackColor = Color.Red;
                                    Tss3.ForeColor = Color.Yellow;
                                    break;
                                }
                                else if (Global.BufLim[int.Parse(sg)] == "I")
                                {
                                    InV[i].colFillColor = Color.Black;
                                    Tss3.Text = "Engine IDLE : " + Global.PSName[i];
                                    Tss3.BackColor = Color.Red;
                                    Tss3.ForeColor = Color.Yellow;
                                    break;
                                }
                                else if (Global.BufLim[int.Parse(sg)] == "A") //&& (Global.flg_LimitON == true))
                                {
                                    if (InV[i].colFillColor == Color.Black)
                                    {
                                        InV[i].colFillColor = Color.Red;
                                        InV[i].colForeColor = Color.Yellow;
                                    }
                                    else if (InV[i].colFillColor == Color.Red)
                                    {
                                        InV[i].colFillColor = Color.Black;
                                        InV[i].colForeColor = Color.Yellow;
                                    }
                                }
                                else if (Global.BufLim[int.Parse(sg)] == "N")
                                {
                                    InV[i].colFillColor = Color.Black;
                                    InV[i].colForeColor = Color.Yellow;  //System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
                                }
                            }
                            else if (int.Parse(sg) > 100)
                            {
                                InV[i].colFillColor = Color.Black;
                                InV[i].colForeColor = Color.Yellow;  //System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));                      
                            }
                        }
                    }
                    else
                    {
                        ArrVal[i].Text = "";
                    }

                    double r = double.Parse(Global.GenData[0]);
                    if (Global.GenData[0] != null) lblRPM.Text = r.ToString("0000"); else lblRPM.Text = "0000";
                       Global.varRPM = Convert.ToInt16(Global.GenData[0]);
                    double n = double.Parse(Global.GenData[1]);
                    if (Global.GenData[1] != null) lblTrq.Text = n.ToString("0000"); else lblTrq.Text = "0000";
                        Global.varTRQ = Double.Parse(lblTrq.Text);

                    //lblTxRpm.Text = Global.T_VarRPM.ToString("0000");
                    cltBar1.C_Fillvalue = Double.Parse(Global.GenData[int.Parse(scrn[60])]);
                    cltBar2.C_Fillvalue = Double.Parse(Global.GenData[int.Parse(scrn[61])]);
                    cltBar3.C_Fillvalue = Double.Parse(Global.GenData[int.Parse(scrn[62])]);
                    cltBar4.C_Fillvalue = Double.Parse(Global.GenData[int.Parse(scrn[63])]);   
                    Global.varTRQ = Double.Parse(Global.GenData[1]);
                    Meter1.Value = float.Parse(Global.GenData[0]);
                    Meter2.Value = float.Parse(Global.GenData[1]);

                Meter1.Value = float.Parse(Global.GenData[0]);
                Meter2.Value = float.Parse(Global.GenData[1]);
                }
                // 
                //////////// engine Rpm///////////
                textBox4.Text = ((int)(Global.varRPM * Global.PTO_Ratio)).ToString("0000");
                Global.GenData[19] = textBox4.Text;
                // 
                flg_Showlim = false;
                for ( i = 0; i <= 100; i++)
                {
                    if (Global.BufLim[i] == "A")
                    {
                        flg_Showlim = true;                        
                        break;
                    }
                }
                if ((flg_Showlim == true) && (Global.varRPM  >= 650)) //(Global.flg_EngStart = true)) 
                {
                    Tss3.BackColor = Color.Red;
                    Tss3.ForeColor = Color.Yellow;
                    Tss3.Text = "Check Alarm : " + Global.PSName[i]; 
                }
                else
                {
                    Tss3.BackColor = Color.Gainsboro;
                    Tss3.ForeColor = Color.Red;
                    Tss3.Text = "Alarm Status..."; 
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error in frmMain: WriteValues():  " + ex.Message);
                return;
            }
        }
        public void servicelog()
        {
            mnusyspara.Enabled  = true;
            mnuChannel.Enabled = true; 
        }
        public void supervisorlog()
        {
            mnuEditor.Enabled = true;
            mnuProject.Enabled = true; 
        }
        public void disable_log()
        {
            mnusyspara.Enabled = false;
            mnuChannel.Enabled = false;
            mnuEditor.Enabled = false;
            mnuProject.Enabled = false; 
        }

      
       private void tmrWrite_Tick(object sender, EventArgs e)
        {
            try
            {                  
                if (wrtCnt >= 8) wrtCnt = 0; else wrtCnt += 1;               
             

                //Tss1.Text = Global.SFC_msg; //  +" : " + Global.SFC_Msg_from_Inst;
                Tss1.Text = Global.SFC_msg + " : " + Global.SFC_Msg_from_Inst;
                Global.flg_SFCSerialStart = true;
                if (Global.flg_SFCSerialStart == true) Read_Serial_SFC();

               
                //if (Global.flg_SFCStart == true)
                //    Read_Serial_SFC();

                if (flg_AnaOut == true) Fun_AnalogOut();
                //Write_Values();
                //******************************************
                //Global.flg_simulateRPM = true;
                if (Global.flg_simulateRPM == true)
                {
                    Global.S_pt1 = (int)(Global.AnaOut1 * 1000);
                    Global.S_pt2 = (int)(Global.AnaOut2 * 40);
                    Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    if (Global.S_pt1 <= 800) Global.S_pt1 = 800;
                    if (Global.S_pt2 <= 0.10) Global.S_pt2 = 0.1;
                    int t = (int)Global.S_pt1;
                    Global.GenData[0] = RandomNumber(t - 5, t + 5).ToString("0000");
                    Global.varRPM = Convert.ToInt16(Global.GenData[0]);
                    

                    Double X = (int)Global.S_pt2;
                    if (X >= 410) X = 410;
                    Global.GenData[1] = RandomNumber2(X - 1.9, X + 1.9).ToString("#00.0");
                    Global.varTRQ = Convert.ToDouble(Global.GenData[1]); //12.10;
                   


                    double r = double.Parse(Global.GenData[0]);
                    if (Global.GenData[0] != null) lblRPM.Text = r.ToString("0000"); else lblRPM.Text = "0000";
                    double n = double.Parse(Global.GenData[1]);
                    if (Global.GenData[1] != null) lblTrq.Text = n.ToString("000.0"); else lblTrq.Text = "000.0";


                }
                //else
                //{
                //    //lblRPM.Text = Global.varRPM.ToString();
                //    //lblTrq.Text = Global.varTRQ.ToString();
                //    if (Global.GenData[0] == null) Global.GenData[0] = "0000";
                //    if (Global.GenData[1] == null) Global.GenData[1] = "00.10";
                //    double r = double.Parse(Global.GenData[0]);
                //    if (Global.GenData[0] != null) lblRPM.Text = r.ToString("0000"); else lblRPM.Text = "0000";
                //    double n = double.Parse(Global.GenData[1]);
                //    if (Global.GenData[1] != null) lblTrq.Text = n.ToString("000.0"); else lblTrq.Text = "000.0";

                //    if (Double.Parse(Global.GenData[0]) <= 0)
                //    {
                //        Double l = Double.Parse(Global.GenData[0]);
                //        Global.varRPM = Int16.Parse(l.ToString("0000"));
                       
                //    }
                //    else lblRPM.Text = Global.varRPM.ToString("0000");

                //    if (Double.Parse(Global.GenData[1]) <= 0)
                //    {
                //        Double l = Double.Parse(Global.GenData[1]);
                //        Global.varTRQ = Math.Abs(Double.Parse(l.ToString("000.0")));
                //        lblTrq.Text = Global.varTRQ.ToString("000.0");
                //    }
                //    else lblTrq.Text = Global.varTRQ.ToString("000.0");
                //}
               // ******************************************   
 

                          
                switch (wrtCnt) 
                {
                    case 1:
                        if (flg_ProgOut == true) Fun_ProgOut();
                        if (Global.Flg_Ready == true)
                        {
                            if (Global.flg_Auto == true)
                            {
                                RdProg();
                                Btn21.Enabled = true;
                                BtnSA .Enabled = false;
                                checkBox13.Text = Global.EngNo;
                                checkBox8.Text = Global.PrjNm;
                                Global.flg_Auto = false;
                                Global.Flg_Ready = false;
                            }
                            else if (Global.flg_Manual == true)
                            {
                                Btn21.Enabled = false;
                                BtnSA.Enabled = true;
                                checkBox13.Text = Global.EngNo;
                                checkBox8.Text = Global.PrjNm;
                                Global.flg_Manual = false;
                                Global.Flg_Ready = false;
                            }
                        }
                        Tss8.Text = DateTime.Now.ToShortTimeString();                        
                        break;
                    case 2:
                        
                        Check_ReadyDyno();
                        if (Global.OPCPort.IsOpen == true) Global.OPCPort.Write(" AKON");  
                        if ((Global.varRPM >= 650) && (Global.flg_CycleStarted == true))
                        {                            
                            //ChkFuelP();
                            ChkLubP();
                            ChkWtrT();
                            ChkLubT();
                        }
                        break;
                    case 3:
                        if (Global.flg_Log_service == true) servicelog(); else if (Global.flg_Log_supervisor == true) supervisorlog(); else disable_log();
                                           
                        break;
                    case 4:
                        if (Global.StpN > 1) Check_Limit(); else Check_Limit_Standby(); 
                        string Buff = "";
                        if ( (Global.flg_smk = true) && (Global.OPCPort.IsOpen == true))
                        {
                            Buff = Global.OPCPort.ReadExisting();
                            Tss5.Text = Buff.Substring(7, 1);
                            if (Buff.Substring(7, 1) == "0")
                            {
                                Global.SmkVal = Buff.Substring(9, 5); //Tss5.Text;  
                            }
                        }                                          
                        break;                    
                    case 5:
                        if (Global.varRPM >= 600) ctlLED1.tmron = true; else ctlLED1.tmron = false;   
                        break;
                    case 6:
                        Global.ReadAnalog();
                        

                        //if (lblSFCStatus.Text != "SFC Status .....")
                        //{
                        //    if (lblSFCStatus.BackColor == Color.Gainsboro)
                        //    {
                        //        lblSFCStatus.BackColor = Color.Red;
                        //        lblSFCStatus.ForeColor = Color.Yellow;
                        //    }
                        //    else if (lblSFCStatus.BackColor == Color.Red)
                        //    {
                        //        lblSFCStatus.BackColor = Color.Gainsboro;
                        //        lblSFCStatus.ForeColor = Color.Yellow;
                        //    }
                        //}
                        //else
                        //{
                        //    lblSFCStatus.BackColor = Color.Gainsboro;
                        //    lblSFCStatus.ForeColor = Color.WhiteSmoke;
                        //}
                        break;
                    case 7:
                        if  (Global.varRPM >= 650)
                        {
                            C_Hours = Int16.Parse(Tss2.Text.Substring(0, 4));
                            C_Minutes = Int16.Parse(Tss2.Text.Substring(5, 2));
                            //C_Seconds = Int16.Parse(Tss2.Text.Substring(8, 2));
                            clsFun.TmCounter(C_Hours, C_Minutes, true);
                            Tss2.Text = clsFun.cummbuff;                           
                        }
                        else
                        {
                            //TextBox1.Text = "0000:00:00";
                            // 
                        }
                        break;
                    case 8:
                        Write_Values();
                        Tss8.Text = DateTime.Now.ToShortTimeString(); 
                        Global.VarPowkW  = clsFun.kW_Power(Global.varRPM, Global.varTRQ);
                        Global.VarPowHp  = clsFun.HP_Power(Global.varRPM, Global.varTRQ);

                        Double P1 = Convert.ToDouble(Global.GenData[12]);   //Global.Atp; // Convert.ToDouble(Global.GenData[Global.fxd[10]]);
                        Double D1 = Convert.ToDouble(Global.GenData[7]);//.ToString();  //Global.Drb; //
                        Double W1 = Global.Web; // Convert.ToDouble(Global.GenData[Global.fxd[9]]);

                        Global.Rel_Hum = clsFun.Cal_Rel_Humid(P1, D1, W1);
                        Global.GenData[120] = Global.Rel_Hum.ToString("00.0") ;
                        //
                        if (Global.Prj[4] == "CF_New")
                            Global.Corfact = clsFun.Cf_new(P1, D1);

                         else if (Global.Prj[4] == "CF_DIN")
                            Global.Corfact = clsFun.CF_DIN_70020(D1, P1);

                        else if (Global.Prj[4] == "CF_IS_10003") 
                            Global.Corfact = clsFun.CF_IS_10000CS(Global.Rel_Hum, D1, P1);
                        else 
                            Global.Corfact = clsFun.CF_DIN_70020(D1, P1);

                        if ((Global.Corfact > 1.2) || (Global.Corfact < 0.8)) Global.Corfact = 1.00000;
                       
                       Global.GenData[105]  = Global.Corfact.ToString("0.0000");   

                        Global.varbmep = clsFun.Cal_bmep(Global.varTRQ, Double.Parse(Global.Svol));
                        Global.C_VarPowkW = Global.VarPowkW * Global.Corfact;
                        Global.C_VarPowHp = Global.VarPowHp * Global.Corfact; 

                        //TextBox2.Text = Global.VarPowHp.ToString();
                        //TextBox3.Text = Global.Corfact.ToString();
                        if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;

                        Global.GenData[101] = Global.SmkVal;
                        Global.GenData[105] = Global.Corfact.ToString("0.0000");       
                        Global.GenData[106] = Global.varTRQ.ToString("00.0");
                        Global.GenData[107] = Global.VarPowkW.ToString("00.0");                                         
                        Global.GenData[110] = ((Global.Corfact) * (Global.varTRQ)).ToString("00.0");
                        Global.GenData[111] = ((Global.Corfact) * (Global.VarPowkW)).ToString("00.0");
                        Global.GenData[115] = Global.VarPowHp.ToString("00.0");
                        Global.GenData[116] = ((Global.VarPowHp) * (Global.Corfact)).ToString("00.0");
                        Global.GenData[119] = Global.varbmep.ToString();
                        Global.GenData[120] = Global.Rel_Hum.ToString("00.0");
                        Global.GenData[124] = Tss2.Text; 
                        break;
                      
                }
            }
               
            catch (Exception ex)
            {
            //    MessageBox.Show("Error in frmMain: tmrWrite_Tick():  " + ex.Message);
            //    Global.Create_OnLog(ex.Message);
                return;
            }

        }
    
        private void init_ReadyStatus()
        {
            try
            {
                if (Global.sysIn[41] == "FALSE")
                {
                    checkBox3.CheckState = CheckState.Unchecked;
                    checkBox3.Text = "ENG. WATER PRESS NOT CHECKED.....";                   
                }
                else
                {
                    checkBox3.CheckState = CheckState.Indeterminate;
                    Lower1 = double.Parse(Global.sysIn[42]);
                    High1 = double.Parse(Global.sysIn[43]);
                    checkBox3.Text = "ENG. WATER PRESS : " + Lower1 + " ~ " + High1;                    
                }
                
                if (Global.sysIn[44] == "FALSE")
                {
                    //checkBox4.CheckState = CheckState.Unchecked;
                    //checkBox4.Text = "ENG.FUEL PRESS NOT CHECKED.....";                   
                }
                else
                {
                    //checkBox4.CheckState = CheckState.Indeterminate;
                    //Lower2 = double.Parse(Global.sysIn[45]);
                    //High2 = double.Parse(Global.sysIn[46]);
                    //checkBox4.Text = "ENG. FUEL PRESS : " + Lower2 + " ~ " + High2;                   
                }

                if (Global.sysIn[47] == "FALSE")
                {
                    checkBox5.CheckState = CheckState.Unchecked;
                    checkBox5.Text = "ENG. LOIL PRESS NOT CHECKED......";                   
                }
                else
                {
                    checkBox5.CheckState = CheckState.Indeterminate;
                    Lower3 = double.Parse(Global.sysIn[48]);
                    High3 = double.Parse(Global.sysIn[49]);
                    checkBox5.Text = "ENG. LOIL PRESS : " + Lower3 + " ~ " + High3;                  
                }

                if (Global.sysIn[50] == "FALSE")
                {
                    checkBox6.CheckState = CheckState.Unchecked;
                    checkBox6.Text = "ENG. WTR_OUT TEMP NOT CHECKED....";                   
                }
                else
                {
                    checkBox6.CheckState = CheckState.Indeterminate;
                    Lower4 = double.Parse(Global.sysIn[51]);
                    High4 = double.Parse(Global.sysIn[52]);
                    checkBox6.Text = "ENG WTROUT TEMP : " + Lower4 + " ~ " + High4;
                    
                }

                if (Global.sysIn[53] == "FALSE")
                {
                    checkBox7.CheckState = CheckState.Unchecked;
                    checkBox7.Text = "ENG. LOIL TEMP NOT CHECKED.....";                   
                }
                else
                {
                    checkBox7.CheckState = CheckState.Indeterminate;
                    Lower5 = double.Parse(Global.sysIn[54]);
                    High5 = double.Parse(Global.sysIn[55]);
                    checkBox7.Text = "ENG. LOIL TEMP: " + Lower5 + " ~ " + High5;                    
                }

                //if (Global.flg_Radiator == true)
                //{
                //    checkBox16.Text = "REDIATOR CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Indeterminate  ;
                //    checkBox16.ForeColor = Color.MediumBlue; 
                //}
                //else
                //{
                //    checkBox16.Text = "REDIATOR NOT CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Unchecked; 
                //    //checkBox16.ForeColor = Color.Red;  
                //}
                //if (Global.flg_Fan == true)
                //{
                //    checkBox17.Text = "COOLING FAN CONNECTED ........";
                //    checkBox17.CheckState = CheckState.Indeterminate;
                //    //checkBox17.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox17.Text = "COOLING FAN  NOT CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Unchecked; 
                //    //checkBox17.ForeColor = Color.Red;
                //}
                //if (Global.flg_AirCln == true)
                //{
                //    checkBox18.Text = "AIR CLEANER CONNECTED ........";
                //    checkBox18.CheckState = CheckState.Indeterminate;
                //    //checkBox18.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox18.Text = "AIR CLEANER NOT CONNECTED ........";
                //    checkBox18.CheckState = CheckState.Unchecked; 
                //    //checkBox18.ForeColor = Color.Red;
                //}
                //if (Global.flg_Silincer == true)
                //{
                //    checkBox19.Text = "SILINCER CONNECTED ........";
                //    checkBox19.CheckState = CheckState.Indeterminate;
                //    //checkBox19.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox19.Text = "SILINCER NOT CONNECTED ........";
                //    checkBox19.CheckState = CheckState.Unchecked; 
                //    //checkBox19.ForeColor = Color.Red;
                //}
                // 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Init_ReadyStatus():  " + ex.Message);
               // 235
            }
        }

        private void Check_ReadyDyno()
        {
            try
            {
                    if (Global.DigIn[6] == Global.flg_VolActive)
                    {
                        UpdateCheckBox(checkBox2, 0);
                        checkBox2.Text = " NO SYSTEM - ALARM .....";
                        cntDSafty = 0;
                        flg_ProgEnd = false;
                        flg_dynaSafety = false;
                        flg_addPlCAlarm = true;
                    } 
                    else
                    {
                        cntDSafty = 0;
                        flg_ProgEnd = false;
                        flg_dynaSafety = false;
                        flg_addPlCAlarm = true;
                        UpdateCheckBox(checkBox2, 1);
                        checkBox2.Text = " CHECK SYSTEM-ALARM.ENGINE NOT READY..";
                        if ((Global.varRPM > 600) && (Global.flg_CycleStarted == true))
                        {
                            if (cntDSafty < 3) cntDSafty += 1;
                            if (cntDSafty == 3)
                            {
                                if (flg_addPlCAlarm == false)
                                {
                                    Global.Create_OnLog("Engine is @ idle due to " + checkBox2.Text + " at RPM :" + Global.varRPM);
                                    flg_addPlCAlarm = true;
                                }
                                if (Global.flg_EngStart == true) tmrEnd.Enabled = true;
                                cntDSafty = cntDSafty + 1;
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Check_ReadyDyno(): " + ex.Message);
            }
        }

        private void Check_wtrPress()
        {
            try
            {
                if (checkBox3.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[2]]);
                    if ((l > Lower1) && (l < High1))
                    {
                        UpdateCheckBox(checkBox3, 0);
                        checkBox3.Text = "ENG. Wtr PRESS : " + Lower1 + "~" + High1;
                         wPCnt = 0;
                        flg_ProgEnd = false;
                        flg_WtrPress  = false;
                        flg_addwtrpres  = true;
                    }
                    else
                    {
                        if (flg_addwtrpres  == true) UpdateCheckBox(checkBox3, 1);
                        checkBox3.Text = "Check Engine Wtr Press...";
                        if (wPCnt < 3) wPCnt += 1; else wPCnt = 4;
                        if (wPCnt == 3)
                        {
                            if (flg_addwtrpres  == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox3.Text + " at RPM :" + Global.varRPM, 9);
                               Global.Create_OnLog("Engine is @ idle due to " + checkBox3.Text + " at RPM :" + Global.varRPM); 
                                flg_addwtrpres  = true;
                            }
                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Check_WtrPress(): " + ex.Message);
            }

        }

        //private void ChkFuelP()
        //{
        //    try
        //    {
        //        if (checkBox4.CheckState == CheckState.Indeterminate)
        //        {
                 
        //            Double l = Convert.ToDouble(Global.GenData[Global.fxd[3]]);
        //            if ((l > Lower2) && (l < High2))
        //            {
        //                UpdateCheckBox(checkBox4, 0);
        //                checkBox4.Text = "ENG. FUEL PRESS : " + Lower2 + "~" + High2;
        //                fPCnt = 0;
        //                flg_ProgEnd = false;
        //                flg_FuelPress = false;
        //                flg_addfuelpres = true;
        //            }
        //            else
        //            {
        //                if (flg_addfuelpres == true) UpdateCheckBox(checkBox4, 1);                       
        //                checkBox4.Text ="Check Engine Fuel Press...";
        //                if (fPCnt < 3)  fPCnt += 1;else fPCnt = 4;
        //                if(fPCnt == 3)
        //                {
        //                     if (flg_addfuelpres  == false)
        //                    {
        //                        //AddListItem("Engine is @ idle due to " + checkBox4.Text + " at RPM :" + Global.varRPM, 9);
        //                        Global.Create_OnLog("Engine is @ idle due to " + checkBox4.Text + " at RPM :" + Global.varRPM);
        //                         flg_addfuelpres  = true;
        //                    }

        //                   if(Global.flg_EngStart == true )  tmrEnd.Enabled = true;
                         
        //                }
        //            }
                        
        //        }
               
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in ChkFuelP(): " + ex.Message);
        //    }
        //}

        private void ChkLubP()
        {
            try
            {
                if (checkBox5.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[4]]);
                    if ((l > Lower3) && (l < High3))
                    {
                        UpdateCheckBox(checkBox5, 0);                       
                        checkBox5.Text = "ENG. LubOil PRESS : " + Lower3 + "~" + High3;
                        lPCnt = 0;
                        flg_ProgEnd = false;
                        flg_OilPress = false;
                        flg_addLuboillpres = true;

                    }
                    else
                    {
                        if (flg_addLuboillpres == true) UpdateCheckBox(checkBox5, 1);
                        checkBox5.Text = "Check Engine Luboil Press...";

                        if (lPCnt < 3) lPCnt += 1; else lPCnt = 4;
                        if (lPCnt == 3)
                        {
                            if (flg_addLuboillpres  == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox5.Text + " at RPM :" + Global.varRPM, 9);
                                flg_addLuboillpres  = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;

                        }

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in ChkLubP(): " + ex.Message);
            }
        }

        private void ChkWtrT()
        {
            try
            {

                if (checkBox6.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[5]]);
                    if ((l > Lower4) && (l < High4))
                    {
                        UpdateCheckBox(checkBox6, 0);
                        checkBox6.Text = "ENG. Wtr Temp : " + Lower4 + "~" + High4;
                        wTCnt  = 0;
                        flg_ProgEnd = false;
                        flg_WtrTemp  = false;
                        flg_addwtrtemp  = true;

                    }
                    else
                    {
                        if (flg_addwtrtemp  == true) UpdateCheckBox(checkBox6, 1);
                        checkBox6.Text = "Check Engine Wtr Temp...";
                        if (wTCnt < 3) wTCnt  += 1; else wTCnt = 4;
                        if (wTCnt  == 3)
                        {
                            if (flg_addwtrtemp  == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox6.Text + " at RPM :" + Global.varRPM, 9);
                                Global.Create_OnLog("Engine is @ idle due to " + checkBox4.Text + " at RPM :" + Global.varRPM);
                                flg_addwtrtemp  = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;

                        }

                    }
                }
               
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in ChkWtrT(): " + ex.Message);
            }
        }

        private void ChkLubT()
        {
            try
            {

                if (checkBox7.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[6]]);
                    if ((l > Lower5) && (l < High5))
                    {
                        UpdateCheckBox(checkBox7, 0);
                        checkBox7.Text = "ENG. LubOil Temp : " + Lower5 + "~" + High5;
                        lTCnt = 0;
                        flg_ProgEnd = false;
                        flg_OliTemp = false;
                        flg_addLuboilTemp = true;

                    }
                    else
                    {
                        if (flg_addLuboilTemp == true) UpdateCheckBox(checkBox7, 1);
                        checkBox7.Text = "Check Engine LubOil Temp...";
                        if (lTCnt < 3) lTCnt += 1; else lTCnt = 4;
                        if (lTCnt == 3)
                        {
                            if (flg_addLuboilTemp == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox7.Text + " at RPM :" + Global.varRPM, 9);
                                Global.Create_OnLog("Engine is @ idle due to " + checkBox7.Text + " at RPM :" + Global.varRPM);
                                flg_addLuboilTemp = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;

                        }
                    }
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error ChkLubT() : " + ex.Message);
            }
        }

        private void Update_Tss1(int Stus)
        {
            try
            {
                if (Stus == 0)
                {
                    Tss1.BackColor = Color.Gainsboro;
                    Tss1.ForeColor = Color.Brown;
                    Tss1.Text = Global.SFC_msg; 
                }
                else if (Stus == 1)
                {
                    if (Tss1.BackColor == Color.Gainsboro)
                    {
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                    }
                    else if (Tss1.BackColor == Color.Red)
                    {
                        Tss1.BackColor = Color.Gainsboro;
                        Tss1.ForeColor = Color.Brown;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: update_tss11():  " + ex.Message);
            }
        }

       

        private void Update_Hold(int Stus)
        {
            try
            {
                if (Stus == 0)
                {
                    Tss1.BackColor = Color.Gainsboro;
                    Tss1.ForeColor = Color.Brown;
                }
                else if (Stus == 1)
                {
                    if (Tss1.BackColor == Color.Gainsboro)
                    {
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                    }
                    else if (Tss1.BackColor == Color.Red)
                    {
                        Tss1.BackColor = Color.Gainsboro;
                        Tss1.ForeColor = Color.Brown;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: update_Hold():  " + ex.Message);
            }
        }



        private void UpdateCheckBox(CheckBox Chk, int Stt)
        {
            try
            {
                if (Stt == 0)
                {
                    Chk.ForeColor = Color.Navy ;
                    Chk.BackColor = Color.Gainsboro;
                    //groupBox4.SendToBack();  
                }
                else if (Stt == 1)
                {
                    //groupBox4.BringToFront();  
                    switch (Chk.Name)
                    {
                        //case "checkBox1":
                        //    if (checkBox1.BackColor == Color.Gainsboro)
                        //    {
                        //        checkBox1.BackColor = Color.Red;
                        //        checkBox1.ForeColor = Color.Yellow;
                        //    }

                        //    else if (checkBox1.BackColor == Color.Red)
                        //    {
                        //        checkBox1.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                        //        checkBox1.ForeColor = Color.Navy;
                        //    }
                        //    break;
                        case "checkBox2":
                            if (checkBox2.BackColor == Color.Gainsboro)
                            {
                                //flg_addPlCAlarm = false;
                                checkBox2.BackColor = Color.Red;
                                checkBox2.ForeColor = Color.Yellow;
                            }

                            else if (checkBox2.BackColor == Color.Red)
                            {
                                checkBox2.BackColor = Color.Gainsboro;  //
                                checkBox2.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox3":
                            if (checkBox3.BackColor == Color.Gainsboro)
                            {
                                flg_addwtrpres = false;
                                checkBox3.BackColor = Color.Red;
                                checkBox3.ForeColor = Color.Yellow;
                            }
                            else if (checkBox3.BackColor == Color.Red)
                            {
                                checkBox3.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox3.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox4":
                            if (checkBox4.BackColor == Color.Gainsboro)
                            {
                                flg_addfuelpres = false;
                                checkBox4.BackColor = Color.Red;
                                checkBox4.ForeColor = Color.Yellow;

                            }
                            else if (checkBox4.BackColor == Color.Red)
                            {
                                checkBox4.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox4.ForeColor = Color.Navy;
                            }

                            break;
                        case "checkBox5":
                            if (checkBox5.BackColor == Color.Gainsboro)
                            {
                                flg_addLuboillpres = false;
                                checkBox5.BackColor = Color.Red;
                                checkBox5.ForeColor = Color.Yellow;
                            }
                            else if (checkBox5.BackColor == Color.Red)
                            {
                                checkBox5.BackColor = Color.Gainsboro;
                                checkBox5.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox6":
                            if (checkBox6.BackColor == Color.Gainsboro)  //SystemColors.ButtonFace)
                            {
                                flg_addwtrtemp = false;
                                checkBox6.BackColor = Color.Red;
                                checkBox6.ForeColor = Color.Yellow;
                            }
                            else if (checkBox6.BackColor == Color.Red)
                            {
                                checkBox6.BackColor =Color.Gainsboro;  // SystemColors.ButtonFace;
                                checkBox6.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox7":
                            if (checkBox7.BackColor == Color.Gainsboro)
                            {
                                flg_addLuboilTemp = false;
                                checkBox7.BackColor = Color.Red;
                                checkBox7.ForeColor = Color.Yellow;
                            }
                            else if (checkBox7.BackColor == Color.Red)
                            {
                                checkBox7.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox7.ForeColor = Color.Navy;
                            }
                            break;

                    }
                }
               
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: UpdateChexkbox():  " + ex.Message);
            }
        }
        private void Show_Dialog()
        {
            if ((flg_WtrPress == true) || (flg_dynaSafety == true) || (flg_WtrTemp == true) || (flg_EngRd == true)
                        || (flg_OliTemp == true) || (flg_FuelPress == true) || (flg_OilPress == true))
            {

               
                //groupBox1.BringToFront();
                //groupBox1.Visible = true;
            }
            else
            {
               
                //groupBox1.BringToFront();
                //groupBox1.Visible = false;
            }
        }

         
        public void Load_ProgStep()
        {
            try
            {
                String E_Hld;
                String M_Trq;
                String T = "0";
                String D = "0";
                String CH = "0";
                Global.smkCn = 0;
                Global.SmkVal = "0.00";

                Global.GenData[3] ="000";
                Global.GenData[4] = "000";
                Global.GenData[103] = "000";
                Global.GenData[104] = "000";
                Global.GenData[105] = "000";
                Global.GenData[108] = "000";
                Global.GenData[109] = "000";
                Global.GenData[112] = "000";
                Global.GenData[113] = "000";
                Global.GenData[117] = "000";
                Global.GenData[118] = "000";
                Global.L_Mode = Global.C_Mode;
                Auto_SmkRd = true;

                if ((Global.StpN + 1) > (GridSeq.RowCount - 1))
                {
                    stopEngine();
                    //MessageBox.Show("Programme Over ........");
                    Global.Create_OnLog("Program Over.");
                    //AddListItem("Program Over.", 2);
                }

                Update_Tss1(0);
                Global.SFC_msg = "Engine Is Running ...";
                Global.StpTm = System.DateTime.Now.ToString("hh:mm:ss");
                txtStepNo.Text = String.Format("{0:000}", (Global.StpN + 1));
                Global.flg_RLoop = false;
                Global.StNo = (Global.StpN + 1);

                GridSeq.Enabled = true;
                Global.LastAna1 = Double.Parse(Global.SetPtOut1);
                Global.LastAna2 = Double.Parse(Global.SetPtOut2);

                GridSeq.Rows[Global.StpN].Selected = true;
                if (Global.StpN >= 2) GridSeq.FirstDisplayedScrollingRowIndex = (Global.StpN - 1);

                if (GridSeq[0, Global.StpN].Value != null)
                {
                    Global.C_Mode = GridSeq.Rows[Global.StpN].Cells[1].Value.ToString();
                    T = GridSeq.Rows[Global.StpN].Cells[3].Value.ToString();
                    TmR1 = ((int.Parse(T.Substring(0, 2)) * 3600) + int.Parse(T.Substring(3, 2)) * 60 + int.Parse(T.Substring(6, 2)));
                    if (TmR1 < 1) TmR1 = 1;
                    T = GridSeq.Rows[Global.StpN].Cells[5].Value.ToString();
                    TmR2 = ((int.Parse(T.Substring(0, 2)) * 3600) + int.Parse(T.Substring(3, 2)) * 60 + int.Parse(T.Substring(6, 2)));
                    if (TmR2 < 1) TmR2 = 1;


                    T = GridSeq.Rows[Global.StpN].Cells[6].Value.ToString();
                    Tstb = ((int.Parse(T.Substring(0, 2)) * 3600) + int.Parse(T.Substring(3, 2)) * 60 + int.Parse(T.Substring(6, 2)));

                    T = GridSeq.Rows[Global.StpN].Cells[7].Value.ToString();
                    Tstd = ((int.Parse(T.Substring(0, 2)) * 3600) + int.Parse(T.Substring(3, 2)) * 60 + int.Parse(T.Substring(6, 2)));
                    SockT = Tstd;
                    if (TmR1 > TmR2) TmR = TmR1; TmR = TmR2;
                    PBar3.Maximum = TmR + 1;

                    T = GridSeq.Rows[Global.StpN].Cells[8].Value.ToString();
                    Tstp = ((int.Parse(T.Substring(1, 2)) * 60) + int.Parse(T.Substring(4, 2)));

                    T = GridSeq.Rows[Global.StpN].Cells[10].Value.ToString();
                    CH = T.Substring(0, 1);
                    switch (CH)
                    {
                        case "Y":
                            LogT = 5;
                            flg_PerStep = true;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                        case "H":
                            LogT = 5;
                            flg_flyUp = true;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                        case "L":
                            LogT = 5;
                            flg_Idle = true;
                            flg_flyUp = false;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                        case "A":
                            LogT = (int.Parse(T.Substring(1, 2)) * 60) + int.Parse(T.Substring(4, 2));
                            flg_PerStep = false;
                            flg_Instat = true;
                            flg_Avg = false;
                            DataCnt = LogT;
                            break;
                        case "N":
                            LogT = 0;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            DataCnt = LogT;
                            break;
                        default:
                            LogT = 0;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                    }
                    if (GridSeq.Rows[Global.StpN].Cells[11].Value.ToString() == "True")
                        Global.Auto_SFC = true;
                    else
                        Global.Auto_SFC = false;

                    if (GridSeq.Rows[Global.StpN].Cells[14].Value.ToString() == "True")
                        Global.flg_SMK415_S = true;
                    else
                        Global.flg_SMK415_S = false;

                    Double IC = Convert.ToDouble(GridSeq.Rows[Global.StpN].Cells[12].Value);
                    if ((IC >= 10) && (GridSeq.Rows[Global.StpN].Cells[14].Value.ToString() == "True"))
                    {
                        //Global.flg_WriteVal = true;

                        //textBox24.Text = (IC * 10.0).ToString();

                        //button50.PerformClick(); 
                    }


                    Global.Ex_Bk = Convert.ToDouble(GridSeq.Rows[Global.StpN].Cells[13].Value);
                    if (GridSeq.Rows[Global.StpN].Cells[15].Value.ToString() == "True")
                    {
                        //flg_ExBkP = true;
                        //if ((Global.Ex_Bk >= 10) && (flg_ExBkP == true))
                        //{
                        //    textBox23.Text = Global.Ex_Bk.ToString();
                        //    Global.Dig_OutBit(0, 0, true);
                        //    Global.Dig_OutBit(0, 1, true);
                        //    //button51.PerformClick();
                        //}
                    }
                    else
                    {
                        Global.Dig_OutBit(0, 0, false);
                    }

                    //if ((Convert.ToBoolean(GridSeq.Rows[StpN].Cells[14].Value.ToString() == true)) && (IC <= 10)) Global.Write_SetValue(16, IC);
                    //M_Trq = GridSeq.Rows[StpN].Cells[15].Value.ToString();

                    TolT = GridSeq.Rows[Global.StpN].Cells[18].Value.ToString();


                    //M_Trq = GridSeq.Rows[StpN].Cells[15].Value.ToString();
                    //if (M_Trq == "MT") Global.Mx_Trq = true; else Global.Mx_Trq = false;
                    //E_Hld = GridSeq.Rows[StpN].Cells[16].Value.ToString();
                    //if (E_Hld == "HC") Auto_Hold = true; else Auto_Hold = false;

                    int pos1 = 0;
                    string str1 = "";
                    int pos2 = 0;
                    string str2 = "";


                    //**********************************
                    
                    //********************************
                    Double x = 0;
                    switch (Global.C_Mode)
                    {
                        case "6":
                            str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                            pos1 = str1.IndexOf(" ", 0);
                            T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                            label20.Text = "R";
                            Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                           
                            str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                            pos2 = str2.IndexOf(" ", 0);
                            D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                            label19.Text = "T";
                            Global.SetPtOut2 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                            GridSeq.Columns[4].HeaderText = "Dynamometer  Demand(rpm)";
                            GridSeq.Columns[2].HeaderText = "Throttle   Demand(Nm)";
                            break;
                        case "5":
                            str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                            pos1 = str1.IndexOf(" ", 0);
                            T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                            label20.Text = "R";
                            Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                           
                            str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                            pos2 = str2.IndexOf(" ", 0);
                            D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                            x = (Convert.ToDouble(D) * (Global.Max_Trq)) / 100;
                            Global.SetPtOut2 = ((x * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                            label19.Text = "%";                            
                            GridSeq.Columns[4].HeaderText = "Dynamometer  Demand(rpm )";
                            GridSeq.Columns[2].HeaderText = "Throttle     Demand(%Nm)";
                            break;
                        case "4":
                            str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                            pos1 = str1.IndexOf(" ", 0);
                            D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                            label20.Text = "R";
                            Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                            str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                            pos2 = str2.IndexOf(" ", 0);
                            T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                            label19.Text = "T";
                            Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();//Convert.ToDouble(Global.sysIn[4]
                            GridSeq.Columns[4].HeaderText = "Dynamometer  Demand(rpm)";
                            GridSeq.Columns[2].HeaderText = "Throttle    Demand(Nm)";
                            break;

                        case "3":
                            str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                            pos1 = str1.IndexOf(" ", 0);
                            D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                            x = (Double.Parse(D) * Global.F_Rpm) / 100;                            
                            label20.Text = "%";                           
                            Global.SetPtOut1 = ((x * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString(); 
                            
                            str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                            pos2 = str2.IndexOf(" ", 0);
                            T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                            label19.Text = "T";
                            Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString(); //Convert.ToDouble(Global.sysIn[4]
                            GridSeq.Columns[4].HeaderText = "Dynamometer  Demand(%)";
                            GridSeq.Columns[2].HeaderText = "Throttle    Demand(Nm)";
                            break;
                        case "2":
                            str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                            pos1 = str1.IndexOf(" ", 0);
                            D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                            label20.Text = "R";
                            Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                            str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                            pos2 = str2.IndexOf(" ", 0);
                            T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                            label19.Text = "%";
                            Global.SetPtOut2 = Global.SetPtOut2 = (((Double.Parse(T)) * 10) / (Global.Max_Trq)).ToString();
                            GridSeq.Columns[4].HeaderText = "Dynamometer  Demand(rpm)";
                            GridSeq.Columns[2].HeaderText = "Throttle    Demand(%Nm)";
                            break;
                        default:
                            str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                            pos1 = str1.IndexOf(" ", 0);
                            D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                            label20.Text = "%";
                            Global.SetPtOut1 = ((Double.Parse(D)) / 10).ToString();
                            str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                            pos2 = str2.IndexOf(" ", 0);
                            T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos1);
                            label19.Text = "%";
                            Global.SetPtOut2 = ((Double.Parse(T)) / 10).ToString();
                            GridSeq.Columns[4].HeaderText = "Dynamometer  Demand( % )";
                            GridSeq.Columns[2].HeaderText = "Throttle    Demand( % )";
                            break;
                    }
                    Global.LastT = Convert.ToDouble(T);
                    Global.LastD = Convert.ToDouble(D);

                    if (TmR1 >= TmR2) TmR = TmR1; else TmR = TmR2;
                    //***********************
                    if ((int.Parse(Global.L_Mode) == 1) && (int.Parse(Global.C_Mode) >= 5))
                    {
                        if (Global.LastAna1 >= Double.Parse(Global.SetPtOut1))
                            Global.AnaOut1 = Global.LastAna1;
                        else
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);                       
                    }
                    if ((int.Parse(Global.L_Mode) >= 5) && (int.Parse(Global.C_Mode) == 4))
                    {
                        TmR1 = 1;
                        TmR1 = 1;
                        TmR = 1;
                    }
                    //***********************
                   
                    Global.Diff1 = (Double.Parse(Global.SetPtOut1) - (Global.LastAna1)) / (TmR1 * 10);
                    Global.Diff2 = (Double.Parse(Global.SetPtOut2) - (Global.LastAna2)) / (TmR2 * 10);
                  
                    PBar1.Maximum = 10000;
                    PBar2.Maximum = 10000;
                }
                else
                {
                    stopEngine();
                }
            }
            catch
            {                
                Global.Create_OnLog("Load Prog.Step Error :" + Global.StNo);
            }
        }
       
                  

           //***********************

        public  void Load_Gridseq_header()
        {
            try
            {
                GridSeq.ColumnCount = 20;
               if (GridSeq.RowCount < 10) GridSeq.RowCount = 10; 
                foreach (DataGridViewColumn colm in GridSeq.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                GridSeq.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                GridSeq.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                GridSeq.Columns[0].Width = 40;
                GridSeq.Columns[0].HeaderText = "Sn";
                GridSeq.Columns[1].Width = 40;
                GridSeq.Columns[1].HeaderText = "MD";
                GridSeq.Columns[2].Width = 60;  //
                GridSeq.Columns[2].HeaderText = "SetPt-1  (rpm)";
                GridSeq.Columns[3].Width = 60;  //
                GridSeq.Columns[3].HeaderText = "RmT-1  (mm:ss)";
                GridSeq.Columns[4].Width = 60;  //
                GridSeq.Columns[4].HeaderText = "SetPt-2 (%)";
                GridSeq.Columns[5].Width = 60;  //
                GridSeq.Columns[5].HeaderText = "RmT-2 (mm:ss)";
                GridSeq.Columns[6].Width = 60;  //
                GridSeq.Columns[6].HeaderText = "T_Stb  (mm:ss)";
                GridSeq.Columns[7].Width = 60;  //
                GridSeq.Columns[7].HeaderText = "T_Std  (mm:ss)";
                GridSeq.Columns[8].Width = 60;  //
                GridSeq.Columns[8].HeaderText = "Stop  (mm:ss)";
                GridSeq.Columns[9].Width = 90;
                GridSeq.Columns[9].HeaderText = "Repeat   (" + Global.loopcount + " )";
                GridSeq.Columns[10].Width = 60;  //
                GridSeq.Columns[10].HeaderText = "LogData     (" + LogT + ")";
                //txtrepeate.Text = Global.loopcount.ToString();
                //txtlog.Text = LogT.ToString();
                GridSeq.Columns[11].Visible = Visible;
                GridSeq.Columns[11].Width = 40;  //
                GridSeq.Columns[11].HeaderText = "SFC  (G/V)";
                GridSeq.Columns[12].Visible = false;
                GridSeq.Columns[12].Width = 90;  //
                GridSeq.Columns[12].HeaderText = "MinLP (bar)";
                GridSeq.Columns[13].Visible = false;   
                GridSeq.Columns[13].Width = 90;  //60;
                GridSeq.Columns[13].HeaderText = "MaxVal ";
                GridSeq.Columns[14].Visible = false;
                GridSeq.Columns[14].Width = 90;  //50;
                GridSeq.Columns[14].HeaderText = "Dwtr";
                GridSeq.Columns[15].Visible = false;
                GridSeq.Columns[15].Width = 90;  //50;
                GridSeq.Columns[15].HeaderText = "D1";
                GridSeq.Columns[16].Visible = false;
                GridSeq.Columns[16].Width = 90;  //30;h
                GridSeq.Columns[16].HeaderText = "D2";
                GridSeq.Columns[17].Visible = false;
                GridSeq.Columns[17].Width = 90;  //40;
                GridSeq.Columns[17].HeaderText = "D3";
                GridSeq.Columns[18].Width = 60;  //80;
                GridSeq.Columns[18].HeaderText = "Tm";
                GridSeq.Columns[19].Width = 235;  //80;
                GridSeq.Columns[19].HeaderText = "Step Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Load_Gridseq_header():  " + ex.Message);
            }
        }

        //public void Check_Limit()
        //{
        //    Int16 L = 0;
        //    String A1, B1, C1, D1;
        //    String A2 = "";
        //    String B2 = "";
        //    String C2 = "";
        //    String D2 = "";
        //    Double InVal = 0;

        //    try
        //    {
                
        //        for (L = 0; L <= 95; L++)
        //        {
        //            if (L == 2) L = 6;                  
        //                A1 = Global.LL1[L].Substring(0, 1);
        //                B1 = Global.L1[L].Substring(0, 1);
        //                C1 = Global.H1[L].Substring(0, 1);
        //                D1 = Global.HH1[L].Substring(0, 1);

        //                if (Global.LL1[L].Substring(1) != String.Empty) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
        //                if (Global.L1[L].Substring(1) != String.Empty) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
        //                if (Global.H1[L].Substring(1) != String.Empty) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
        //                if (Global.HH1[L].Substring(1) != String.Empty) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];
        //            //}
        //            InVal = Double.Parse(Global.GenData[L]);
        //            Global.StrAlarm = "";
        //            if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Double.Parse(D2))))
        //            {
        //                Global.Flg_AList = true;
        //                if ((Global.Flg_AList == true) && (Global.arrLim[L] == "") || (Global.arrLim[L] == "A"))
        //                {
        //                    Global.arrLim[L] = "O : " + Global.PSName[L] + " ";
        //                    Global.BufLim[L] = "0";      //if (ViewGrid[2, L].Style.BackColor == Color.Green) 
        //                    Global.Create_OnLog("IGNITION OFF  : " + Global.PSName[L]);
        //                    Global.StrAlarm = Global.StrAlarm + "," + Global.arrLim[L];  
        //                    btnAlarm.Text ="Engine ShutOFF: " + Global.PSName[L];
        //                    AddListItem("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal, 2);
        //                    //Global.Create_OnLog("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal);
        //                    LogData();
        //                    stopEngine();
        //                    return;
        //                }
        //            }
        //            else if (((A1 == "I") && (InVal < double.Parse(A2))) || ((D1 == "I") && (InVal > Double.Parse(D2))))
        //            {
        //               Global.Flg_AList = true;
        //                if ((Global.Flg_AList == true) &&   (Global.BufLim[L] != "I"))    //(ViewGrid[2, L].Style.BackColor == Color.Gainsboro))
        //                {
        //                    Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
        //                    Global.BufLim[L] = "I";    //if (ViewGrid[2, L].Style.BackColor == Color.Blue)
        //                    Global.Create_OnLog("Idle  : " + Global.PSName[L]);
        //                    Global.StrAlarm = Global.StrAlarm + "," + Global.arrLim[L];  
        //                    btnAlarm.Text ="Engine @ Idle:" + Global.PSName[L];
        //                    AddListItem("Engine @ Idle: " + Global.PSName[L] + " : " + InVal,10);
        //                    //Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal);
        //                    LogData();
        //                    IdelEng(); 
        //                    return;
        //                }
        //            }
        //            else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
        //            {
        //                Global.Flg_AList = true;
                      
        //                if ((Global.Flg_AList == true) && ((Global.arrLim[L] == "") || (Global.arrLim[L] == null)))    //A : " + Global.PSName[L] + " ";
        //                {
        //                    Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
        //                    Global.BufLim[L] = "A";  //if (ViewGrid[2, L].Style.BackColor == Color.Red)
        //                    AddListItem("Alarm  : " + Global.PSName[L], 4);
        //                    //Global.Create_OnLog("Alarm  : " + Global.PSName[L]);                          
        //                    btnAlarm.Text = "Check Engine Alarm..";
        //                }
                      
        //            }
                   
        //            else
        //            {
                        
        //                Global.arrLim[L] = "";
        //                Global.BufLim[L] = "N";
                       
        //            }
        //            for (int k = 0; k <= 95; k++)
        //            {
        //                Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
        //                if (Global.StrAlarm == "") btnAlarm.Text = "Engine Is Running.....";
   
        //            }
        //        }


        //    }
        //    catch 
        //    {

        //        //MessageBox.Show("Error Check_Limit :" + L + " : " + InVal + ex.Message);
        //        //AddListItem("En Check_Limit :" + L + " : " + InVal, 10);
        //        Global.Create_OnLog("En Check_Limit :" + L + " : " + InVal);  
        //    }
        //}

        public void Check_Limit_Standby()
        {
            Int16 L = 0;
            String B1, C1;
            String B2 = "";
            String C2 = "";
            Double InVal = 0;
           
                for (L = 0; L <= 95; L++)
                {
                    if (L == 2) L = 6;                    
                    B1 = Global.Ls[L].Substring(0, 1);
                    C1 = Global.Hs[L].Substring(0, 1);
                    if (Global.Ls[L].Substring(1) != String.Empty) B2 = Global.Ls[L].Substring(1); else B2 = Global.PMin[L];
                    if (Global.Hs[L].Substring(1) != String.Empty) C2 = Global.Hs[L].Substring(1); else C2 = Global.PMax[L];

                    InVal = Convert.ToDouble(Global.GenData[L]);
                    Global.StrAlarm = "";
                    if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
                    {
                        Global.BufLim[L] = "A";                       
                    }
                    else
                    {                       
                        Global.BufLim[L] = "N";
                    }
                }
        }

        private void Check_Limit()
        {
          Int16 L = 0;
          String A1 = "";
          String B1 = "";
          String C1 = "";
          String D1 = "";

          String A2 = "";
          String B2 = "";
          String C2 = "";
          String D2 = "";
          Double InVal = 0;
          // 
          try
          {
              for (L = 0; L <= 95; L++)
              {
                  if (L == 2) L = 6;
                  if (Global.PSName[L] != "Not_Prog")
                  {
                      if (Global.LL1[L] != "") A1 = Global.LL1[L].Substring(0, 1);
                      if (Global.L1[L] != "") B1 = Global.L1[L].Substring(0, 1);
                      if (Global.H1[L] != "") C1 = Global.H1[L].Substring(0, 1);
                      if (Global.HH1[L] != "") D1 = Global.HH1[L].Substring(0, 1);

                      if (Global.LL1[L].Length > 1) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
                      if (Global.L1[L].Length > 1) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
                      if (Global.H1[L].Length > 1) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
                      if (Global.HH1[L].Length > 1) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];

                      if (Global.GenData[L] != null) InVal = Convert.ToDouble(Global.GenData[L]); else InVal = 0.0;
                      Global.StrAlarm = "";
                      if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Convert.ToDouble(D2))))
                      {
                          Global.Flg_AList = true;
                          if ((Global.Flg_AList == true))
                          {
                              Global.arrLim[L] = "O : " + Global.PSName[L] + " ";
                              Global.BufLim[L] = "O";     
                              Global.Create_OnLog("IGNITION OFF  : " + Global.PSName[L]);
                              Global.StrAlarm = "Engine 'OFF'" + Global.arrLim[L];
                              Global.Create_OnLog("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal);
                              LogData();
                              stopEngine();
                              return;
                          }
                      }
                      else if (((A1 == "I") && (InVal < Convert.ToDouble(A2))) || ((D1 == "I") && (InVal > Convert.ToDouble(D2))))
                      {
                          Global.Flg_AList = true;

                          if (Global.LimNo[L] <= 2)
                          {
                              Global.LimNo[L] += 1;
                              //AddListItem("Engine @ Idle: " + Global.PSName[L] + " : " + InVal + "count :" + Global.LimNo[L], 6);
                              Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal);
                          }
                          if (Global.LimNo[L] > 2)
                          {
                              if ((Global.Flg_AList == true) && (Global.BufLim[L] != "I"))   
                              {
                                  Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
                                  Global.BufLim[L] = "I";                                  
                                  Global.StrAlarm = "Engine @ Idle " + " : " + InVal; 
                                  Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal);
                                  LogData();
                                  IdelEng();                                 
                              }
                          }
                          return;
                      }
                      //Global.StrAlarm = "";
                      else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
                      {                          
                          if (Global.BufLim[L] == "N")
                          {
                              Global.BufLim[L] = "A";
                              Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
                              Global.Create_OnLog("Alarm  : " + Global.PSName[L]);
                          }
                      }
                      else
                      {
                          Global.BufLim[L] = "N";
                      }                      
                  }
              }
                for (int k = 0; k <= 95; k++)
                {
                  Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
                }
              }
          catch (Exception ex)
          {
            Global.Create_OnLog("Error Check_Limit :" + L + " : " + InVal + ex.Message);
          }
        }


        //public void AddListItem(string message, int Icon)
        //{
        //    try
        //    {
        //        if (Global.varRPM >= 600)
        //        {
        //            listView1.View = View.SmallIcon;
        //            listView1.SmallImageList = imageList1;
        //            listView1.Items.Add(DateTime.Now.ToString("hh:mm:ss") + ":  " + message, +Icon);
        //            if (message.StartsWith(Global.StNo + ": Step Started") == false)
        //            {
        //                Global.Create_OnLog(message);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in frmMain: AddListItem():  " + ex.Message);
        //    }
        //}

        public void Check_Necessary_Files()
        {
            try
            {
                if (System.IO.Directory.Exists(Global.PATH) == false)
                {

                    MessageBox.Show(Global.PATH + " folder does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "General.accdb") == false)
                {

                    MessageBox.Show(Global.PATH + " General.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Data.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Data.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Limit.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Limit.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Sequence.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Sequence.accdb does not exist!!! Can not start Application.");

                }

                if (System.IO.File.Exists(Global.PATH + "Log.accdb") == false)
                {

                    MessageBox.Show(Global.PATH + " Log.accdb does not exist!!! Can not start Application.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Check_Necessary_Files():  " + ex.Message);
            }
        }

        private void Fun_ProgOut()
        {
            string str;
            try
            {

                if (TmR > 0)
                {
                    //lblStatus.Text = "RAMP TIME:";
                    PBar3.Caption = "RAMP TIME:";
                    GridSeq.Enabled = false;
                    flg_Ramp = true;
                    flg_Stb = false;
                    flg_Std = false;
                    //lblStatus.ForeColor = Color.Red; 
                    TmR = TmR - 1;
                    if (TmR1 > 0) TmR1 = (TmR1 - 1);
                    if (TmR2 > 0) TmR2 = (TmR2 - 1);
                    if (TmR1 <= 0)
                    {
                        TmR1 = 0;
                        Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                        if((Global.C_Mode =="1")||(Global.C_Mode =="3")  )
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("0000");
                        else
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                    }
                    if (TmR2 <= 0)
                    {
                        TmR2 = 0;
                        Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                        if ((Global.C_Mode == "1") || (Global.C_Mode == "2") || (Global.C_Mode == "5"))
                            txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("000.0");
                        else
                            txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0"); //Convert.ToDouble(Global.sysIn[4]
                    }
                    t = TimeSpan.FromSeconds(TmR);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                    // txtPStatus.Text = string.Format("{0:0000}", TmR);
                    settimefor_gridseq();
                    PBar3.Value = TmR;

                    if (TmR <= 0)
                    {
                        TmR = 0;
                        //Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                        //Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                        //lblStatus.Text = "STABILISATION TIME:";
                        PBar3.Caption = "STABILISATION TIME:";
                        GridSeq.Enabled = true;
                        //lblStatus.ForeColor = Color.Green;
                        t = TimeSpan.FromSeconds(Tstb);
                        answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                        txtPStatus.Text = answer;
                        //txtPStatus.Text = string.Format("{0:0000}", Tstb);
                        settimefor_gridseq();
                        PBar3.Maximum = Tstb;
                        flg_Ramp = false;
                        flg_Stb = true;
                        flg_Std = false;
                    }
                }
                else if (Tstb > 0)
                {
                    Tstb = (Tstb - 1);
                    t = TimeSpan.FromSeconds(Tstb);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                    settimefor_gridseq();
                    PBar3.Value = Tstb;
                    if (Tstb <= 0)
                    {
                        Tstb = 0;                       
                        PBar3.Caption = "STEADY TIME:";
                        GridSeq.Enabled = true;
                        //lblStatus.ForeColor = Color.Blue;
                        t = TimeSpan.FromSeconds(Tstb);
                        answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                        txtPStatus.Text = answer;
                        // txtPStatus.Text = string.Format("{0:0000}", Tstb);
                        settimefor_gridseq();

                        if (PBar3.Caption == "STEADY TIME:")                       
                            PBar3.Maximum = Tstd;
                        //Global.Auto_SFC = true;

                        if (Global.Auto_SFC == true)
                        {
                            //if (R_Cnt == 1)
                            //{
                            //    Global.flg_SFC = false;
                            //    Global.SFC_Reset = true;                                
                            //    Global.flg_SFCStart = true;
                            //    Global.flg_SFCSerialStart = true;
                            //    //--------------dt 14/12/2017 ----- by 
                            //    tmrReset.Start();
                            //}
                            //else
                            //{
                            //    R_Cnt++;
                            //    Global.flg_SFC = false;
                            //    Global.SFC_Reset = true;
                            //    Global.Auto_SFC = false;
                            //    Global.flg_SFCStart = true;
                            //    Global.flg_SFCSerialStart = false;

                            //}
                            Global.flg_SFC = false;
                            Global.SFC_Reset = true;
                            Global.Auto_SFC = false;
                            Global.flg_SFCStart = true;
                            tmrReset.Start();
                            // 
                        }
                        flg_Ramp = false;
                        flg_Stb = false;
                        flg_Std = true;
                    }
                }
                else if (Tstd > 0)
                {
                    Tstd = Tstd - 1;
                    t = TimeSpan.FromSeconds(Tstd);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds );
                    txtPStatus.Text = answer;
                    // txtPStatus.Text = string.Format("{0:0000}", Tstd);  
                    settimefor_gridseq();
                    PBar3.Value = Tstd;
                    if (Tstd <= 0)
                    {
                        Tstd = 0;
                        PBar3.Caption = "RAMP TIME:";
                        GridSeq.Enabled = false;
                        ////////////////////////////////////////////////////////

                        if (GridSeq.Rows[Global.StpN].Cells[9].Value != DBNull.Value)
                        {

                            str = GridSeq.Rows[Global.StpN].Cells[9].Value.ToString();
                            if (str.Substring(3, 1).ToString() == "R")
                            {
                                Global.flg_RLoop = true;
                                Srloop = int.Parse(str.Substring(0, 3).ToString());
                                Erloop = int.Parse(str.Substring(4).ToString());
                                if ((Global.flg_RLoop == true) && (Erloop > Global.loopcount))// (int.Parse(str.Substring(pos + 1)))))
                                {
                                    //Global.loopcount -= 1; 
                                    Global.loopcount += 1;

                                    //n = (int.Parse(str.Substring(0, pos))).ToString("000");
                                    //n1 = (loopcnt - 1).ToString("000");
                                    Global.Create_OnLog("Repeat  (" + Global.loopcount + ")");

                                    GridSeq.Columns[9].HeaderText = "Repeat  (" + Global.loopcount + ")";
                                    //GridSeq.Rows[StpN].Cells[9].Value = n + "R" + n1;
                                    //StpN = int.Parse(str.Substring(0, pos ))-1;
                                    Global.StpN = Srloop - 1;// int.Parse(str.Substring(0, pos)) - 1;
                                    Global.StNo = Global.StpN + 1;
                                }
                                else
                                {
                                    Global.loopcount = 0;
                                    GridSeq.Columns[9].HeaderText = "Repeat  (" + Global.loopcount + ")";

                                    Global.StpN = Global.StpN + 1;
                                    //StpN = int.Parse(str.Substring(0, pos)) ;
                                    txtStepNo.Text = String.Format("{0:000}", (Global.StpN + 1));
                                    Global.StNo = (Global.StpN + 1);
                                }
                            }
                            else
                            {
                                Global.flg_RLoop = false;
                                Global.StpN = Global.StpN + 1;
                                Global.StNo = (Global.StpN + 1);
                            }
                        }             
                        //StpN = StpN + 1;
                        Load_ProgStep();
                        flg_Ramp = true;
                        flg_Stb = false;
                        flg_Std = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Fun_ProgOut():  " + ex.Message);
            }
           
        }
        private void Hold_Cycle(Boolean flg_Hold)
        {
            try
            {
                if (flg_Hold == true) 
                {
                    Auto_Hold = false;
                    if (Btn24.Text  == "Cycle_Hold")
                   {
                        Btn24.Text = "Cycle_Resume";
                        Global.Create_OnLog("Cycle Hold....."); 
                        flg_ProgOut = false;
                        Global.SFC_msg = "Cycle Is on Hold ...";
                        Update_Hold(1); 
                   }                
                   else if (Btn24.Text == "Cycle_Resume")
                   {
                        Btn24.Text = "Cycle_Hold";
                        Global.Create_OnLog("Cycle Resume.....");
                        Update_Tss1(0);
                        Global.SFC_msg = "Cycle Is Running...";
                        flg_ProgOut = true;
                        flg_AnaOut = true; 
                        Auto_Hold = false;
                        Global.Auto_SFC = false;
                        Update_Hold(0); 
                   }
                }
            }                           
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Hold_Cycle():  " + ex.Message);
            }
        }

        public void Create_FileName(String ENo)
        {
            try
            {
                String Str = null;
                int pos1 = 1;
                int pos2 = 2;
                int pos3 = 1;
                String Dt = DateTime.Now.ToString("ddMMMyyyy");
                ENo = Global.EngNo;
                ENo = Global.EngNo.Replace(" ", "");
                ENo = ENo.Replace(".", "");
                ENo = ENo.Replace("!", "");
                ENo = ENo.Replace("'", "");
                ENo = ENo.Replace("[]", "");
                ENo = ENo.Replace("_", "");
                ENo = ENo.Replace("-", "");

                //******************************
                Global.Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblLastFl", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                while (Rd.Read())
                {
                    Str = Rd.GetValue(0).ToString();
                }
                if (Global.flg_NewFile == true)
                {
                    pos1 = Str.IndexOf("_", 0);
                    pos2 = Str.IndexOf("_", (pos1 + 1));
                    pos3 = Str.IndexOf("_", (pos2 + 1));

                    int T = int.Parse(Str.Substring(pos3 + 1)) + 1;
                    String Ct = T.ToString("00");
                    if (Dt == Str.Substring(pos1 + 1, 9))
                    {
                        Global.Eng_FileNm = "Gen_" + Dt + "_" + ENo + "_" + Ct;
                    }
                    else
                    {
                        Global.Eng_FileNm = "Gen_" + Dt + "_" + ENo + "_01";
                    }
                    if (Global.Eng_FileNm == String.Empty) Global.Eng_FileNm = "Manual_Data";

                    Global.Open_Connection("General", "con");
                    cmd = new MySqlCommand("Update tblLastFl SET " +
                        " AutoFile = '" + Global.Eng_FileNm + "'", Global.con);
                    cmd.ExecuteNonQuery();

                    //*******************************

                    Global.Eng_Error_FileNm = "LogErr" + (Global.Eng_FileNm.Substring(3));
                    Global.Eng_PMFileNm = "PM" + (Global.Eng_FileNm.Substring(3));
                    Global.Eng_Inst_FileNm = "Inst" + (Global.Eng_FileNm.Substring(3));
                    //Global.Eng_FLog_FileNm = "Fast" + (Global.Eng_FileNm.Substring(3));

                    checkBox13.Text = Global.EngNo;
                    checkBox15.Text = Global.Eng_FileNm;
                    checkBox8.Text = Global.PrjNm;

                    Create_Gen_Table();
                    Create_ErTable();
                    Create_Inst_Table();
                    
                    if (Global.flg_RecorsPmData == true) Create_PMTable();
                    checkBox15.Text = Global.Eng_FileNm;

                }
                else if (Global.flg_OldFile == true)
                {
                    Global.Eng_FileNm = Str;

                    Global.Eng_Error_FileNm = "LogErr" + (Global.Eng_FileNm.Substring(3));
                    Global.Eng_PMFileNm = "PM" + (Global.Eng_FileNm.Substring(3));
                    Global.Eng_Inst_FileNm = "Inst" + (Global.Eng_FileNm.Substring(3));
                   
                    checkBox13.Text = Global.EngNo;
                    checkBox15.Text = Global.Eng_FileNm;
                    checkBox8.Text = Global.PrjNm;
                    checkBox15.Text = Global.Eng_FileNm;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_FileName():  " + ex.Message);
            }
        }
        
        private void Create_ErTable()
        {
            try
            {
                int i = 0;
                String StrTb = null;
                Global.SnEr = 0;
                StrTb = StrTb + "EngineNo TEXT, ";
                StrTb = StrTb + "StepNo TEXT, ";
                StrTb = StrTb + "EngineRPM TEXT, ";
                StrTb = StrTb + "MES TEXT, ";
                StrTb = StrTb + "TM TEXT, ";
                StrTb = StrTb + "Id NUMBER PRIMARY KEY";

                if (System.IO.File.Exists(Global.DataPath + "Error_Data\\" + Global.Eng_Error_FileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "Error_Data\\" + Global.Eng_Error_FileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_Table():  " + ex.Message);
            }
        }

        private void Create_Gen_Table()
        {
            try
            {
                int i = 0;
                Boolean flg_Filefound = false;
                String StrTb = null;
                String StrTb1 = null;
                String StrTb2 = null;
                for (i = 0; i <= 125; i++)
                {
                    Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    Global.PSName[i] = Global.PSName[i].Replace("-", "");
                    StrTb = StrTb + i.ToString("000") + Global.PSName[i] + "  (" + Global.PUnit[i] + "), ";
                }
                if (System.IO.File.Exists(Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_Table():  " + ex.Message);
            }
        }

        private void Create_Inst_Table()
        {
            try
            {
                int i = 0;
                Boolean flg_Filefound = false;
                String StrTb = null;
                String StrTb1 = null;
                String StrTb2 = null;

                for (i = 0; i <= 125; i++)
                {
                    Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    Global.PSName[i] = Global.PSName[i].Replace("-", "");
                    //StrTb = StrTb + i.ToString("000") + Global.PSName[i] + "  (" + Global.PUnit[i] + "), ";
                }

                StrTb1 = "TM DateTime  ***, 000Eng RPM  rpm,";
                for (i = 1; i <= 50; i++)
                {
                    StrTb1 = StrTb1 + i.ToString("000") + Global.PSName[Global.vId[i]] + "  (" + Global.PUnit[Global.vId[i]] + "), ";
                }
                StrTb = StrTb1 + "S_ln,";

                if (System.IO.File.Exists(Global.DataPath + "Inst_Data\\" + Global.Eng_Inst_FileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "Inst_Data\\" + Global.Eng_Inst_FileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_Inst_Table():  " + ex.Message);
            }
        }



        
        
        private void Create_PMTable()
        {
            try
            {
                int i = 0;
                Boolean flg_Filefound = false;
                String StrTb = null;

                for (i = 0; i <= 125; i++)
                {
                    Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    Global.PSName[i] = Global.PSName[i].Replace("-", "");
                    //StrTb = StrTb + i.ToString("000") + Global.PSName[i] + " TEXT, ";
                }

                StrTb = "TM Date ***, 00RPM rpm, ";
                for (i = 1; i <= 11; i++)
                {
                    string X = i.ToString("000");
                    StrTb += X + Global.PSName[Global.Pm_PNo[i]] + " " + Global.PUnit[Global.Pm_PNo[i]]+", ";
                }               
                StrTb = StrTb + "Alarm,";

                if (System.IO.File.Exists(Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_Table():  " + ex.Message);
            }
        }
        public void Make_mdb(String mdbPath)
        {
            try
            {
                Global.Data_Dir = DateTime.Now.ToString("MMMyy");
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo) == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo);
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir) == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir);
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data");
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Inst_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Inst_Data");
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Error_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Error_Data");
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data");
                }


                //if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data") == false)
                //{
                //    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data");
                //}
                //if (System.IO.Directory.Exists(mdbPath) == false) System.IO.Directory.CreateDirectory(mdbPath);

                //if (System.IO.File.Exists(mdbPath + "\\Data.accdb") == false) System.IO.File.Copy(Global.PATH + "Data.accdb", Global.DataPath + "\\Data.accdb");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Problem in creating data base ..." + ex.Message);
            }

        }
        private void CapturePMData()
        {
            try
            {
                int i = 0;
                int t = 0;
                PmData[0] = DateTime.Now.ToString("hh:mm:ss tt");
                for (i = 0; i <= 12; i++)
                {
                    t = Global.Pm_PNo[i];
                    PmData[i+1] = Global.GenData[t];
                }
                if (( Global.StrAlarm == null )||( Global.StrAlarm =="" ))   PmData[13] = "****"; else PmData[13] = Global.StrAlarm;
       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in CapturePMData():" + ex.Message);
            }
        }

        private void RecordPMData()
        {
            int i = 0;
            CapturePMData();            
            String Str = String.Empty;
            String Str1 = String.Empty;           
            for (i = 0; i <= 12; i++)
            {
                if (PmData[i] == null)
                {
                    PmData[i] = "0.0";
                }
                Str = Str + PmData[i] + ", ";

            }
            Str = Str + "***" +",\n";
            
           

            var filePath = Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv";

            using (var wr = new StreamWriter(filePath, true))
            {
                var row = new List<string> { Str.Substring(0, Str.Length - 1) };
                var sb = new StringBuilder();
                foreach (string value in row)
                {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(value);
                }
                wr.WriteLine(sb.ToString());
            }
            int linecount = File.ReadAllLines(filePath).Count();
            if (linecount >= 120)
            {
                var file = new List<string>(System.IO.File.ReadAllLines(filePath));
                file.RemoveAt(1);
                File.WriteAllLines(filePath, file.ToArray());
                //lines.WriteAllLines(filePath, lines.Skip(1).ToArray());
            }                

        }


        //private void RecordPMData()
        //{          
        //    try
        //    {
        //        int i = 0;
        //        CapturePMData();
        //        String Str = String.Empty;
        //        String Str1 = String.Empty;
        //         //Str = PmData[0] ;
        //        for (i = 0; i <= 12; i++)
        //        {
        //            if (PmData[i] == null)
        //            {
        //                PmData[i] = "0.0";
        //            }
        //            Str = Str + PmData[i] +  "', '";
                   
        //        }
                             
        //        string DTTm = "";
        //        Global.Open_PMConn("Data", "conPM");
        //        OleDbDataAdapter adp1 = new OleDbDataAdapter("Select * from "+ Global.Eng_PMFileNm , Global.conPM );
        //        DataSet ds = new DataSet();
        //        adp1.Fill(ds);
        //        Global.conPM.Close();
        //        if (ds.Tables[0].Rows.Count > 119)
        //        {
        //            Global.Open_PMConn("Data", "conPM");
        //            OleDbCommand cmd = new OleDbCommand("select min(TM)from " + Global.Eng_PMFileNm, Global.conPM);
        //            OleDbDataReader rd = cmd.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                DTTm = rd.GetValue(0).ToString();
        //            }
        //            Global.conPM.Close();

        //            if (DTTm != "")
        //            {
        //                Global.Open_PMConn("Data", "conPM");
        //                OleDbCommand cmd1 = new OleDbCommand("Delete from " + Global.Eng_PMFileNm + " where [TM] = # " + DTTm + " #", Global.conPM);   //("Delete * from " + Global.Eng_PMFileNm, where[TM] = # "+ DTTm+" #" , Global.conData);
        //                cmd1.ExecuteNonQuery();
        //            }                   
        //        }
        //        Global.Open_PMConn("Data", "conPM");
        //        OleDbCommand cmd2 = new OleDbCommand("Insert into " + Global.Eng_PMFileNm + " values('" + Str + PmData[13] + "' )", Global.conPM);
        //        cmd2.ExecuteNonQuery();
        //        Global.conPM.Close();
               
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in frmMain: RecordPMData():  " + ex.Message);
        //    }
        //}
        private void fill_Engine_Details()
        {
            try
            {
                String Str = "";
                Global.CStopTm = DateTime.Now.ToString("hh:mm:ss tt");

                for (int x = 0; x <= 19; x++) EngData[x] = null;
                //string  Str = null;
                EngData[0] = Global.Eng_FileNm;
                EngData[1] = Global.EngType;
                EngData[2] = Global.TestRef;
                EngData[3] = Global.FipNo;
                EngData[4] = Global.EngNo;
                EngData[5] = Global.NCyl;
                EngData[6] = Global.Bor;
                EngData[7] = Global.Strk;
                EngData[8] = Global.Svol;
                
                if (Global.flg_Radiator == true) EngData[9] = "YES"; else EngData[9] = "NO";
                if (Global.flg_Fan == true) EngData[10] = "YES"; else EngData[10] = "NO";
                if (Global.flg_AirCln == true) EngData[11] = "YES"; else EngData[11] = "NO";
                if (Global.flg_Silincer == true) EngData[12] = "YES"; else EngData[12] = "NO";
                // 
                EngData[13] = "EDB- 200";
                EngData[14] = Global.OperatorNm;
                EngData[15] = Global.EnginerNm;
                EngData[16] = Global.T_CellNo;
                EngData[17] = Global.CStrtTm;
                EngData[18] = Global.CStopTm;
                if (Global.ErrorMatrix == null) Global.ErrorMatrix = "*******";
                EngData[19] = Global.ErrorMatrix;
                // 
                Str = "";
                for (int i = 0; i <= 18; i++)
                {
                    if ((EngData[i] == null) || (EngData[i] == ""))
                    {
                        EngData[i] = "****";
                    }
                    Str = Str + EngData[i] + ", ";
                }
                Str = Str + EngData[19] + ",\n";
 
                var filePath = Global.DataPath + "Error_Data\\EngineDetails.csv";
                using (var wr = new StreamWriter(filePath, true))
                {
                    var row = new List<string> { Str.Substring(0, Str.Length - 1) };
                    var sb = new StringBuilder();
                    foreach (string value in row)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");
                        sb.Append(value);
                    }
                    wr.WriteLine(sb.ToString());
                }

                //Global.Open_DataConn("Data", "conData");
                //OleDbCommand cmd2 = new OleDbCommand("Insert into EngDetails values('" + Str + EngData[19] + "' )", Global.conData);
                //cmd2.ExecuteNonQuery();
                //Global.conData.Close();
            }

            catch (Exception ex)
            {
                return;
            }
        }
        public void LogData()
        {
            try
            {
                if (Global.Eng_FileNm == "") Global.Eng_FileNm = "Man";
                int i = 0;
                Global.Capture_Data(Global.flg_SFCStart);
                if (Global.Sn == 0) fill_Engine_Details();
                Global.Sn += 1;

                String strData = null;
                for (i = 0; i <= 124; i++)
                {
                    if (Global.Data[i] == null) Global.Data[i] = "0.0";
                    strData = strData + Global.Data[i] + ", ";
                }
                //strData = strData + Global.Sn + ",\n";
                strData = strData + Global.StrAlarm + ", " + Global.Sn + ",\n";
                var filePath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
                using (var wr = new StreamWriter(filePath, true))
                {
                    var row = new List<string> { strData.Substring(0, strData.Length - 1) };
                    var sb = new StringBuilder();
                    foreach (string value in row)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");
                        sb.Append(value);
                    }
                    wr.WriteLine(sb.ToString());
                }
                ////*****************************

                //Update_ViewData();
                st.Start();
                lblLog.Text = Global.Sn.ToString("000");
                Global.Create_OnLog("Data Logged... ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in LogData() :" + ex.Message);
                Global.flg_SFCStart = false;
            }

        }

       
       
        //private void MakeAVGData()
        //{
        //    try
        //    {
        //        String Str = String.Empty;
        //        int i = 0;
        //        int sn1 = 0;
        //        int sn2 = 0;
        //        Global.Open_Connection("General", "con");
        //        OleDbDataAdapter Adp = new OleDbDataAdapter("SELECT * FROM AvgTemp", Global.con);
        //        DataSet ds = new DataSet();
        //        Adp.Fill(ds);

        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            Str = "SELECT ";
        //            for (i = 0; i < 95; i++)
        //            {
        //                if ((i != 2) && (i != 3) && (i != 4))
        //                {
        //                    if (i == 94)
        //                    {
        //                        Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + ") ";
        //                    }
        //                    else
        //                    {
        //                        Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + "), ";
        //                    }
        //                }
        //            }

        //            Str = Str + "from AvgTemp";
        //            OleDbCommand AVGcmd = new OleDbCommand(Str, Global.con);
        //            AVGcmd.ExecuteNonQuery();
        //            OleDbDataReader Rd = AVGcmd.ExecuteReader();
                                      
        //            i = 0;
        //            while (Rd.Read())
        //            {
        //                for (i = 0; i < 92; i++)
        //                {
        //                  if (i == 3) Global.ArrData[3] = Global.GenData[3];
        //                  if (i == 4) Global.ArrData[4] = Global.GenData[4];
                           
                           
        //                    Global.ArrData[i] = Rd.GetValue(i).ToString();
                           
        //                    if (Global.ArrData[i] == null)
        //                    {
        //                        Global.ArrData[i] = "0.0";
        //                    }
        //                }
        //            }
        //            Global.con.Close();  
        //            Double T = 0;
        //            T = Double.Parse(Global.ArrData[0]);
        //            Global.ArrData[0] = T.ToString("0000");

        //            Global.AvgRpm = int.Parse(Global.ArrData[0]);
        //            Global.AvgTrq = Convert.ToDouble(Global.ArrData[1]);

        //            if (Convert.ToString(Global.AvgRpm) == null) Global.AvgRpm = Global.varRPM;
        //            if (Convert.ToString(Global.AvgTrq) == null) Global.AvgTrq  = Global.varTRQ;
        //            Double P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / (4500 * 9.81));
        //            Global.AvgPowPs = Convert.ToDouble(P.ToString("00.00"));
        //            P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / 60000);
        //            Global.AvgPowkW = Convert.ToDouble(P.ToString("00.00"));
                    
        //            if (Global.AvgPowkW <= 0) Global.AvgPowkW = 0.1;
        //            if (Global.AvgPowPs <= 0) Global.AvgPowPs = 0.1;
                   

        //            for (i = 0; i < 92; i++)
        //            {
        //                if (i == Global.fxd[11]) Global.ArrData[11] = Global.GenData[3].ToString();
        //                else if (i == Global.fxd[12]) Global.ArrData[12] = Global.GenData[4].ToString();
        //                else
        //                {
        //                    Double l = Double.Parse(Global.ArrData[i]);
        //                    if (Global.PMax[i].Substring(1, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("0.000");
        //                    }
        //                    else if (Global.PMax[i].Substring(2, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("00.00");
        //                    }
        //                    else if (Global.PMax[i].Substring(3, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("000.0");

        //                    }
        //                    else
        //                    {
        //                        Global.ArrData[i] = l.ToString("0000");
        //                    }
        //                }
        //            }
        //            //if (Global.flg_SFCStart == true) Calculate_SFC();
        //            int t = 100;
        //            if (Global.flg_SFCStart == true)
        //            {
        //                Global.Data[3] = Global.ArrData[11];
        //                Global.Data[4] = Global.ArrData[12];
        //                Global.Data[t + 1] = Global.SmkVal.ToString();
        //                Global.Data[t + 2] = Global.BlBy.ToString();
        //                Global.Data[t + 3] = Global.ArrData[11].ToString();
        //                Global.Data[t + 4] = Global.ArrData[12].ToString();

        //                if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //                Global.Data[t + 5] = Global.Corfact.ToString("0.00000");
        //                Global.Data[t + 6] = Global.AvgTrq.ToString("00.0");
        //                Global.Data[t + 7] = Global.AvgPowkW.ToString("00.0");
        //                Global.Data[t + 8] = Global.SFCVal.ToString("000.0");
        //                Global.Data[t + 9] = Global.Bi_Val.ToString("00.0");
        //                Global.Data[t + 10] = (Convert.ToDouble(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 11] = (Convert.ToDouble(Global.Data[107]) * Global.Corfact).ToString("00.0"); 
        //                Global.Data[t + 12] = (Convert.ToDouble(Global.Data[108]) / Global.Corfact).ToString("00.0");
        //                Global.Data[t + 13] = (Convert.ToDouble(double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
        //                Global.Data[t + 14] = (Convert.ToDouble((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
        //                Global.Data[t + 15] =  Global.AvgPowPs.ToString("00.0");
        //                Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
        //                Global.Data[t + 17] = ((Global.SFCVal) / 0.735).ToString("000.0");
        //                Global.Data[t + 18] = ((Global.SFCVal) / (0.735 * Global.Corfact)).ToString("000.0");
        //                Global.Data[t + 19] = (Global.varbmep).ToString(); 
        //                Global.Data[t + 20] = "0.0";
        //                Global.Data[t + 21] = "0.0";
                         
        //            }
        //            else 
        //            {
        //                Global.Data[3] = "00.00";
        //                Global.Data[4] = "00.00";
        //                Global.Data[t + 1] = "00.00";
        //                Global.Data[t + 2] = "00.00";
        //                Global.Data[t + 3] = "00.00";
        //                Global.Data[t + 4] = "00.00";
        //                if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //                Global.Data[t + 5] = Global.Corfact.ToString("0.00000");
        //                Global.Data[t + 6] = Global.AvgTrq.ToString("00.0");
        //                Global.Data[t + 7] = Global.AvgPowkW.ToString("00.0");
        //                Global.Data[t + 8] = "00.00";
        //                Global.Data[t + 9] = "00.00";
        //                Global.Data[t + 10] = (Convert.ToDouble(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 11] = (Convert.ToDouble(Global.Data[107]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 12] = "00.00";
        //                Global.Data[t + 13] = "00.00";
        //                Global.Data[t + 14] = "00.00";
        //                Global.Data[t + 15] = Global.AvgPowPs.ToString("00.0");
        //                Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
        //                Global.Data[t + 17] = "00.00";
        //                Global.Data[t + 18] = "00.00";
        //                Global.Data[t + 19] = (Global.varbmep).ToString(); 
        //                Global.Data[t + 20] = "0.0";
        //                Global.Data[t + 21] = "0.0";
                       
        //            }
        //            Global.Data[122] = Global.Prj[5]; // +", " + Global.T_CellNo + ", " + Global.Shift + ", " + Global.EngNo + ", " + Global.FipNo + ", " + Global.EngMd;
        //            Global.Data[123] = Global.StpTm;
        //            Global.Data[124] = Global.cumhours;   //Global.Data[124] = "***"; // Global.T_CellNo + ", " + Global.Shift + ", " + Global.EngNo + ", " + Global.FipNo + ", " + Global.EngMd;
        //                if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
        //                Global.Data[125] = Global.StrAlarm;
                   
        //            Global.Open_Connection("General", "Con");
        //            OleDbCommand cmd = new OleDbCommand("DELETE * FROM AVGTemp", Global.con);
        //            cmd.ExecuteNonQuery();
        //            Global.con.Close ();
        //            for (int k = 0; k < 125; k++)
        //            {
        //                Global.GenData[k] = Global.Data[k];   
        //            }
        //            //if (Global.flg_SFCStart == true) Calculate_SFC();

        //            Sn += 1;
        //            String strData = null;
        //            for (i = 0; i <= 125; i++)
        //            {
        //                if (Global.GenData[i] == null) Global.GenData[i] = "0.0";
        //                strData = strData + Global.GenData[i] + "', '";
        //            }


        //            Global.Open_DataConn("Data", "conData");
        //            OleDbDataAdapter adpFilenm = new OleDbDataAdapter("SELECT * FROM " + Global.Eng_FileNm, Global.conData);
        //            DataSet ds4 = new DataSet();
        //            adpFilenm.Fill(ds4);
                 
        //            if (ds4.Tables[0].Rows.Count != 0)
        //            {
                       
        //                OleDbCommand cmd4 = new OleDbCommand("SELECT MAX(Pn)FROM " + Global.Eng_FileNm, Global.conData);
        //                OleDbDataReader rd4 = cmd4.ExecuteReader();
        //                while (rd4.Read())
        //                {

        //                    sn1 = int.Parse(rd4.GetValue(0).ToString());
        //                }
        //            }
        //            else
        //            {
        //                sn1 = 0;
        //            }
        //            sn2 = sn1 + 1;


        //            cmd = new OleDbCommand();
        //            cmd.CommandText = "INSERT INTO " + Global.Eng_FileNm + " VALUES ('" + strData + Global.Eng_FileNm + "', '" + sn2 + "')";
        //            cmd.Connection = Global.conData;
        //            cmd.ExecuteNonQuery();
        //            txtlog.Text = Sn.ToString();
        //            Global.conData.Close();  
                                  
        //        }
        //        tmrLog.Enabled = true; 
        //            Global.flg_SFCStart = false;
        //    }

        //    catch (Exception ex)
        //    {
        //        //AddListItem("Error in Make avg ", 6);
        //        Global.Create_OnLog("Error in Make avg "+ex.Message );  
        //        return;
        //    }

            //******************************

        //}

        
        private void RdProg()
        {
            try
            {
                //if(Global.DigOut[6] == "1")
                //{
                //    Global.sysIn[4] = "2000";
                //}
                //else
                //{
                //    Global.sysIn[4] = "1000";
                //}
                String A = " (rpm)";
                String B = " (Nm)";
                String C = " (%)";
                
                Global.Open_Connection("Sequence", "conSeq");
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Global.Prj[2] + " ORDER BY StepNo", Global.conSeq);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                Int16 x = 0;
                Int16 y = 0;
                string st = "";
                GridSeq.RowCount = (ds.Tables[0].Rows.Count + 1);

                for (x = 0; x <= (ds.Tables[0].Rows.Count - 1); x++)
                {
                    for (y = 0; y < (ds.Tables[0].Columns.Count); y++)
                    {
                        String T = "0";
                        switch (y)
                        {
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                                T = ds.Tables[0].Rows[x].ItemArray[y].ToString();
                                int TR = ((int.Parse(T.Substring(0, 2)) * 60) + int.Parse(T.Substring(3, 2)));
                                if (TR <= 1) TR = 1;
                                TimeSpan t = TimeSpan.FromSeconds(TR);
                                GridSeq[y, x].Value = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
                                break;
                            case 18:
                                Int16 Ts = Convert.ToInt16(ds.Tables[0].Rows[x].ItemArray[18]);
                                t = TimeSpan.FromSeconds(Ts);

                                GridSeq[y, x].Value = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
                                break;
                            default:
                                GridSeq[y, x].Value = ds.Tables[0].Rows[x].ItemArray[y].ToString();
                                break;
                        }
                    } 
                             
                Global.conSeq.Close();
                Int16 Q = Convert.ToInt16(GridSeq[1, x].Value);
                switch (Q)
                {
                    case 1:
                        GridSeq[2, x].Value = GridSeq[2, x].Value + C;
                        GridSeq[4, x].Value = GridSeq[4, x].Value + C;
                        break;
                    case 2:
                        GridSeq[2, x].Value = GridSeq[2, x].Value + A;
                        GridSeq[4, x].Value = GridSeq[4, x].Value + C;
                        break;
                    case 3:
                        GridSeq[2, x].Value = GridSeq[2, x].Value + C;
                        GridSeq[4, x].Value = GridSeq[4, x].Value + B;
                        break;
                    case 4:
                        GridSeq[2, x].Value = GridSeq[2, x].Value + A;
                        GridSeq[4, x].Value = GridSeq[4, x].Value + B;
                        break;
                    case 5:
                        GridSeq[2, x].Value = GridSeq[2, x].Value + A;
                        GridSeq[4, x].Value = GridSeq[4, x].Value + C;
                        break;
                    case 6:
                        GridSeq[2, x].Value = GridSeq[2, x].Value + A;
                        GridSeq[4, x].Value = GridSeq[4, x].Value + B;
                        break;
                }
                }
                   
                        
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: RdProg():  " + ex.Message);
            }
        }
       
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private static double RandomNumber2(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max- min) + min;
        }

        private void Fun_AnalogOut()
        {
            try
            {
                if (PBar3.Caption == "RAMP TIME:")
                {
                    flg_Ramp = true;                   
                    //clsFun.Mode_Mode();
                    clsFun.MODE_TO_MODE(); //  .Mode_to_Mode();  
                    tmrWrite.Interval = 100;
                }
                else if ((PBar3.Caption == "STEADY TIME:") || (PBar3.Caption == "STABILISATION TIME:"))
                {
                    flg_Ramp = false;
                    switch (int.Parse(Global.C_Mode))
                    {
                        case 1:
                            Global.Mode_Out(1, 0, 0);
                            break;
                        case 2:
                            Global.Mode_Out(0, 1, 0);
                            break;
                        case 3:
                            Global.Mode_Out(1, 1, 0);
                            break;
                        case 4:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 5:
                            Global.Mode_Out(1, 0, 1);
                            break;
                        case 6:
                            Global.Mode_Out(0, 1, 1);
                            break;
                    }
                    Tss7.Text = Global.AnaOut2.ToString("0.000");
                    tmrWrite.Interval = 100;
                    switch (Global.C_Mode)
                    {
                        case "2":
                        case "3":
                        case "4":
                        case "5":
                        case "6":
                            if (Global.sysIn[13] == "TRUE")
                            {
                                int rDiff = (Convert.ToInt32(Convert.ToDouble(Global.SetPtOut1) * (Convert.ToDouble(Global.sysIn[5]) / 10)) - Convert.ToInt32(Global.varRPM));
                                if ((rDiff <= 20) && (rDiff >= 2))
                                {
                                    Global.AnaOut1 = Global.AnaOut1 + 0.02;        //0.0002;
                                }
                                else if ((rDiff >= -20) && (rDiff <= -2))
                                {
                                    Global.AnaOut1 = Global.AnaOut1 - 0.02;         //0.0002
                                }
                            }
                            break;
                        default:
                            Tss6.Text = Global.AnaOut1.ToString("0.000");
                            Tss7.Text = Global.AnaOut2.ToString("0.000");
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString();
                            txtSetpt2.Text = (Global.AnaOut2 * 10).ToString();
                            break;
                    }
                }
                //Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                //Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);               

                switch (int.Parse(Global.C_Mode))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        PBar1.Value = (int)(Global.AnaOut1 * 1000);
                        PBar2.Value = (int)(Global.AnaOut2 * 1000);
                        break;
                    case 5:
                    case 6:
                        PBar1.Value = (int)(Global.AnaOut2 * 1000);
                        PBar2.Value = (int)(Global.AnaOut1 * 1000);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Fun_AnalogOut():  " + ex.Message);
            }
        }
           
       
        private void tmrEnd_Tick(object sender, EventArgs e)
        {
            try
            {              

                flg_AnaOut = false;
                flg_ProgOut = false; 
                if (stopsec <= 0) stopsec = 0; else stopsec -= 1;
                t = TimeSpan.FromSeconds(stopsec);

                answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                txtPStatus.Text = answer;

                settimefor_gridseq();
                PBar1.Value =(int)(Global.AnaOut1*1000);
                PBar2.Value = (int)(Global.AnaOut2*1000);  
               
                PBar3.Maximum = 100;
                PBar3.Value = (int)(stopsec);
                if (PBar3.Value == 0)
                    PBar3.Value = 0; 
                if (int.Parse(Global.C_Mode) <= 4)
                {
                    if ((Global.AnaOut2 > 0.1) && (Global.AnaOut1 >= 0.81))
                    {
                        Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0) Global.Edif1 = 0;
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.800}", Global.AnaOut2);

                    }
                    else
                    {
                        Global.AnaOut1 = 001;
                        Global.AnaOut2 = 001;
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.800}", Global.AnaOut2);
                        Global.Mode_Out(1, 0, 0);
                        ResetOutPut();                       
                        tmrEnd.Enabled = false;
                        EngOK frm = new EngOK();
                        frm.ShowDialog(this);
                        frm.Dispose();
                    }
                }
                else if (int.Parse(Global.C_Mode) >= 5)
                {
                    if ((Global.AnaOut2 > 0.1))
                    {
                        Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0.8) Global.Edif1 = 0;
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    }
                    else
                    {
                        Global.AnaOut1 = 0.8;
                        Global.AnaOut2 = 0.01;
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Global.Mode_Out(1, 0, 0);
                        //Global.Dig_OutBit(0, 7, false);
                        // 
                        tmrEnd.Enabled = false;
                        ResetOutPut();
                        EngOK frm = new EngOK();
                        frm.ShowDialog(this);
                        frm.Dispose(); 
                    }
                }
                Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);                
                Global.flg_EngStart = false;
                Global.Sn = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: tmrEnd_Tick():  " + ex.Message);
            }
        }

        public void Log_InstData()
        {
            try
            {
                int t1 = 0;
                if (Global.Eng_Inst_FileNm == "") Global.Eng_Inst_FileNm = "Inst_Man";
                int i = 0;
                Global.Capture_Data(Global.flg_SFCStart);
                Global.ISn += 1;
                String InstData = null;
                InstData = IData[0] = DateTime.Now.ToString() + ", "; ;

                for (i = 0; i <= 49; i++)    //Global.vIdNo - 3
                {
                    t1 = Global.vId[i];
                    IData[i + 1] = Global.GenData[t1];
                    if (IData[i + 1] == null) IData[i + 1] = "0.0";
                    InstData = InstData + IData[i + 1] + ", ";
                }
                InstData = InstData + Global.ISn + ",\n";
                var filePath = Global.DataPath + "Inst_Data\\" + Global.Eng_Inst_FileNm + ".csv";
                using (var wr = new StreamWriter(filePath, true))
                {
                    var row = new List<string> { InstData.Substring(0, InstData.Length - 1) };
                    var sb = new StringBuilder();
                    foreach (string value in row)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");
                        sb.Append(value);
                    }
                    wr.WriteLine(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Inst_LogData() :" + ex.Message);
            }
        }

        private void tmrLog_Tick(object sender, EventArgs e)
        {
            try
            {
                if (LogCnt > 30)
                {
                    LogCnt = 1;
                   //Log_InstData();
                }
                else
                {
                    LogCnt++;
                }
               //*********************
                if ((flg_Std == true) && (Tstd == 5) && (Global.flg_SFCStart == true))
                {
                    flg_ProgOut = false;
                    Global.Create_OnLog("Cycle Hold for SFC");
                    Tss3.Text = "Cycle Hold For SFC ....."; 
                }
               //***************************
                if (Global.flg_RecorsPmData == true)
                {
                    RecordPMData();
                    //PMText(); 
                }
                if (flg_PerStep == true)
                {
                    if (SockT >= 40)
                    {
                        //if ((Global.flg_SMK415_S == true) && (Auto_SmkRd == true))
                        //{
                        //    Auto_SmkRd = false;
                        //}

                        if (((Tstd == 35) || (Tstd == 34)) && (flg_PerStep == true))
                        {
                            Global.Open_Connection("General", "con");
                            MySqlCommand cmd = new MySqlCommand("DELETE * FROM AvgTemp", Global.con);
                            cmd.ExecuteNonQuery();
                            Global.con.Close();
                            GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                            Tss1.Text = "Averaging Started.....";
                            Tss1.BackColor = Color.Red;
                            Tss1.ForeColor = Color.Yellow;
                            tmrAvg.Start();
                            Global.flg_DataSave = true;
                        }
                        else
                        {
                            //if ((Tstd == 7) && (Global.flg_SMK415_S == true))
                            //{
                            //    Global.smkPort.DiscardInBuffer();
                            //    Global.smkPort.Write("O");
                            //}
                            if (Tstd == 5)
                            {
                                tmrAvg.Stop();
                                st.Stop();
                                long ts = st.ElapsedMilliseconds;
                                s = TimeSpan.FromMilliseconds(ts);
                                Global.StepTime = String.Format("{0:0000}:{1:00}:{2:00}",
                                                                      s.Hours, s.Minutes, s.Seconds);
                                Tss1.Text = "Data Logged.....";
                                Tss1.BackColor = Color.Silver;
                                Tss1.ForeColor = Color.Blue;

                                //if (Global.flg_SMK415_S == true) Global.SmkVal = Double.Parse(Global.smkPort.ReadExisting());
                                MakeAVGData();
                            }
                        }
                    }
                    else
                    {
                        GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                        if ((Tstd == 6) || (Tstd == 5)) //(flg_Std == true) && 
                        {
                            LogData();

                            flg_PerStep = false;

                        }
                    }
                }
                if (flg_Instat == true)
                {

                    GridSeq.Columns[10].HeaderText = "LogData    ( " + DataCnt + " )";

                    if (flg_Std == true)
                    {
                        if (DataCnt <= -1) DataCnt = LogT; else DataCnt -= 1;


                        if (LogT >= 35)
                        {
                            if (((DataCnt == 25) || (DataCnt == 24)) && (flg_Instat == true))
                            {
                                Global.Open_Connection("General", "con");
                                MySqlCommand cmd = new MySqlCommand("DELETE * FROM AvgTemp", Global.con);
                                cmd.ExecuteNonQuery();
                                Global.con.Close();

                                Tss9.Text = "Averaging Started.....";
                                Tss9.BackColor = Color.Red;
                                Tss9.ForeColor = Color.Yellow;
                                tmrAvg.Start();
                                Global.flg_DataSave = true;

                            }
                            else
                            {
                                //if ((DataCnt == 7) && (Global.flg_SMK415_S == true))
                                //{
                                //    Global.smkPort.DiscardInBuffer();
                                //    Global.smkPort.Write("O");
                                //}
                                if (DataCnt == 5)
                                {
                                    st.Stop();
                                    long ts = st.ElapsedMilliseconds;
                                    s = TimeSpan.FromMilliseconds(ts);
                                    Global.StepTime = String.Format("{0:0000}:{1:00}:{2:00}",
                                                                          s.Hours, s.Minutes, s.Seconds);
                                    Tss9.Text = "Data Logged.....";
                                    Tss9.BackColor = Color.Silver;
                                    Tss9.ForeColor = Color.Blue;
                                    //if (Global.flg_SMK415_S == true) Global.SmkVal = Double.Parse(Global.smkPort.ReadExisting());
                                    DataCnt = LogT;
                                    MakeAVGData();

                                }
                            }

                        }
                    }
                }
                else
                {
                    if ((flg_PerStep == true) && (flg_Std == true) && (SockT <= 45))
                    {
                        if (DataCnt == 5)
                        {
                            LogData();
                            GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                        }
                        else
                        {
                            DataCnt -= 1;
                            GridSeq.Columns[10].HeaderText = "LogData    ( " + DataCnt + " )";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:10740  " + ex.Message);
                Global.Create_OnLog("Error TmrLog Data");
                return;
            }
        }

        private void MakeAVGData()
        {
            try
            {
                String Str = String.Empty;
                int i = 0;
                Global.Open_Connection("General", "con");
                MySqlDataAdapter Adp = new MySqlDataAdapter("SELECT * FROM AvgTemp", Global.con);
                DataSet ds = new DataSet();
                Adp.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Str = "SELECT ";
                    for (i = 0; i < 95; i++)
                    {
                        if ((i != 2) && (i != 3) && (i != 4))
                        {
                            if (i == 94)
                            {
                                Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + ") ";
                            }
                            else
                            {
                                Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + "), ";
                            }
                        } //
                    }
                    Str = Str + "from AvgTemp";
                    MySqlCommand AVGcmd = new MySqlCommand(Str, Global.con);
                    AVGcmd.ExecuteNonQuery();
                    MySqlDataReader Rd = AVGcmd.ExecuteReader();
                    i = 0;
                    Double M = 0;
                    while (Rd.Read())
                    {
                        for (i = 0; i < 95; i++)
                        {
                            M = Double.Parse(Rd.GetValue(i).ToString());
                            if ((Global.PUnit[i] == "Nm") || (Global.PUnit[i] == "°C") || (Global.PUnit[i] == "%"))
                                Global.ArrData[i] = M.ToString("000.0");
                            else if ((Global.PUnit[i] == "bar"))
                                Global.ArrData[i] = M.ToString("0.00");
                            else if ((Global.PUnit[i] == "rpm") || (Global.PUnit[i] == "r/min") || (Global.PUnit[i] == "mbar") || (Global.PUnit[i] == "lpm"))
                                Global.ArrData[i] = M.ToString("0000");
                            else
                                Global.ArrData[i] = M.ToString("##0.0##");

                            if (Global.ArrData[i] == null) Global.ArrData[i] = "0.0";

                            if (Global.ArrData[i] == null)
                            {
                                Global.ArrData[i] = "0.0";
                            }
                            if (i == 3) Global.ArrData[3] = Global.GenData[3];
                            if (i == 4) Global.ArrData[4] = Global.GenData[4];
                        }
                    }
                    Global.con.Close();
                    Double T = 0;
                    T = Double.Parse(Global.ArrData[0]);
                    //Global.ArrData[0] = T.ToString("0000");
                    Global.AvgRpm = int.Parse(Global.ArrData[0]);
                    Global.AvgTrq = Double.Parse(Global.ArrData[1]);
                    if (Global.AvgRpm <= 0) Global.AvgRpm = 0.1;
                    if (Global.AvgTrq <= 0) Global.AvgTrq = 0.1;
                    Double P = 0;
                    P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / (4500 * 9.81));
                    Global.AvgPowPs = Double.Parse(P.ToString("00.00"));
                    P = 0;
                    P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / 60000);
                    Global.AvgPowkW = Double.Parse(P.ToString("00.00"));
                    if (Global.AvgPowkW <= 0) Global.AvgPowkW = 0.1;
                    if (Global.AvgPowPs <= 0) Global.AvgPowPs = 0.1;

                    if ((Global.AvgRpm >= 1000) && (Global.AvgTrq >= 10))
                    {
                        //Double SFC = (Convert.ToDouble(Global.ArrData[89]) * 1000 / Global.AvgPowPs);

                        //if (SFC >= 1000)
                        //{
                        //    Global.ArrData[108] = "999";
                        //    Global.SFCVal = 999;
                        //}
                        //else
                        //{
                        //    Global.ArrData[108] = SFC.ToString("000.0");
                        //    Global.SFCVal = SFC;
                        //}
                    }
                    else
                        //Global.SFCVal = 00.0;

                    for (i = 0; i <= 100; i++)
                    {
                        if (Global.ArrData[i] == null)
                        {
                            Global.ArrData[i] = "0.00";
                        }
                        Global.Data[i] = Global.ArrData[i];
                    }
                    int t = 100;
                    Global.Data[t + 1] = Global.SmkVal.ToString();
                    Global.Data[t + 2] = "00.0";  // Global.Blow_by.ToString();
                    Global.Data[t + 3] = Global.SFCwt.ToString("##0.0");
                    Global.Data[t + 4] = Global.SFCTm.ToString("##0.0"); 
                    if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
                    Global.Data[t + 5] = Global.Corfact.ToString("0.000");  //
                    Global.Data[t + 6] = Global.varTRQ.ToString("000.0");
                    Global.Data[t + 7] = Global.VarPowkW.ToString("000.0");
                    Global.Data[t + 8] = (Global.SFCValkW).ToString("000.0");
                    Global.Data[t + 9] = Global.Bi_Val.ToString("00.0");
                    Global.Data[t + 10] = (Global.AvgTrq * Global.Corfact).ToString("00.00");
                    Global.Data[t + 11] = (Double.Parse(Global.Data[107]) * Global.Corfact).ToString("00.0");
                    Global.Data[t + 12] = (Double.Parse(Global.Data[108]) / Global.Corfact).ToString("00.0");

                    Global.Data[t + 13] = (Convert.ToDouble(double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6).ToString("00.00");
                    Global.Data[t + 14] = (Convert.ToDouble((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("00.00");
                    Global.Data[t + 15] = Global.AvgPowPs.ToString("00.0");
                    Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
                    Global.Data[t + 17] = Global.SFCValPs.ToString("000.0");
                    Global.Data[t + 18] = ((Global.SFCValPs) / (Global.Corfact)).ToString("000.0");
                    Global.Data[t + 19] = Global.varbmep.ToString("0.000");
                    Global.Data[t + 20] = Global.Rel_Hum.ToString("00.0");

                    //s = TimeSpan.FromSeconds(S_Tm);
                    //Global.StepTime = string.Format("{0:D2}:{1:D2}:{2:D2}", s.Hours, s.Minutes, s.Seconds);


                    Global.Data[121] = Global.C_bmep.ToString("0.000");
                    Global.Data[122] = System.DateTime.Now.ToString("hh:mm:ss tt");
                    Global.Data[123] = Global.S_StartTime;
                    Global.Data[124] = Global.cumhours;
                    if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
                    Global.Data[125] = "*****";

                    //*****************************
                    if (Global.Eng_FileNm == "") Global.Eng_FileNm = "Man";
                    if (Global.flg_DataSave == true)
                    {
                        i = 0;
                        if (Global.Sn == 0) fill_Engine_Details();
                        Global.Sn += 1;

                        String strData = null;
                        for (i = 0; i <= 124; i++)
                        {
                            if (Global.Data[i] == null) Global.Data[i] = "0.0";
                            strData = strData + Global.Data[i] + ", ";
                        }
                        strData = strData + Global.StrAlarm + ", " + Global.Sn + ",\n";
                        var filePath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
                        using (var wr = new StreamWriter(filePath, true))
                        {
                            var row = new List<string> { strData.Substring(0, strData.Length - 1) };
                            var sb = new StringBuilder();
                            foreach (string value in row)
                            {
                                if (sb.Length > 0)
                                    sb.Append(",");
                                sb.Append(value);
                            }
                            wr.WriteLine(sb.ToString());
                            Global.flg_DataSave = false;
                        }
                    }
                    //***********************
                }
                st.Start();
                tmrLog.Enabled = true;
                Global.flg_SFCStart = false;
               
                //S_Tm = 0;
                lblLog.Text = Global.Sn.ToString("000");
                Global.Create_OnLog("Avg-Data Logged... ");
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in Make avg " + ex.Message);
                return;
            }
            //******************************
        }

        //    try
        //    {

        //        if (Global.flg_RecorsPmData == true) RecordPMData();
        //        if (flg_PerStep == true)
        //        {
        //            if (SockT >= 45)
        //            {
        //                if ((Global.flg_SMK415_S == true) && (Auto_SmkRd == true))
        //                {
        //                    //mnuSmk.PerformClick();
        //                    Auto_SmkRd = false;
        //                }

        //                if ((Tstd == 35) && (flg_PerStep == true))
        //                {

        //                    Global.Open_Connection("General", "con");
        //                    OleDbCommand cmd = new OleDbCommand("DELETE * FROM AvgTemp", Global.con);
        //                    cmd.ExecuteNonQuery();
        //                    Global.con.Close();
                            
                            
        //                    GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
        //                    Tss9.Text = "Averaging Started.....";
        //                    Tss9.BackColor = Color.Red;
        //                    Tss9.ForeColor = Color.Yellow;
        //                    tmrAvg.Start();
        //                }
        //                else
        //                    if (Tstd == 5)
        //                    {
        //                        tmrAvg.Stop();
        //                        Tss9.Text = "Data Logged.....";
        //                        Tss9.BackColor = Color.Silver;
        //                        Tss9.ForeColor = Color.Blue;
        //                        MakeAVGData();
        //                        //Update_ViewData();
        //                    }
        //            }
        //            else
        //            {
        //                GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
        //                if ((flg_Std == true) && (Tstd == 5))
        //                {
        //                    LogData();
        //                    flg_PerStep = false;
        //                }
        //            }
        //        }
        //        if (flg_Instat == true)
        //        {

        //            GridSeq.Columns[10].HeaderText = "LogData    ( " + DataCnt + " )";

        //            if (flg_Std == true)
        //            {
        //                if (DataCnt <= -1) DataCnt = LogT; else DataCnt -= 1;


        //                if (LogT >= 35)
        //                {
                           
        //                    if ((DataCnt == 25) && (flg_Instat == true))
        //                    {
        //                        Global.Open_Connection("General", "con");
        //                        OleDbCommand cmd = new OleDbCommand("DELETE * FROM AvgTemp", Global.con);
        //                        cmd.ExecuteNonQuery();
        //                        Global.con.Close();                                
                                
        //                        Tss9.Text = "Averaging Started.....";
        //                        Tss9.BackColor = Color.Red;
        //                        Tss9.ForeColor = Color.Yellow;
        //                        tmrAvg.Start();
        //                    }
        //                    else if (DataCnt == 5)
        //                    {
        //                        //DataCnt = LogT;
        //                        tmrAvg.Stop();
        //                        Tss9.Text = "Data Logged.....";
        //                        Tss9.BackColor = Color.Silver;
        //                        Tss9.ForeColor = Color.Blue;
        //                        //LogData();
        //                        MakeAVGData();
        //                        //Update_ViewData();
        //                    }


        //                }
        //            }

        //        }
        //        else
        //        {
        //            if ((flg_PerStep == true) && (flg_Std == true) && (SockT <= 45))
        //            {
        //                if (DataCnt == 5)
        //                {
        //                    LogData();
        //                    //DataCnt = SockT;

        //                    GridSeq.Columns[10].HeaderText = "LogData    ( " + LogT + " )";

        //                }
        //                else
        //                {

        //                    DataCnt -= 1;
        //                    GridSeq.Columns[10].HeaderText = "LogData    ( " + DataCnt + " )";
        //                }
        //                //Update_ViewData();

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:10740  " + ex.Message);
        //        AddListItem("Error TmrLog Data", 6);
        //        return;
        //    }
        //}

        
        //private void LogAVGData()
        //{
        //    try
        //    {
        //        int i = 0;
        //        String strData = null;
        //        for (i = 0; i < 99; i++)
        //        {
        //            Global.Data[i] = Global.GenData[i];
        //            if (Global.Data[i] == null) Global.Data[i] = "0.0";
        //            strData = strData + Global.Data[i] + "', '";
        //        }
        //        Global.Open_Connection("General", "con");
        //        OleDbCommand cmd = new OleDbCommand();
        //        cmd.CommandText = "INSERT INTO AvgTemp VALUES ('" + strData + "', '" + Sn + "')";
        //        cmd.Connection = Global.con;
        //        cmd.ExecuteNonQuery();
        //        Global.con.Close();
        //    }
        //    catch
        //    {
        //        Global.Create_OnLog("Error in Log Avg");
        //        return;

        //    }
        //}

        //private void MakeAVGData()
        //{
        //    try
        //    {
        //        String Str = String.Empty;
        //        int i = 0;
        //        int sn1 = 0;
        //        int sn2 = 0;
        //        Global.Open_Connection("General", "con");
        //        OleDbDataAdapter Adp = new OleDbDataAdapter("SELECT * FROM AvgTemp", Global.con);
        //        DataSet ds = new DataSet();
        //        Adp.Fill(ds);

        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            Str = "SELECT ";
        //            for (i = 0; i < 95; i++)
        //            {
        //                if ((i != 2) && (i != 3) && (i != 4))
        //                {
        //                    if (i == 94)
        //                    {
        //                        Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + ") ";
        //                    }
        //                    else
        //                    {
        //                        Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + "), ";
        //                    }
        //                }
        //            }

        //            Str = Str + "from AvgTemp";
        //            OleDbCommand AVGcmd = new OleDbCommand(Str, Global.con);
        //            AVGcmd.ExecuteNonQuery();
        //            OleDbDataReader Rd = AVGcmd.ExecuteReader();

        //            i = 0;
        //            while (Rd.Read())
        //            {
        //                for (i = 0; i < 92; i++)
        //                {
        //                    if (i == 3) Global.ArrData[3] = Global.GenData[3];
        //                    if (i == 4) Global.ArrData[4] = Global.GenData[4];


        //                    Global.ArrData[i] = Rd.GetValue(i).ToString();

        //                    if (Global.ArrData[i] == null)
        //                    {
        //                        Global.ArrData[i] = "0.0";
        //                    }
        //                }
        //            }
        //            Global.con.Close();
        //            Double T = 0;
        //            T = Double.Parse(Global.ArrData[0]);
        //            Global.ArrData[0] = T.ToString("0000");

        //            Global.AvgRpm = int.Parse(Global.ArrData[0]);
        //            Global.AvgTrq = Convert.ToDouble(Global.ArrData[1]);

        //            if (Convert.ToString(Global.AvgRpm) == null) Global.AvgRpm = Global.varRPM;
        //            if (Convert.ToString(Global.AvgTrq) == null) Global.AvgTrq = Global.varTRQ;
        //            Double P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / (4500 * 9.81));
        //            Global.AvgPowPs = Convert.ToDouble(P.ToString("00.00"));
        //            P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / 60000);
        //            Global.AvgPowkW = Convert.ToDouble(P.ToString("00.00"));

        //            if (Global.AvgPowkW <= 0) Global.AvgPowkW = 0.1;
        //            if (Global.AvgPowPs <= 0) Global.AvgPowPs = 0.1;


        //            for (i = 0; i < 92; i++)
        //            {
        //                if (i == Global.fxd[11]) Global.ArrData[11] = Global.GenData[3].ToString();
        //                else if (i == Global.fxd[12]) Global.ArrData[12] = Global.GenData[4].ToString();
        //                else
        //                {
        //                    Double l = Double.Parse(Global.ArrData[i]);
        //                    if (Global.PMax[i].Substring(1, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("0.000");
        //                    }
        //                    else if (Global.PMax[i].Substring(2, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("00.00");
        //                    }
        //                    else if (Global.PMax[i].Substring(3, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("000.0");

        //                    }
        //                    else
        //                    {
        //                        Global.ArrData[i] = l.ToString("0000");
        //                    }
        //                }
        //            }
        //            //if (Global.flg_SFCStart == true) Calculate_SFC();
        //            int t = 100;
        //            if (Global.flg_SFCStart == true)
        //            {
        //                Global.Data[3] = Global.ArrData[3];
        //                Global.Data[4] = Global.ArrData[4];
        //                Global.Data[t + 1] = Global.SmkVal.ToString();
        //                Global.Data[t + 2] = Global.BlBy.ToString();
        //                Global.Data[t + 3] = Global.ArrData[11].ToString();
        //                Global.Data[t + 4] = Global.ArrData[12].ToString();

        //                if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //                Global.Data[t + 5] = Global.Corfact.ToString("0.00000");
        //                Global.Data[t + 6] = Global.AvgTrq.ToString("00.0");
        //                Global.Data[t + 7] = Global.AvgPowkW.ToString("00.0");
        //                Global.Data[t + 8] = Global.SFCValkW.ToString("000.0");
        //                Global.Data[t + 9] = Global.Bi_Val.ToString("00.0");
        //                Global.Data[t + 10] = (Convert.ToDouble(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 11] = (Convert.ToDouble(Global.Data[107]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 12] = (Convert.ToDouble(Global.Data[108]) / Global.Corfact).ToString("00.0");
        //                Global.Data[t + 13] = (Convert.ToDouble(double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
        //                Global.Data[t + 14] = (Convert.ToDouble((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
        //                Global.Data[t + 15] = Global.AvgPowPs.ToString("00.0");
        //                Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
        //                Global.Data[t + 17] = ((Global.SFCValPs) / 0.735).ToString("000.0");
        //                Global.Data[t + 18] = ((Global.SFCValPs) / (0.735 * Global.Corfact)).ToString("000.0");
        //                Global.Data[t + 19] = (Global.varbmep).ToString();
        //                Global.Data[t + 20] = "0.0";
        //                Global.Data[t + 21] = "0.0";

        //            }
        //            else
        //            {
        //                Global.Data[3] = "00.00";
        //                Global.Data[4] = "00.00";
        //                Global.Data[t + 1] = "00.00";
        //                Global.Data[t + 2] = "00.00";
        //                Global.Data[t + 3] = "00.00";
        //                Global.Data[t + 4] = "00.00";
        //                if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //                Global.Data[t + 5] = Global.Corfact.ToString("0.00000");
        //                Global.Data[t + 6] = Global.AvgTrq.ToString("00.0");
        //                Global.Data[t + 7] = Global.AvgPowkW.ToString("00.0");
        //                Global.Data[t + 8] = "00.00";
        //                Global.Data[t + 9] = "00.00";
        //                Global.Data[t + 10] = (Convert.ToDouble(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 11] = (Convert.ToDouble(Global.Data[107]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 12] = "00.00";
        //                Global.Data[t + 13] = "00.00";
        //                Global.Data[t + 14] = "00.00";
        //                Global.Data[t + 15] = Global.AvgPowPs.ToString("00.0");
        //                Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
        //                Global.Data[t + 17] = "00.00";
        //                Global.Data[t + 18] = "00.00";
        //                Global.Data[t + 19] = Global.varbmep.ToString("00.00")  ;
        //                Global.Data[t + 20] = Global.Rel_Hum.ToString("00.0") ;
        //                Global.Data[t + 21] = "0.0";

        //            }
        //            string L = DateTime.Now.ToString("dd/MM/yyyy");
        //            if (Global.OperatorNm == null) Global.OperatorNm = "OpName";
        //            if (Global.TKnNo == null) Global.TKnNo = "TNo";
        //            if (Global.EngMd == null) Global.EngMd = "EngMd";
        //            Global.Data[121] = L + ", " + Global.Shift + ", " + Global.T_CellNo + ", " + Global.OperatorNm + ", " + Global.TKnNo + ", " + Global.EngNo + ", " + Global.EngMd + ", " + Global.FipNo;
        //            Global.Data[122] = "****";  // Global.Prj[5]; // +", " + Global.T_CellNo + ", " + Global.Shift + ", " + Global.EngNo + ", " + Global.FipNo + ", " + Global.EngMd;
        //            Global.Data[123] = Global.StpTm;
        //            Global.Data[124] = Global.cumhours;   //Global.Data[124] = "***"; // Global.T_CellNo + ", " + Global.Shift + ", " + Global.EngNo + ", " + Global.FipNo + ", " + Global.EngMd;
        //            if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
        //            Global.Data[125] = Global.StrAlarm;

        //            Global.Open_Connection("General", "con");
        //            OleDbCommand cmd = new OleDbCommand("DELETE * FROM AvgTemp", Global.con);
        //            cmd.ExecuteNonQuery();
        //            Global.con.Close();
        //            for (int k = 0; k < 125; k++)
        //            {
        //                Global.GenData[k] = Global.Data[k];
        //            }
        //            //if (Global.flg_SFCStart == true) Calculate_SFC();
        //            if (Global.Sn == 0) fill_Engine_Details();
        //            Global.Sn += 1;
        //            String strData = null;
        //            for (i = 0; i <= 125; i++)
        //            {
        //                if (Global.GenData[i] == null) Global.GenData[i] = "0.0";
        //                strData = strData + Global.GenData[i] + "', '";
        //            }


        //            Global.Open_DataConn("Data", "conData");
        //            OleDbDataAdapter adpFilenm = new OleDbDataAdapter("SELECT * FROM " + Global.Eng_FileNm, Global.conData);
        //            DataSet ds4 = new DataSet();
        //            adpFilenm.Fill(ds4);

        //            if (ds4.Tables[0].Rows.Count != 0)
        //            {

        //                OleDbCommand cmd4 = new OleDbCommand("SELECT MAX(Pn)FROM " + Global.Eng_FileNm, Global.conData);
        //                OleDbDataReader rd4 = cmd4.ExecuteReader();
        //                while (rd4.Read())
        //                {

        //                    sn1 = int.Parse(rd4.GetValue(0).ToString());
        //                }
        //            }
        //            else
        //            {
        //                sn1 = 0;
        //            }
        //            sn2 = sn1 + 1;


        //            cmd = new OleDbCommand();
        //            cmd.CommandText = "INSERT INTO " + Global.Eng_FileNm + " VALUES ('" + strData + Global.Eng_FileNm + "', '" + Global.Sn+ "')";
        //            cmd.Connection = Global.conData;
        //            cmd.ExecuteNonQuery();
        //            lblLog.Text = Global.Sn.ToString("000"); 
        //            Global.conData.Close();

        //        }

        //        tmrLog.Enabled = true;
        //        Global.flg_SFCStart = false;
        //        DGView.RowCount = Global.Sn + 2;
        //        DGView.ColumnCount = 16;
        //        DGView.Rows[Global.Sn - 1].Cells[0].Value = Global.Sn;
        //        for (i = 0; i < 15; i++)
        //        {
        //            DGView.Rows[Global.Sn - 1].Cells[i + 1].Value = Global.Data[int.Parse(ViewNo[i])];
        //        }

        //        DGView.Rows[Global.Sn - 1].Selected = true;
        //        if (Global.Sn >= 5)
        //        {
        //            DGView.RowCount += 1;
        //            DGView.FirstDisplayedScrollingRowIndex = (Global.Sn - 4);
        //        }               

        //        //Update_ViewData();
        //    }

        //    catch (Exception ex)
        //    {
        //        //AddListItem("Error in Make avg ", 6);
        //        Global.Create_OnLog("Error in Make avg " + ex.Message);
        //        return;
        //    }
        //}
        ////******************************


        //}

        //private void MakeAVGData()
        //{
        //    try
        //    {
        //        String Str = String.Empty;
        //        int i = 0;

        //        Global.Open_Connection("General", "con");
        //        OleDbDataAdapter Adp = new OleDbDataAdapter("SELECT * FROM AvgTemp", Global.con);
        //        DataSet ds = new DataSet();
        //        Adp.Fill(ds);
        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            Str = "SELECT ";
        //            for (i = 0; i < 95; i++)
        //            {
        //                //if ((i != 2) && (i != 3) && (i != 4))
        //                //{
        //                if (i == 94)
        //                {
        //                    Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + ") ";
        //                }
        //                else
        //                {
        //                    Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + "), ";
        //                }
        //                //}
        //            }
        //            Str = Str + "from AvgTemp";
        //            OleDbCommand AVGcmd = new OleDbCommand(Str, Global.con);
        //            AVGcmd.ExecuteNonQuery();
        //            OleDbDataReader Rd = AVGcmd.ExecuteReader();
        //            i = 0;
        //            Double M = 0;
        //            while (Rd.Read())
        //            {
        //                for (i = 0; i < 95; i++)
        //                {

        //                    M = Double.Parse(Rd.GetValue(i).ToString());
        //                    if ((Global.PUnit[i] == "Nm") || (Global.PUnit[i] == "°C") || (Global.PUnit[i] == "%"))
        //                        Global.ArrData[i] = M.ToString("000.0");
        //                    else if ((Global.PUnit[i] == "bar"))
        //                        Global.ArrData[i] = M.ToString("0.000");
        //                    else if ((Global.PUnit[i] == "rpm") || (Global.PUnit[i] == "mbar") || (Global.PUnit[i] == "lpm"))
        //                        Global.ArrData[i] = M.ToString("000");
        //                    else
        //                        Global.ArrData[i] = M.ToString("##0.0##");

        //                    if (Global.ArrData[i] == null) Global.ArrData[i] = "0.0";


        //                    //Global.ArrData[i] = M.ToString("###0.0##");
        //                    if (Global.ArrData[i] == null)
        //                    {
        //                        Global.ArrData[i] = "0.0";
        //                    }
        //                }
        //            }
        //            Global.con.Close();
        //            Double T = 0;
        //            T = Double.Parse(Global.ArrData[20]);
        //            Global.ArrData[20] = T.ToString("0000");
        //            Global.AvgRpm = int.Parse(Global.ArrData[20]);
        //            Global.AvgTrq = Double.Parse(Global.ArrData[21]);
        //            if (Global.AvgRpm <= 0) Global.AvgRpm = 0.1;
        //            if (Global.AvgTrq <= 0) Global.AvgTrq = 0.1;
        //            Double P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / (4500 * 9.81));
        //            Global.AvgPowPs = Double.Parse(P.ToString("00.00"));
        //            P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / 60000);
        //            Global.AvgPowkW = Double.Parse(P.ToString("00.00"));
        //            if (Global.AvgPowkW <= 0) Global.AvgPowkW = 0.1;
        //            if (Global.AvgPowPs <= 0) Global.AvgPowPs = 0.1;

                   
        //            for (i = 0; i <= 100; i++)
        //            {
        //                if (Global.ArrData[i] == null)
        //                {
        //                    Global.ArrData[i] = "0.00";

        //                }
        //                Global.Data[i] = Global.ArrData[i];
        //            }
        //            int t = 100;


        //            Global.Data[t + 1] = Global.AvgTrq.ToString();
        //            Global.Data[t + 2] = Global.AvgPowkW.ToString();
        //            if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //            Global.Data[t + 3] = Global.Corfact.ToString("0.00000");
        //            Global.Data[t + 4] = (Global.AvgPowkW * Global.Corfact).ToString("00.00");
        //            Global.Data[t + 5] = (Global.AvgTrq * Global.Corfact).ToString("00.00");
        //            Global.Data[t + 6] = ("00.0");
        //            Global.Data[t + 7] = Global.SmkVal.ToString();
        //            Global.Data[t + 8] = (Global.SFCVal).ToString("000.0");
        //            Global.Data[t + 9] = Global.StNo.ToString();
        //            if (Global.StrAlarm == String.Empty) Global.PSName[t] = "*****";
        //            Global.Data[125] = Global.StrAlarm; //(Double.Parse(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //            //Global.Data[t + 11] = (Double.Parse(Global.Data[107]) * Global.Corfact).ToString("00.0");
        //            //Global.Data[t + 12] = (Double.Parse(Global.Data[108]) / Global.Corfact).ToString("00.0");

        //            Global.Data[t + 13] = "00.0"; // (Double.Parse(Double.Parse(Global.Data[103]) / Double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
        //            Global.Data[t + 14] = "00.0"; //(Double.Parse((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
        //            Global.Data[t + 15] = "00.0"; //Global.AvgPowkW.ToString("00.0");
        //            Global.Data[t + 16] = "00.0"; //((Global.AvgPowkW) * (Global.Corfact)).ToString("00.0");
        //            Global.Data[t + 17] = Global.Prj[5];//"00.0"; //Global.SFCValkw.ToString("000.0");
        //            Global.Data[t + 18] = System.DateTime.Now.ToString("hh:mm:ss AMPM");  //Global.CStrtTm;    // "00.0"; //((Global.SFCValkw) /(Global.Corfact)).ToString("000.0");
        //            Global.Data[t + 19] = Global.EngHrs;//(Global.varbmep).ToString();
        //            Global.Data[120] = "000.0";
        //            string m = DateTime.Now.ToString("dd/MM/yyyy");
        //            Global.Data[121] = m + ", " + Global.Shift + ", " + Global.T_CellNo + ", " + Global.OperatorNm + ", " + Global.TKnNo + ", " + Global.EngNo + ", " + Global.EngMd + ", " + Global.FipNo;
        //            Global.Data[122] = Global.Prj[5];
        //            Global.Data[123] = Global.StpTm;
        //            Global.Data[124] = Global.EngHrs;

        //            /* Set Comment */
        //            Global.Open_Connection("General", "con");
        //            //Global.con.Open();
        //            OleDbCommand cmd = new OleDbCommand("DELETE * FROM AVGTemp", Global.con);
        //            cmd.ExecuteNonQuery();
        //            Global.con.Close();
        //            for (int k = 0; k < 125; k++)
        //            {
        //                if (Global.Data[k] == "") Global.Data[k] = "0";
        //                Global.GenData[k] = Global.Data[k];
        //            }
        //            Global.Sn++;
        //            textBox21.Text = Global.Sn.ToString("000");
        //            String strData = null;
        //            String Dts = System.DateTime.Now.ToString("hh:mm:ss AMPM");
        //            if (Global.StrAlarm == "") Global.StrAlarm = "***";
        //            Global.cumhours = Tss2.Text;
        //            if (Global.StrAlarm == "") Global.StrAlarm = "***";
        //            for (i = 20; i <= 116; i++)
        //            {
        //                Global.Data[0] = (i + 1).ToString("000");
        //                if (Global.Data[i] == null) Global.Data[i] = "0.0";
        //                strData = strData + Global.Data[i] + "', '"; //i.ToString("000") + "', '";; //
        //            }
        //            strData = strData + Global.StNo + "', '" + Global.TestTyp + "', '" + Dts + "', '" + Global.cumhours + "', '" + Global.StrAlarm + "', '";  //   CStrtTm
        //            Global.Open_DataConn("Data", "conData");
        //            cmd = new OleDbCommand();
        //            cmd.CommandText = "INSERT INTO " + Global.Eng_FileNm + " VALUES ('" + strData + Global.Eng_FileNm + "', '" + Global.Sn + "')";
        //            cmd.Connection = Global.conData;
        //            cmd.ExecuteNonQuery();
        //            Global.conData.Close();
        //            textBox21.Text = Global.Sn.ToString("000");


        //            //******************
        //            //Log_MESData();
        //            //***********************
        //        }

        //        tmrLog.Enabled = true;
        //        Global.flg_SFCStart = false;
        //        Update_ViewData();
        //    }
        //    catch (Exception ex)
        //    {
        //        //AddListItem("Error in Make avg ", 6);
        //        Global.Create_OnLog("Error in Make avg " + ex.Message);
        //        return;
        //    }
        //    //******************************
        //}



       


        public  void ResetOutPut()
        {
            try
            {
                flg_AnaOut = true;
                Global.C_Mode = "1";
                Global.Mode_Out(1, 0, 0);
                Global.SetPtOut1 = "0";
                Global.SetPtOut2 = "0";
                Global.LastAna1 = 0;
                Global.LastAna2 = 0;
                Global.LastAna3 = 0;
                Global.AnaOut1 = 0.01;
                Global.AnaOut2 = 0.01;
                Global.C_Mode = "1";
                 flg_AnaOut = false;
                 Global.flg_RunStart = false;
                 //btn25.Enabled = true;
                 Btn25.Enabled = false;

                 mnuRunStatus.Enabled = true;
                 BtnIdle.Enabled = false;
                 mnuMan.Enabled = false; 
                 Btn21.Enabled = false;
                 BtnSA.Enabled = false; 

                t = TimeSpan.FromSeconds(0);
                answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                txtPStatus.Text = answer;
                //txtPStatus.Text = "000";
                settimefor_gridseq();
                tmrLog.Enabled = false;
                LogT = 0;
                //checkBox16.Text = "000";
                PBar3.Value = 1;
                //Btn21.Enabled = true;
                Btn22.Enabled = false;              
                Btn24.Enabled = false;
                lblLog.Text = "000"; 
                
                GridSeq.Rows.Clear();
                GridSeq.RowCount = 10; 
                Global.Rd_Confg();                
                Load_Arr();
                Global.Prj[3] = "Lim_STANDBY";               
                Global.Read_LimtStandby();
                Global.SFC_msg = "SFC Status.";
                //if  (Global.flg_smk = true) Global.Init_OPCPort();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: ResetOutPut():  " + ex.Message);
            }
        }
        public void IdelEng()
        {
            try
            {
                Global.flg_SFCStart = false;
                Global.flg_SFCON = false;
                Global.flg_SFCOVER = false;
                Global.flg_SFCReset = false;

                flg_Avg = false;
                flg_Ramp = false;
                flg_Stb = false;
                flg_Std = false;
                Global.Edif1 = (Global.AnaOut1) / (100);
                Global.Edif2 = (Global.AnaOut2) / (100);
                stopsec = 100;
                tmrIdel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: IdelEng():  " + ex.Message);
            }
        }

        public void stopEngine()
        {
            try
            {
                Global.flg_SFCStart = false;
                Global.flg_SFCON = false;
                Global.flg_SFCOVER = false;
                Global.flg_SFCReset = false;
                Global.flg_LimitON = false;
                flg_Avg = false;
                flg_Ramp = false;
                flg_Stb = false;
                flg_Std = false;
                Global.Edif1 = (Global.AnaOut1) / 20;
                Global.Edif2 = (Global.AnaOut2) / 10;
                stopsec = 100;
                
                string h = Tss2.Text.Substring(0, 4);
                string m = Tss2.Text.Substring(5, 2);
                string hm = h + "." + m;
                //Global.Open_Connection("General", "con");
                //OleDbCommand cmd = new OleDbCommand("Update tblProject SET  C_Time = '" + hm + "' where ProjectFile= '" + Global.PrjNm + "'", Global.con);
                //cmd.ExecuteNonQuery();
                //Global.con.Close();
                tmrEnd.Enabled = true;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in StopEng function", ex.Message);
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (flg_ProgOut == true)
                {
                    frmLEfiles frm = new frmLEfiles();
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn1_Click():  " + ex.Message);
            }
        }

       
        //private void tmrReset_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (CntReset >= 5)
        //        {
        //            Global.fl_Rate = 0;
        //            Global.Bi_Val = 0;                   
        //            Global.SFC_msg = "SFC RESET....";
        //            //Global.Read_Vol();
        //            //Global.Dig_OutBit(0, 0, false);
        //            //Global.Dig_OutBit(0, 1, false);
        //            Global.flg_SFCStart = true;
        //            tmrSFC.Enabled = true;
        //            tmrLog.Enabled = false;  
        //            CntReset = 0;
        //            //st.Reset();
        //            Global.Create_OnLog("SFC RESET...");
        //            tmrReset.Enabled = false;
                  

        //        }
        //        else
        //        {
        //            Global.Dig_OutBit(0, 0, true);
        //            Global.Dig_OutBit(0, 1, true);
        //            CntReset = CntReset + 1;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show( ex .Message);
        //    }
        //}


        public void settimefor_gridseq()
        {
            if (PBar3.Caption == "RAMP TIME:")
            {

                GridSeq.Columns[3].HeaderText = " RmT-1 (" + txtPStatus.Text + ")";
                GridSeq.Columns[5].HeaderText = " RmT-2 (" + txtPStatus.Text + ")";
            }
            if (PBar3.Caption == "STABILISATION TIME:")
            {
                GridSeq.Columns[6].HeaderText = " T_Stb (" + txtPStatus.Text + ")";

            }
            if (PBar3.Caption == "STEADY TIME:")
            {
                GridSeq.Columns[7].HeaderText = " T_Std (" + txtPStatus.Text + ")";
            }
        }

        private void tmrIdel_Tick(object sender, EventArgs e)
        {           
            flg_AnaOut = false;
            flg_ProgOut = false;            
            if (stopsec <= 0) stopsec = 0; else  stopsec -= 1; 
            t = TimeSpan.FromSeconds(stopsec);
            answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            txtPStatus.Text = answer;

            //txtPStatus.Text = (seconds / 10).ToString ();
            settimefor_gridseq();
            //d = Convert.ToDouble  (txtPStatus.Text);
            PBar3.Maximum = 100;
            PBar3.Value = (int)(stopsec);
            Double MR = (Global.I_Rpm * 10.0) / Double.Parse(Global.sysIn[5]);

            if (int.Parse(Global.C_Mode) <= 4)
            {
                if ((Global.AnaOut2 > 0) || (Global.AnaOut1 > MR))
                {
                    Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                    Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                    if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                    if (Global.AnaOut1 <= MR) Global.Edif1 = 0;
                    Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    Tss5.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                }
                else
                {
                    Global.AnaOut1 = MR;
                    Global.AnaOut2 = 00.01;
                    Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    Tss5.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);                   
                    t = TimeSpan.FromSeconds(0);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;                  
                    settimefor_gridseq();
                    tmrIdel.Enabled = false;
                }
            }
            else if (int.Parse(Global.C_Mode) >= 5)
            {
                if ((Global.AnaOut2 > 0) || (Global.AnaOut1 > MR))
                {
                    Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                    Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                    if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                    if (Global.AnaOut1 <= MR) Global.Edif1 = 0;
                    Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    Tss5.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                }
                else
                {
                    Global.AnaOut1 = MR;
                    Global.AnaOut2 = 0;
                    Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    Tss5.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    t = TimeSpan.FromSeconds(0);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                    settimefor_gridseq();                   
                    tmrIdel.Enabled = false;
                }
            } 
        }
       
       
        //private void tmrmod_Tick(object sender, EventArgs e)
        //{
        //    if (Global.flg_rdMod == true)
        //    {
        //        Global.Read_ModbusValues();
        //    }
        //    else
        //    {
        //        for (int i = 0; i <= 15; i++)
        //        {
        //            Global.GenData[79 + i] = "00.00";
        //        }
        //    }                

        //}
        //public void Calculate_SFC()
        //{
        //    try
        //    {
        //       int r;               
        //       int N;
        //       Global.SGrv = "0.835";
        //       if (Global.VarPowkW <= 1) Global.VarPowkW = 1;

        //       N = int.Parse(Global.NCyl);
        //       if (N <= 0) N = 4;
        //       r = int.Parse(Global.varRPM.ToString ()); 


        //       //Global.GenData[103] = (Global.Vol * 0.835).ToString();
        //       //Global.GenData[104] = Global.SFCTm.ToString(); 

        //      //Global.GenData[3] = (Global.Vol * 0.835).ToString();
        //      //Global.GenData[4] = Global.SFCTm.ToString(); 

        //       Global.SFCwt = double.Parse(Global.GenData[3].ToString());
        //       Global.SFCTm = double.Parse(Global.GenData[4].ToString());

        //       if (Global.VarPowHp <= 0) Global.VarPowHp = 0.1;
        //        Global.SFCVal = clsFun.Cal_SFC_G(Global.VarPowHp, Global.SFCwt, Global.SFCTm);   
        //        Global.fl_Rate = clsFun.Flow_Rate (Global.SFCwt, Global.SFCTm);  
        //        Global.Bi_Val = clsFun.Fuel_Del(Global.SFCwt, Global.SFCTm,r,N);
        //        Global.GenData[108] = Global.SFCVal.ToString("000.0");                
        //        Global.GenData[113] = (Global.fl_Rate  * 3.6).ToString("00.0");
        //        Global.GenData[114] = ((Global.fl_Rate * 3.6) / double.Parse(Global.SGrv)).ToString("00.0");
        //        Global.GenData[109] = (Global.Bi_Val).ToString("00.00");;
        //        Global.GenData[112] = (Global.SFCVal * Global.Corfact).ToString("000.0");
        //        Global.GenData[115] = ((Global.fl_Rate * 3.6) / double.Parse(Global.SGrv)).ToString("00.0");

        //        //LblFuelVolume.Text = Global.Vol.ToString("000");
        //        //lblSFCTm.Text = Global.SFCTm.ToString("000.00");
        //        //lblFuelFlow.Text = Global.fl_Rate.ToString("00.00");
        //        //lblSmoke.Text = Global.SmkVal.ToString("00.0");
        //        //LogData();

        //    }
        //    catch 
        //    {
        //    }
        //}
        //public void Read_SFC()
        //{
        //    Update_Tss11(1);
        //    try
        //    {
        //      label21.Text = Global.SFC_Msg_from_Inst; 
        //        switch (Global.SFC_Msg_from_Inst)
        //        {
        //            case "*02X44":

        //                if (Global.SFC_msg == "SFC ON")
        //                {
        //                    Global.SFC_msg = "SFC OVER";
        //                    tmrSFC.Enabled = false;
        //                    AddListItem("SFC OVER", 5);
        //                    Global.DelaySc(1);
        //                    //MakeAVGData();
        //                    Calculate_SFC();
        //                    LogData();
        //                    Global.flg_SFCStart = false;
        //                    Update_Tss11(0);
        //                    Global.flg_SFC = false;
        //                }
        //                break;

        //            case "*02X22": //   '"_RESET"
        //                // AddListItem(" SFC RESET ", 2);
        //                Global.SFC_msg = "SFC RESET";
        //                Update_Tss11(1);
        //                Update_Tss11(0);
        //                Global.flg_SFC = true;
        //                break;
        //            case "*02X33": //  '"SFC_ON"
        //                if (Global.SFC_msg != "SFC ON")
        //                {
        //                    AddListItem(" SFC ON ", 3);
        //                    Global.SFC_msg = "SFC ON";
        //                    Global.flg_SFC = true;
        //                    //tmrSFC.Enabled = true;
        //                }                      
                       
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Read_SFC Errer ...." + ex.Message);
        //    }

        //}
     
     
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login ();
            frm.ShowDialog(this);
            frm.Dispose();
        }     
        
        private void eDITORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            //Process pr = new Process(); 
            foreach (Process pr in prs)
            {
                //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                if (pr.ProcessName == "Editors") pr.Kill();
                if (pr.ProcessName == "EXCEL") pr.Kill();
                //if (pr.ProcessName == "DataAppliacation") pr.Kill();
            }
            p.StartInfo = new ProcessStartInfo(Global.PATH + "Editors.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal ;
            p.Start();
        }
        //private void toolStripMenuItem1_Click(object sender, EventArgs e)
        //{
           
        //        Process[] prs = Process.GetProcesses();
        //        foreach (Process pr in prs)
        //        {
        //            if (pr.ProcessName == "ModbusPollCS") pr.Kill();
        //            if (pr.ProcessName == "Editors") pr.Kill();
        //            //if (pr.ProcessName == "DataAppliacation") pr.Kill();
        //        }
            
        //    tmrmod.Enabled = false;
        //    this.Close();
        //}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPATH + "Help.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("file not Found" + helpFilepath);
            }
        }

        //private void mnuSystem_MouseMove(object sender, MouseEventArgs e)
        //{
        //    mnusystem.ForeColor = Color.White;    
        //}

        //private void mnuSystem_MouseLeave(object sender, EventArgs e)
        //{
        //    mnusystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));   
        //}

        private void mnuChannel_MouseMove(object sender, MouseEventArgs e)
        {
            mnuChannel.ForeColor = Color.White;  
        }

        private void mnuChannel_MouseLeave(object sender, EventArgs e)
        {
            mnuChannel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));   
        }

        //private void Btn12_Click(object sender, EventArgs e)
        //{
        //    frmLEfiles frm = new frmLEfiles();
        //    frm.Show();
        //    //frm.Dispose();
        //}

        //private void Btn13_Click(object sender, EventArgs e)
        //{
        //   
        //}


        //private void Btn14_Click(object sender, EventArgs e)
        //{
        //    frmRStatus frm = new frmRStatus();
        //    frm.Show();
        //    //frm.Dispose();

        //}

        public  DateTime Eng_Start_DelaySc(int nSeconds)
        {
            try
            {
                System.DateTime ThisMoment = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, nSeconds, 0);
                System.DateTime AfterWards = ThisMoment.Add(duration);
               
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                    Btn21.Enabled = false;                   
                    if (Global.varRPM >= 550)
                    {
                        return System.DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15016", ex.Message);
            }
            return System.DateTime.Now;
        }

        private void Btn21_Click(object sender, EventArgs e)
        {

            //checkBox14.Text = Global.EngNo;
            //checkBox7.Text = Global.PrjNm;
            try
            {


                if ((Global.EngNo == null) || (Global.PrjNm == null))
                {
                    EngDialog frm = new EngDialog(this);
                    frm.ShowDialog(this);
                    frm.Dispose();
                    return;
                }
                int c = 0;
                Global.StpN = 0;
                Sn = 0;
                Global.Dig_OutBit(1, 8, true);
                BtnSA.Enabled = false;
                Global.flg_Auto = true;
                Btn21.Enabled = false;
                Global.LastAna1 = 0;
                Global.LastAna2 = 0;
                RdProg();
               Global.rd_tblproject();
                Load_ProgStep();
                init_ReadyStatus();
                if (Global.varRPM <= Global.I_Rpm)  
                {
                    Tss1.Text = "Wait For RunningIn signal ......";
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    Btn21.Enabled = false;
                    Btn22.Enabled = false;
                    Btn23.Enabled = false;
                    Btn24.Enabled = false;
                    Btn25.Enabled = false;
                    Btn26.Enabled = false;
                    BtnIdle.Enabled = false;
                    mnuMan.Enabled = false; 


                    Global.Dig_OutBit(0, 7, true);  //Ingnition on
                    Global.DelaySc(1);
                    Global.Dig_OutBit(1, 8, true);  //Eng start Pulse
                    Global.DelaySc(1);
                    Global.Dig_OutBit(1, 8, false);//Eng start Pulse false
                    
                    
                    Tss1.Text = "Satrt the Engine....";
                    Eng_Start_DelaySc(3);


                    if (((Global.varRPM >= Global.I_Rpm)) && (((Global.DigIn[8] == 1) && (Global.DigOut[6] == "1")) || ((Global.DigIn[8] == 0) && (Global.DigOut[6] == "0"))))
                    {
                        Tss2.Text = Global.cumhours;
                        Global.flg_CycleStarted = true;
                        Tss1.Text = "Engine Started ......";
                        Update_Tss1(1);
                        Global.DelaySc(1);
                        Tss1.Text = "Engine Is Running ......";                      
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                        Global.Create_OnLog("Engine Is Running ......");
                        //AddListItem("Engine Is Running ......", 5);
                        Btn25.Enabled = true;
                        mnuRunStatus.Enabled = true;
                        flg_AnaOut = true;
                        flg_ProgOut = true;
                        Make_mdb(Global.DataPath);
                        tmrLog.Enabled = true;
                        Create_FileName(Global.EngNo);

                        Btn21.Enabled = false;
                        Btn22.Enabled = true;
                        Btn23.Enabled = true;
                        Btn24.Enabled = true;
                        Btn25.Enabled = true;
                        Btn26.Enabled = true;
                        BtnIdle.Enabled = true;
                        mnuMan.Enabled = true;                       
                        mnuRunStatus.Enabled = true;
                        Global.flg_EngStart = true;
                        Global.flg_CylStart = true;
                    }
                    else
                    {
                        Tss1.Text = "Wait For Engine Running signal ......";
                    a: DialogResult result1 = MessageBox.Show("Wait For Engine Running signal ......" + c, "Engine Message", MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                        {
                            if (((Global.varRPM >= Global.I_Rpm)) && (((Global.DigIn[8] == 1) && (Global.DigOut[6] == "1")) || ((Global.DigIn[8] == 0) && (Global.DigOut[6] == "0"))))
                            {
                                Create_FileName(Global.EngNo);
                                Tss2.Text = Global.cumhours;
                                Global.flg_CycleStarted = true;
                                Tss1.Text = "Engine Started ......";
                                Tss1.BackColor = Color.Red;
                                Tss1.ForeColor = Color.Yellow;
                                Global.DelaySc(1);                               
                                Tss1.Text = "Engine Is Running ......";
                                //st.Start();
                                Tss1.BackColor = Color.Red;
                                Tss1.ForeColor = Color.Yellow;
                                //AddListItem("Engine Is Running ......", 5);
                                Global.Create_OnLog("Engine Started ..... ");
                                flg_AnaOut = true;
                                flg_ProgOut = true;
                                Make_mdb(Global.DataPath);
                                Create_FileName(Global.EngNo);
                                tmrWrite.Start();
                                tmrLog.Start();
                                Btn21.Enabled = false;
                                Btn22.Enabled = true;
                                Btn23.Enabled = true;
                                Btn24.Enabled = true;
                                Btn25.Enabled = true;
                                Btn26.Enabled = true;
                                BtnIdle.Enabled = true;
                                mnuMan.Enabled = true;
                                mnuRunStatus.Enabled = true;
                                Global.flg_EngStart = true;
                                Global.flg_CylStart = true;
                            }
                            else
                            {
                                c += 1;
                                Global.DelaySc(3);
                                if (c >= 3)
                                {
                                    Btn21.Enabled = true;
                                    Btn22.Enabled = false;
                                    Btn23.Enabled = false;
                                    Btn24.Enabled = false;
                                    Btn25.Enabled = false;
                                    Btn26.Enabled = false;
                                    BtnIdle.Enabled = false;
                                    mnuMan.Enabled = false;
                                  
                                    mnuRunStatus.Enabled = false;
                                    Tss1.Text = "Engine Not Started ......";
                                    Tss1.BackColor = Color.Gainsboro;
                                    MessageBox.Show("Engine Not Started. Try Again ......");
                                    return;

                                    Tss1.Text = "Engine Not Started ......";
                                    Tss1.BackColor = Color.Gainsboro;
                                    MessageBox.Show("Engine Not Started. Try Again ......");
                                    return;
                                }
                                else
                                {
                                    Tss1.Text = "Wait For Engine Start....";
                                    Global.DelaySc(1);
                                    Eng_Start_DelaySc(3);
                                    goto a;

                                }

                            }

                        }
                        else
                        {
                            Btn21.Enabled = true;
                            Btn22.Enabled = false;
                            Btn23.Enabled = false;
                            Btn24.Enabled = false;
                            Btn25.Enabled = false;
                            Btn26.Enabled = false;
                            BtnIdle.Enabled = false;
                            mnuMan.Enabled = false;                          
                            mnuRunStatus.Enabled = false;
                            Tss1.Text = "Engine Not Started ......";
                            Tss1.BackColor = Color.Gainsboro;
                            MessageBox.Show("Engine Not Started. Try Again ......");
                    
                        }
                    }
                }
                else if (((Global.varRPM >= Global.I_Rpm)) && (((Global.DigIn[8] == 1) && (Global.DigOut[6] == "1")) || ((Global.DigIn[8] == 0) && (Global.DigOut[6] == "0"))))
                {    // && (Global.DigIn[6] == 0))
                    Create_FileName(Global.EngNo);
                    Tss2.Text = Global.cumhours;
                    Tss1.Text = "Engine Started ......";
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    Global.flg_CycleStarted = true;
                    Global.DelaySc(1);
                    Tss1.Text = "Engine Is Running ......";
                    //st.Start();
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    //AddListItem("Engine Is Running ......", 5);
                    Global.Create_OnLog("Engine Started ..... ");
                    flg_AnaOut = true;
                    flg_ProgOut = true;
                    Make_mdb(Global.DataPath);
                    tmrWrite.Start();
                    tmrLog.Start();
                    Btn25.Enabled = true;
                    mnuRunStatus.Enabled = true;
                    Create_FileName(Global.EngNo);
                    Btn21.Enabled = false;
                    Btn22.Enabled = true;
                    Btn23.Enabled = true;
                    Btn24.Enabled = true;
                    Btn25.Enabled = true;
                    Btn26.Enabled = true;
                    BtnIdle.Enabled = true;
                    mnuMan.Enabled = true; 
                    mnuRunStatus.Enabled = true;

                    Global.flg_EngStart = true;
                    Global.flg_CylStart = true;
                }
                else if (Global.varRPM < Global.I_Rpm)  // && (Global.DigIn[6] == 0))
                {
                    Btn21.Enabled = true;
                    Btn22.Enabled = false;
                    Btn23.Enabled = false;
                    Btn24.Enabled = false;
                    Btn25.Enabled = false;
                    Btn26.Enabled = false;
                    BtnIdle.Enabled = false;
                    mnuMan.Enabled = false;
                    mnuRunStatus.Enabled = false;
                    Tss1.Text = "Engine Not Started ......";
                    Tss1.BackColor = Color.Gainsboro;
                    MessageBox.Show("Engine is Not ready.");

                }
                Global.CStrtTm = DateTime.Now.ToString("hh:mm:ss tt");
                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn22_Click():  " + ex.Message);

                Global.Create_OnLog("Engine Start Problem");
            }
        }

        private void Btn22_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmrIdel.Enabled == true) tmrIdel.Enabled = false;
                
                Global.Create_OnLog("Engine Stop By Operator .....");
                stopEngine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn23_Click():  " + ex.Message);
            }
        }

        private void Btn23_Click(object sender, EventArgs e)
        {
            LogData();
        }

       

       
       
      
       
        //private void btn26_Click(object sender, EventArgs e)
        //{
        //    if (btn26.Text == "ShowLData")
        //    {
        //        DGView.Visible = true;
        //        DGView.BringToFront();  
        //        btn26.Text = "HideLData";
        //    }
        //    else
        //    {
        //        DGView.Visible = false;
        //        DGView.SendToBack();  
        //        btn26.Text = "ShowLData";
        //    }
        //}

      
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (label22.Location.X + label22.Width <= 0)
        //    {
        //        label22.Left = panel2.Width;
        //    }
        //    else
        //    {
        //        label22.Left -= 10;
        //    }
        //}

        private void mnuClose_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            //Process pr = new Process(); 
            foreach (Process pr in prs)
            {
                //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                if (pr.ProcessName == "Editors") pr.Kill();
                if (pr.ProcessName == "EXCEL") pr.Kill();
            }
            this.Close();


        }

       

        private void mnuLogIn_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog(this);
            frm.Dispose();

        }
        private void mnuLogData_Click(object sender, EventArgs e)
        {
            LogData(); 
        }

       
      
        private void mnuChannel_Click(object sender, EventArgs e)
        {
            frmConf frm = new frmConf();
            frm.ShowDialog(this);
            frm.Dispose();
        }

      
      
       
        private void mnuShowDataFiles_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                if (pr.ProcessName == "DataManagement") pr.Kill();
                if (pr.ProcessName == "EXCEL") pr.Kill();
            }

            ////

            p.StartInfo = new ProcessStartInfo(Global.PATH + "DataManagement.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
           


            //showdata frm = new showdata(); // frmShowData(); 
            //frm.ShowDialog(this);
            //frm.Dispose(); 
        }

      

        private void mnuReset_Click(object sender, EventArgs e)
        {
            ResetOutPut();
            EngDialog frm = new EngDialog(this);
            frm.ShowDialog(this);
            frm.Dispose(); 
        }

      
#region read sfc
        //public void Read_SFC()
        //{
        //    try
        //    {
                
        //        switch (Global.SFC_Msg_from_Inst)
        //        {
        //            case "*02X44":

        //                if (Global.SFC_msg == "SFC ON")
        //                {
        //                    Global.SFC_msg = "SFC OVER";
        //                    tmrSFC.Enabled = false;
        //                   Global.Create_OnLog("SFC OVER");
        //                    Global.DelaySc(1);
        //                    Calculate_SFC();
        //                    LogData();
        //                    Update_Tss1(0);
        //                    Tss1.BackColor = Color.Silver;
        //                    Tss1.ForeColor = Color.Black;  
        //                    Global.flg_SFC = false;
        //                }
        //                break;
        //            case "*02X22": //   '"_RESET"     
                   
        //                Global.SFC_msg = "SFC RESET";
        //                //Update_Tss1(1);
        //                Update_Tss1(0);
        //                Tss1.BackColor = Color.Red;
        //                Tss1.ForeColor = Color.Yellow;  
        //                Global.flg_SFC = true;
        //                break;

        //            case "*02X33": //  '"SFC_ON"
        //                if (Global.SFC_msg != "SFC ON")
        //                {
        //                    Global.Create_OnLog(" SFC ON ");

        //                    Global.SFC_msg = "SFC ON";
        //                    Global.flg_SFC = true;
        //                    Tss1.BackColor = Color.Red;
        //                    Tss1.ForeColor = Color.Yellow;   
        //                }
        //                //Update_Tss1(1);
        //                tmrSFC.Enabled = true;
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message);
        //    }
        //}


        public void Calculate_SFC()
        {
            try
            {                
                int r;               
                int N;

               Global.SGrv = "0.835";
               if(Global.E_Pow <= 1) Global.E_Pow  = 1;
               N = int.Parse(Global.NCyl);
               if (N <= 0) N = 3;
              // r = int.Parse(Global.varRPM.ToString ());
               r = int.Parse(textBox4.Text);

               Global.SFCwt = double.Parse(Global.GenData[3]);

               Global.SFCTm = double.Parse(Global.GenData[4]); 
               
                Global.SFCValkW = clsFun.Cal_SFC_G(Global.VarPowkW, Global.SFCwt, Global.SFCTm);
                Global.SFCValPs = clsFun.Cal_SFC_G(Global.VarPowHp, Global.SFCwt, Global.SFCTm);

                Global.fl_Rate = clsFun.Flow_Rate(Global.SFCwt, Global.SFCTm);
                Global.Bi_Val = clsFun.Fuel_Del(Global.SFCwt, Global.SFCTm,r,N);

                //Double P1 = Convert.ToDouble(Global.GenData[Global.fxd[10]]);
                //Double D1 = Convert.ToDouble(Global.GenData[Global.fxd[8]]);
                //Double W1 = Convert.ToDouble(Global.GenData[Global.fxd[9]]);

                Double P1 = Global.Atp;
                Double D1 = Global.Drb; 
                Double W1 = Global.Web;
                Double S1 = Convert.ToDouble(Global.Svol);


                if (Global.Prj[4] == "IS_1585_NA")
                    Global.Corfact = clsFun.CF_ISO_1585_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_1585_TC")
                    Global.Corfact = clsFun.CF_ISO_1585_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_14599_NA")
                    Global.Corfact = clsFun.IS_14599_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_14599_TC")
                    Global.Corfact = clsFun.IS_14599_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "CF_DIN")
                    Global.Corfact = clsFun.CF_DIN_70020(D1, P1);
                else if (Global.Prj[4] == "CF_IS_10003")
                    Global.Corfact = clsFun.CF_IS_10000CS(Global.Rel_Hum, D1, P1);
                else
                    Global.Corfact = clsFun.CF_DIN_70020(D1, P1);

               
                Global.C_SFCValkW = Global.SFCValkW / Global.Corfact;
                Global.C_SFCValPs  = Global.SFCValPs / Global.Corfact;
               
                Global.GenData[103] = Global.SFCwt.ToString("000");
                Global.GenData[104] = Global.SFCTm.ToString("000.0"); ;
                Global.GenData[105] = Global.Corfact.ToString("0.0000"); ;
                Global.GenData[108] = Global.SFCValkW.ToString("00.0"); ;
                Global.GenData[109] = Global.Bi_Val.ToString("00.0"); ;
                Global.GenData[112] = Global.C_SFCValkW.ToString("00.0"); ;
                Global.GenData[113] = Global.fl_Rate.ToString("00.00"); ;
                Global.GenData[117] = Global.SFCValPs.ToString("00.0"); ;
                Global.GenData[118] = Global.C_SFCValPs.ToString("00.0"); ; 

                //TextBox4.Text = Global.SFCValPs.ToString();
                //TextBox5.Text = Global.fl_Rate.ToString();
                //TextBox6.Text = Global.Bi_Val.ToString();
                Global.SFC_msg = "SFC Status .....";
                flg_ProgOut = true;
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message);
            }
        }





#endregion
        public void Read_Serial_SFC()
        {
            //Update_Tss1(1);
            try
            {
                //label21.Text = Global.SFC_Msg_from_Inst;
                switch (Global.SFC_Msg_from_Inst)
                {
                    case "*02X44":

                        if (Global.SFC_msg == "SFC ON")    // |//| (Global.SFC_msg == "SFC RESET"))       //|| (Global.SFC_msg == "SFC RESET")) //Global.SFC_msg == "SFC ON") ||
                        {
                            tmrSFC.Enabled = false;
                            tmrReset.Enabled = false;
                           
                            Global.SFC_msg = "SFC OVER";
                            Global.Create_OnLog("SFC OVER");
                            Global.R_Add = 0;
                            Global.DelaySc(2);
                           // MakeAVGData();
                            Calculate_SFC();
                            LogData();

                            //Update_ViewData(); 
                            Update_Tss1(0);
                            Global.flg_SFCStart = false;
                            Tss1.BackColor = Color.Gainsboro;
                            Tss1.ForeColor = Color.Black;
                            Tss5.BackColor = Color.Red;
                            Tss1.ForeColor = Color.Black;
                            Global.flg_SFC = false;
                            // 
                        }
                        break;
                    case "*02X22": //   '"_RESET"
                        // Global.Create_OnLog(" SFC RESET ", 2);
                        Global.SFC_msg = "SFC RESET";
                        Update_Tss1(1);
                        Update_Tss1(0);
                        Global.flg_SFC = true;
                        Global.flg_SFCStart = true;  //ok 1
                        Tss1.BackColor = Color.Gainsboro;
                        Tss1.ForeColor = Color.DarkBlue;
                        break;
                    case "*02X33": //  '"SFC_ON"
                        if (Global.SFC_msg != "SFC ON")
                        {
                            //Global.Create_OnLog(" SFC ON ", 3);
                            Global.SFC_msg = "SFC ON";
                            Global.flg_SFC = true;
                            Tss1.BackColor = Color.Red;
                            Tss1.ForeColor = Color.Yellow;
                            tmrSFC.Enabled = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Read_SFC Errer ...." + ex.Message);
            }

        }

      
        private void Tss6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.AnaOut1 >= 9.999) Global.AnaOut1 = 9.999;
               
                    Automation.BDaq.ErrorCode err;
                    dataScaled[0] = Global.AnaOut1;
                    err = Global.InstantAO.Write(0, 1, dataScaled);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Tss5 :" + ex.Message);
            }
        }

        private void Tss7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Global.AnaOut2 >= 9.999) Global.AnaOut2 = 9.999;
               
                    Automation.BDaq.ErrorCode err;
                    dataScaled[1] = Global.AnaOut2;
                    err = Global.InstantAO.Write(0, 2, dataScaled);
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in Tss6 :" + ex.Message);
            }
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
            Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
            Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
            textBox8.Text = Tss2.Text;  
        }  
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetOutPut();
            EngDialog frm = new EngDialog(this);
            frm.ShowDialog(this);
            frm.Dispose(); 
        }

       
       
        private void mnuShowData_Click(object sender, EventArgs e)
        {
            frmRStatus frm = new frmRStatus();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void mnuLimEngFile_Click(object sender, EventArgs e)
        {
            frmLEfiles frm = new frmLEfiles();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void tmrAvg_Tick(object sender, EventArgs e)
        {
            LogAVGData();
        }

        private void LogAVGData()
        {
            try
            {
                int i = 0;
                String strData = null;
                for (i = 0; i < 99; i++)
                {
                    Global.Data[i] = Global.GenData[i];
                    if (Global.Data[i] == null) Global.Data[i] = "0.0";
                    strData = strData + Global.Data[i] + "', '";
                }
                Global.Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO AvgTemp VALUES ('" + strData + "', '" + Sn + "')";
                cmd.Connection = Global.con;
                cmd.ExecuteNonQuery();
                Global.con.Close();
            }
            catch
            {
                Global.Create_OnLog("Error in Log Avg");
                return;
            }
        }

        private void GridSeq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int Lst = Global.StpN;

            if (Btn24.Text == "Cycle_Resume")
            {
                Hold_Cycle(true);
            }
            int Ast = GridSeq.CurrentRow.Index;
            if ((Ast <= -1) || (Ast >= GridSeq.RowCount) || (Ast == Lst))
            {
                MessageBox.Show("Invalid Selection of Step......");
                return;
            }
            else
            {
                if (MessageBox.Show("Do you Want to Select Step No. " + (Ast + 1) + " ...?", "Step Change", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //lblStatus.Text = "RAMP TIME:";
                    PBar3.Caption = "RAMP TIME:";
                    //GridSeq.Enabled = false;
                    Global.LastAna1 = Double.Parse(Global.SetPtOut1);
                    Global.LastAna2 = Double.Parse(Global.SetPtOut2);
                    Global.StpN = Ast;
                    Load_ProgStep();
                    Hold_Cycle(false);
                }
            }
        }

        private void BtnSA_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel6.BringToFront();

            //radioButton1.BringToFront();
            //radioButton2.BringToFront();
            //radioButton3.BringToFront();
            //radioButton4.BringToFront();  

            comboBox2.SelectedIndex = 0; 
            Global.flg_Auto = false;
            Global.main.Make_mdb(Global.DataPath);

            Global.main.Create_FileName(Global.EngNo);
            Global.Sn = 0;
            checkBox13.Text = Global.EngNo;
            checkBox15.Text = Global.Eng_FileNm;
            checkBox8.Text = Global.PrjNm;
            //LoadDgView();
            // 
           
        }

        private void Btn26_Click(object sender, EventArgs e)
        {
            try
            {
                Global.flg_SFC = false;
                Global.SFC_Reset = true;
                Global.Auto_SFC = false;
                tmrReset.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn13_Click():  " + ex.Message);
            }
        }

        private void Btn25_Click(object sender, EventArgs e)
        {
            LogData();
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                panel6.Left = e.X + panel6.Left - MouseDownLocation.X;
                panel6.Top = e.Y + panel6.Top - MouseDownLocation.Y;
            }
        }
        private void valueout()
        {
            double T = 0;
            double D = 0;
            Global.LastRPM = ((Convert.ToDouble(Global.varRPM) * 10)/Convert.ToDouble(Global.sysIn[5]));
            Global.LastTrq = ((Convert.ToDouble(Global.varTRQ) * 10) / Convert.ToDouble(Global.sysIn[4]));  //
            //Global.LastPos = (Convert.ToDouble(Global.GenData[76])/10);

            Global.LastAna1 = double.Parse(Global.SetPtOut1);
            Global.LastAna2 = double.Parse(Global.SetPtOut2);
           


            MSt = comboBox2.Text.Substring(0, 1);
            Global.C_Mode = MSt;
            //*****************           
            switch (Global.C_Mode)
            {
                case "6":
                    checkBox6.Checked = true; 
                    T = Double.Parse(textBox3.Text);
                    Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();                   
                    D = Double.Parse(textBox2.Text);
                    Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.tblpro[4]))).ToString();       //Convert.ToDouble(Global.sysIn[4]            
                    break;
                case "5":
                    checkBox5.Checked = true; 
                    T = Double.Parse(textBox3.Text);                   
                    Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                   
                    D = Double.Parse(textBox2.Text);
                    Double x = (D * (Global.Max_Trq)) / 100;
                    Global.SetPtOut2 = ((x * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();     //Convert.ToDouble(Global.sysIn[4]              
                    break;                   
                case "4":
                    checkBox4.Checked = true; 
                    T = Double.Parse(textBox3.Text);                   
                    Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                    D = Double.Parse(textBox2.Text);
                    Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();      //Convert.ToDouble(Global.sysIn[4]                               
                    break;
                case "3":
                    checkBox3.Checked = true; 
                    T = Double.Parse(textBox3.Text);                   
                    x = (T * (Global.F_Rpm)) / 100;
                    Global.SetPtOut1 = ((x * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();                    
                   
                    D = Double.Parse(textBox2.Text);
                    Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();   //Convert.ToDouble(Global.sysIn[4]                 
                    break;                   
                case "2":
                    checkBox2.Checked = true; 
                    T = double.Parse(textBox3.Text);                   
                    Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                    
                    D = double.Parse(textBox2.Text);                   
                    x = (D * (Global.Max_Trq)) / 100;
                    Global.SetPtOut2 = ((x * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                    break;                    
                default:                    
                    Global.Mode_Out(1, 0, 0);
                    T = double.Parse(textBox3.Text);                   
                    Global.SetPtOut1 = (T / 10).ToString();
                    D = double.Parse(textBox2.Text);                    
                    Global.SetPtOut2 = (D / 10).ToString();
                    break;
            }
            //***********************
            Global.SetRPM = textBox3.Text;
            Global.SetTRQ = textBox2.Text;
           
            //*********************
            RMP1 = int.Parse(textBox6.Text) * 9;
            RMP2 = int.Parse(textBox5.Text) * 9;
            if (RMP1 >= RMP2) RMP = RMP1; else RMP = RMP2;
             Global.LastT = Convert.ToDouble(T);
             Global.LastD = Convert.ToDouble(D);

                    Global.Diff1 = (Double.Parse(Global.SetPtOut1) - (Global.LastAna1)) / RMP1;  
                    Global.Diff2 = (Double.Parse(Global.SetPtOut2) - (Global.LastAna2)) / RMP2;
                  
                    PBar1.Maximum = 10000;
                    PBar2.Maximum = 10000;
                    flg_M_Ramp = true;
                    tmrAnaOut.Start();    
        }         
       
            
            


        private void btnDemand1_Click(object sender, EventArgs e)
        {
            if (M_Demand == 0)
            {
                fill_Engine_Details();
                M_Demand = 1;
            }
            valueout();
            //button2.Enabled = true;
            Double x = Double.Parse(textBox3.Text);
            Double y = Double.Parse(textBox2.Text);

            tmrLog.Start();
            timer1.Start();
          
            Btn21.Enabled = false;
            Btn22.Enabled = true;
            Btn23.Enabled = true;
            Btn24.Enabled = true;
            Btn25.Enabled = true;
            Btn26.Enabled = true;
            BtnIdle.Enabled = true;
            mnuMan.Enabled = true; 
            mnuRunStatus.Enabled = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Double x = Double.Parse(textBox3.Text);
                Double y = Double.Parse(textBox2.Text);
                MSt = comboBox2.Text.Substring(0, 1);

                switch (MSt)
                {
                    case "1":
                        label13.Text = "%";
                        label12.Text = "%";
                        textBox3.Text = x.ToString("00.00");
                        textBox2.Text = y.ToString("00.00");
                        break;
                    case "2":
                        label13.Text = "R";
                        label12.Text = "T%";
                        textBox3.Text = x.ToString("0000");
                        textBox2.Text = y.ToString("00.00");
                        break;
                    case "3":
                        label13.Text = "R%";
                        label12.Text = "T";
                        textBox3.Text = x.ToString("00.00");
                        textBox2.Text = y.ToString("000.0");
                        break;
                    case "4":
                        label13.Text = "R";
                        label12.Text = "T";
                        textBox3.Text = x.ToString("0000");
                        textBox2.Text = y.ToString("000.0");
                        break;
                    case "5":
                        label13.Text = "R";
                        label12.Text = "T%";
                        textBox3.Text = x.ToString("0000");
                        textBox2.Text = y.ToString("00.00");
                        break;
                    case "6":
                        label13.Text = "R";
                        label12.Text = "T";
                        textBox3.Text = x.ToString("0000");
                        textBox2.Text = y.ToString("000.0");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tmrAnaOut_Tick(object sender, EventArgs e)
        {
            if ((Global.DigOut[3] == "1") && (Global.DigOut[4] == "0") && (Global.DigOut[5] == "0")) radioButton1.Checked = true;
            if ((Global.DigOut[3] == "0") && (Global.DigOut[4] == "1") && (Global.DigOut[5] == "0")) radioButton2.Checked = true;
            if ((Global.DigOut[3] == "1") && (Global.DigOut[4] == "1") && (Global.DigOut[5] == "0")) radioButton3.Checked = true;
            if ((Global.DigOut[3] == "0") && (Global.DigOut[4] == "0") && (Global.DigOut[5] == "1")) radioButton4.Checked = true;
            if ((Global.DigOut[3] == "1") && (Global.DigOut[4] == "0") && (Global.DigOut[5] == "1")) radioButton5.Checked = true;
            if ((Global.DigOut[3] == "0") && (Global.DigOut[4] == "1") && (Global.DigOut[5] == "1")) radioButton6.Checked = true;


            if (flg_M_Ramp == true)
            {
                
                if (RMP1 <= 0)
                {
                    RMP1 = 0;
                    label17.Text = "sec";
                }
                else
                {
                    RMP1 -= 1;
                    label17.Text = RMP1.ToString();
                }
                if (RMP2 <= 0)
                {
                    RMP2 = 0;
                    label16.Text = "sec";
                }
                else
                {
                    RMP2 -= 1;
                    label16.Text = RMP2.ToString();
                }
                if (RMP <= 0)
                {
                    RMP = 0;                   
                    Global.L_Mode = Global.C_Mode;
                    flg_M_Ramp = false;
                    Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                    Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                }
                else
                {
                    RMP -= 1;                  
                    clsPID.MODE_TO_MODE();
                }
            }
            else
            {
                flg_M_Ramp = false;

                switch (int.Parse(Global.C_Mode))
                {
                    case 1:
                        Global.Mode_Out(1, 0, 0);
                        break;
                    case 2:
                        Global.Mode_Out(0, 0, 1);
                        break;
                    case 3:
                        Global.Mode_Out(0, 0, 1);
                        break;
                    case 4:
                        Global.Mode_Out(0, 0, 1);                        
                        break;
                    case 5:
                        Global.Mode_Out(0, 1, 1);
                        break;
                    case 6:
                        Global.Mode_Out(0, 1, 1);
                        break;
                }

                switch (Global.C_Mode)
                {
                    case "2":
                    case "4":
                    case "5":
                    case "6":
                        if (Global.RcrOn == "TRUE")
                        {
                            int rDiff = (Convert.ToInt32(Convert.ToDouble(Global.SetPtOut1) * (Convert.ToDouble(Global.sysIn[5]) / 10)) - Convert.ToInt32(Global.varRPM));

                            if ((rDiff <= 80) && (rDiff >= 3))
                            {
                                Global.AnaOut1 = Global.AnaOut1 + 0.0002;
                            }
                            else if ((rDiff >= -80) && (rDiff <= -3))
                            {
                                Global.AnaOut1 = Global.AnaOut1 - 0.0002;
                            }
                        }
                        break;
                }


            }

        }
        private void tmrRead_Tick(object sender, EventArgs e)
        {
            if (Global.RTPort.IsOpen == true) Global.Rd_SerialPort_RT();
            //if (Global.msPort.IsOpen == true) Global.Rd_SerialPort(); 
        }      

       
        private void btmIdle_Click(object sender, EventArgs e)
        {
            tmrIdel.Start(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            textBox3.Text = "0";
            textBox2.Text = "0";
            valueout(); 
        }

      

      

        private void Tss10_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.BringToFront();
            flowLayoutPanel2.SendToBack();           
            Tss10.BackColor = Color.DarkGray;
            Tss11.BackColor = Color.Silver;
          //  Tss12.Text = "1";

        }

        private void Tss11_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.BringToFront();
            flowLayoutPanel1.SendToBack();
            Tss10.BackColor = Color.Silver;
            Tss11.BackColor = Color.DarkGray;
      //      Tss12.Text = "2";
        }

        private void Btn24_Click(object sender, EventArgs e)
        {
            Hold_Cycle(true);
            Auto_Hold = false;
        }

        private void BtnIdle_Click(object sender, EventArgs e)
        {
            tmrIdel.Start();  
        }

        private void mnuGraph_Click(object sender, EventArgs e)
        {
            OnLineGraph frm = new OnLineGraph();
            frm.ShowDialog(this);
            frm.Dispose(); 
        }

        private void mnuShowValues_Click(object sender, EventArgs e)
        {
            frmInOut frm = new frmInOut();
            frm.ShowDialog(this);
        }

        private void mnuSimulate_Click(object sender, EventArgs e)
        {
            frmSimulation frm = new frmSimulation();
            frm.ShowDialog();
            frm.Dispose(); 
        }

        private void mnuSystemPara_Click(object sender, EventArgs e)
        {
            frmSysP frm = new frmSysP();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void mnuChannels_Click(object sender, EventArgs e)
        {
            frmConf frm = new frmConf(); 
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void mnuProject_Click(object sender, EventArgs e)
        {
            frmProject frm = new frmProject();
            frm.ShowDialog(this);
            frm.Dispose();
        }

       
        private void mnuEditor_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "Editors") pr.Kill();
                if (pr.ProcessName == "EXCEL") pr.Kill();
            }
            p.StartInfo = new ProcessStartInfo(Global.PATH + "Editors.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
        }

        private void Meter1_ValueInRangeChanged(object sender, AGaugeApp.AGauge.ValueInRangeChangedEventArgs e)
        {

        }

        private void Tss8_Click(object sender, EventArgs e)
        {

        }

        private void tmrSFC_Tick(object sender, EventArgs e)
        {

        }

        private void tmrReset_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CntReset >= 5)
                {
                    // Global.fl_Rate = 0;
                    //Global.Bi_Val = 0;
                    Cnt = 0;
                    // Global.SFC_msg = "SFC RESET....";
                    //Global.Read_Vol();
                    Global.Dig_OutBit(0, 0, false);
                    Global.Dig_OutBit(0, 1, false);
                    // Global.flg_SFCStart = true;
                    tmrSFC.Enabled = true;
                    CntReset = 0;
                    //st.Reset();
                    Global.Create_OnLog("SFC RESET...");
                    tmrReset.Enabled = false;

                }
                else
                {
                    Global.Dig_OutBit(0, 0, true);
                    Global.Dig_OutBit(0, 1, true);
                    CntReset = CntReset + 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
       
      
       

       

      
      
       
       

       
       
       

       
      

       
       
      

      
       
       
     
       
        
       
   




    }
}
       

       
       

       

       
       
       
       

        

     

       

       
       
           

       

        
       
       

        
       
        

       

       


        

        
         
        
       
       

       
     
   

       

 
        
    

       