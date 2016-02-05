using System.Collections.Generic;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace CBIR
{
    public class CV
    {
        private const double SimilarityLimit = 0.01;

        public List<WeightedImage> FindSimilarImages(Image query, List<Image> images)
        {
            return images.Select(image => new WeightedImage
            {
                Image = image,
                Similarity = GetImageSimilarity(query, image)
            })
            .OrderByDescending(i => i.Similarity) 
            .Where(i => i.Similarity > SimilarityLimit)
            .ToList();
        }

        private double GetImageSimilarity(Image first, Image second, HistogramCompMethod method = HistogramCompMethod.Correl)
        {
            return CvInvoke.CompareHist(first.Histogram, second.Histogram, method);
        }
    }
}
