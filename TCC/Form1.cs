using TCC.elementos;

namespace TCC
{
    public partial class Form1 : Form
    {
        TextBox txtEmail;
        TextBox txtSenha;
        TextBox nome;
        TextBox cpf;
        DateTimePicker data;
        RadioButton rbM;
        RadioButton rbF;
        public Form1()
        {
            InitializeComponent();
            panelFlutuante.AutoScroll = true;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            panelOverlay.Visible = true;
            panelFlutuante.Visible = true;


            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(100, 100);
            pictureBox.Location = new Point(225, 15);
            pictureBox.Image = Properties.Resources.usuario;
            panelFlutuante.Controls.Add(pictureBox);


            txtEmail = Elementos.CriarTxtBox("Digite seu e-mail", 150, 160, panelFlutuante);
            txtSenha = Elementos.CriarTxtBox("Digite sua senha", 150, 230, panelFlutuante);

            Elementos.CriarBtn("Entrar",150,310,255,50,panelFlutuante,() => MsgEntrar());


            panelFlutuante.BringToFront();
        }

        public void MsgEntrar()
        {
            MessageBox.Show($"E-mail: {txtEmail.Text} \nSenha: {txtSenha.Text}");
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            panelOverlay.Visible = true;
            panelFlutuante.Visible = true;

            Elementos.CriarLbl("Crie sua conta", 155, 15, panelFlutuante);

            nome = Elementos.CriarTxtBox("Digite seu Nome", 150, 110, panelFlutuante);
            cpf = Elementos.CriarTxtBox("Digite seu CPF", 150, 170, panelFlutuante);
            data = Elementos.CriarCalendario(150, 230, panelFlutuante);
            rbM = Elementos.CriarRadioBtn("Masculino", 150, 290, panelFlutuante);
            rbF = Elementos.CriarRadioBtn("Feminino", 260, 290, panelFlutuante);

            Elementos.CriarBtn("Criar", 150, 450, 255, 50, panelFlutuante, () => MsgCriar());
        }

        public void MsgCriar()
        {
            string sexoSelecionado = rbM.Checked ? "Masculino" :
                                 rbF.Checked ? "Feminino" :
                                 "Nenhum selecionado";

            MessageBox.Show($"Data selecionada: {data.Value.ToString("dd/MM/yyyy")}\n" +
                $"Nome: {nome.Text}\n" +
                $"CPF: {cpf.Text}\n" +
                $"Sexo: {sexoSelecionado}");
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
