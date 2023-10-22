using System.Net.Sockets;
using System.IO;

namespace Iniserver
{
    class iniserver
    {
        public iniserver()
        {
            
        }
        public iniserver(StreamWriter i)
        {
            this._writer = i;
        }
        private StreamWriter _writer;   

        public StreamWriter Writer
        {
            get { return _writer; }
            set { _writer = value; }
        }

        private TcpListener _listener;

        public TcpListener listener
        {
            get { return _listener; }

            set
            {
                if (_listener == null)
                {
                    _listener = value;

                }
            }
        }

        private TcpClient _client;

        public TcpClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        private NetworkStream _ns;

        public NetworkStream ns
        {
            get { return _ns; }

            set
            {
                if (_ns == null)
                    _ns = value;
            }
        }
    }
}
