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
                DataSender ds = new DataSender();
                Thread t = new Thread(() => Generadati(ds,id));
                t.Name = "id" + id;
                t.Start();
                lstThread.Add(t);
            }
            DataSender dsi = new DataSender();
            Thread invio = new Thread(()=>InvioDati(dsi));
            invio.Start();
        }
        public static void InvioDati(DataSender datasender)
        {
            while (true)
            {
                datasender.Send();
            }
        }
        public static void Generadati(DataSender datasender, string id)
        {
            VirtualGPSSensor sensor = new VirtualGPSSensor(Convert.ToInt32(id));
            while (true)
            {
                string dato = sensor.Dati();
                datasender.Write(dato);
                System.Threading.Thread.Sleep(10000);
            }

        }
    }
}
