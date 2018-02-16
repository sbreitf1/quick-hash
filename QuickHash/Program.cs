using System;
using System.Windows.Forms;
using QuickHash.Properties;

namespace QuickHash
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Settings.Default.FirstStart)
            {
                Settings.Default.Upgrade();
                Settings.Default.FirstStart = false;
                Settings.Default.Save();
            }

            Application.Run(new MainForm());
        }
    }
}
