﻿using System;
[assembly: CLSCompliant(true)]
namespace Grayscale.GeoDot
{
    using System.Windows.Forms;

    /// <summary>
    /// プログラム。
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
