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
        /// <param name="p">点。</param>
        /// <returns>セーブデータ用の点。</returns>
        public static GeoPoint CreateGeoPoint(Point p)
        {
            return new GeoPoint(p.X, p.Y);
        }

        /// <summary>
        /// 変換。
        /// </summary>
        /// <param name="gp">セーブデータ用の点。</param>
        /// <returns>描画用の点。</returns>
        public static Point ToPoint(GeoPoint gp)
        {
            return new Point(gp.X, gp.Y);
        }
    }
}
