namespace Grayscale.GeoDot
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// ピクセルの２次元配列。
    /// </summary>
    public class PixelBoard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PixelBoard"/> class.
        /// </summary>
        public PixelBoard()
        {
            this.Width = 128;
            this.Height = 128;

            this.Bitmap = new Bitmap(this.Width, this.Height);
            this.PointList = new List<Point>();
            this.RefreshImage();
        }

        /// <summary>
        /// Gets or sets マウスでクリックしたポイント。
        /// </summary>
        public List<Point> PointList { get; set; }

        /// <summary>
        /// Gets or sets 横幅。
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets 縦幅。
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets 画像データ。
        /// </summary>
        public Bitmap Bitmap { get; private set; }

        /// <summary>
        /// 点を追加する。
        /// </summary>
        /// <param name="centerX">横位置。</param>
        /// <param name="centerY">縦位置。</param>
        public void AddPoint(int centerX, int centerY)
        {
            this.PointList.Add(new Point(centerX, centerY));
            this.RefreshImage();
        }

        /// <summary>
        /// 関節点を描画します。
        /// </summary>
        /// <param name="centerX">横位置。</param>
        /// <param name="centerY">縦位置。</param>
        public void DrawJointPoint(int centerX, int centerY)
        {
            Color color = Color.Gray;

            // 上辺
            for (int x = centerX - 2; x < centerX + 3; x++)
            {
                this.Bitmap.SetPixel(x, centerY - 2, color);
            }

            // 右辺
            for (int y = centerY - 2; y < centerY + 3; y++)
            {
                this.Bitmap.SetPixel(centerX + 2, y, color);
            }

            // 下辺
            for (int x = centerX - 2; x < centerX + 3; x++)
            {
                this.Bitmap.SetPixel(x, centerY + 2, color);
            }

            // 左辺
            for (int y = centerY - 2; y < centerY + 3; y++)
            {
                this.Bitmap.SetPixel(centerX - 2, y, color);
            }
        }

        /// <summary>
        /// 画像の再描画。
        /// </summary>
        public void RefreshImage()
        {
            // 白で塗りつぶす。
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    this.Bitmap.SetPixel(x, y, Color.White);
                }
            }

            foreach (var point in this.PointList)
            {
                this.DrawJointPoint(point.X, point.Y);
            }
        }
    }
}
