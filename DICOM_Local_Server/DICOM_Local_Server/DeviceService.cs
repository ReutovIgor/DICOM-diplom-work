using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace DICOM_Local_Server
{
    class DeviceListener : TcpListenerService
    {
        public DeviceListener(int port): base(port)
        {
            base.onConnection += new ClientConnection(listenClient);
        }

        public void listenClient()
        {
            TcpClient client = base.getClient();
            DeviceClient deviceClient = new DeviceClient(client);
            Thread thread = new Thread(new ThreadStart(deviceClient.processRequest));
            thread.Start();
            Thread.Sleep(1);
        }
    }

    class DeviceClient: TcpClientService
    {
        string path;
        public DeviceClient(TcpClient client):base(client)
        {
            this.path = AppDomain.CurrentDomain.BaseDirectory;
            this.path += "dicomFiles\\";
        }

        public override void processRequest()
        {
            if (base.canRead())
            {
                byte[] descLength = base.getInputStream(0, 4);
                int descSize = BitConverter.ToInt32(descLength, 0);

                byte[] desc = base.getInputStream(0, descSize);
                string description = System.Text.Encoding.Unicode.GetString(desc);
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                Dictionary<string, dynamic> descriptionObject = (Dictionary<string, dynamic>)serializer.DeserializeObject(description);

                //decode file
                int size = Convert.ToInt32(descriptionObject["FileSize"]);
                byte[] file = base.getInputStream(0, size);
                File.WriteAllBytes(this.path + descriptionObject["FileName"], file);

                descriptionObject.Add("FilePath", this.path);
                DB_Controll.openConnection();
                var authResponse = DB_Controll.SendRequest("check_device", descriptionObject);
                var patientResponse = DB_Controll.SendRequest("get_patienId", descriptionObject);
                if (authResponse.Keys.Count == 1 && patientResponse.Keys.Count == 1)
                {
                    var addResponse = DB_Controll.SendRequest("add_file", descriptionObject);
                    if (addResponse.Keys.Count == 1)
                    {
                        var a = addResponse[0];
                        
                        var requestObject = new Dictionary<string, dynamic>()
                        {
                            {"fileId", addResponse[0]["id"]},
                            {"patienId", patientResponse[0]["id"]}
                        };
                        var addResponse2 = DB_Controll.SendRequest("connect_file_patient", requestObject);
                    }
                }
                DB_Controll.closeConnection();
            }

            base.closeConnection();
        }
    }
}
