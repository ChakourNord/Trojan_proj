using Iniserver;
using Server_Blyat;
using Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Server
{
    class server
    {
        public static iniserver iniserver = new iniserver();
        public static List<iniserver> ini = new List<iniserver>();
        

        public static void startserver(object[] list)
        {

            IPAddress ipp = (IPAddress)list[0];
            int port = (int)list[1];
            iniserver.listener = new TcpListener(ipp, port);

            iniserver.listener.Start();




            /* Start Listeneting at the specified port */


            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :" +
                              iniserver.listener.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");

            iniserver.Client = iniserver.listener.AcceptTcpClient();

            iniserver.ns = new NetworkStream(iniserver.Client.Client);


            StreamWriter sw = new StreamWriter(iniserver.Client.GetStream());
            Console.WriteLine("Connection accepted from " + iniserver.Client.Client.RemoteEndPoint);


            string input;

            Thread thread1 = new Thread(read);
            thread1.Start();


            while (true)
            {
                input = Console.ReadLine();
                sw.WriteLine(input);
                sw.Flush();
                if (input == "exit")
                {
                    Environment.Exit(0);
                }


            }


        }

        public static void read() => files.read();
    }
}
