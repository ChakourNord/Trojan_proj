using Iniserver;
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

        public static void fileread(string name, int bytee)
        {

            StreamReader sr = new StreamReader(iniserver.Client.GetStream());

            NetworkStream s = iniserver.ns;
            //StreamReader sr = new StreamReader(iniserver.ns);
            /*
            string data;
            int data1 = -1;
            /*
            while (data1 == -1)
            {
                data = sr.ReadLine();
                Console.WriteLine(data);
                try
                { data1 = Convert.ToInt32(data); }
                catch (FormatException) { }
            }

            */

            int a;
            byte[] b = new byte[bytee];
            bool check = true;
            bool check2 = true;
            const string end = ".txt";
            int i = 1;
            while (check)
            {
                var ir = iniserver.Client.Client.Available;
                Console.Write("ANFANG");
                do
                {
                    Console.WriteLine("DRIN");

                    a = s.Read(b, 0, b.Length);
                    File.WriteAllBytes(@"D:\Users\chako\Desktop\tmp2\" + name + i + end, b);
                    i++;
                    if (sr.ReadLine() == "--FIN--")
                        check2 = false;
                } while (check);
                string g = null;
                Console.WriteLine("FIN");
                Console.WriteLine(a);
                check = false;
                /*
                if (redata == "--END--")
                {
                    check = false;
                    
                    if (redata == "--END--")
                        g = redata;
                    redata = " ";
                    
                }


                Console.WriteLine(redata);
                iniserver.Writer.WriteLine(redata, Encoding.Default);
                iniserver.Writer.Flush();
                if(g == "--END--")
                iniserver.Writer.Close();*/










            }

        }

        public static void read()
        {

            StreamReader sr = new StreamReader(iniserver.Client.GetStream());

            while (true)
            {
                string data = null;
                const string end = ".txt";
                int bytee = 0;
                string name = null;
                data = sr.ReadLine();
                if (data == "File")
                {
                    if (name == null && bytee == 0)
                    {
                        name = sr.ReadLine();
                        name = name + end;
                        bytee = Convert.ToInt32(sr.ReadLine());
                    }

                    fileread(name,bytee);
                }
                else
                {



                    Console.WriteLine(data);

                }
            }

        }
    }
}
