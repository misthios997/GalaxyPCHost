using System.Drawing;
using System.Windows.Forms;

namespace GalaxyPCHost
{
    public class MainForm : Form
    {
        Button btn;

        public MainForm()
        {
            Text = "GalaxyPCHost";
            Width = 420;
            Height = 260;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(120, 80, 220);

            Label title = new Label()
            {
                Text = "GalaxyTopia",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                AutoSize = true,
                Top = 35,
                Left = 95
            };

            btn = new Button()
            {
                Text = "Connect",
                Width = 160,
                Height = 50,
                Top = 140,
                Left = 125,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btn.Click += (s, e) =>
            {
                if (btn.Text == "Connect")
                {
                    HostManager.Connect();
                    btn.Text = "Disconnect";
                    btn.BackColor = Color.Green;
                }
                else
                {
                    HostManager.Disconnect();
                    btn.Text = "Connect";
                    btn.BackColor = Color.Gray;
                }
            };

            FormClosing += (s, e) =>
            {
                HostManager.Disconnect();
            };

            Controls.Add(title);
            Controls.Add(btn);
        }
    }
}
