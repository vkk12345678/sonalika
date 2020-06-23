using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
//using AcroPDFLib;

 


namespace Logger
{

    public partial class showdata : Form
    {
        string L;        
       
        Boolean flg_ProdChk = false ;
        Boolean flg_Report = true;
        Boolean flg_PMchk = true;
        Boolean flg_Multichk = false;
        long Rstart, Rstop;

        //excel._Application wapp;

        //excel.Worksheets wsheet;
        //excel.Workbooks wbook;
        string NodeT;
        int M;
        int N;

        public showdata()
        {
            InitializeComponent();
        }

      
       
      
        private void LOAD_REPORT()
        {            
            L = "D:\\TestCell_" + Global.T_CellNo + "\\";
            String L1 = L + comboBox1.Text  ; 
            M = L1.Length+1; 
            TVreport.Nodes.Clear(); 
            TVreport.Nodes.Add("R1", L1);  
            TVreport.Nodes["R1"].Tag = "R1";
            
            if (System.IO.Directory.Exists(L +(comboBox1.Text) ) == true)
            {                
                   String [] files1 = System.IO.Directory.GetFiles(L+comboBox1.Text );
                   foreach (string fnm in files1)
                   {                     
                      N= fnm.Length - 5;
                      if (fnm.Substring(N) == ".xlsx")                    
                      {
                          TVreport.Nodes["R1"].Nodes.Add("R1", fnm.Substring(M));                         
                      }

                   }
                   
             }
             TVreport.Nodes["R1"].Expand();
        }
       
        private void showdata_Load(object sender, EventArgs e)
        {
            fill_combo();       
            defaultCombo();
        }
        private void defaultCombo()
        {
            comboBox1.Text = DateTime.Now.ToString("MMMyy");
            flg_Report = true;
            LOAD_REPORT ();
        }
        private void fill_combo()
        {
            comboBox1.Text = DateTime.Now.ToString("MMM");
            L = "D:\\TestCell_" + Global.T_CellNo + "\\";
            M = L.Length;  //("D:\\TestCell_" & T_CellNo & "\\");
            comboBox1.Items.Clear();
            String[] files = System.IO.Directory.GetDirectories(L);

            foreach (String fnm in files)
            {
                comboBox1.Items.Add(fnm.Substring(M));
            }

        }
        
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_REPORT();

            
           if (flg_ProdChk == true)
            {
                cmdRd.Enabled = false;
           
                //TV.Nodes.Clear();
                //TV.Enabled = true;              
                //Load_TV_Date();
            }
            else if (flg_Multichk == true)
            {
                cmdRd.Enabled = false;             
                //TV.Enabled = false;               
                //LoadMulti();              
            }
            
        }

        
        
        

       
        

                    
     
        //private void TV_AfterSelect_1(object sender, TreeViewEventArgs e)
        //{

        //    NodeT = TV.SelectedNode.Text;
        //    if (TV.SelectedNode.Tag == "D " || TV.SelectedNode.Tag != "R1")
        //    {
        //        cmdRd.Enabled = true;
        //        label1.Text = TV.SelectedNode.Text;
        //        //View_Data();
        //    }
           
        //}
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    
       
        private void TVreport_AfterSelect(object sender, TreeViewEventArgs e)
        {

            Excel.Application xlApp = new Excel.Application(); 
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "AcroRd32")
                {
                    pr.Kill();
                }
            }
          
            object objMissing = System.Reflection.Missing.Value;
            
            NodeT = TVreport.SelectedNode.Text;
            if ((TVreport.SelectedNode.Tag != "R1"))//    .SelectedNode.Tag != "D") || (TVPM.SelectedNode.Tag != "R1"))
            {
                label1.Text = TVreport.SelectedNode.Text;
                //textBox1.Text = TVreport .SelectedNode.Text;   
                //////////////////////Excel Application//////////////////////////
                string Pt = "D:\\TestCell_VII\\" + comboBox1.Text + "\\";
              
  
                xlWorkBook = xlApp.Workbooks.Open(Pt + label1.Text, 0, false, 5, "", "", objMissing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlApp.Visible = true;
                //xlWorkBook = xlApp.Workbooks.Open(Global.DataPath + label1.Text, 0, true, 5, "", "", objMissing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                ////xlworkSheetREP = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("475 DI");
                //xlApp.Visible = true;
                 ////////////////////////////////////////////////////////////////////////////
                //*****PDF FILE*******************//
                //string showFilepath = @""+ Global.DataPath + label1.Text;// ;+ "Project.chm";
                //if (File.Exists(showFilepath))
                //{
                //    Process.Start(showFilepath);
                //}
                //else
                //{
                //    MessageBox.Show("file not Found" + showFilepath);
                //}
                //******************************************

            }
            else
            {

            }

          
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TVreport.Nodes.Clear(); 
            L = "D:\\TestCell_" + Global.T_CellNo + "\\";
            String L1 = L + comboBox1.Text;
            string L2 = L1 + "\\AAAAA";
            M = L2.Length ;  
            TVreport.Nodes.Add("R1", L1);   // .Nodes.Add("R1", Global.DataPath + "Data");
            TVreport.Nodes["R1"].Tag = "R1";

            if (System.IO.Directory.Exists(L + (comboBox1.Text)) == true)
            {
                String[] files1 = System.IO.Directory.GetFiles(L + comboBox1.Text);
                foreach (string fnm in files1)
                {
                    //this.TVreport.ImageList = "c:\\ED00010_ "  ;
                    N = fnm.Length - 5;

                    if (fnm.Substring(N) == ".xlsx")//(fnm.Substring(N) == ".pdf")
                    {
                        int pos;
                        pos = Convert.ToInt16(fnm.IndexOf("_", M));
                        if (textBox1.Text == fnm.Substring(M,pos-M))
                        {
                            TVreport.Nodes["R1"].Nodes.Add("R1", fnm.Substring(L1.Length+1));
                            label1.Text = fnm.Substring(L1.Length + 1);
                               
                        }
                    }
                }
            }
            TVreport.Nodes["R1"].Expand();
           


 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

       
       
       
        }

    }
//}

       
    

