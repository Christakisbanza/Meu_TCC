using System;
using System.Drawing;
using System.Windows.Forms;

namespace TCC.elementos.elementosMsg
{
    public class MsgTemporaria : Form
    {

        private Label label;

        public MsgTemporaria(string message, int duration = 3000) 
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Opacity = 0.5;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Size = new Size(400, 200);

            label = new Label()
            {
                Text = message,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 12),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(label);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = duration; // em milissegundos
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                this.Close();
            };
            timer.Start();
        }
    }
}
