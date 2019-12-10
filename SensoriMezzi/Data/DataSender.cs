using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using CSRedis;

namespace SensoriMezzi.Data
{
    class DataSender : DataReader
    {
        private string url;

        public DataSender(string Url) : base()
        {
            url = Url;
        }
        public void Send()
        {
            try
            {
                if (redis.LLen("sensors_data") != 0)
                {
                    HttpWebRequest httpWebRequestData;
                    httpWebRequestData = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequestData.ContentType = "application/json";
                    httpWebRequestData.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequestData.GetRequestStream()))
                    {
                        try
                        {
                            string dataJson = redis.BLPop(30,"sensors_data");
                            streamWriter.Write(dataJson);
                            streamWriter.Flush();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        streamWriter.Close();

                    }
                    var httpResponseData = (HttpWebResponse)httpWebRequestData.GetResponse();
                    using (var streamReader = new StreamReader(httpResponseData.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("DataSender : " + e.Message);
            }
        }
    }
}

