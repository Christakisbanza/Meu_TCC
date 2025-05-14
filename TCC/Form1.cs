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

            

            TextBox txtEmail = new TextBox();
            txtEmail.Size = new Size(250, 35);
            txtEmail.Location = new Point(150, 150);
            txtEmail.Multiline = true;
            txtEmail.BorderStyle = BorderStyle.None;
            string placeholder = "Digite seu e-mail";
            txtEmail.Text = placeholder;
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Enter += (sender, e) =>
            {
                if (txtEmail.Text == placeholder)
                {
                    txtEmail.Text = "";
                    txtEmail.ForeColor = Color.Black;
                }
            };
            txtEmail.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    txtEmail.Text = placeholder;
                    txtEmail.ForeColor = Color.Gray;
                }
            };
            txtEmail.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtEmail.Width, txtEmail.Height, 12, 12));


            panelFlutuante.Controls.Add(pictureBox);
            panelFlutuante.Controls.Add(txtEmail);



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
