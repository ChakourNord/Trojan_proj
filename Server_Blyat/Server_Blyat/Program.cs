using Server;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using Iniserver;
using System;
using System.Globalization;

namespace Server_Blyat
{
    class Program
    {
        static void Main(string[] args)
        {

            //FileStream file = new FileStream(@"D:\Users\chako\Desktop\Neuer Ordner\Cookie.db", FileMode.Open);
            /*Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string u = File.ReadAllText(@"D:\Users\chako\Desktop\Neuer Ordner\Cookie.sys");

            //Console.WriteLine(u);
            CultureInfo culture = new CultureInfo("de-DE");
            var codePage = culture.TextInfo.ANSICodePage;
            File.WriteAllText(@"D:\Users\chako\Desktop\Neuer Ordner\Cookiekjkhjk", u, Encoding.GetEncoding(codePage));
            Console.WriteLine("jaaaaaaaaaaaaaaaaaaaaaaa");*/

            
            server server = new server();
            IPAddress ipp = IPAddress.Parse("192.168.178.46");
            int port = 4433;
            List<object> list = new List<object>() { ipp, port };
            

            server.startserver(list.ToArray());
            




        }





    }


}






