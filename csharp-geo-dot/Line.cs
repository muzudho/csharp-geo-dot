namespace Grayscale.GeoDot
{
    using System.Drawing;

    /// <summary>
    /// 線が引かれている２点間。
    /// </summary>
    public class Line
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="a">始点。</param>
        /// <param name="b">終点。</param>
        public Line(Point a, Point b)
        {
            this.PointA = a;
            this.PointB = b;
        }

        /// <summary>
        /// Gets 始点。
        /// </summary>
        public Point PointA { get; private set; }

        /// <summary>
        /// Gets 終点。
        /// </summary>
        public Point PointB { get; private set; }
    }
}
