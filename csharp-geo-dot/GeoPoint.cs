namespace Grayscale.GeoDot
{
    using System;
    using System.Drawing;

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
        /// <param name="x">横位置。</param>
        /// <param name="y">縦位置。</param>
        public GeoPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
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
