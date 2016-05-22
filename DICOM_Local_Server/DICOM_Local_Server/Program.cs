using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;
using System.Web.Script.Serialization;

namespace DICOM_Local_Server
{
    public class TCPListenerServer
    {
        private int port;
        private TcpListener listener;
        bool isActive;

        public TCPListenerServer(int port)
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
                TcpClient client = this.listener.AcceptTcpClient();
                DeviceClient deviceClient = new DeviceClient(client);
                Thread thread = new Thread(new ThreadStart(deviceClient.processRequest));
                thread.Start();
                Thread.Sleep(1);
            }
        }
    }

    public class DeviceClient
    {
        TcpClient device;
        NetworkStream input;
        //StreamWriter output;

        public DeviceClient (TcpClient client)
        {
            this.device = client;
            this.input = client.GetStream();
            this.device.ReceiveBufferSize = 1000000;
        }

        public void processRequest()
        {
            if (this.input.CanRead)
            {

                /*
                byte[] bytes = new byte[this.device.ReceiveBufferSize];
                this.input.Read(bytes, 0, this.device.ReceiveBufferSize);

                byte[] descr = new byte[260];
                System.Buffer.BlockCopy(bytes, 4, descr, 0, 260);
                string description3 = System.Text.Encoding.Unicode.GetString(descr);
                */


                byte[] descLength = new byte[4];
                this.input.Read(descLength, 0, 4);
                int descSize = BitConverter.ToInt32(descLength,0);

                byte[] desc = new byte[descSize];
                byte[] a = new byte[descSize];
                this.input.Read(a, 0, descSize);
                
                //System.Buffer.BlockCopy(a, 4, desc, 0, descSize);
                string description2 = System.Text.Encoding.Unicode.GetString(a);
                //string description = System.Text.Encoding.Unicode.GetString(desc);

                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                Dictionary<string, dynamic> descriptionObject = (Dictionary<string, dynamic>)serializer.DeserializeObject(description2);

                //decode file
                byte[] file = new byte[descriptionObject["FileSize"]];
                this.input.Read(file, 0, descriptionObject["FileSize"]);
                string path = "C:\\Users\\Project\\Documents\\Visual Studio 2013\\Projects\\DICOM_Local_Client\\DICOM_Local_Client\\bin\\Debug\\DCM files received\\CR-MONO1-10-chest_1111";
                File.WriteAllBytes(path, file);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TCPListenerServer deviceListener = new TCPListenerServer(8000);
            Thread thread = new Thread(new ThreadStart(deviceListener.listen));
            thread.Start();
        }
    }
}
