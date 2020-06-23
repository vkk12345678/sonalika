﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient; 
using System.Windows.Forms;

namespace Logger
{
    public partial class frmStart : Form
    {      
        private string[] TkN = new string[25];
        private string[] Nam = new string[25];
        private Int16 I = 0;
        private Boolean flg_Resize = false;
        private String TNm = "";
        private String Pwd = "";
       

        public frmStart()
        {
            InitializeComponent();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            flg_Resize = true;
            cmbTkN.Items.Clear();  
            Global.Open_Connection("General", "con");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Sec", Global.con);           
            MySqlDataReader rd = cmd.ExecuteReader();
            I = 0;
            while (rd.Read())
            {
                if (rd.GetValue(0).ToString() != "DataSec")
                {
                    I++;
                    TkN[I] = rd.GetValue(0).ToString();
                    Nam[I] = rd.GetValue(1).ToString();                    
                    //cmbTkN.Items.Add(TkN[I]);
                   // cmbTkN.SelectedIndex = 0;
                }
            }
           Global.con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Width >= 500) flg_Resize = false; else flg_Resize = true;


            if (flg_Resize == false)
            {
                this.Width = 500;
                this.Height = 250;
            }
            else
            {
                this.Width += 10;
                this.Height += 5;
            }
            
            
            if (label4.Location.X >= -450)
            {
                label4.Location = new Point(label4.Location.X - 1, label4.Location.Y);
            }
            else
            {
                label4.Location = new Point(label4.Location.X + 1000, label4.Location.Y);
            }
            if (label3.Location.X >= -450)
            {                
                label3.Location = new Point(label3.Location.X - 1, label3.Location.Y);
            }
            else
            {
                label3.Location = new Point(label3.Location.X + 1000, label3.Location.Y);
            }
        }

       
        private void btnOK_Click(object sender, EventArgs e)
        {
            TNm = cmbTkN.Text;
            Pwd = textBox1.Text;  
            Global.Open_Connection("General", "con");
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM Sec WHERE TokenNo = '" + TNm + "'", Global.con);
            DataSet ds = new DataSet();
            adp.Fill(ds);  
            
            if (ds.Tables[0].Rows[0].ItemArray[1].ToString() == Pwd)
            {
                timer1.Stop();
                //Global.ResultOK = true;
                frmMain frm2 = new frmMain();
                frm2.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
                frm2.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Oper ID No OR Password is Not Matching.   Pl Try Again... ");
               // Global.ResultOK = true;
            }
        }
        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void cmbTkN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
