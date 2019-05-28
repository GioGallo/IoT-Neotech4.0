using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensoriCLI
{
    class VirtualGPSSensor : iSensor, iGPSSensor
    {
        private double LatStazione = 45.956720;
        private double LongStazione = 12.654347;
        private double costante = (0.000100 - 0.000010) + 0.000010;
        private int id;
        private const int maxPersone=70;
        private int persone=0;



        public string getGPS()
        {
            return "latitudine\": " + "\"" + getLatitudine().ToString("00.000000") + "\"" + ",\"longitudine\" : " + "\"" + getLongitudine().ToString("00.000000");
        }

        public VirtualGPSSensor(int id)
        {
            this.id = id;
        }
        public double getLatitudine()
        {
            Random random = new Random();
            LatStazione += random.NextDouble() * costante;
            return LatStazione;
        }

        public double getLongitudine()
        {
            Random random = new Random();
            LongStazione += random.NextDouble() * costante;
            return LongStazione;
        }

        public void SetGPS(double lat, double log)
        { }

        public void SetLatitudine(double lat)
        { }

        public void SetLongitudine(double log)
        { }

        public string GetTimestamp()
        {
            long unixTimestamp = ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds) * 1000000000;
            return unixTimestamp.ToString();
        }
        public string ToJson()
        {
            return "{\"id\": " + id + ",\"" + getGPS() + "\",\"orario\":\"" + GetTimestamp() + "\"";
        }

        private int nPersone()
        {
            Random random = new Random();
            int n = random.Next(-5, 5);
            if (n<0)
            {
                if (persone+n>=0)
                {
                    persone = persone + n;
                }
                else
                {
                    persone = 0;
                }
            }
            else
            {
                if(persone+n>=maxPersone)
                {
                    persone = 70;
                }
                else
                {
                    persone = persone + n;
                }
            }
            return persone;
        }

        private string Apertura()
        {
            Random random = new Random();

            if(random.Next() %2 ==0)
            {
                return "false";
            }
            return "true";

        }
        /*{"id": 1,"latitudine": "45.956748","longitudine" : "12.654375","orario":"1559033359000000000","Aperto":false,"Persone":0}*/
        public string Dati()
        {
            return ToJson()+",\"Aperto\":"+Apertura()+",\"Persone\":"+nPersone()+"}";
        }
    }
}
