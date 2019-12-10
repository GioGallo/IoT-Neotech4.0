using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SensoriMezzi.Modelli;
using Newtonsoft.Json;
using System.Reflection;

namespace SensoriMezzi.Sensori
{
    class VirtualGPSSensor : ISensor, IGPSSensor
    {
        private readonly int Id;
        private double[][][] coordinates;
        private const int maxPersone = 70;
        private int persone;
        private int indexLat;
        private int indexLon;
        private int Max;

        public VirtualGPSSensor(int id)
        {
            Id = id;
            coordinates = GetPercorso();
            Max = coordinates[0].Length;
            persone = 0;
            indexLat = 0;
            indexLon = 0;
        }
        public string getGps()
        {
            return "latitudine\": " + "\"" + getLatitudine().ToString("00.000000000") + "\"" + ",\"longitudine\" : " + "\"" + getLongitudine().ToString("00.000000000");

        }

        public double[][][] GetPercorso()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string exeDir = System.IO.Path.GetDirectoryName(exePath);
            var myJsonString = File.ReadAllText(exeDir+ @"\Percorsi\csavrwaiwd.json");
            var percorso = JsonConvert.DeserializeObject<Percorso>(myJsonString);
            return percorso.features.geometry.coordinates;
        }

        public string getTimestamp()
        {
            long unixTimestamp = ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds) * 1000000000;
            return unixTimestamp.ToString();
        }

        public string ToJson()
        {
            return "{\"id\": " + Id + ",\"" + getGps() + "\",\"orario\":\"" + getTimestamp() + "\"";
        }

        public double getLatitudine()
        {
            if (indexLat == Max)
            {
                indexLat = 0;
            }

            double[] x = coordinates[0][indexLat];
            double y = x[0];
            indexLat++;
            return y;
        }

        public double getLongitudine()
        {
            if (indexLon == Max)
            {
                indexLon = 0;
            }
            double[] x = coordinates[0][indexLon];
            double y = x[1];
            indexLon++;
            return y;
        }
        private int nPersone()
        {
            Random random = new Random();
            int n = random.Next(-5, 5);
            if (n < 0)
            {
                if (persone + n >= 0)
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
                if (persone + n >= maxPersone)
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

            if (random.Next() % 2 == 0)
            {
                return "false";
            }
            return "true";
        }
        private int Velocità()
        {
            Random random = new Random();
            return random.Next(10, 50);
        }
        public string Dati()
        {
            string porte = Apertura();
            if (porte == "true")
            {
                return ToJson() + ",\"Aperto\":" + porte + ",\"Persone\":" + nPersone() + ",\"Velocità\": 0" + "}";
            }
            else
            {
                return ToJson() + ",\"Aperto\":" + Apertura() + ",\"Persone\":" + persone + ",\"Velocità\":" + Velocità() + "}";
            }
        }
    }
}
