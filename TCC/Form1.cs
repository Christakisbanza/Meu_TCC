namespace TCC
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
       

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

            
            CriarBtn("Digite seu e-mail", 150,150);

            CriarBtn("Digite sua senha", 150, 220);


            Button btnEntrar = new Button();
            btnEntrar.Size = new Size(255, 50);
            btnEntrar.Location = new Point(150, 300);
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

        private void CriarBtn(string placeholder, int x, int y)
        {

            TextBox textBox = new TextBox();
            textBox.Size = new Size(250, 35);
            textBox.Location = new Point(x, y);
            textBox.Multiline = true;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };
            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
            textBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox.Width, textBox.Height, 12, 12));

            panelFlutuante.Controls.Add(textBox);
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
