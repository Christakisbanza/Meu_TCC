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

            container = Elementos.CriarPanelContainer(this);
            container.Controls.Add(btnEntrar);
            container.Controls.Add(btnCriarConta);
            container.Controls.Add(txtInicial);

            this.Resize += (s, e) =>
            {
                CentralizarControle(panelFlutuante, 200);
                btnEntrar.Location = new Point(120,400);
                btnCriarConta.Location = new Point(550, 400);
                txtInicial.Location = new Point(130,100);

                CentralizarPainel(this,container);

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
            pictureBox.Location = new Point(225, 15);
            pictureBox.Image = Properties.Resources.usuario;
            panelFlutuante.Controls.Add(pictureBox);

            Elementos.CriarLbl("Email:", 145, 130, 10, panelFlutuante);
            txtEmail = Elementos.CriarTxtBoxLogin(150, 160, panelFlutuante);

            Elementos.CriarLbl("Senha:", 145, 200, 10, panelFlutuante);
            txtSenha = Elementos.CriarTxtBoxLogin(150, 230, panelFlutuante);

            Elementos.CriarBtn("Entrar", 150, 310, 255, 50, 11, panelFlutuante, () => PegarDadosBD.BuscarDados(panelOverlay, panelFlutuante, txtEmail, txtSenha, this));


            panelFlutuante.BringToFront();
        }



        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            panelOverlay.Visible = true;
            panelFlutuante.Visible = true;
            container.Visible = false;

            Elementos.CriarLbl("Crie sua conta", 155, 15, 17, panelFlutuante);

            Elementos.CriarLbl("Email:", 70, 110, 10, panelFlutuante);
            emailCriar = Elementos.CriarTxtBoxLogin(150, 110, panelFlutuante);

            Elementos.CriarLbl("Senha:", 70, 175, 10, panelFlutuante);
            senhaCriar = Elementos.CriarTxtBoxLogin(150, 175, panelFlutuante);

            Elementos.CriarLbl("CPF:", 70, 245, 10, panelFlutuante);
            cpf = Elementos.CriarTxtBoxLogin(150, 245, panelFlutuante);

            Elementos.CriarLbl("Data de Nascimento:", 70, 320, 9, panelFlutuante);
            data = Elementos.CriarCalendario(270, 320, panelFlutuante);

            Elementos.CriarLbl("Sexo:", 70, 370, 10, panelFlutuante);
            rbM = Elementos.CriarRadioBtn("M", 200, 370, panelFlutuante);
            rbF = Elementos.CriarRadioBtn("F", 150, 370, panelFlutuante);


            checkAdm = Elementos.CriarCheckBox("Administrador", 150, 420, panelFlutuante);

            Elementos.CriarLbl("Nome Empresa:", 70, 510, 10, panelFlutuante);
            nomeEmpresa = Elementos.CriarTxtBoxLogin(150, 510, panelFlutuante);

            Elementos.CriarLbl("CNPJ:", 70, 570, 10, panelFlutuante);
            cnpj = Elementos.CriarTxtBoxLogin(150, 570, panelFlutuante);


            Elementos.CriarBtn("Criar", 150, 650, 255, 50, 11, panelFlutuante, () => DBConexion.salvarDadosNoBancoDeDados(panelOverlay, panelFlutuante,container, new User(emailCriar, senhaCriar, cpf, data, rbM, rbF, checkAdm), new Empresa(nomeEmpresa, cnpj)));

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

        private void CentralizarControle(Control ctrl, int posY)
        {
            ctrl.Location = new Point((this.ClientSize.Width - ctrl.Width) / 2, posY);
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
