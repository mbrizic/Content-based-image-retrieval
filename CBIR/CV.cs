using System.Collections.Generic;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace CBIR
{
    public class CV
    {
        public Image FindSimilarImage(Image query, List<Image> images)
        {
            return images.Select(image => new WeightedImage
            {
                Image = image,
                Similarity = GetImageSimilarity(query, image)
            })
            .OrderByDescending(i => i.Similarity)
            .First()
            .Image;
        }

        private double GetImageSimilarity(Image first, Image second, HistogramCompMethod method = HistogramCompMethod.Correl)
        {
            return CvInvoke.CompareHist(first.Histogram, second.Histogram, method);
        }

        private class WeightedImage
        {
            public Image Image;
            public double Similarity;
        }
    }
}
