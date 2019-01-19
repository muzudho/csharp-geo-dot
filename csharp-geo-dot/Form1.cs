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
            var config = TomlSettings.Create(cfg => cfg
                .ConfigureType<decimal>(type => type
                    .WithConversionFor<TomlFloat>(convert => convert
                        .ToToml(dec => (double)dec)
                        .FromToml(tf => (decimal)tf.Value))));

            var s = Toml.WriteString(this.mainUserControl1.SaveData);
            Console.WriteLine("Toml = " + s);
            File.WriteAllText("geo-dot-save.toml", s);
        }
    }
}
