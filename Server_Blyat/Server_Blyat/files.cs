using Iniserver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Iniserver;

namespace Files
{
    class files
    {
        public static iniserver iniserver = new iniserver();
        public static List<iniserver> ini = new List<iniserver>();
        private string name;
        private int bytee;

        public files ()
        { 
        }
        public files (string name, int bytee)
        {
            this.name = name;
            this.bytee = bytee;
        }

        public string Name { get => name; set => name = value; }
        public int Bytee { get => bytee; set => bytee = value; }

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

                    fileread(name, bytee);
                }
                else
                {



                    Console.WriteLine(data);

                }
            }

        }
    }
}
