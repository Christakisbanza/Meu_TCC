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

        Panel container;

        public Form1()
        {
            InitializeComponent();
            panelFlutuante.AutoScroll = true;
            panelFlutuante.BorderStyle = BorderStyle.Fixed3D;
            panelFlutuante.Size = new Size(800, 600);

            container = Elementos.CriarPanelContainer(this);
            container.Controls.Add(btnEntrar);
            container.Controls.Add(btnCriarConta);
            container.Controls.Add(txtInicial);

            this.Resize += (s, e) =>
            {
                btnEntrar.Location = new Point(120,400);
                btnCriarConta.Location = new Point(550, 400);
                txtInicial.Location = new Point(130,100);

                CentralizarPainel(this,container);
            };
            panelOverlay.Resize += (s, e) =>
            {
                CentralizarPainel(panelOverlay, panelFlutuante);
            };

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            panelOverlay.Visible = true;
            panelFlutuante.Visible = true;
            container.Visible = false; 

            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(100, 100);
            pictureBox.Location = new Point(350, 15);
            pictureBox.Image = Properties.Resources.usuario;
            panelFlutuante.Controls.Add(pictureBox);

            Elementos.CriarLbl("Email:", 250, 200, 10, panelFlutuante);
            txtEmail = Elementos.CriarTxtBoxLogin(255, 230, panelFlutuante);

            Elementos.CriarLbl("Senha:", 250, 300, 10, panelFlutuante);
            txtSenha = Elementos.CriarTxtBoxLogin(255, 330, panelFlutuante);

            Elementos.CriarBtn("Entrar", 270, 450, 255, 50, 11, panelFlutuante, () => PegarDadosBD.BuscarDados(panelOverlay, panelFlutuante, txtEmail, txtSenha, this));


            panelFlutuante.BringToFront();
        }



        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            panelOverlay.Visible = true;
            panelFlutuante.Visible = true;
            container.Visible = false;

           
            Elementos.CriarLbl("Crie sua conta", 270, 15, 17, panelFlutuante);
           
 
            Elementos.CriarLbl("Email:", 150, 110, 10, panelFlutuante);
            emailCriar = Elementos.CriarTxtBoxLogin(320, 110, panelFlutuante);

            Elementos.CriarLbl("Senha:", 150, 175, 10, panelFlutuante);
            senhaCriar = Elementos.CriarTxtBoxLogin(320, 175, panelFlutuante);

            Elementos.CriarLbl("CPF:", 150, 245, 10, panelFlutuante);
            cpf = Elementos.CriarTxtBoxLogin(320, 245, panelFlutuante);

            Elementos.CriarLbl("Data de Nascimento:", 150, 320, 9, panelFlutuante);
            data = Elementos.CriarCalendario(350, 320, panelFlutuante);

            Elementos.CriarLbl("Sexo:", 150, 370, 10, panelFlutuante);
            rbM = Elementos.CriarRadioBtn("M", 280, 370, panelFlutuante);
            rbF = Elementos.CriarRadioBtn("F", 230, 370, panelFlutuante);


            checkAdm = Elementos.CriarCheckBox("Administrador", 150, 420, panelFlutuante);

            Elementos.CriarLbl("Nome Empresa:", 150, 510, 10, panelFlutuante);
            nomeEmpresa = Elementos.CriarTxtBoxLogin(320, 510, panelFlutuante);

            Elementos.CriarLbl("CNPJ:", 150, 570, 10, panelFlutuante);
            cnpj = Elementos.CriarTxtBoxLogin(320, 570, panelFlutuante);


            Elementos.CriarBtn("Criar", 270, 650, 255, 50, 11, panelFlutuante, () => DBConexion.salvarDadosNoBancoDeDados(panelOverlay, panelFlutuante,container, new User(emailCriar, senhaCriar, cpf, data, rbM, rbF, checkAdm), new Empresa(nomeEmpresa, cnpj)));

        }



        private void panelOverlay_MouseClick(object sender, MouseEventArgs e)
        {

            if (!panelFlutuante.Bounds.Contains(e.Location))
            {
                panelOverlay.Visible = false;
                panelFlutuante.Visible = false;
                container.Visible = true;
                panelFlutuante.Controls.Clear();
            }
        }

        public static void CentralizarPainel(Panel panelContainer, Panel panel)
        {
            panel.Left = (panelContainer.ClientSize.Width - panel.Width) / 2;
            panel.Top = (panelContainer.ClientSize.Height - panel.Height) / 2;
        }

        public static void CentralizarPainel(Form1 form, Panel panel)
        {
            panel.Left = (form.ClientSize.Width - panel.Width) / 2;
            panel.Top = (form.ClientSize.Height - panel.Height) / 2;
        }




    }
}
