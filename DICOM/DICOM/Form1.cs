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
using openDicom.Registry;
using openDicom.File;
using openDicom.DataStructure;
using openDicom.DataStructure.DataSet;
using openDicom.Image;


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
            
            DataElementDictionary dataElementDictionary = new DataElementDictionary ();
            UidDictionary uidDictionary = new UidDictionary();
            string elementsLOcation = @"C:\Users\Vextrell\Desktop\DICOM\DICOM\DICOM-LIbrary\opendicom-sharp\dd\dicom-elements-2007.dic";
            string uidsLocation = @"C:\Users\Vextrell\Desktop\DICOM\DICOM\DICOM-LIbrary\opendicom-sharp\dd\dicom-uids-2007.dic";
            try
            {
                dataElementDictionary.LoadFrom(elementsLOcation,
                    DictionaryFileFormat.BinaryFile);
                uidDictionary.LoadFrom(uidsLocation,
                    DictionaryFileFormat.BinaryFile);
            }
            catch (Exception dictionaryException)
            {
                Console.Error.WriteLine("Problems processing dictionaries:\n" +
                    dictionaryException);
                return;
            }
            
            AcrNemaFile file = null;
            try
            {
                if (DicomFile.IsDicomFile(fileName))
                    file = new DicomFile(fileName, false);
                else if (AcrNemaFile.IsAcrNemaFile(fileName))
                    file = new AcrNemaFile(fileName, false);
                else
                    Console.Error.WriteLine("Selected file is wether a " +
                        "DICOM nor an ACR-NEMA file.");
            }
            catch (Exception dicomFileException)
            {
                Console.Error.WriteLine("Problems processing DICOM file:\n" +
                    dicomFileException);
                return;
            }
            bool flag = file.HasPixelData;
            openDicom.Image.PixelData obraz = new openDicom.Image.PixelData(file.DataSet);

            byte[][] pixelimage = obraz.ToBytesArray();
            int dicomHeight = obraz.Rows;
            int dicomWidth = obraz.Columns;
            //obraz

            List<byte> bytes = new List<byte>(); // this list should be filled with values
            int width = 100;
            int height = 100;
            int bpp = 24;

            Bitmap bmp = new Bitmap(width, height);
            //bmp = new Bitmap()
            for (int y = 0; y < dicomHeight; y++)
            {
                for (int x = 0; x < dicomWidth; x++)
                {
                    int i = ((y * dicomWidth) + x) * (bpp / 8);
                    if (bpp == 24) // in this case you have 3 color values (red, green, blue)
                    {
                        // first byte will be red, because you are writing it as first value
                        byte r = pixelimage[i][0];
                        byte g = pixelimage[i + 1][0];
                        byte b = pixelimage[i + 2][0];
                        Color color = Color.FromArgb(r, g, b);
                        bmp.SetPixel(x, y, color);
                    }

                }
            }
            
        }
    }
}
