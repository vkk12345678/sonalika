using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logger
{
    public partial class frmRStatus : Form
    {
        private string[] ViewNo = new string[22];
        public frmRStatus()
        {
            InitializeComponent();
            
        }
        //private void LoadPm()
        //{
        //    try
        //    {
        //        GridGen.Refresh(); 

        //        Global.Open_PMConn("Data", "conPM");
        //        OleDbDataAdapter adp = new OleDbDataAdapter("Select * from " + Global.Eng_PMFileNm + " Order By TM ", Global.conPM);
        //        DataSet ds = new DataSet();
        //        adp.Fill(ds);
        //        GridGen.DataSource = ds.Tables[0];
        //        foreach (DataGridViewColumn colm in GridGen.Columns)
        //        {
        //            colm.SortMode = DataGridViewColumnSortMode.NotSortable;
        //            colm.Width = 80;
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 12001", ex.Message); 
        //    }
        //}
        private void LoadPm()
        {
            try
            {
                GridGen.Refresh();
                String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";
                string strFileName = DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv";
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                DataSet ds1 = new DataSet("Temp");
                adapter.Fill(ds1);
                GridGen.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 12003", ex.Message);
            }
        }
        private void LoadGen()
        {
            try
            {
                GridGen.Refresh(); 
                String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";
                string strFileName = DataPath + "Gen_Data\\" + Global.Eng_FileNm+ ".csv";
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                DataSet ds1 = new DataSet("Temp");
                adapter.Fill(ds1);
                GridGen.DataSource = ds1.Tables[0];                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 12002", ex.Message);
            }
        }
        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuGen_Click(object sender, EventArgs e)
        {
            LoadGen(); 
        }

        private void mnuPM_Click(object sender, EventArgs e)
        {
            LoadPm(); 
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {

        }

        private void mnuAvg_Click(object sender, EventArgs e)
        {
            try
            {
                GridGen.Refresh(); 
                String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";
                string strFileName = DataPath + "Inst_Data\\" + Global.Eng_Inst_FileNm + ".csv";
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                DataSet ds1 = new DataSet("Temp");
                adapter.Fill(ds1);
                GridGen.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 12002", ex.Message);
            }
        }

        private void RunStatus_Click(object sender, EventArgs e)
        {
            try
            {
                GridGen.Refresh();
                String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";
                string strFileName = DataPath + "Error_Data\\" + Global.Eng_Error_FileNm + ".csv";
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                DataSet ds1 = new DataSet("Temp");
                adapter.Fill(ds1);
                GridGen.DataSource = ds1.Tables[0];
                GridGen.Columns[0].Width = 60;
                GridGen.Columns[1].Width = 100;
                GridGen.Columns[2].Width = 60;
                GridGen.Columns[3].Width = 350;
                GridGen.Columns[4].Width = 120;
                GridGen.Columns[5].Width = 60;
                

 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 12002", ex.Message);
            }

        }
       
     }
}
