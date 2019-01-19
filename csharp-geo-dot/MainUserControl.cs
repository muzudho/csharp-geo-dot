namespace Grayscale.GeoDot
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// ユーザーコントロール。
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        /// <summary>
        /// マウスでクリックしたポイント。
        /// </summary>
        private Point point;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainUserControl"/> class.
        /// </summary>
        public MainUserControl()
        {
            this.InitializeComponent();
            this.PixelBoard = new PixelBoard();
        }

        /// <summary>
        /// Gets ピクセルの２次元配列。
        /// </summary>
        public PixelBoard PixelBoard { get; private set; }

        private void MainUserControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(0, 0, this.PixelBoard.Width, this.PixelBoard.Height));

            // マウスで押下した点。
            if (this.point != null)
            {
                e.Graphics.DrawEllipse(Pens.Red, new Rectangle(this.point.X - 2, this.point.Y - 2, 4, 4));
            }

            // ピクセルの２次元配列。
            for (int y = 0; y < this.PixelBoard.Height; y++)
            {
                for (int x = 0; x < this.PixelBoard.Width; x++)
                {
                    var pen = new Pen(this.PixelBoard.Board[y][x]);
                    e.Graphics.DrawRectangle(pen, new System.Drawing.Rectangle(x, y, 1, 1));
                }
            }
        }

        private void MainUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.point = new Point(e.X, e.Y);
            this.PixelBoard.CreateBox(e.X, e.Y);
            this.Refresh();
        }
    }
}
