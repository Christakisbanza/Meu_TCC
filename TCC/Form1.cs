using TCC.dbConexion;
using TCC.elementos;
using TCC.entities;

namespace TCC
{
    public partial class Form1 : Form
    {
        TextBox txtEmail;
        TextBox txtSenha;

        TextBox emailCriar;
        TextBox senhaCriar;
        TextBox cpf;

        TextBox nomeEmpresa;
        TextBox cnpj;

        DateTimePicker data;

        RadioButton rbM;
        RadioButton rbF;

        CheckBox checkAdm;

        User user;

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

            Elementos.CriarLbl("Crie sua conta", 155, 15,17, panelFlutuante);

            emailCriar = Elementos.CriarTxtBox("Digite seu E-mail", 150, 110, panelFlutuante);
            senhaCriar = Elementos.CriarTxtBox("Crie sua Senha", 150, 175, panelFlutuante);
            cpf = Elementos.CriarTxtBox("Digite seu CPF", 150, 245, panelFlutuante);

            Elementos.CriarLbl("Data de Nascimento:", 145, 295, 9, panelFlutuante);
            data = Elementos.CriarCalendario(150, 320, panelFlutuante);

            rbM = Elementos.CriarRadioBtn("Masculino", 150, 370, panelFlutuante);
            rbF = Elementos.CriarRadioBtn("Feminino", 260, 370, panelFlutuante);
    

            checkAdm = Elementos.CriarCheckBox("Administrador",150, 420, panelFlutuante);

            nomeEmpresa = Elementos.CriarTxtBox("Digite o Nome da Empresa", 150, 510, panelFlutuante);
            cnpj = Elementos.CriarTxtBox("Digite o CNPJ da Empresa", 150, 570, panelFlutuante);

            user = new User(emailCriar, senhaCriar,cpf, data, rbM, rbF, checkAdm);
            DBConexion.AddUser(user);

            Elementos.CriarBtn("Criar", 150, 650, 255, 50, panelFlutuante, () => DBConexion.salvarDadosNoBancoDeDados());

            panelFlutuante.BringToFront();
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
