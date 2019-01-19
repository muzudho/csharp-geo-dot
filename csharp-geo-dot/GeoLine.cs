﻿namespace Grayscale.GeoDot
{
    using System.Drawing;

    /// <summary>
    /// 線が引かれている２点間。
    /// </summary>
    public class GeoLine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLine"/> class.
        /// </summary>
        public GeoLine()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLine"/> class.
        /// </summary>
        /// <param name="a">始点。</param>
        /// <param name="b">終点。</param>
        public GeoLine(GeoPoint a, GeoPoint b)
        {
            this.PointA = a;
            this.PointB = b;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLine"/> class.
        /// </summary>
        /// <param name="a">始点。</param>
        /// <param name="b">終点。</param>
        public GeoLine(Point a, Point b)
        {
            this.PointA = new GeoPoint(a);
            this.PointB = new GeoPoint(b);
        }

        /// <summary>
        /// Gets or sets 始点。
        /// </summary>
        public GeoPoint PointA { get; set; }

        /// <summary>
        /// Gets or sets 終点。
        /// </summary>
        public GeoPoint PointB { get; set; }
    }
}
