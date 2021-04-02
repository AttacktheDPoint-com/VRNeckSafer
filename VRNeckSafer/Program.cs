using System;
using System.Windows.Forms;

namespace VRNeckSafer
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var mutex = new System.Threading.Mutex(false, "saebamini.com SingletonApp"))
            {
                bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
                if (isAnotherInstanceOpen)
                {
                    MessageBox.Show("VRNS already running!", "VRNeckSafer - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // main application entry point
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                mutex.ReleaseMutex();
            }

        }
    }
}
