using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CBIR
{
    public partial class MainForm : Form
    {
        private CV cv;
        private List<Image> images;
        private string path;
        public MainForm()
        {
            InitializeComponent();
            cv = new CV();
            path = @"C:\CBIR-test";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            images = OpenImagesFromFolder(path);
            GeneratePictureBoxRowForImages(images, panel);
            pathLabel.Text = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var image = OpenImage();
            
            if (image == null)
                return;

            pictureBox1.Image = image.Bitmap;

            var similarImages = cv.FindSimilarImages(image, images);
            var firstSimilarImage = similarImages.First();

            pictureBox2.Image = firstSimilarImage.Image.Bitmap;

            similarityLabel.Text = firstSimilarImage.GetSimilarityAsPercentString();
            similarityProgressBar.Value = firstSimilarImage.GetSimilarityAsPercent();

            GeneratePictureBoxRowForImages(similarImages, resultsPanel);
        }

        private void changeFolderButton_Click(object sender, EventArgs e)
        {
            images = OpenImagesFromFolder();
            pathLabel.Text = path;
        }

        private List<Image> OpenImagesFromFolder(string path = null)
        {
            List<string> files;

            if (path == null)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                this.path = fbd.SelectedPath;
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
                dlg.Title = "Otvori sliku po kojoj želiš pretraživati: ";

                return (dlg.ShowDialog() == DialogResult.OK) 
                    ? new Image(dlg.FileName)
                    : null;
            }
        }

        private void GeneratePictureBoxRowForImages(List<Image> images, FlowLayoutPanel container)
        {
            container.Controls.Clear();

            images.ForEach(i =>
            {
                container.Controls.Add(new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(60, 60),
                    Image = i.Bitmap
                });
            });
        }

        private void GeneratePictureBoxRowForImages(List<WeightedImage> images, FlowLayoutPanel container)
        {
            container.Controls.Clear();

            images.ForEach(i =>
            {
                container.Controls.Add(new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown,
                    Size = new Size(60, 120),
                    Controls = {
                        new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = new Size(60, 60),
                            Image = i.Image.Bitmap
                        },
                        new ProgressBar
                        {
                          Size = new Size(60, 20),
                          Value = i.GetSimilarityAsPercent()
                        },
                        new Label
                        {
                            Text = i.GetSimilarityAsPercentString(),
                            Size = new Size(60, 20),
                            TextAlign = ContentAlignment.MiddleCenter
                        }
                    }
                });
            });
        }
    }
}
