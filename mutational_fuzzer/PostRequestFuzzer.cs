using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace mutational_fuzzer
{
    public class PostRequestFuzzer
    {
        public static void MakeRequest(string[] args)
        {
            string[] requestLines = File.ReadAllLines(args[0]);
            string[] parms = requestLines[requestLines.Length - 1].Split('&');
            string host = string.Empty;
            StringBuilder requestBuilder = new StringBuilder();

            foreach (string ln in requestLines)
            {
                if (ln.StartsWith("Host:"))
                    host = ln.Split(' ')[1].Replace("\r", string.Empty);
                requestBuilder.Append(ln + "\n");
            }
            //https://stackoverflow.com/questions/6686261/what-at-the-bare-minimum-is-required-for-an-http-request
            string request = requestBuilder.ToString() + "\r\n";    //for http requests, must end in \r\n or else will hang
            Console.WriteLine(request);

            IPEndPoint rhost = new IPEndPoint(IPAddress.Parse(host), 80);
            foreach (string parm in parms)
            {
                using (Socket sock = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp))
                {
                    sock.Connect(rhost);

                    string val = parm.Split('=')[1];
                    string req = request.Replace("=" + val, "=" + val + "'");

                    byte[] reqBytes = Encoding.ASCII.GetBytes(req);
                    sock.Send(reqBytes);

                    byte[] buf = new byte[sock.ReceiveBufferSize];

                    sock.Receive(buf);
                    string response = Encoding.ASCII.GetString(buf);
                    if (response.Contains("error in your SQL syntax"))
                        Console.WriteLine("Parameter " + parm + "might be vulnerable.");
                    Console.WriteLine(" to SQL injection with value: " + val + "'");
                    
                }
            }

        }
    }
}
