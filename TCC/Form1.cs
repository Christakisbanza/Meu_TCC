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
            panelFlutuante.Visible = true;
            panelFlutuante.BringToFront();
        }

        
    }
}
