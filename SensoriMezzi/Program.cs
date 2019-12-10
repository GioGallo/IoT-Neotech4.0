using Microsoft.Extensions.Configuration;
using SensoriMezzi.Data;
using SensoriMezzi.Sensori;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SensoriMezzi
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            DataReader dr = new DataReader();
            string id = configuration.GetConnectionString("Id");
            Thread t = new Thread(() => Generadati(dr,id));
            t.Name = "id" + id;
            t.Start();


            DataSender ds = new DataSender(configuration.GetConnectionString("UrlApi"));
            Thread invio = new Thread(() => InvioDati(ds));
            invio.Start();
            //Console.WriteLine("Sensori in funzione");
        }
        public static void InvioDati(DataSender datasender)
        {
            while (true)
            {
                datasender.Send();
            }
        }
        public static void Generadati(DataReader datareader, string id)
        {
            VirtualGPSSensor sensor = new VirtualGPSSensor(Convert.ToInt32(id));
            while (true)
            {
                string dato = sensor.Dati();
                datareader.Write(dato);
                Console.WriteLine(dato);
                System.Threading.Thread.Sleep(10000);
            }

        }
    }
}
