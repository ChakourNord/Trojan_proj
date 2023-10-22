using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Befehle
{
    class befehle
    {

        public void b1(string command)
        {


            
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd";
            cmd.StartInfo.Arguments = @"/c" + command ;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            string itz = cmd.StandardOutput.ReadToEnd();
            Console.WriteLine(itz);
            Console.WriteLine("\n--END--");

        }
    }
}
