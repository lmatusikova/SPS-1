using System;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            // open a port on which the server listens
            TcpListener listener = new TcpListener(1234);
            listener.Start();

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                // accept the connection
                TcpClient client = listener.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());

                try
                {
                    string request = sr.ReadLine();
                    string[] tokens = request.Split(' ');
                    string page = tokens[1];

                    if (page == "/")
                    {
                        page = "index.html";
                    }

                    StreamReader file = new StreamReader("../../web/" + page);

                    // send the response
                    sw.WriteLine("HTTP/1.0 200 OK\n");

                    // write the file line by line
                    string data = file.ReadLine();
                    while(data != null)
                    {
                        sw.WriteLine(data);
                        sw.Flush();
                        data = file.ReadLine();
                    }
                }
                catch (Exception e)
                {
                    sw.WriteLine("HTTP/1.0 404 NOT FOUND\n");
                    sw.WriteLine("<h1>ERROR</h1>");
                    sw.WriteLine("<p>The page was not found.</p>");
                    sw.Flush();
                }
                finally
                {
                    client.Close();
                }
            }
        }
    }
}
