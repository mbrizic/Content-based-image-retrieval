using System;
using System.Globalization;

namespace CBIR
{
    public class WeightedImage
    {
        public Image Image;
        public double Similarity;

        public string GetSimilarityAsString(int numberOfDecimals = 5)
        {
            return this.Similarity.ToString(CultureInfo.CurrentCulture).Substring(0, numberOfDecimals);
        }
    }
}
