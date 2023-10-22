using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace filesend
{
    class Filesend
    {
        public byte[] Data { get; set; }
        public string namef { get; set; }

        public string path { get; set; }

       
        public string bytes()
        {
            Data = File.ReadAllBytes(path);
            string bytesg = Encoding.UTF8.GetString(Data);
            return bytesg;
        }
        public void filesend()
        {
           
           
        }
    }
}
