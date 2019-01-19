namespace Grayscale.GeoDot
{
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

            // 白で塗りつぶす。
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    this.Bitmap.SetPixel(x, y, Color.White);
                }
            }
        }

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
        /// 箱を作成する。
        /// </summary>
        /// <param name="centerX">横位置。</param>
        /// <param name="centerY">縦位置。</param>
        public void CreateBox(int centerX, int centerY)
        {
            // 上辺
            for (int x = centerX - 2; x < centerX + 2; x++)
            {
                this.Bitmap.SetPixel(x, centerY - 2, Color.Black);
            }

            // 右辺
            for (int y = centerY - 2; y < centerY + 2; y++)
            {
                this.Bitmap.SetPixel(centerX+2, y, Color.Black);
            }

            // 下辺
            for (int x = centerX - 2; x < centerX + 2; x++)
            {
                this.Bitmap.SetPixel(x, centerY + 2, Color.Black);
            }

            // 左辺
            for (int y = centerY - 2; y < centerY + 2; y++)
            {
                this.Bitmap.SetPixel(centerX - 2, y, Color.Black);
            }
        }
    }
}
