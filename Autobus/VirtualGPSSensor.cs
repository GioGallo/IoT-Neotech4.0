using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobus
{
    class VirtualGPSSensor : iSensor, iGPSSensor
    {
        private double LatStazione = 45.956720;
        private double LongStazione = 12.654347;

        public string getGPS()
        {
            return "latitudine\": " + "\""+getLatitudine().ToString("00.000000")+"\"" + ",\"longitudine\" : " + "\""+getLongitudine().ToString("00.000000");
        }

        public double getLatitudine()
        {
            Random random = new Random();
            LatStazione += random.NextDouble() * (0.000100 - 0.000010) + 0.000010;
            return LatStazione;
        }

        public double getLongitudine()
        {
            Random random = new Random();
            LongStazione += random.NextDouble() * (0.000100 - 0.000010) + 0.000010;
            return LongStazione;
        }

        public void SetGPS(double lat, double log)
        { }

        public void SetLatitudine(double lat)
        { }

        public void SetLongitudine(double log)
        { }

        public string GetTimestamp(DateTime value)
        {
            TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return span.TotalSeconds.ToString();
        }
        public string ToJson(int id)
        {
            return "{\"id\": "+id+",\""+getGPS()+"\",\"orario\":\""+GetTimestamp(DateTime.Now)+"\"";
        }
    }
}

