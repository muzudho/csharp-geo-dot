namespace Grayscale.GeoDot
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Toml形式に入出力することを想定。
    /// </summary>
    public class SaveData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveData"/> class.
        /// </summary>
        public SaveData()
        {
            this.PointList = new List<GeoPoint>();
            this.LineList = new List<GeoLine>();
        }

        /// <summary>
        /// Gets or sets マウスでクリックしたポイント。
        /// </summary>
        public List<GeoPoint> PointList { get; set; }

        /// <summary>
        /// Gets or sets 線が引かれている２点間のリスト。
        /// </summary>
        public List<GeoLine> LineList { get; set; }
    }
}
