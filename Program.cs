using System;
using System.Windows.Forms;

namespace GalaxyPCHost
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
            {
                HostManager.Disconnect();
            };

            Application.Run(new MainForm());
        }
    }
}
