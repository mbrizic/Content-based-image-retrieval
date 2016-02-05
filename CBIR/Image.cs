using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace CBIR
{
    public class Image : Image<Bgr, byte>
    {
        public Image<Gray, byte>[] Channels;
        public DenseHistogram Histogram;

        public Image(Bitmap bitmap)
            : base(bitmap)
        {
            this.Channels = this.Split();
            this.Histogram = GetBgrHistogram();
        }

        public Image(string imageUrl)
            : this(new Bitmap(imageUrl)) {}

        private DenseHistogram GetBgrHistogram()
        {
            var binSize = 256;
            var range = new RangeF(0, 256);

            var hist = new DenseHistogram(
                new[] { binSize, binSize, binSize },
                new[] { range, range, range });

            hist.Calculate(Channels, false, null);

            return hist;
        }

        public void Show()
        {
            var viewer = new ImageViewer(this);
            viewer.ShowDialog();
        }
    }
}
