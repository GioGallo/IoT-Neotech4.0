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
            List<String> idMezzi = new AppSettingsReader().GetValue("idMezzi", typeof(string)).ToString().Split(',').ToList();
            List<Thread> lstThread = new List<Thread>();
            foreach (string id in idMezzi)
            {
                Thread t = new Thread(() => Generadati(id));
                t.Name = "id" + id;
                t.Start();
                lstThread.Add(t);
            }
            Thread invio = new Thread(InvioDati);
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
        public static void Generadati(string id)
        {
            DataSender redis = new DataSender();
            VirtualGPSSensor sensor = new VirtualGPSSensor(Convert.ToInt32(id));
            while (true)
            {
                string dato = sensor.Dati();
                redis.Read(dato);
            }

        }
    }
}
