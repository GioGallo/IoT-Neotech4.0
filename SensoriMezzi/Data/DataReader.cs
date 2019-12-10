using CSRedis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SensoriMezzi.Data
{
    class DataReader
    {
        protected RedisClient redis;

        public DataReader()
        {
            redis = new RedisClient("127.0.0.1");
        }
        public void Write(string data)
        {
            try
            {
               // redis.LPush("sensors_data",data);
                redis.LPush("sensor_data",data);
            }
            catch (Exception e)
            {
                Console.WriteLine("DataReader : " + e.Message);
            }

        }
    }
}
