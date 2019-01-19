namespace Grayscale.GeoDot
{
    using System;

    /// <summary>
    /// セーブデータ用の点。
    /// </summary>
    [Serializable]
    public class GeoPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPoint"/> class.
        /// </summary>
        public GeoPoint()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPoint"/> class.
        /// </summary>
        /// <param name="left">横位置。</param>
        /// <param name="top">縦位置。</param>
        public GeoPoint(int left, int top)
        {
            this.X = left;
            this.Y = top;
        }

        /// <summary>
        /// Gets or sets 横位置。
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets 縦位置。
        /// </summary>
        public int Y { get; set; }
    }
}
