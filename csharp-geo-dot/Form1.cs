namespace Grayscale.GeoDot
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Nett;

    /// <summary>
    /// フォーム。
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 保存。
        /// </summary>
        /// <param name="sender">送信元。</param>
        /// <param name="e">イベント。</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var s = Toml.WriteString(this.mainUserControl1.SaveData);
            Console.WriteLine("Toml = " + s);
            File.WriteAllText("geo-dot-save.toml", s);
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainUserControl1.PixelBoard.Clear();
            this.mainUserControl1.SaveData = Toml.ReadFile<SaveData>("geo-dot-save.toml");
            this.mainUserControl1.PixelBoard.RefreshImage(this.mainUserControl1.SaveData);
            this.mainUserControl1.Refresh();
        }
    }
}
