using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    class clsPID
    {
        public static void MODE_TO_MODE()
        {
            try
            {
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
            catch //(Exception ex)
            {
                return;
            }
        }
      
        public static void Mode234_to_Mode56()
        {
            Global.Mode_Out(0, 1, 1);
            if (Global.Diff1 > 0)
                if (Global.varRPM >= Double.Parse(Global.SetRPM)) Global.Diff1 = 0;
                else if (Global.Diff1 < 0)
                    if (Global.varRPM <= Double.Parse(Global.SetRPM)) Global.Diff1 = 0;
            if (Global.Diff2 > 0)
                if (Global.varTRQ > Double.Parse(Global.SetTRQ)) Global.Diff2 = 0;
                else if (Global.Diff2 < 0)
                    if (Global.varTRQ <= Double.Parse(Global.SetTRQ)) Global.Diff2 = 0;

            if ((Global.Diff1 == 0) && (Global.Diff2 == 0)) Global.Mode_Out(0, 1, 1);

            Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
            Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
        }

        public static void Mode56_to_Mode234()
        {
            Global.Mode_Out(0, 1, 1);
            if (Global.Diff1 > 0)
                if (Global.varRPM >= Double.Parse(Global.SetRPM)) Global.Diff1 = 0;
                else if (Global.Diff1 < 0)
                    if (Global.varRPM <= Double.Parse(Global.SetRPM)) Global.Diff1 = 0;
            if (Global.Diff2 > 0)
                if (Global.varTRQ > Double.Parse(Global.SetTRQ)) Global.Diff2 = 0;
                else if (Global.Diff2 < 0)
                    if (Global.varTRQ <= Double.Parse(Global.SetTRQ)) Global.Diff2 = 0;

            if ((Global.Diff1 == 0) && (Global.Diff2 == 0)) Global.Mode_Out(0, 0, 1);

            Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
            Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
        }





        
        
        
        
        
      

       


    }
}
