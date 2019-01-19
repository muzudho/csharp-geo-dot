namespace Grayscale.GeoDot
{
    using System.Drawing;

    /// <summary>
    /// オブジェクト作成など。
    /// </summary>
    public static class GeoHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPoint"/> class.
        /// </summary>
        /// <param name="point">点。</param>
        /// <returns>セーブデータ用の点。</returns>
        public static GeoPoint CreateGeoPoint(Point point)
        {
            return new GeoPoint(point.X, point.Y);
        }

        /// <summary>
        /// 変換。
        /// </summary>
        /// <param name="point">セーブデータ用の点。</param>
        /// <returns>描画用の点。</returns>
        public static Point ToPoint(GeoPoint point)
        {
            return new Point(point.X, point.Y);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLine"/> class.
        /// </summary>
        /// <param name="begin">始点。</param>
        /// <param name="end">終点。</param>
        /// <returns>２点間の線。</returns>
        public static GeoLine CreateGeoLine(Point begin, Point end)
        {
            return new GeoLine(GeoHelper.CreateGeoPoint(begin), GeoHelper.CreateGeoPoint(end));
        }
    }
}
