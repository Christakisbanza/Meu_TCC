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


            
            Elementos.CriarBtn("Digite seu e-mail", 150, 160, panelFlutuante);
            Elementos.CriarBtn("Digite sua senha", 150, 230, panelFlutuante);


            Button btnEntrar = new Button();
            btnEntrar.Size = new Size(255, 50);
            btnEntrar.Location = new Point(150, 310);
            btnEntrar.Text = "Entrar";
            btnEntrar.ForeColor = Color.Black;
            btnEntrar.Font = new Font(btnEntrar.Font, FontStyle.Bold);
            btnEntrar.Click += (s, e) =>
            {
                MessageBox.Show("Botão entrar clicado !");
            };


            panelFlutuante.Controls.Add(pictureBox);
            panelFlutuante.Controls.Add(btnEntrar);


            panelFlutuante.BringToFront();
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
