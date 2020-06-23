﻿using System;
using System.Data; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Automation.BDaq;
using System.Globalization; 
using System.IO.Ports ;
using System.IO;
using System.Management;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop;



 
namespace Logger     //WindowsFormsApplication1
{
    public class Global
    {
        public static string BarcodeNo;

        public static SerialPort BarcodePort = new SerialPort();
        public static string PATH = Application.StartupPath + "\\";
        public static string HelpPATH = "C:\\Windows\\Help\\DynalecHelp\\";//"C:\\DYNALEC_EDAC\\Logger\\bin\\Debug\\";
        public static string Data_Dir;
        public static string CDate = DateTime.Now.ToString("MMMyy");  
        public static string DataPath; // = "D:\\TestCell_" + T_CellNo + "\\" & Data_Dir & "\\";
        public static  string[] bin0 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] bin1 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };
        public static MySqlConnection con = new MySqlConnection();
        public static MySqlConnection conLim = new MySqlConnection();
        public static MySqlConnection conSeq = new MySqlConnection();
        public static MySqlConnection conData = new MySqlConnection();
        public static MySqlConnection conMES = new MySqlConnection();
        public static MySqlConnection conLog = new MySqlConnection();
        public static MySqlConnection conPM = new MySqlConnection();

        public static int[]LimNo = new int[100];
        public static String[] PNo = new String[130];
        public static String[] PName = new String[130];
        public static String[] PSName = new String[130];
        public static String[] PUnit = new String[130];
        public static String[] PMin = new String[130];
        public static String[] PMax = new String[130];
        public static String[] PMark = new String[130];
        public static String[] GenData = new String[130];
        public static string[] st1 = new string[8];
        public static string[] st2 = new string[8];
        

        public static String[] arr = new String[50];
        public static String CStrtTm;
        public static String CStopTm;

        public static String[] Data = new String[130];
        public static String[] ArrData = new String[130];
        public static String[] PmArr = new String[150];
        public static String[] Arr = new String[5];

        public static SerialPort msPort = new SerialPort();
        public static SerialPort RTPort = new SerialPort();
        public static SerialPort OPCPort = new SerialPort();
        public static SerialPort mbPort = new SerialPort();
        public static SerialPort mssmk = new SerialPort();
        public static SerialPort smkPort = new SerialPort();
        public static int cntlist=0;
        
        public static Automation.BDaq.InstantDoCtrl InstantDO = new InstantDoCtrl();
        public static Automation.BDaq.InstantDiCtrl InstantDI = new InstantDiCtrl();
        public static Automation.BDaq.InstantAoCtrl InstantAO = new InstantAoCtrl();
        public static Automation.BDaq.InstantAiCtrl InstantAI = new InstantAiCtrl();

        public static int smk = 1;
        public static int ISn = 0;
        public static int smkCn = 1;
        public static Double Ex_Bk = 1;

        public static int loopcount=0;
        public static int[] DigIn = new int [20];
        public static string[] DigOut = new string[20];
        public static String[] Prj = new String[20];
        //public static int[] DigOut1 = new int[8];
         
        
        public static String[] sysIn = new String[80];
        public static String[] eng_f = new String[80];
        public static String[] prj_f = new String[80];
        public static String[] tblpro = new String[20];
        public static int[] fxd = new int[60];
        public static int[] Pm_PNo = new int[20];

        public static int[] vId = new int[130];
        public static String[] vIdName = new string[130];
        public static int vIdNo = 0;
      
        public static Boolean flg_EngStart = false ;       
        public static Boolean flg_SFCStart = false;
        public static Boolean flg_Module1 = false;
        public static Boolean flg_Module2 = false;
        public static Boolean flg_Module3 = false;

        public static Boolean flg_SFCSerialStart = false;


        public static Boolean flg_Manual = false;
        public static Boolean flg_Auto = false;
        public static Boolean flg_even_Mode = false;
        public static Boolean flg_CycleStarted = false;

        public static  double  [] m_data = new double[16];
        public static  string[] GetData = new string[16];
        public static String[] L1 = new String[105];
        public static String[] LL1 = new String[105];
        public static String[] H1 = new String[105];
        public static String[] HH1 = new String[105];
        public static String[] Hs = new String[105];
        public static String[] Ls = new String[105];



        public static String[] L2 = new String[105];
        public static String[] LL2 = new String[105];
        public static String[] H2 = new String[105];
        public static String[] HH2 = new String[105];
        public static String[] BufLim = new String[105];
        public static String[] arrLim = new String[105];
                          
        public static String SFC_Msg_from_Inst = "";
        public static String SFC_Status = "";
        public static string modcnt;
        public static Double E_Pow;
       public static  Boolean Flg_AList = true;

       public static int StpN = 0;

        public static Boolean SFC_Reset = false;
        public static Boolean Mx_Trq = false;
        public static Int16 RealRPM;
        public static Int16 varRPM;
        public static double varTRQ;
        public static double varLUB;
        public static double varbmep;
        public static double varWtr;
        public static Int16 T_VarRPM;
        public static Int16 T_VarTRQ;

        public static Double Gear_1 = 1;
        public static Double Gear_2 = 1;
        public static Double Gear_3 = 1;
        public static Double Gear_4 = 1;
        public static Double Gear_5 = 1;
        public static Double TransAxcl = 1;
        public static Double PTO_Ratio = 1;
        public static double Tq_Range;
        



        public static string RBuffer = "0";
        public static string TBuf_old = "0";
        public static string TBuf_New = "0";

        public static String StpTm;  
        public static String EngHrs;
        public static String SFC_msg;
        public static string bufftss4;
        public static string bufftss8;
        public static string wrongbuf;
        public static string HAlarm;
        public static String SED; 

        public static int VolA = 100;
        public static int VolB = 200;
        public static String C_Mnth;
        public static int VolC = 300;
        public static int Vol = 100;
        public static int StNo = 1;
        public static Boolean flg_LogM = false;

      public static   Int16 ADAMCnt = 1;
      public static   Int16 ChnCnt = -1;
      public static  int stopid ;
     public static  Int16 t = 31;
     public static Int16 U = 39;
     public static Int16 V = 47;
     public static Int16 W = 55;
     public static Int16 X = 63;

      public static  String S_Out = "00";
      public static Int16 R_Add = 0;
      public static Int16 I_Add = 0;
      public static String A_Out = "00";
      public static Int16 A_Add = 0;
      public static string EngType="";
      public static string TestTyp = "";
      public static int Sn = 0;
      public static int ErrSn = 0;
      public static int LogTm = 0;
      public static int LTm = 0;

      public static int I_Rpm = 0;
      public static int F_Rpm = 0;
      public static Double Max_Pow = 0;
      public static Double Pow_RPM = 0;
      public static Double Max_Trq = 0;
      public static Double Trq_RPM = 0;



     


        public static string Bor="100";
        public static string NCyl="2";
        public static string Strk="100";
        public static string Svol="1.5";
        public static string SGrv="0.835";
        public static string FuelType="";
        public static String EngNo;
        public static String EngineNo;

        public static String PrjNm;
        public static String EnginerNm;
        public static String Chasis_N;
        public static String OperatorNm;
        public static String TestNo;
        public static String TestRef;
        public static String RedFlgItem;
        public static String JobOrdNo;
        public static String ExOn;
        public static String FanOn;
        public static String ACSOn;
        public static String T_Date;
        public static String I_Tm;
        public static String Shift;
        public static String FipNo;
        public static String EngMd;
        public static String TKnNo;
        public static Double Rel_Hum;

       


        public static String SFCStatus;
        public static Int16  LogCounter;
        public static string  cumhours="0000:00:00";

        public static Boolean flg_prjOn = false;
        public static Boolean Flg_Ready = false;
        public static Boolean flg_LimitON = false; 
         public static Boolean flg_SMK437 = false;
         public static Boolean flg_SMK415 = false;
         public static Boolean flg_SMK415_S = false;
         public static Boolean flg_ManPC = false;
         public static Boolean flg_AutoPC = false;
         public static Boolean Auto_SFC = false;
         public static Boolean flg_Man_Perf = true;
         public static string StepTime;
         public static String S_StartTime;
         public static Boolean flg_Analog = false;
         public static Boolean flg_Digital = false;

         public static Boolean flg_smk = false;
         public static Boolean flg_Radiator = false;
         public static Boolean flg_Fan = false;
         public static Boolean flg_AirCln = false;
         public static Boolean flg_Silincer = false;
         

         public static Boolean flg_SFC = false;
         public static Boolean flg_SFCReset = false;
         public static Boolean flg_SFCON = false;
         public static Boolean flg_SFCOVER = false;
         public static Boolean flg_rdMod = false;
         public static Boolean flg_LoginRPM = false;
         public static Boolean flg_RecorsPmData = false;
         public static Boolean flg_simulateRPM = false;
         public static Boolean flg_Log_service = false;
         public static Boolean flg_Log_supervisor = false;         
         public static int flg_VolActive = 1;
         public static Boolean flg_RunStart = false;
         public static Boolean flg_RLoop = false;

        public static Double Diff1; 
        public static Double Diff2;
        public static Double Diff3;
        public static Double Diff4;
        public static Double MDiff;

        public static Double Edif1;
        public static Double Edif2;

        
 
        public static Double AnaOut1= 0.01;
        public static Double AnaOut2= 0.01;
        public static Double LastAna1= 0;
        public static Double LastAna2= 0;
        public static Double LastAna3 = 0;
        public static Double LastT = 0;
        public static Double LastD = 0;
        public static Double LastRPM = 0;
        public static Double LastTrq = 0;
        public static Double LastPos = 0;
 
        public static String SetPtOut1 = "0";
        public static String SetPtOut2 = "0";
        public static String SetRPM = "0";
        public static String SetTRQ = "0";

        public static String L_SetPtOut1 = "0";
        public static String L_SetPtOut2 = "0"; 
        public static String C_Mode = "1";
        public static String L_Mode = "1";
        public static String G_Mode = "1";

        public static Double L_Error1 = 0;
        public static Double L_Error2 = 0;

        public static string RcrOn = "FALSE";
        public static string TcrOn = "FALSE";
       
        public static String Eng_FileNm;
        public static String Eng_FileNm1;
        public static String Eng_PMFileNm;
        public static String Eng_Error_FileNm;
        public static String Eng_Inst_FileNm;
        public static String Eng_FLog_FileNm;
        public static Boolean flg_CylStart = false;

        public static string T_CellNo;
        public static Double SFCwt;
        public static Double SFCTm;
        public static string SmkVal;
        public static Double BlBy;
        public static int SnEr = 0;
        public static Double S_pt1 = 0;
        public static Double S_pt2 = 0;
        public static Double AvgPowPs;
        public static Double AvgPowkW;
        public static Double AvgRpm;
        public static Double AvgTrq;
        public static Double SFCValkW;
        public static Double SFCValPs;
        public static Double C_SFCValkW;
        public static Double C_SFCValPs;
        public static Double Bi_Val;
        public static Double fl_Rate;
        public static Double Corfact;
        //public static Double VarTrq;
        public static Double VarPowkW;
        public static Double VarPowHp;
        public static Double C_VarPowkW;
        public static Double C_VarPowHp; 
       
        public static String StrAlarm = "Alarm Status...";
        //public static String RunStatus;
        public static String ErrorMatrix;
        public static String MD1, MD2, MD3, MD4, MD5;
        public static Double Drb = 33.0;
        public static Double Web = 27.0;
        public static Double Atp = 1.013;
        public static Double C_bmep;

        public static frmMain main = new frmMain();
        public static Boolean flg_frmManual = false;
        public static Boolean flg_NewFile = false;
        public static Boolean flg_OldFile = false;
        public static Boolean flg_DataSave = false;



        public static string Processor_Id()
        {
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }
            return id;

        }

        public static void ConfigDevice()
        {
            string deviceinfo = sysIn[3];
            int deviceNo = int.Parse(sysIn[3].Substring(13));          
            try
            {
                InstantAO.SelectedDevice = new DeviceInformation(deviceNo, deviceinfo , AccessMode.ModeWrite, 0);                
                InstantAO.Channels[0].ValueRange = ValueRange.V_0To10;
                InstantAO.Channels[1].ValueRange = ValueRange.V_0To10;                
                //***********************
                //InstantDI.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceNo, deviceinfo, AccessMode.ModeRead, 0);

                //InstantDI.SelectedDevice = new DeviceInformation(deviceNo, "PCI-1716,BID#1", AccessMode.ModeWrite, 0);
                
                InstantDI.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceNo);
                
                ///***********************************
                InstantDO.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceNo, deviceinfo, AccessMode.ModeWrite, 0);
                
                ///************************************
                InstantAI.SelectedDevice = new DeviceInformation(deviceNo, deviceinfo, AccessMode.ModeRead, 0);                             
            }
            catch(Exception ex)
            {

                DialogResult result1 =
                MessageBox.Show("ERROR : ..." + "\n\n" +
                                "1.Invalid Device No ........!" + "\n\n" +
                             "OR 2.Decive is Not available....",   "SYSTEM ERROR", MessageBoxButtons.OK);
                if (result1 == DialogResult.OK)
                {
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
        }



        public static void Init_BarcodePort()
        {
            try
            {
                BarcodePort.PortName = "COM6";// sysIn[7];//"COM25";//Global.sysIn[40]; // sysIn[36];
                if (BarcodePort.IsOpen == true) BarcodePort.Dispose(); // .Close();
                BarcodePort.BaudRate = int.Parse("9600");
                BarcodePort.DataBits = int.Parse("8");
                BarcodePort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                BarcodePort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");

                //BarcodePort.Handshake = Handshake.XOnXOff;
                if (BarcodePort.IsOpen == false)
                {
                    BarcodePort.Dispose();
                    BarcodePort.PortName = "COM6"; //sysIn[6]; //sysIn[20];
                    BarcodePort.Open();
                }
            }
            catch
            {
                //MessageBox.Show("Error : " + ex.Message);
                return;
            }
        }
        
       public static  void Init_OPCPort()
        {
            try
            {
             OPCPort.PortName = sysIn[40];
             if (OPCPort.IsOpen == true) OPCPort.Dispose(); // .Close();
             OPCPort.BaudRate = int.Parse("9600");
             OPCPort.DataBits = int.Parse("8");
             OPCPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
             OPCPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");

             if (OPCPort.IsOpen == false)
                {
                    OPCPort.PortName = sysIn[40];
                    OPCPort.Open();
                }
                
            }
            catch 
            {
                MessageBox.Show("THER IS NO COMMUNICATION " + "\n\n" +
                                 " WITH SMOKE METER....... ", "System COM Port ERROR");
                return;
            }
        }
        public static void Init_SrPort()
        {
            try
            {
                msPort.PortName = sysIn[36];
                if (msPort.IsOpen == true) msPort.Dispose(); // .Close();
                msPort.BaudRate = int.Parse("9600");
                msPort.DataBits = int.Parse("8");
                msPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                msPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (msPort.IsOpen == false)
                {
                    msPort.Dispose();
                    msPort.PortName = sysIn[36];
                    msPort.Open();
                }               
            }
            catch
            {
                MessageBox.Show("THER IS NO COMMUNICATION " + "\n\n" +
                                " WITH ADAM instrument....... ", "System COM Port ERROR");
                return;
            }
        }

       
        public static void Init_RTPort()
        {
            try
            {
                RTPort.PortName = sysIn[20];   //"COM3";  //
                if (RTPort.IsOpen == true) RTPort.Dispose(); // .Close();
                RTPort.BaudRate = int.Parse("9600"); 
                RTPort.DataBits = int.Parse("8");
                RTPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                RTPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (RTPort.IsOpen == false)
                {
                    RTPort.Dispose();
                    RTPort.PortName = sysIn[20];  
                    RTPort.Open();
                }
            }
            catch
            {
                MessageBox.Show("THER IS NO COMMUNICATION " + "\n\n" +
                                " WITH INSTRUMENT ....... ", "System COM Port ERROR");
                return;
               // return;
            }
        }
        // ----------- dt - 04/06/2016--------- start Code from here -------------------

        public static void Rd_SerialPort_RT()
        {
            String buffer = "";
            try
            {
                buffer = (RTPort.ReadExisting());
                bufftss8 = buffer;

                char[] chars = buffer.ToCharArray();
                for (int i = 0; i < buffer.Length; i++)
                {
                    int code;
                    code = Convert.ToInt16(chars[i]);
                    if (!(((code <= 57) && (code >= 48)) || (code == 46) || (code == 42) || (code == 88) || (code == 43) || (code == 37) || (code == 45)))
                    {
                        buffer = buffer + chars[i];
                        //return;
                    }
                }
                if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) != "XXXXX"))
                {
                    Int16 pos;
                    pos = Convert.ToInt16(buffer.IndexOf("X", 1)); //InStr(1, Buffer, "X")
                    int L = int.Parse(buffer.Substring(pos - 2, 2));
                    //int L = I_Add; 
                    if (L == 2)
                    {
                        pos = Convert.ToInt16(buffer.IndexOf("*", 1));
                        SFC_Msg_from_Inst = buffer.Substring(0, 6);
                        GenData[2] = SFC_Msg_from_Inst;

                    }
                    else if (L == 0)
                    {
                        double M = Convert.ToDouble(buffer.Substring(5, 5));
                        Global.varRPM = (Int16)M;
                        GenData[0] = varRPM.ToString("0000");
                    }
                    else if (L == 1)
                    {
                        Double N = Convert.ToDouble(buffer.Substring(5, 5)); 
                        ///10;
                        //if (N > 9999)
                        //{
                        //    GenData[1] = N.ToString("0000.0");
                        //}
                        //else
                        //{
                        //    GenData[1] = (N / 10).ToString("0000.0");
                        //}
                        GenData[1] = N.ToString("0000");
                        varTRQ = N;

                    }
                    else
                    {
                        if (buffer.Substring(4, 1) == "+")
                        {
                            S_Out = (buffer.Substring(1, 2));
                            Global.GenData[int.Parse(S_Out)] = buffer.Substring(5, 5);
                        }
                        else
                        {
                            S_Out = (buffer.Substring(1, 2));
                            Global.GenData[int.Parse(S_Out)] = buffer.Substring(4, 6);
                        }
                    }

                    S_Out = (buffer.Substring(1, 2));
                    bufftss8 = buffer;

                }
                else if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) == "XXXXX"))
                {
                    S_Out = (buffer.Substring(1, 2));
                    Global.GenData[int.Parse(S_Out)] = "88888";
                }
                if (R_Add >= 13) R_Add = 0; else R_Add += 1; // R_Add = 19
                RTPort.DiscardInBuffer();
                switch (R_Add)
                {
                    case 0:
                        RTPort.Write("*00T%");
                        break;
                    case 1:
                        RTPort.Write("*01T%");
                        break;
                    case 2:
                        if ((Global.SFC_Reset == true) && (SFC_Msg_from_Inst == "*02X11"))
                        {
                            RTPort.Write("*02R%");
                            Global.flg_SFCReset = false;
                            SFC_Status = "SFC RESET";
                            SFC_msg = "SFC RESET";
                            Global.flg_SFCStart = true;
                            Global.SFC_Reset = false;
                            Global.flg_SFCSerialStart = true;
                        }
                        else
                        {
                            RTPort.Write("*02T%");
                        }
                        break;
                    case 3:
                        RTPort.Write("*03T%");
                        break;
                    case 4:
                        RTPort.Write("*04T%");
                        break;
                    case 5:
                        RTPort.Write("*05T%");
                        break;
                    case 6:
                        RTPort.Write("*06T%");
                        break;
                    case 7:
                        RTPort.Write("*07T%");
                        break;
                    case 8:
                        RTPort.Write("*08T%");
                        break;
                    case 9:
                        RTPort.Write("*09T%");
                        break;
                    case 10:
                        RTPort.Write("*10T%");
                        break;
                    case 11:
                        RTPort.Write("*11T%");
                        break;
                    case 12:
                        RTPort.Write("*12T%");
                        break;
                    //case 13:
                    //    RTPort.Write("*13T%");
                    //    break;
                    //case 14:
                    //    RTPort.Write("*14T%");
                    //    break;
                    //case 15:
                    //    RTPort.Write("*15T%");
                    //    break;
                    //case 16:
                    //    RTPort.Write("*16T%");
                    //    break;
                    //case 17:
                    //    RTPort.Write("*17T%");
                    //    break;
                    //case 18:
                    //    RTPort.Write("*18T%");
                    //    break;
                }
            }
            catch
            {               
                return;                
            }

        }


      

        public static void Rd_SerialPort()
        {
            String buffer = "";
            try
            {
               
                buffer = (msPort.ReadExisting());
                bufftss4 = buffer;

                char[] chars = buffer.ToCharArray();
                for (int i = 0; i < buffer.Length; i++)
                {
                    int code;
                    code = Convert.ToInt16(chars[i]);
                    if (!(((code <= 57) && (code >= 48)) || (code == 46) || (code == 42) || (code == 88) || (code == 43) || (code == 37) || (code == 45)))
                    {
                        buffer = buffer + chars[i];
                        //return;
                    }
                }



                //if ((buffer.Substring(3, 1) == "X") && (buffer.Substring(10, 1) == "%"))
                //{
                //    bufftss4 = buffer;
                //    //char[] chars = buffer.ToCharArray();
                //    for (int i = 0; i <= 15; i++) // buffer.Length; i++)
                //    //for (int i = 0; i <= buffer.Length; i++) 
                //    {
                //        int code;
                //        code = Convert.ToInt16(chars[i]);
                //        //if (code == 
                //        if (!(((code <= 57) && (code >= 47)) || (code == 46) || (code == 42) || (code == 88) || (code == 43) || (code == 37) || (code == 45)))
                //        {
                //            buffer = buffer + chars[i];
                //            return;
                //        }
                //    }
                //}
                if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) != "XXXXX"))
                {
                    Int16 pos;
                    pos = Convert.ToInt16(buffer.IndexOf("X", 1));
                    int L = int.Parse(buffer.Substring(pos - 2, 2));

                    if (buffer.Substring(4, 1) == "+")
                    {
                        S_Out = (buffer.Substring(1, 2));
                        Global.GenData[int.Parse(S_Out)] = buffer.Substring(5, 5);
                    }
                    else
                    {
                        S_Out = (buffer.Substring(1, 2));
                        Global.GenData[int.Parse(S_Out)] = buffer.Substring(4, 6);
                    }
                }
                else if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) == "XXXXX") && (buffer.Substring(1, 1) == "*"))
                {
                    S_Out = (buffer.Substring(1, 2));
                    Global.GenData[int.Parse(S_Out)] = "88888";
                }




                msPort.Close();
                //msPort.DiscardInBuffer();
                if (!Global.msPort.IsOpen == true) Global.msPort.Open();

                if (I_Add >= 6) I_Add = 0; else I_Add += 1;
                switch (I_Add)
                {

                    case 0:
                        msPort.Write("*21T%");
                        break;
                    case 1:
                        msPort.Write("*22T%");
                        break;
                    case 2:
                        msPort.Write("*23T%");
                        break;
                    case 3:
                        msPort.Write("*24T%");
                        break;
                    case 4:
                        msPort.Write("*25T%");
                        break;
                    case 5:
                        msPort.Write("*26T%");
                        break;
                    //case 6:
                    //    msPort.Write("*16T%");
                    //    break;
                    //case 7:
                    //    msPort.Write("*17T%");
                    //    break;
                    //case 8:
                    //    msPort.Write("*18T%");
                    //    break;
                    //case 9:
                    //    //msPort.Write("*19T%");
                    //    //break;
                    //case 10:
                    //    msPort.Write("*20T%");
                    //    break;
                    //case 11:
                    //    msPort.Write("*21T%");
                    //    break;
                    //case 12:
                    //    msPort.Write("*22T%");
                    //    break;
                    //case 13:
                    //    msPort.Write("*23T%");
                    //    break;
                    //case 14:
                    //    msPort.Write("*24T%");
                    //    break;
                }
            }
            catch (Exception ex)
            {

                //msPort.Write("*00T%");
                //if (I_Add >= 21) I_Add = 0; else I_Add += 1;
                //I_Add += 1;
                return;
                //MessageBox.Show("read serial Port String Not proper: " + I_Add + ":-" + buffer);
            }

        }


 
      public static  void ReadAnalog()
        {
            try
            {
                Automation.BDaq.ErrorCode err;
                Global.Read_DigIn();
                //InstantAI.SelectedDevice = new DeviceInformation(0, "PCI-1716,BID#0", AccessMode.ModeRead, 0);

                for (int j = 0; j <= 8; j++)
                {
                    if (DigIn[j] == 1)
                    {
                        DigIn[j] = 1;
                    }
                    else
                    {
                        DigIn[j] = 0;
                    }
                }

               int D;
                for (int i = 0; i < 7; i++)
                {

                    D = 71 + i;
                    err = InstantAI.Read(0, 8, m_data);
                    Double Mn = Double.Parse(PMin[D]);
                    Double Mx = Double.Parse(PMax[D]);
                    Double Range = (Mx - Mn);
                    Double l = m_data[i] * Range / 10;
                    GenData[D] = l.ToString("000.00");                   
                }

                for (int Chnl = 0; Chnl < 99; Chnl++)
                {
                    if ((PSName[Chnl] == "Not_Prog") || (GenData[Chnl] == null))
                    {

                        GenData[Chnl] = "000";
                    }
                    else
                    {

                        GenData[Chnl] = GenData[Chnl];
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Code:- 15003", ex.Message);
            }
           
        }

      public static void Create_OnLog(string Msg)
      {
          try
          {
              if (Global.flg_CylStart == true)
              {
                  SnEr++;
                  Global.I_Tm = System.DateTime.Now.ToString("hh:mm:ss tt");
                  String strData = Global.EngNo + ", " + Global.StNo + ", " + Global.varRPM + ", " + Msg + ", " + Global.I_Tm + ", " + Global.SnEr + ",\n";

                  var filePath = Global.DataPath + "Error_Data\\" + Global.Eng_Error_FileNm + ".csv";
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
              }
          }

          catch (Exception ex)
          {
              MessageBox.Show("Error Code:- 15007", ex.Message);
          }

      }

        
        public static void Open_Connection(String db, String conNm)
        {
            try
            {
               // OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Global.PATH + db + ".accdb;Jet OLEDB:DATABASE Password = gen.edac");
                MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
                conn.Open();

                if (conNm == "con")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                        con = conn;
                    }
                }
                if (conNm == "conLim")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conLim.Close();
                        conLim = conn;
                    }
                }
                if (conNm == "conSeq")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conSeq.Close();
                        conSeq = conn;
                    }
                }
                if (conNm == "conMES")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conMES.Close();
                        conMES = conn;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15008", ex.Message);
            }

        }
        public static void Read_DigIn()
        {
            try
            {

                Automation.BDaq.ErrorCode err;
                //InstantDI.SelectedDevice = new Automation.BDaq.DeviceInformation(1, "PCI-1716,BID#1", AccessMode.ModeWrite, 0);
                //txtDi.Text = "";
                byte dIportData = 0;
                err = InstantDI.Read(1, out dIportData);
                string dIbinaryval = "";
                dIbinaryval = Convert.ToString(Convert.ToInt32(dIportData.ToString("X2"), 16), 2);
                long Sr1 = Convert.ToUInt32(dIbinaryval);
                String S1 = Sr1.ToString("00000000");

                dIbinaryval = "";
                err = InstantDI.Read(0, out dIportData);
                dIbinaryval = Convert.ToString(Convert.ToInt32(dIportData.ToString("X2"), 16), 2);
                long Sr2 = Convert.ToUInt32(dIbinaryval);
                String S2 = Sr2.ToString("00000000");
                String S = S1 + S2;

                for (int i = 0; i <= S.Length - 1; i++)
                {
                    DigIn[i] = int.Parse(S.Substring((S.Length - i) - 1, 1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15009" +ex.Message );
                return;
            }
        }

        public static void Dig_OutBit(int port, int Bt, Boolean State)
        {
            
               //InstantDO.SelectedDevice = new Automation.BDaq.DeviceInformation(1, "PCI-1716,BID#0", AccessMode.ModeWrite, 0);

            try
            {
                Automation.BDaq.ErrorCode err;
                string str = "";
                port = 0;
                if (Bt >= 8)
                {
                    port = 1;
                    Bt = Bt - 8;
                }
                else
                {
                    port = 0;
                    Bt = Bt - 0;
                }
                if (port == 0)
                {
                    if (State == true) bin0[Bt] = "1"; else bin0[Bt] = "0";
                    for (int i = 7; i >= 0; i--)
                    {
                        str = str + bin0[i];
                        DigOut[i] = bin0[i]; 
                    }                    
                    string output = "";

                    for (int i = 0; i <= str.Length - 4; i += 4)
                    {
                        output += string.Format("{0:X}", Convert.ToByte(str.Substring(i, 4), 2));
                    }
                    int state = Int32.Parse(output, NumberStyles.AllowHexSpecifier); //dec.ToString ();

                    err = InstantDO.Write(port, (byte)state);
                }
                else if (port == 1)
                {

                    if (State == true) bin1[Bt] = "1"; else bin1[Bt] = "0";
                    for (int i = 7; i >= 0; i--)
                    {
                        str = str + bin1[i];
                        DigOut[i + 8] = bin1[i]; 
                    }
                   
                    string output = "";

                    for (int i = 0; i <= str.Length - 4; i += 4)
                    {
                        output += string.Format("{0:X}", Convert.ToByte(str.Substring(i, 4), 2));
                    }
                    int state = Int32.Parse(output, NumberStyles.AllowHexSpecifier); //dec.ToString ();

                    err = InstantDO.Write(port, (byte)state);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15010", ex.Message); 
            }

        }
        public  static void Mode_Out(int DOutA, int DOutB, int DOutC)
        {
            if (DOutA == 1) Dig_OutBit(0, 3, true); else Dig_OutBit(0, 3, false);
            if (DOutB == 1) Dig_OutBit(0, 4, true); else Dig_OutBit(0, 4, false);
            if (DOutC == 1) Dig_OutBit(0, 5, true); else Dig_OutBit(0, 5, false);
        }

        public static void Open_DataConn(String db, String cNm)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
                // OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Global.DataPath + db + ".accdb;Jet OLEDB:DATABASE Password = gen.edac");
                //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source=" + Global.DataPath + db + ".accdb");
                cn.Open();

                if (cNm == "conData")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conData.Close();
                        conData = cn;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15011", ex.Message);  
            }

        }

        public static void Open_LogConn(String db, String cNm)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
                //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source= D:\\TestCell_" + T_CellNo + "\\" + db + "\\" + "Log.accdb;Jet OLEDB:DATABASE Password = gen.edac");
                //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source= D:\\TestCell_" + T_CellNo + "\\" + db + "\\" + "Log.accdb");
                cn.Open();

                if (cNm == "conLog")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conLog.Close();
                        conLog = cn;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-15012", ex.Message);    
            }
        }

        public static void Create_Tb_EngDetails()
        {
            try
            {
                int i = 0;
                String StrTb = null;

                for (i = 1; i <= 19; i++)
                    StrTb = StrTb + "Ch" + i.ToString() + ", ";

                StrTb = StrTb + "Ch20";
                if (System.IO.File.Exists(Global.DataPath + "Error_Data\\EngineDetails.csv") == false)
                {
                    string Dpath = Global.DataPath + "Error_Data\\EngineDetails.csv";
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


        /// <summary>
        /// ///////////////////////////////////////////////////sayali
        /// 
        /// 
         public static void  Create_perf()
         {
            Global.C_Mnth = DateTime.Now.ToString("MMMyy");// DateTime.Now.Month.ToString(); 
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "EXCEL") pr.Kill();
            }
            try
            {
            String[] Perfno = new String[50];
            String[] Perfhead = new String[50];
            String[] Perfunit = new String[50];
            object misValue = System.Reflection.Missing.Value;
            int i, k;
            int j, rx;
            xlApp = new Excel.Application();

            xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Performance.xltx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("FTB");
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Perf");

            xlWorkSheet.get_Range("B16", "AG30").ClearContents();

            Open_Connection("General", "con");
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM tblEngine WHERE EngineFile = '" + Eng_FileNm1 + "'", con);
            MySqlDataReader Rd1 = cmd1.ExecuteReader();
            Int16 x = 0;
            while (Rd1.Read())
            {
                for (x = 0; x <= (Rd1.FieldCount - 1); x++)
                {
                    eng_f[x] = Rd1.GetValue(x).ToString();
                }
            }
            Open_Connection("General", "con");
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM tblProject WHERE ProjectFile = '" + Global.PrjNm + "'", con);
            MySqlDataReader Rd2 = cmd2.ExecuteReader();
            Int16 y = 0;
            while (Rd2.Read())
            {
                for (y = 0; y <= (Rd2.FieldCount - 1); y++)
                {
                    prj_f[y] = Rd2.GetValue(y).ToString();
                }
            }

            String Eng_FNm = Eng_FileNm;
           // xlWorkSheet.Cells[9, 23] =      //Global.sysIn[10].ToString();//
            xlWorkSheet.Cells[10, 20] = Global.I_Rpm;//
            xlWorkSheet.Cells[5, 5] = Global.EngNo;//
            xlWorkSheet.Cells[10, 19] = Global.F_Rpm;//
            xlWorkSheet.Cells[4, 5] = Global.EngMd;//
            xlWorkSheet.Cells[6, 5] = Global.Chasis_N;
            xlWorkSheet.Cells[8, 5] = Global.flg_Fan;
            xlWorkSheet.Cells[9, 5] = Global.flg_Radiator;
            xlWorkSheet.Cells[12, 14] = Global.flg_Silincer;
           // xlWorkSheet.Cells[12, 14] = ;

           xlWorkSheet.Cells[8, 14] = eng_f[3];
           xlWorkSheet.Cells[6, 25] = eng_f[12];//coolent
           xlWorkSheet.Cells[7, 25] = eng_f[9];//oil
           xlWorkSheet.Cells[9, 14] = prj_f[7];
           xlWorkSheet.Cells[10, 14] = prj_f[12];
           xlWorkSheet.Cells[9, 23] = prj_f[14];//pto ratio
           xlWorkSheet.Cells[11, 19] = prj_f[11];//idl
           xlWorkSheet.Cells[12, 19] = flg_AirCln;
           xlWorkSheet.Cells[4, 25] = EnginerNm;
           xlWorkSheet.Cells[4, 30] = DateTime.Now.ToString("dd_MM_yyyy");
                xlWorkSheet.Cells[5, 15] = FipNo;
           xlWorkSheet.Cells[11, 23] = Global.T_CellNo;
                    Global.Open_Connection("General", "con");
                    MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Perf ", Global.con);
                    DataSet ds2 = new DataSet();
                    adp2.Fill(ds2);
                   
                    k = ds2.Tables[0].Rows.Count;
                    //k = 14;
                    for (i = 0; i <= k - 1; i++)
                    {
                        Perfno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
                        Perfhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                        Perfunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                    }
                    k = i;
                    adp2.Dispose();
                    ds2.Dispose();
                    Global.con.Close();
                   
                    

                    //////////////////////////
                    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.C_Mnth + "\\";
                    string strFileName = Global.DataPath + "Gen_Data\\" + Eng_FileNm + ".csv";
                    MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                   conn.Open();
                   MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                    DataSet ds1 = new DataSet("Temp");
                   adapter.Fill(ds1);
                    rx = ds1.Tables[0].Rows.Count;
                   
                    if (rx > 15) rx = 15;
                    for (int m = 0; m <= rx - 1; m++)
                    {
                        xlWorkSheet.Cells[m + 16, 2] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[0])].ToString();
                        xlWorkSheet.Cells[m + 16, 3] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[1])].ToString();
                        xlWorkSheet.Cells[m + 16, 4] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[2])].ToString();
                        xlWorkSheet.Cells[m + 16, 5] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[3])].ToString();
                        xlWorkSheet.Cells[m + 16, 6] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[4])].ToString();
                        xlWorkSheet.Cells[m + 16, 8] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[5])].ToString();
                        xlWorkSheet.Cells[m + 16, 9] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[6])].ToString();
                        xlWorkSheet.Cells[m + 16, 10] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[7])].ToString();
                        xlWorkSheet.Cells[m + 16, 13] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[8])].ToString();
                        xlWorkSheet.Cells[m + 16, 14] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[9])].ToString();
                        xlWorkSheet.Cells[m + 16, 15] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[10])].ToString();
                        xlWorkSheet.Cells[m + 16, 17] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[11])].ToString();
                        xlWorkSheet.Cells[m + 16, 18] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[12])].ToString();
                        xlWorkSheet.Cells[m + 16, 20] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[13])].ToString();
                        xlWorkSheet.Cells[m + 16, 21] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[16])].ToString();
                        xlWorkSheet.Cells[m + 16, 22] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[14])].ToString();
                        xlWorkSheet.Cells[m + 16, 24] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[17])].ToString();
                        xlWorkSheet.Cells[m + 16, 27] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[15])].ToString();
                        xlWorkSheet.Cells[m + 16, 32] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[18])].ToString();
                    }
                    Global.conData.Close();
                    xlWorkBook.SaveAs((object)(Global.DataPath + "Perf_" + Eng_FNm.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                    xlApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Code - 10207", ex.Message);
                }
            }
        /// //////////////////////////////////////////////////////
        /// </summary>
        /// <param name="db"></param>
        /// <param name="cPm"></param>

        public static void Open_PMConn(String db, String cPm)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
               //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source= " + DataPath + "Data.accdb;Jet OLEDB:DATABASE Password = gen.edac"); //   D:\\TestCell_" + T_CellNo + "\\" + db + "\\" + "Log.accdb");
               //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source= D:\\TestCell_" + T_CellNo + "\\" + db + "\\" + "PM.accdb");
                cn.Open();

                if (cPm == "conPM")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conPM.Close();
                        conPM = cn;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-15013", ex.Message);
            }
        }

        public static void  Rd_Confg()
        {
            try
            {
                Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tb_Std ORDER BY ParameterNo", con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                int x = 0;
                while (Rd.Read())
                {
                    PNo[x] = Rd.GetValue(0).ToString();
                    PName[x] = Rd.GetValue(1).ToString();
                    PMin[x] = Rd.GetValue(2).ToString();
                    PMax[x] = Rd.GetValue(3).ToString();
                    PUnit[x] = Rd.GetValue(4).ToString();
                    PSName[x] = Rd.GetValue(5).ToString();
                    PMark[x] = Rd.GetValue(6).ToString();
                    x += 1;
                }
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM Tb_Fixed ORDER BY N", con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();
                x = 0;
                while (Rd1.Read())
                {
                    fxd[x] = Convert.ToInt16(Rd1.GetValue(1));
                    x += 1;
                }

                //OleDbCommand cmd4 = new OleDbCommand("SELECT * FROM Tb_View ORDER BY N", con);
                //OleDbDataReader Rd4 = cmd1.ExecuteReader();
                //x = 0;
                //while (Rd4.Read())
                //{
                //    ViewNo[x] = Convert.ToInt16(Rd4.GetValue(1));
                //    x += 1;
                //}


                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM Tb_PM ORDER BY N", con);
                MySqlDataReader Rd2 = cmd2.ExecuteReader();
                x = 0;
                while (Rd2.Read())
                {
                    Pm_PNo[x] = Convert.ToInt16(Rd2.GetValue(1)) ;
                    x += 1;
                }


                MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM Tb_View ORDER BY N", con);
                MySqlDataReader Rd3 = cmd3.ExecuteReader();
                x = 0;
                while (Rd3.Read())
                {
                    vId[x] = Convert.ToInt16(Rd3.GetValue(1));
                    //vName[x] = Convert.ToInt16(Rd.GetValue(2));
                    //vUnit[x] = Convert.ToInt16(Rd.GetValue(3));
                    x += 1;
                }
                vIdNo = x;
                Global.con.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15013", ex.Message);
            }
        }
        public static void Rd_System()
        {
            try
            {
                Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = 'SystemPara'", con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {
                    for (x = 0; x <= (Rd.FieldCount - 1); x++)
                    {
                        sysIn[x] = Rd.GetValue(x).ToString();
                    }
                }
                Global.con.Close();   
                    MD1 = sysIn[22];
                    MD2 = sysIn[25];
                    MD3 = sysIn[28];
                    MD4 = sysIn[31];
                    MD5 = sysIn[34];
                    if (sysIn[17] == "TRUE") flg_VolActive = 1; else flg_VolActive = 0;

                    flg_rdMod = Convert.ToBoolean(sysIn[61]);
                    flg_LoginRPM = Convert.ToBoolean(sysIn[13]);
                    flg_simulateRPM = Convert.ToBoolean(sysIn[67]);
                    flg_RecorsPmData = Convert.ToBoolean(sysIn[15]);
                    RcrOn = sysIn[13];
                    TcrOn = sysIn[14];

                    T_CellNo = sysIn[9];
                  
                    Data_Dir = DateTime.Now.ToString("MMMyy");
                    DataPath = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15014", ex.Message); 
            }
        }
        public static void rd_tblproject()
        {
            try
            {
                Global.Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject WHERE ProjectFile = '" + Global.PrjNm + "'", Global.con);
                MySqlDataReader Rd5 = cmd.ExecuteReader();         
                int x = 0;
                while (Rd5.Read())
                {
                    for (x = 0; x <= (Rd5.FieldCount - 1); x++)
                    {
                        tblpro[x] = Rd5.GetValue(x).ToString();
                    }
                }
                Global.con.Close();   
                Global.Eng_FileNm1 = tblpro[1];
                PTO_Ratio =Double.Parse(tblpro[14]);
                Tq_Range = Double.Parse(tblpro[13]);
                if (Tq_Range >= 1000) Dig_OutBit(1, 8, true); else Dig_OutBit(1, 8, false);
                Double X = Double.Parse(tblpro[12]);
                Max_Trq = X + (X / 10);
                I_Rpm =  Int32.Parse(tblpro[11]);                                                          
                F_Rpm = Int32.Parse(tblpro[10]); 
                Trq_RPM = Double.Parse(tblpro[9]);
                Pow_RPM = Double.Parse(tblpro[7]);                                                                                                                       
                Max_Pow = Double.Parse(tblpro[6]) ;                                                     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error In Reading Project Table", ex.Message);
            }
        }
    
        public static DateTime DelayMs(int nMs)
        {
            try
            {
                System.DateTime ThisMoment = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, nMs);
                System.DateTime AfterWards = ThisMoment.Add(duration);
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15015", ex.Message);
            }
                return System.DateTime.Now;            
        }
        ///////////////////////////////////////////////////////////////////////////////

       public static DateTime DelaySc(int nSeconds)
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15016", ex.Message);
            }
                return System.DateTime.Now; 
        }

       public static void Capture_Data(Boolean flgSFC)
       {
           try
           {
               int t = 0;
               int I = 0;
               t = 100;
               StpTm = DateTime.Now.ToString("hh:mm:ss tt ");
               EngHrs = "11:22:00";
               for (I = 0; I <= 92; I++)
               {
                   if (Global.GenData[I] == null) Global.GenData[I] = "0.0"; 
                   Data[I] = GenData[I];
               }
               
               if (flgSFC == false)
               {
                   Data[t + 1] = GenData[101];
                   Data[t + 2] = GenData[fxd[14]];
                   Data[t + 3] = "0.0";
                   Data[t + 4] = "0.0";
                   Data[t + 5] = Corfact.ToString("0.00000");
                   Data[t + 6] = varTRQ .ToString("000.0");
                   Data[t + 7] = VarPowkW.ToString("00.00");
                   Data[t + 8] = "0.0";
                   Data[t + 9] = "0.0";
                   Data[t + 10] = GenData[110];
                   Data[t + 11] = GenData[111];
                   Data[t + 12] = "0.0";
                   Data[t + 13] = "0.0";
                   Data[t + 14] = "0.0";
                   Data[t + 15] = Global.VarPowHp.ToString("00.00");
                   Data[t + 16] = GenData[116];
                   Data[t + 17] = "0.0";
                   Data[t + 18] = "0.0";
                   Data[t + 19] = Global.varbmep.ToString("0.000");
                   Data[t + 20] = "0.0";

               }
               else if (flgSFC == true)
               {
                   Global.flg_SFCON = false;
                   //Global.Data[3] = GenData[3];
                   //Global.Data[4] = GenData[4];
                   if (SmkVal == null) SmkVal = "0.00"; 
                   Global.Data[t + 1] = SmkVal.ToString();
                   Global.Data[t + 2] = BlBy.ToString();
                   Global.Data[t + 3] = SFCwt.ToString(); // .ArrData[11].ToString();
                   Global.Data[t + 4] = SFCTm.ToString(); // .ArrData[12].ToString();                       
                   Global.Data[t + 5] = Corfact.ToString("0.00000");
                   Global.Data[t + 6] = varTRQ.ToString("00.0");
                   Global.Data[t + 7] = VarPowkW.ToString("00.0");
                   Global.Data[t + 8] = SFCValkW.ToString("000.0");
                   Global.Data[t + 9] = Bi_Val.ToString("00.0");
                   Global.Data[t + 10] = GenData[110];  //Global.varTRQ.ToString("00.0");
                   Global.Data[t + 11] = GenData[111];
                   Global.Data[t + 12] = (Convert.ToDouble(Global.Data[108]) * Global.Corfact).ToString("00.0");
                   Global.Data[t + 13] = (Convert.ToDouble(double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
                   Global.Data[t + 14] = (Convert.ToDouble((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
                    Global.Data[t + 15] = VarPowHp.ToString("00.0");
                   Global.Data[t + 16] = GenData[116];
                   Global.Data[t + 17] = (SFCValPs).ToString("000.0");
                   Global.Data[t + 18] = GenData[118];
                   Global.Data[t + 19] = Global.varbmep.ToString("0.000");
                   Global.Data[t + 20] = "0.0";
               }
               string l = DateTime.Now.ToString("dd/MM/yyyy");
               if (OperatorNm == null) OperatorNm = "OpName";
               if (TKnNo == null) TKnNo = "TNo";
               if (EngMd == null) EngMd = "EngMd";

               Global.Data[121] = Global.C_bmep.ToString("0.000");
               Global.Data[122] = System.DateTime.Now.ToString("hh:mm:ss tt");
               Global.Data[123] = Global.S_StartTime;
               Global.Data[124] = Global.cumhours;
               if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
               Global.Data[125] = "*****";

               //Data[121] = l + ", " + Shift + ", " + T_CellNo + ", " + OperatorNm + ", " + TKnNo + ", " + EngNo + ", " + EngMd + ", " + FipNo;
               //Data[122] = "****"; // Global.TestTyp;
               //Data[123] = StpTm;
               //Data[124] = EngHrs; ;
               //if (StrAlarm == String.Empty) StrAlarm = "*****";
               //Data[125] = StrAlarm;
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error Code:- 1517", ex.Message);
           }
       }


       //public static void Capture_Data()
       //{
       //    try
       //    {
       //        int t = 0;
       //        int I = 0;
       //        t = 100;
       //        StpTm = DateTime.Now.ToLongTimeString();
       //        EngHrs = "11:22:00";
       //        for (I = 0; I <= 100; I++)
       //        {
       //            if (Global.GenData[I] == null) Global.GenData[I] = "0.0"; 
       //            Data[I] = GenData[I];
       //        }
       //        Data[101] = SmkVal;
       //        Data[102] = BlBy.ToString("00.00");
       //        Data[103] = SFCwt.ToString("000.0");
       //        Data[104] = SFCTm.ToString("00.00");
       //        Data[105] = Corfact.ToString("0.0000");
       //        Data[106] = varTRQ.ToString("000.0");
       //        Data[107] = VarPowkW.ToString("00.0");
       //        Data[108] = SFCValkW.ToString("00.0");
       //        Data[109] = Bi_Val.ToString("00.00");
       //        Data[110] = varTRQ.ToString("000.0");
       //        Data[111] = C_VarPowkW.ToString("000.0");
       //        Data[112] = C_SFCValkW.ToString("000.0");
       //        Data[113] = fl_Rate.ToString("00.00");
       //        Data[114] = fl_Rate.ToString("00.00");
       //        Data[115] = VarPowHp.ToString("000.0");
       //        Data[116] = C_VarPowHp.ToString("000.0");
       //        Data[117] = SFCValPs.ToString("000");
       //        Data[118] = C_SFCValPs.ToString("000");
       //        Data[119] = varbmep.ToString("0.000");
       //        Data[120] = "000.0";
       //        Data[121] = "000.0";
       //        string l = DateTime.Now.ToString("dd/MM/yyyy");
       //        Data[121] = l + ", " + Shift + ", " + T_CellNo + ", " + OperatorNm + ", " + TKnNo + ", " + EngNo + ", " + EngMd + ", " + FipNo;                 
       //        Data[122] = Global.TestTyp;
       //        Data[123] = StpTm;
       //        Data[124] = EngHrs;
       //        if (Global.StrAlarm == String.Empty) Global.PSName[t] = "*****";
       //        Data[125] = Global.StrAlarm;
       //    }
       //    catch (Exception ex)
       //    {
       //        MessageBox.Show("Error Code:- 1517", ex.Message);
       //    }
       //}
       public static void Read_Vol()
       {
           if (DigIn[3] == 1) Vol = VolB;
           else if (DigIn[4] == 1) Vol = VolC;
           else Vol = VolA;
       }       

        public static void Mode_to_Mode()
        {
            try
            {
               if (flg_even_Mode == true)
               {
                   if (L_Mode != C_Mode)                   
                       Global.Mode_Out(0, 1, 1);
                   else
                   {
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
                               Global.Mode_Out(0, 1, 1);
                               break;
                           case 6:
                               Global.Mode_Out(0, 1, 1);
                               break;
                       }
                   }
                   
                   if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15018", ex.Message);
            }
       }
        //public static void Mode_Not_Mode()
        //{
        //    try
        //    {
        //        if (flg_even_Mode == false)
        //        {
        //            if (Global.MDiff > 0)    //+ve
        //            {
        //                if (Global.LastAna2 > Global.LastAna1)
        //                    flg_even_Mode = true;
        //            }
        //            else if (Global.MDiff < 0)    //-ve
        //            {
        //                if (Global.LastAna2 < Global.LastAna1)
        //                    flg_even_Mode = true;
        //            }
        //            Global.LastAna2 = Global.LastAna2 + Global.MDiff;
        //        }
        //    }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error Code:- 16019", ex.Message);
        //        }
        //    }

        public static void Read_Limfl()
        {
            try
            {
                Global.Open_Connection("Limit", "conLim");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + Prj[3], Global.conLim);
                MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {
                    Global.LL1[x] = Rd.GetValue(2).ToString();
                    Global.L1[x] = Rd.GetValue(3).ToString();
                    Global.H1[x] = Rd.GetValue(4).ToString();
                    Global.HH1[x] = Rd.GetValue(5).ToString();
                    x += 1;
                }
                Global.con.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-15019", ex.Message); 
            }
        }
        public static void Read_LimtStandby()
        {
            try
            {
                Global.Open_Connection("Limit", "conLim");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM LIM_STANDBY", Global.conLim);
                MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {

                    Global.Ls[x] = Rd.GetValue(3).ToString();
                    Global.Hs[x] = Rd.GetValue(4).ToString();

                    x += 1;
                }
                Global.con.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-15019", ex.Message);
            }
        }
        public static void Read_Eng()
        {
            try
            {
                Global.Open_Connection("General", "con");
                MySqlCommand cmd = new MySqlCommand("select * from tblEngine where EngineFile='" + Global.Prj[1] + "'  ", Global.con);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {

                    EngType = rd.GetValue(1).ToString();
                    Bor = rd.GetValue(2).ToString();
                    NCyl = rd.GetValue(3).ToString();
                    Strk = rd.GetValue(4).ToString();
                    Svol = rd.GetValue(5).ToString();
                    SGrv = rd.GetValue(6).ToString();

                }
                Global.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15020", ex.Message); 
            }
   
        }
      //***************** 

    }
    
}
