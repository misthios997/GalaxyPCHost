using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GalaxyPCHost
{
    static class Program
    {
        static string hostsPath = @"C:\Windows\System32\drivers\etc\hosts";
        static string backupPath = @"C:\Windows\System32\drivers\etc\hosts.galaxy.bak";

        static string[] gtpsLines =
        {
            "91.134.85.13 www.growtopia1.com",
            "91.134.85.13 www.growtopia2.com"
        };

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }

        class MainForm : Form
        {
            Button connect = new Button();
            Button disconnect = new Button();
            Label status = new Label();

            public MainForm()
            {
                Text = "GalaxyTopia PC Host";
                Width = 300;
                Height = 200;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;

                connect.Text = "CONNECT";
                connect.SetBounds(50, 20, 180, 40);
                connect.Click += (s, e) => ConnectGTPS();

                disconnect.Text = "DISCONNECT";
                disconnect.SetBounds(50, 70, 180, 40);
                disconnect.Click += (s, e) => DisconnectGTPS();

                status.Text = "Status: Idle";
                status.SetBounds(50, 130, 200, 20);

                Controls.Add(connect);
                Controls.Add(disconnect);
                Controls.Add(status);
            }

            void ConnectGTPS()
            {
                if (!File.Exists(backupPath))
                    File.Copy(hostsPath, backupPath);

                var lines = File.ReadAllLines(hostsPath).ToList();
                foreach (var l in gtpsLines)
                    if (!lines.Any(x => x.Contains(l)))
                        lines.Add(l);

                File.WriteAllLines(hostsPath, lines);
                status.Text = "Status: Connected to GalaxyTopia";

                MessageBox.Show("Connected ke GalaxyTopia!\nBuka Growtopia.",
                    "GalaxyTopia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            void DisconnectGTPS()
            {
                if (File.Exists(backupPath))
                {
                    File.Copy(backupPath, hostsPath, true);
                    File.Delete(backupPath);
                    status.Text = "Status: Normal IP";
                }
            }
        }
    }
}
