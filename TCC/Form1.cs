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

            

            TextBox textBox = new TextBox();
            textBox.Size = new Size(200, 25);
            textBox.Location = new Point(180, 150);
            string placeholder = "Digite seu e-mail";
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



            panelFlutuante.Controls.Add(pictureBox);
            panelFlutuante.Controls.Add(textBox);



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
