using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    class clsFun
    {       
        
        const Double Pi = 3.1428571;
        public static string  cummbuff;
        public static Int16 ss;

        public static Double HP_Power(int rpm, Double Tq)
        {
            if (rpm <= 0) rpm = 1;
            if (Tq <= 0) Tq = 0.1;
            rpm = Global.varRPM;
            Tq = Math.Abs(Global.varTRQ);
            //Double Tmp = (2 * Pi * rpm * Tq) / (4500 * 9.81 );
            Double Tmp = ((rpm * Tq) / 9549.305) / 0.746;
            return Convert.ToDouble(Tmp.ToString("00.00"));
        }

        public static Double Ps_Power(int rpm, Double Tq)
        {
            if (rpm <= 0) rpm = 1;
            if (Tq <= 0) Tq = 0.1;
            rpm = Global.varRPM;
            Tq = Math.Abs(Global.varTRQ);
            Double Tmp = (2 * Pi * rpm * Tq) / (4500 * 9.81 * 1.014);
            return Convert.ToDouble(Tmp.ToString("00.00"));
        }

        public static Double Tqbackup(Double maxtq, Double RtTq)
        {
            maxtq = Global.Max_Trq;
            RtTq = Global.T_VarTRQ;
            Double Tmp = ((maxtq - RtTq) / RtTq) * 100;
            return Convert.ToDouble(Tmp.ToString("00.00"));

        }
      
        public static Double kW_Power(int rpm, Double Tq)
        {
            if (rpm <= 0) rpm = 1;
            if (Tq <= 0)  Tq = 0.1;
            rpm = Global.varRPM;
            Tq = Math.Abs(Global.varTRQ);
           // Double Tmp = (2 * Pi * rpm * Tq) / 60000;
            Double Tmp = (rpm * Tq) / 9549.305;
            return Convert.ToDouble(Tmp.ToString("00.00"));
        }

        public static Double Cal_SFC_G(Double Pow,Double Gm,Double Tm)
        {
            if (Pow <= 0) Pow = 1;
            if (Gm <= 0)  Gm = 0.1;
            if (Tm <= 0) Tm = 0.1;
            Double Tmp = ((Gm * 3600) / (Pow * Tm));
            return Convert.ToDouble(Tmp.ToString("000"));
        }
        public static Double Cal_SFC_V(Double Pow,Double Vm,Double Tm)
        {
            if (Pow <= 0) Pow = 1;
            if (Vm <= 0)  Vm = 0.1;
            if (Tm <= 0)  Tm = 0.1;
            Double Tmp = ((Vm * 0.835 * 3600) / (Pow * Tm));
            return Convert.ToDouble(Tmp.ToString("000"));
        }
        public static Double Flow_Rate(Double Gm,Double Tm)
        {            
            if (Gm <= 0) Gm = 0.1;
            if (Tm <= 0)  Tm = 0.1;
            Double Tmp = (Gm / Tm)*3.6;
            return Convert.ToDouble(Tmp.ToString("00.0"));
        }

        public static Double Fuel_Del(Double Gm,Double Tm, int rpm, int Cn)
        {
            if (rpm <= 0)  rpm = 1;
            if (Cn <= 0)  Cn = 3;           
            if (Gm <= 0)  Gm = 0.1;
            if (Tm <= 0)  Tm = 0.1;
            Double Tmp = (Gm * 2000 * 3600) / (60 * Tm * 0.835 * rpm * Cn);
            return Convert.ToDouble(Tmp.ToString("00.0"));
        }
        public static Double Cal_bmep(Double Tq, Double vol)
        {
            if (vol <= 0)  vol = 1.0;
            if (Tq <= 0)  Tq = 0.1;
            Double Tmp = (4 * 3.142 * Tq) / (vol * 100);
            return Convert.ToDouble(Tmp.ToString("0.000"));
        }

        public  static string  TmCounter(Int16 hr, Int16 mm,  Boolean stat)
        {           
            if (stat == true)
            {
                if (ss > 59)
                {
                    ss = 0;
                    if (mm == 59)
                    {
                        mm = 0;
                        if (hr != 0) hr += 1; else hr = 1;
                    }
                    else
                    {
                        mm += 1;
                    }
                }
                else
                    ss += 1;
            }
            else if (stat == false)
            {
                if (ss < 1)
                {
                    ss = 59;
                    if (mm == 0)
                    {
                        mm = 59;
                        if (hr != 0) hr -= 1;
                    }
                    else
                    {
                        mm -= 1;
                    }
                }
                else
                    ss -= 1;
            }
            cummbuff = hr.ToString("0000") + ":" + mm.ToString("00");  // +":" + ss.ToString("00"); ;
            return cummbuff;
        }

        public static Double CF_DIN_70020(Double DbT, Double Pb)
        {
            try
            {
                double Sq_Root = 1;
                double inv_corfct = 1;

                if ((Pb >= 1.1000) || (Pb <= 0.900)) Pb =  1.013;
                if ((DbT >= 50.0) || (DbT <= 10)) DbT = 31;

                Sq_Root = Math.Sqrt(((273 + DbT) / 293));
                inv_corfct = (Sq_Root * (760 / (Pb * 750)));

                return Convert.ToDouble(inv_corfct.ToString("0.00000"));
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in CF_DIN_70020" + ex.Message);
                return (1.0000);
            }

        }

        public static Double Cf_new(Double Patm, Double Tatm)
        {
            try
            {
                if ((Patm >= 1.1000) || (Patm <= 0.900)) Patm = 0.98;
                if ((Tatm >= 50.0) || (Tatm <= 10)) Tatm = 31;
                double cf = 1 + ((0.65 * (100 - Patm)) + (0.17 * (Tatm - 300))) / 100;
                return Convert.ToDouble(cf.ToString("0.00000"));
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in CF_New" + ex.Message);
                return (1.0000);
            }
        }

        public static Double SatWtrVp(Double T)
        {
            if ((T <= 10) || (T >= 55)) T = 32;
            double T1 = (4.6291 + (0.311 * T) + (0.0133 * T * T) + (0.00007 * T * T * T) + (0.000005 * T * T * T * T) - (0.000000008 * T * T * T * T * T));
            return (T1 / 800);
        }
        public static Double Cal_Rel_Humid(Double Bp, Double Dt, Double Wt)
        {
            Double Psw, Psd, PV = 0;
            Double Rel_Hum = 0;
            Psw = SatWtrVp(Wt);
            PV = Psw - ((Bp - Psw) * (Dt - Wt) * 1.8) / (2800 - 1.3 * (1.8 * (Dt + 32)));
            Psd = SatWtrVp(Dt);
            Rel_Hum = ((PV * 100) / (Psd));
            return Convert.ToDouble(Rel_Hum.ToString("00.0"));
            //return (Rel_Hum);
        }
        public static Double CF_IS_10000CS(Double rel, Double T, Double Pb)
        {
            double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(T);

            double T1, T2, T3;
            //pressure Corrections
            T1 = (svp * 100) / 750;     // water Vp mmhg to kpa
            T2 = ((Pb * 1000) / 10) - (T1 * (rel / 100));//saturated water vapour Press
            T3 = T2 / refsvp; //Pressure Corrction
            //Temperature Corrections
            T1 = Math.Pow((300 / (273 + T)), 0.75);
            T2 = T1 * T3;
            inv_corfct = 1 / (T2 - 0.7 * (1 - T2) * ((1 / 0.85) - 1));
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }
        public static Double CF_BS_AU_141_A(Double fd, Double T, Double Pb)
        {            
            double refAtms = 760;
            double inv_corfct = 1;
            double refTemp = 20.0;
            double T1, T2, T3;
            //pressure Corrections
            T1 = Math.Pow((fd / 0.834), 2.88) * (refAtms - (Pb * 750)) * 0.00000059;
            //Temperture Corrections
            T2 = Math.Pow((fd / 0.834), 1.76) * (T - refTemp) * 0.00012;
            T3 = (T1 + T2 + 100) / 100;
            inv_corfct = T3;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }


        public static Double CF_ISO_1585_NA(Double Bp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            //double TCR = 1.0;
            //double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 32;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));
            int r = 1;
            Double qc = q / r;
            if (qc < 40)
                fm = 0.3;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow (((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }


        public static Double CF_ISO_1585_TC(Double Bp, Double Tp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            double TCR = 1.0;
            double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 30;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));

            Double r = (Bp + Tp) / Bp;
            Double qc = q / r;
            if (qc < 40)
                fm = 0.3;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow(((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }

        public static Double CF_ISO_15550_NA(Double Bp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            double TCR = 1.0;
            double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 32;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));
            int r = 1;
            Double qc = q / r;
            if (qc < 37.5)
                fm = 0.2;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow(((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }



        public static Double IS_14599_NA(Double Bp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            double TCR = 1.0;
            double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 32;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));
            int r = 1;
            Double qc = q / r;
            if (qc < 40)
                fm = 0.3;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow (((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }


        public static Double IS_14599_TC(Double Bp, Double Tp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            //double TCR = 1.0;
            //double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 30;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));

            Double r = (Bp + Tp) / Bp;
            Double qc = q / r;
            if (qc < 40)
                fm = 0.3;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow(((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }

        //*****************************
      


        //public static void Mode_to_Mode()
        //{
        //    try
        //    {

        //        if ((Global.L_Mode == "5") && (Global.C_Mode == "6")) Mode5_to_Mode6();
        //        if ((Global.L_Mode == "5") && (Global.C_Mode == "4")) Mode5_to_Mode4();

        //        if ((Global.L_Mode == "6") && (Global.C_Mode == "5")) Mode6_to_Mode5();
        //        if ((Global.L_Mode == "6") && (Global.C_Mode == "4")) Mode6_to_Mode4();

        //        if ((Global.L_Mode == "4") && (Global.C_Mode == "6")) Mode4_to_Mode6();
        //        if ((Global.L_Mode == "4") && (Global.C_Mode == "5")) Mode4_to_Mode5();

        //        if (Global.L_Mode == Global.C_Mode) Mode_Mode(); 

        //    }
        //    catch (Exception ex)
        //    {
        //        return; 
        //    }
        //}

            public static void Mode_Mode()
            {           
                try
                {
                
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
                Global.AnaOut2 = Global.LastAna2 + Global.Diff2;    

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
            }

            catch (Exception ex)
            {
                return; 
            }
        }
       

        public static void MODE_TO_MODE()
        {
            try
            {
                switch(int.Parse(Global.C_Mode))
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
                        Global.AnaOut2 = Double.Parse( Global.SetPtOut2);
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
            catch 
            {
                return;
            }
        }

        //**************************

        //*************************
        public static void MODE_NOT_MODE()
        {
            try
            {   
                
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
                //***********************************

                if ((Global.L_Mode == "4") &&((Global.C_Mode == "5") || (Global.C_Mode == "6")))
                {
                    Global.Mode_Out(0, 1, 1);
                    Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }              
                else
                {
                    Global.Mode_Out(0, 1, 1);
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;   
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }


            }
            catch // (Exception ex)
            {
                return;    // MessageBox.Show("Error Code:- Fun10002", ex.Message);
            }
        }





          
       
//************************************
    }
}
