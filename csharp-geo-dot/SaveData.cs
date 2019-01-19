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
            this.PointList = new List<Point>();
            this.LineList = new List<Line>();
        }

        /// <summary>
        /// Gets マウスでクリックしたポイント。
        /// </summary>
        public List<Point> PointList { get; private set; }

        /// <summary>
        /// Gets 線が引かれている２点間のリスト。
        /// </summary>
        public List<Line> LineList { get; private set; }
    }
}
