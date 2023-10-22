using System.Net.Sockets;
using System.IO;

namespace Networkstr
{   //listener klasse
    class networkstr
    {

        private TcpClient client1;

        public TcpClient client
        {
            get { return client1; }

            set
            {
               if(client1 == null)
                {
                    client1 = value;
                }
            }
        }

        public StreamWriter streamre { get; set; }

        private NetworkStream str;

        public NetworkStream _Stream
        { 
            get { return str; }

            set { str = value; }


        }

        
        private NetworkStream _stream;

        public NetworkStream stream
        {
            
            get { return _stream; }
            set { _stream = value; }
        }

    }
}
