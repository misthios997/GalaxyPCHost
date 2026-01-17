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
}                    Color.FromArgb(138, 43, 226),   // ungu
                    Color.FromArgb(0, 191, 255),    // biru terang
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }

            void ConnectClicked(object sender, EventArgs e)
            {
                if (connected) return;

                try
                {
                    if (!File.Exists(backupPath))
                        File.Copy(hostsPath, backupPath);

                    var lines = File.ReadAllLines(hostsPath).ToList();
                    foreach (var l in gtpsLines)
                        if (!lines.Any(x => x.Contains(l)))
                            lines.Add(l);

                    File.WriteAllLines(hostsPath, lines);

                    btnConnect.BackColor = Color.Green; // jadi hijau
                    btnConnect.Text = "CONNECTED";
                    connected = true;

                    MessageBox.Show(
                        "Terhubung ke GalaxyTopia!\nSilakan buka Growtopia.",
                        "GalaxyTopia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
    }
}
