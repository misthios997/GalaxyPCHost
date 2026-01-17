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
            Width = 400;
            Height = 250;
            BackColor = Color.FromArgb(120, 70, 200);

            Label title = new Label()
            {
                Text = "GalaxyTopia",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                AutoSize = true,
                Top = 30,
                Left = 90
            };

            btn = new Button()
            {
                Text = "Connect",
                Width = 140,
                Height = 45,
                Top = 130,
                Left = 120,
                BackColor = Color.Gray
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
