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
        private string path;
        public MainForm()
        {
            InitializeComponent();
            cv = new CV();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            images = path != null ?
                OpenImagesFromFolder(path) : 
                OpenImagesFromFolder();

            pathLabel.Text = "Path: " + path;
            similarityProgressBar.Value = 0;
            similarityLabel.Text = "";

            GeneratePictureBoxRowForImages(images, panel);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var image = OpenImage();
            
            if (image == null)
                return;

            queryImagePictureBox.Image = image.Bitmap;

            var similarImages = cv.FindSimilarImages(image, images);
            var mostSimilarImage = similarImages.First();

            mostSimilarImagePictureBox.Image = mostSimilarImage.Image.Bitmap;

            similarityLabel.Text = mostSimilarImage.GetSimilarityAsPercentString();
            similarityProgressBar.Value = mostSimilarImage.GetSimilarityAsPercent();

            GeneratePictureBoxRowForImages(similarImages, resultsPanel);
        }

        private void changeFolderButton_Click(object sender, EventArgs e)
        {
            images = OpenImagesFromFolder();
            GeneratePictureBoxRowForImages(images, panel);
            pathLabel.Text = "Path: " + path;
        }

        private List<Image> OpenImagesFromFolder(string path = null)
        {
            List<string> files;

            if (path == null)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Choose images folder you want to perform search on: ";
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
                dlg.Title = "Choose query image: ";

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
