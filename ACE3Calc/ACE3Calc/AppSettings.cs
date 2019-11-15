using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ACE3Calc
{
    static class AppSettings
    {
        public static double currrentversion = 0.4;
        public static double lastverison;

        public static bool CheckNewVersion()
        {
            double versionfrominet;

            //Код инициализации интернт соединения

            versionfrominet = 0.5;
            lastverison = versionfrominet;

            

            if (currrentversion < versionfrominet)
            {
                return true;
            }

            return false;
        }
    }
}
