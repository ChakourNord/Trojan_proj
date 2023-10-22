using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Client;


namespace main
{
    class Program
    {


        static void Main(string[] args)
        {
            

            
            List<object> data = new List<object>() { "192.168.178.46", 4433 };
            client fclient = new client();
            fclient.startclient(data.ToArray());
            




        }
        private static void append()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            bool bol = true;
            int i = 2;
            //Console.WriteLine(u);
            do
            {
                
                CultureInfo culture = new CultureInfo("de-DE");
                var codePage = culture.TextInfo.ANSICodePage;
                StreamWriter sw = File.AppendText(@$"D:\Users\chako\Desktop\tmp\cookie1.txt");
                byte[] st = File.ReadAllBytes(@$"D:\Users\chako\Desktop\tmp\cookie{i}.txt");
                string path = Encoding.GetEncoding(codePage).GetString(st);
                sw.WriteLine(path);
                sw.Close();
                Console.WriteLine("ok");
                
                i++;
                if(i == 5)
                {
                    bol = false;
                    Console.WriteLine("fin");
                }
            } while (bol);
        }

    }
}

