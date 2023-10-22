using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;

namespace Server_blyat
{
    class Server {

        public static IPAddress ipAd;

        // use local m/c IP address, and 
        // use the same in the client

        /* Initializes the Listener */
        public static TcpListener myList;

        /* Start Listeneting at the specified port */

        public static Socket s;
        public static void startserver()
        {
            ipAd = IPAddress.Parse("192.168.178.46");

            // use local m/c IP address, and 
            // use the same in the client

            /* Initializes the Listener */
            TcpListener myList = new TcpListener(ipAd, 4444);

            /* Start Listeneting at the specified port */
            myList.Start();

            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :"+myList.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");

            Socket s = myList.AcceptSocket();
            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
            bool a = true;
            while (a)
            {
                byte[] b = new byte[100];
                int k = s.Receive(b);


                for (int i = 0; i < k; i++)
                {
                    Console.Write(Convert.ToChar(b[i]));

                }
                Console.WriteLine();
                if (b[0] == '-')
                {
                    a = false;
                    Console.WriteLine("ist zuuu");
                }

            }

            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
            /* clean up */
            s.Close();
            myList.Stop();

        }
        
        public static void auchsend()
        {
            Thread threadsend = new Thread(auchsend);
            threadsend.Start();

            while (true)
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes(Console.ReadLine()));
            }
            
        }

    }



}
 
