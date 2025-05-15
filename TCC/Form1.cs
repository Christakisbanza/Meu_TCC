using TCC.elementos;

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
            pictureBox.Location = new Point(220, 15);
            pictureBox.Image = Properties.Resources.usuario;


            
            Elementos.CriarTxtBox("Digite seu e-mail", 150, 160, panelFlutuante);
            Elementos.CriarTxtBox("Digite sua senha", 150, 230, panelFlutuante);

            Elementos.CriarBtn("Entrar",150,310,255,50,panelFlutuante,() => Msg());


            panelFlutuante.Controls.Add(pictureBox);
            


            panelFlutuante.BringToFront();
        }

        public void Msg()
        {
            MessageBox.Show("Clicou !");
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            panelOverlay.Visible = true;
            panelFlutuante.Visible = true;
        }

        

        private void panelOverlay_MouseClick(object sender, MouseEventArgs e)
        {

            if (!panelFlutuante.Bounds.Contains(e.Location))
            {
                panelOverlay.Visible = false;
                panelFlutuante.Visible = false;
                panelFlutuante.Controls.Clear();
            }
        }

        

    }
}
