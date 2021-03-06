﻿namespace SolutionConverter
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The main class which holds the program's entry point method.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        [STAThread]
        public static void Main(string[] args)
        {
			LoadResourceDll.RegistDLL();
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                Application.Run(new FrmMain(args[0]));
            }
            else
            {
                Application.Run(new FrmMain());
            }
        }
    }
}
