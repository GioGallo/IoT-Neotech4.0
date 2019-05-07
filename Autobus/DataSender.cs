using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSRedis;
using System.Threading.Tasks;
using System.IO;

namespace Autobus
{
    class DataSender
    {
        private RedisClient redis;
        public DataSender()
        {
            redis = new RedisClient("127.0.0.1");
        }

        public void Read(string data)
        {
            redis.LPush("sensors_data", data);
        }
        public void Send()
        {
            try
            {
                if(redis.LLen("sensors_data")==0)
                {

                }
                else
                {
                    StreamWriter sw = File.AppendText("C:\\Users\\Giovanni Gallo\\Desktop\\dati.txt");
                    sw.WriteLine(redis.BLPop(30, "sensors_data"));
                    sw.Close();
                }

            }catch(Exception e)
            {

            }
        }
    }
}
