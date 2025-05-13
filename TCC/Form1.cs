namespace TCC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            panelOverlay.Visible = true;
            panelFlutuante.Visible = true;

            int centerX = (this.ClientSize.Width - panelFlutuante.Width) / 2;
            int centerY = (this.ClientSize.Height - panelFlutuante.Height) / 2;
            panelFlutuante.Location = new Point(centerX, centerY);

            panelFlutuante.BringToFront();
        }

        private void panelOverlay_MouseClick(object sender, MouseEventArgs e)
        {

            if (!panelFlutuante.Bounds.Contains(e.Location))
            {
                panelOverlay.Visible = false;
                panelFlutuante.Visible = false;
            }
        }

        
    }
}
