using System;
using System.Globalization;

namespace CBIR
{
    public class WeightedImage
    {
        public Image Image;
        public double Similarity;

        public string GetSimilarityAsPercentString(int numberOfDecimals = 5)
        {
            return GetSimilarityAsPercent().ToString() + "%";
        }

        public int GetSimilarityAsPercent()
        {
            return (int) (this.Similarity * 100);
        }
    }
}
