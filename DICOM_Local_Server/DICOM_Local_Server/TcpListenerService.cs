using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace DICOM_Local_Server
{
    public abstract class TcpListenerService
    {
        private int port;
        private TcpListener listener;
        bool isActive;
        public delegate void ClientConnection();

        public event ClientConnection onConnection;

        public TcpListenerService(int port)
        {
            this.port = port;
            this.isActive = true;
        }

        public void listen()
        {
            this.listener = new TcpListener(IPAddress.Any, port);
            this.listener.Start();
            while (this.isActive)
            {
                onConnection();
            }
        }

        public void setListener(ClientConnection onConnection)
        {
            this.onConnection = onConnection;
        }

        public TcpClient getClient()
        {
            return this.listener.AcceptTcpClient();
        }
    }

    public abstract class TcpClientService
    {
        TcpClient client;
        NetworkStream input;

        public TcpClientService(TcpClient client)
        {
            this.client = client;
            this.input = client.GetStream();
            this.client.ReceiveBufferSize = 1000000;
        }

        public bool canRead()
        {
            return this.input.CanRead;
        }

        public byte[] getInputStream(int offset, int size)
        {
            byte[] a = new byte[size];
            this.input.Read(a, offset, size);
            return a;
        }

        public void closeConnection()
        {
            this.client.Close();
        }

        public abstract void processRequest();
    }
}
