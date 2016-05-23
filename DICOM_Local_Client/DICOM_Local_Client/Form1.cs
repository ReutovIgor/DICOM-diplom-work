using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Web.Script.Serialization;

namespace DICOM_Local_Client
{
    public partial class Form1 : Form
    {
        string filePath = "";
        string fileName = "";
        string deviceSN = "";
        string deviceUsername = "";
        string devicePassword = "";
        public Form1()
        {
            InitializeComponent();
            this.FilePath_textBox.Text = "C:\\Users\\Project\\Documents\\Visual Studio 2013\\Projects\\DICOM_Local_Client\\DICOM_Local_Client\\bin\\Debug\\DCM files\\CR-MONO1-10-chest";
            this.filePath = "C:\\Users\\Project\\Documents\\Visual Studio 2013\\Projects\\DICOM_Local_Client\\DICOM_Local_Client\\bin\\Debug\\DCM files\\CR-MONO1-10-chest";
            this.fileName = Path.GetFileName(filePath);
            this.PatienName.Text = "Alex";
            this.PatinetSurname.Text = "Brown";
            this.PatientUsername.Text = "Alex_Brown_1989";
            this.deviceSN = "X-ray1";
            this.deviceUsername = "XR1";
            this.devicePassword = "ray1";
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            filePath = dialog.FileName;
            fileName = Path.GetFileName(filePath);
        }

        private void SendFileButton_Click(object sender, EventArgs e)
        {
            //Get file in bytes
            Stream fileStream = File.OpenRead(this.filePath);
            byte[] fileBuffer = new byte[fileStream.Length];
            fileStream.Read(fileBuffer, 0, (int)fileStream.Length);

            //compose request description and conver to byte array
            Dictionary<string, dynamic> clientDescription = new Dictionary<string, dynamic>();
            clientDescription.Add("Name", this.PatienName.Text);
            clientDescription.Add("Surname", this.PatinetSurname.Text);
            clientDescription.Add("UserName", this.PatientUsername.Text);
            clientDescription.Add("DoB", this.PatientDoB.Value.Date.ToShortDateString());
            clientDescription.Add("FileName", this.fileName);
            clientDescription.Add("FileSize", fileBuffer.Length.ToString());
            var date = DateTime.Now;
            clientDescription.Add("FileDate", date.ToShortDateString());
            clientDescription.Add("DeviceSN", this.deviceSN);
            clientDescription.Add("DeviceUsername", this.deviceUsername);
            clientDescription.Add("DevicePassword", this.devicePassword);
            

            string Clientdescritption = (new JavaScriptSerializer()).Serialize(clientDescription);
            byte[] description = System.Text.Encoding.Unicode.GetBytes(Clientdescritption);
            //store desc length as byte array
            byte[] descLength_byte = BitConverter.GetBytes(description.Length);

            string a = System.Text.Encoding.Unicode.GetString(description);

            //compose request stream
            byte[] composeRequest = new byte[description.Length + fileBuffer.Length + descLength_byte.Length];
            System.Buffer.BlockCopy(descLength_byte, 0, composeRequest, 0, descLength_byte.Length);
            System.Buffer.BlockCopy(description, 0, composeRequest, descLength_byte.Length, description.Length);
            System.Buffer.BlockCopy(fileBuffer, 0, composeRequest, descLength_byte.Length + description.Length, fileBuffer.Length);

            //send the file to the server
            TcpClient client = new TcpClient("127.0.0.1", 8000);
            NetworkStream networkStream = client.GetStream();
            networkStream.Write(composeRequest, 0, composeRequest.Length);
            networkStream.Close();
        }
    }
}
