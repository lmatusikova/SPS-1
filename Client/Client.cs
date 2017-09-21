using System;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the name of a server: ");
            string server = Console.ReadLine();
            Console.WriteLine("Please enter port number (press Enter for 80): ");
            string line = Console.ReadLine();

            int port = 80;
            if (line != "")
            {
                port = Convert.ToInt32(line);
            }

            // open the client connection and setup streams
            TcpClient client = new TcpClient(server, port);
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            try {
                // send HTTP request
                sw.WriteLine("GET / HTTP/1.0\r\n");
                // flush it so it won't wait
                sw.Flush();

                // write the result to the console
                string data = sr.ReadLine();
                while(data != null)
                {
                    Console.WriteLine(data);
                    data = sr.ReadLine();
                }
                client.Close();
            }
            catch (Exception e)
            {
                // exception is thrown when server closes connection sooner 
                // than our client, but we can ignore it
            }
            // we wait for input so the window does not close
            Console.ReadLine();
        }
    }
}
