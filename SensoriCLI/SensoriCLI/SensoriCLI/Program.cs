using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SensoriCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread dati = new Thread(Generadati);
            Thread invio = new Thread(InvioDati);
            dati.Start();
            invio.Start();
        }
        public static void InvioDati()
        {
            DataSender redis = new DataSender();
            while (true)
            {
                redis.Send();
            }
        }
        public static void Generadati()
        {
            string[] idMezzi = new AppSettingsReader().GetValue("idMezzi", typeof(string)).ToString().Split(',');
            DataSender redis = new DataSender();
            List<VirtualGPSSensor> sensors = new List<VirtualGPSSensor>();
            foreach (string id in idMezzi)
            {
                sensors.Add(new VirtualGPSSensor(Convert.ToInt32(id)));
            }
            while (true)
            {
                foreach (VirtualGPSSensor sensor in sensors)
                {
                    string dati = sensor.Dati();
                    Console.WriteLine(dati);
                    redis.Read(dati);
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
