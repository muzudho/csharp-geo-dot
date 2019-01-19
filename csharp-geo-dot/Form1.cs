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
            switch (this.saveFileDialog1.ShowDialog(this))
            {
                case DialogResult.OK:
                    {
                        var s = Toml.WriteString(this.mainUserControl1.SaveData);
                        Console.WriteLine("Toml = " + s);

                        // "geo-dot-save.toml"
                        File.WriteAllText(this.saveFileDialog1.FileName, s);
                    }

                    break;
            }
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
