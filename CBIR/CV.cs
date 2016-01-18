using System.Collections.Generic;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace CBIR
{
    public class CV
    {
        public List<WeightedImage> FindSimilarImages(Image query, List<Image> images)
        {
            return images.Select(image => new WeightedImage
            {
                Image = image,
                Similarity = GetImageSimilarity(query, image)
            })
            .OrderByDescending(i => i.Similarity)
            .ToList();
        }

        private double GetImageSimilarity(Image first, Image second, HistogramCompMethod method = HistogramCompMethod.Correl)
        {
            return CvInvoke.CompareHist(first.Histogram, second.Histogram, method);
        }
    }
}
