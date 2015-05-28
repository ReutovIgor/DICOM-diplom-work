using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvilDICOM;
using EvilDICOM.Core;
using EvilDICOM.Core.Dictionaries;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Extensions;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO;
using EvilDICOM.Core.Logging;
using EvilDICOM.Core.Modules;
using EvilDICOM.Core.Selection;



namespace DICOM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = " ";
            OpenFileDialog diag = new OpenFileDialog();
            DialogResult result = diag.ShowDialog();
            if(result == DialogResult.OK)
            {
                fileName = diag.FileName;
            }

            var file = DICOMObject.Read(fileName);
            var stream = file.PixelStream;
            Image img = Image.FromStream(stream);
            Bitmap bt = new Bitmap(stream);
            this.pictureBox1.Image = bt;
            //var imgFile = new ImageMatrix(fileName);
            //pictureBox1.Image = imgFile.GetImage(0);
            
        }


    }
}
