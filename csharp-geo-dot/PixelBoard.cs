namespace Grayscale.GeoDot
{
    using System;
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
            this.HoverPoint = default(Point);
            this.PointList = new List<Point>();
            this.RefreshImage();
        }

        /// <summary>
        /// Gets マウスカーソルがあるポイント。
        /// </summary>
        public Point HoverPoint { get; private set; }

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
        /// マウスカーソルがある位置。
        /// </summary>
        /// <param name="center">中央位置。</param>
        public void SetHoverPoint(Point center)
        {
            this.HoverPoint = center;
            this.RefreshImage();
        }

        /// <summary>
        /// マウスカーソルが重なっていると判定するかどうか。
        /// </summary>
        /// <param name="p">関節点。</param>
        /// <returns>マウスカーソルと重なっている。</returns>
        public bool IsHoverPoint(Point p)
        {
            if (this.HoverPoint.X - 2 < p.X && p.X < this.HoverPoint.X + 2 &&
                      this.HoverPoint.Y - 2 < p.Y && p.Y < this.HoverPoint.Y + 2)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 関節点を描画します。
        /// </summary>
        /// <param name="center">中央位置。</param>
        public void DrawJointPoint(Point center)
        {
            Color color = Color.Gray;
            if (this.IsHoverPoint(center))
            {
                color = Color.Green;
            }

            // 上辺
            for (int x = center.X - 2; x < center.X + 3; x++)
            {
                this.Bitmap.SetPixel(x, center.Y - 2, color);
            }

            // 右辺
            for (int y = center.Y - 2; y < center.Y + 3; y++)
            {
                this.Bitmap.SetPixel(center.X + 2, y, color);
            }

            // 下辺
            for (int x = center.X - 2; x < center.X + 3; x++)
            {
                this.Bitmap.SetPixel(x, center.Y + 2, color);
            }

            // 左辺
            for (int y = center.Y - 2; y < center.Y + 3; y++)
            {
                this.Bitmap.SetPixel(center.X - 2, y, color);
            }
        }

        /// <summary>
        /// 関節点と、関節点を直線で結びます。
        /// </summary>
        /// <param name="a">関節点a。</param>
        /// <param name="b">関節点b。</param>
        public void DrawLine(Point a, Point b)
        {
            var minX = Math.Min(a.X, b.X);
            var maxX = Math.Max(a.X, b.X);
            var minY = Math.Min(a.Y, b.Y);
            var maxY = Math.Max(a.Y, b.Y);

            // 幅（プラス、マイナス）
            var hX = b.X - a.X;
            var hY = b.Y - a.Y;
            var width = Math.Abs(hX);
            var height = Math.Abs(hY);
            if (width < 1)
            {
                width = 1;
            }

            if (height < 1)
            {
                height = 1;
            }

            // 点b への向き。
            var yStep = 1;
            if (b.Y < a.Y)
            {
                yStep = -1;
            }

            var xStep = 1;
            if (b.X < a.X)
            {
                xStep = -1;
            }

            Color color = Color.Black;

            // 点a から 点b に向かって線を引く。
            if (width < height)
            {
                // ヨコの方が短い場合、タテが抜けないようにする。
                for (int len = 0; len < height; len++)
                {
                    this.Bitmap.SetPixel((int)(a.X + (xStep * len * ((float)width / height))), a.Y + (yStep * len), color);
                }
            }
            else
            {
                for (int len = 0; len < width; len++)
                {
                    this.Bitmap.SetPixel(a.X + (xStep * len), (int)(a.Y + (yStep * len * ((float)height / width))), color);
                }
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

            // 関節点の描画。
            foreach (var point in this.PointList)
            {
                this.DrawJointPoint(point);
            }

            // 関節点をつなぐ線の描画。
            Point prePoint = Point.Empty;
            foreach (var point in this.PointList)
            {
                if (prePoint != Point.Empty)
                {
                    this.DrawLine(prePoint, point);
                }

                prePoint = point;
            }
        }
    }
}
