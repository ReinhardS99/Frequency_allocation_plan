using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Frequency_allocation_plan
{ 
    class Global_variables
    {
        public string[] Call_ID = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S" };

        public int[] Freq_ID = { 110, 111, 112, 113, 114, 115};

        public double[] iEast = new double[] { 536660, 537032, 537109, 537110, 537206, 537248, 537250, 537267, 537269, 537270, 537356, 537380, 537458, 537604, 537720, 537905, 537910, 537953, 538050 };
        public double[] iNorth = new double[] { 183800, 184006, 183884, 184695, 184685, 185016, 185020, 184783, 183451, 184140, 184927, 184727, 184495, 184134, 184057, 184591, 184441, 184295, 184245 };

       public double dDist1, dDist2, dLdist = 0, Dvalue1=0,Dvalue2=0 ;
        public int pif=0, dCount, dPos, dlcount;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Global_variables g = new Global_variables();
            //Console.WriteLine("Hello, World!");
            Console.WriteLine("Call_iD\t  Easting\t Northing\t Frequency");

                for (int i = 0; i <= 18; i++)
                {
                    double Xval1, Xval2, Yval1, Yval2;

                Xval1 = g.iEast[i];
                Yval1 = g.iNorth[i];
                g.dPos = 0;
                g.dLdist = 0;
                for (int j = 0; j <= 18; j++)
                    {

                        Xval2 = g.iEast[j];

                        Yval2 = g.iNorth[j];

                    g.dDist1 = Cal_distance(Xval1, Xval2, Yval1, Yval2);

                    if (g.dLdist < g.dDist1)
                    {
                        g.dLdist = g.dDist1;
                        //g.dlcount = g.dCount;
                        g.dCount = g.dPos;
                        
                    }
                    g.dPos++;
                    //g.dlcount = g.dCount;
                    //g.dDist2 = g.Freq_ID[g.pif];
                }
                if (g.dCount== g.dlcount)
                {
                    // Console.WriteLine(g.dLdist.ToString());
                    //g.dPos = g.dCount;
                    
                    g.pif = g.pif + 1;
                    g.dDist2 = g.Freq_ID[g.pif];

                }
                else
                {
                    g.pif = 0;
                    //g.pif = g.Freq_ID[i];
                    g.dDist2 = g.Freq_ID[g.pif];
                }
                Console.WriteLine(g.Call_ID[i] + "\t  " + g.iEast[i].ToString() + "\t  " + g.iNorth[i].ToString() + "\t\t" + /*g.dLdist.ToString() + " " + g.dCount.ToString() + " " + g.dPos.ToString() + " " +*/ g.dDist2.ToString());
                g.dlcount = g.dCount;

            }
        }

        static double Cal_distance(double X1, double X2, double Y1, double Y2)
        {
            double distance,v1,v2,m1,m2;
            m1=X2-X1;
            m2=Y2-Y1;

            v1 = Math.Pow(m1, 2);

            v2 = Math.Pow(m2, 2);

            distance = Math.Sqrt( v1+ v2);

            return distance;
        }

    }
}
