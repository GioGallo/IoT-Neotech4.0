using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobus
{
    interface iGPSSensor
    {
        void SetLongitudine(double log);
        void SetLatitudine(double lat);
        void SetGPS(double lat, double log);


        string GetTimestamp();

        double getLatitudine();
        double getLongitudine();
        string getGPS();
    }
}
