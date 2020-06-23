using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Logger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static System.Threading.Thread tst = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());  //  frmAbout());
            //System.Threading.Thread tst = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            //tst.SetApartmentState(System.Threading.ApartmentState.STA);
            //tst.Start(); 
                    
        }
        //public static void ThreadProc()
        //{
        //    Application.Run(new frmStart());
        //}
       
    }
}
