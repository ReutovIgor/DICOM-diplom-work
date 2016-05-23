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
    class Program
    {
        static void Main(string[] args)
        {
            DeviceListener deviceListener = new DeviceListener(8000);
            Thread thread = new Thread(new ThreadStart(deviceListener.listen));
            thread.Start();
        }
    }
}
