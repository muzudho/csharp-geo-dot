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
            this.Board = new Color[this.Height][];
            for (int y = 0; y < this.Height; y++)
            {
                this.Board[y] = new Color[this.Width];

                for (int x = 0; x < this.Width; x++)
                {
                    this.Board[y][x] = Color.White;
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
        /// Gets ピクセルの２次元配列。
        /// </summary>
        public Color[][] Board { get; private set; }

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
                this.Board[centerY - 2][x] = Color.Black;
            }
        }
    }
}
