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
           

            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(100, 100);
            pictureBox.Location = new Point(220, 10);
            pictureBox.Image = Properties.Resources.usuario; 

            panelFlutuante.Controls.Add(pictureBox);

            Label novaLabel = new Label();
            novaLabel.Text = "Entrar com uma conta existente";
            novaLabel.Location = new Point(10, 10); // Posição da Label dentro do painel
            novaLabel.Size = new Size(100, 100); // Tamanho da Label

            panelFlutuante.Controls.Add(novaLabel);

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
