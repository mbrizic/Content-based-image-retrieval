using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CBIR
{
    public partial class MainForm : Form
    {
        private CV cv;
        private List<Image> images; 
        public MainForm()
        {
            InitializeComponent();
            cv = new CV();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            images = OpenImagesFromFolder(@"C:\CBIR-test");
            GeneratePictureBoxRow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var image = OpenImage();
            
            if (image == null)
                return;

            pictureBox1.Image = image.Bitmap;

            var similarImage = cv.FindSimilarImage(image, images);
            pictureBox2.Image = similarImage.Bitmap;
        }

        private List<Image> OpenImagesFromFolder(string path = null)
        {
            List<string> files;

            if (path == null)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                files = Directory.GetFiles(fbd.SelectedPath).ToList();
            }
            else
            {
                files = Directory.GetFiles(path).ToList();
            }

            return files.Select(f => new Image(f))
                .ToList();
        }

        private Image OpenImage()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    return new Image(dlg.FileName);
                }
                else
                {
                    return null;
                }
            }
        }

        private void GeneratePictureBoxRow()
        {
            images.ForEach(i =>
            {
                panel.Controls.Add(new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(62, 62),
                    Image = i.Bitmap
                });
            });
        }
    }
}
