using System;
using System.Net;
using System.IO;

namespace mutational_fuzzer
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            PostRequestFuzzer.MakeRequest(args);
            //string url = args[0];
            //int index = url.IndexOf("?");
            //string[] parms = url.Remove(0, index + 1).Split("&");
            //foreach (string parm in parms)
            //{
            //    string xssUrl = url.Replace(parm, parm + "df<xss>df");
            //    string sqlUrl = url.Replace(parm, parm + "sdfd'sa");

            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sqlUrl);
            //    request.Method = "GET";

            //    string sqlresp = string.Empty;
            //    Console.WriteLine("Reading first streams..");
            //    using (StreamReader rdr = new StreamReader(request.GetResponse().GetResponseStream()))
            //        sqlresp = rdr.ReadToEnd();

            //    request = (HttpWebRequest)WebRequest.Create(xssUrl);
            //    request.Method = "GET";
            //    string xssresp = string.Empty;
            //    Console.WriteLine("Reading second stream..");
            //    using (StreamReader rdr = new StreamReader(request.GetResponse().GetResponseStream()))
            //        xssresp = rdr.ReadToEnd();

            //    if (xssresp.Contains("<xss>"))
            //    {
            //        Console.WriteLine("Possible XSS point in " + parm);
            //    }
            //    if (sqlresp.Contains("error in your SQL syntax"))
            //    {
            //        Console.WriteLine("SQL injection point found in " + parm);
            //    }
            //    Console.WriteLine("Finished..");

            //}
        }
    }
}
