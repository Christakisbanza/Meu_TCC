using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC.elementos;

namespace TCC.app
{
    internal class TelaInicial
    {
        static TextBox nome;
        static TextBox preco;
        static TextBox quantidade;
        static TextBox categorioa;
        static TextBox descricao;

        static Button btnImg;
        static Button btnCadastrar;

        static List<String> email = new List<String>();
        static List<String> dados = new List<String>();
        public static void CriarTelaInicial(Form1 form)
        {
            Panel panelDeFundo = Elementos.CriarPanelEntrar(form);

            
            foreach (var i in email)
            {
                Elementos.CriarLbl($"Olá, {i}", 300, 90, 20, panelDeFundo);
            }

            Elementos.CriarImgPerfil(1500, 50, panelDeFundo, () => ClicouNoPerfil(panelDeFundo));

            Button btn1 = Elementos.CriarBtn("Cadastrar Produtos", 50, 50, 300, 80, 12, panelDeFundo, () => CadastrarProdutos(panelDeFundo));
            Button btn2 = Elementos.CriarBtn("Ver Produtos", 50, 180, 300, 80, 12, panelDeFundo, () => VerProdutos(panelDeFundo));
            Button btn3 = Elementos.CriarBtn("Fornecedores", 50, 310, 300, 80, 12, panelDeFundo, () => Fornecedores(panelDeFundo));
            Button btn4 = Elementos.CriarBtn("Configurações", 50, 440, 300, 80, 12, panelDeFundo, () => Configurações(panelDeFundo));

            Panel btns = Elementos.CriarPanelContainerBtnsIniciais(panelDeFundo, [btn1,btn2,btn3,btn4]);
        }

        public static void ClicouNoPerfil(Panel panelDeFundo)
        {
            Panel p = Elementos.CriarPanelPrincipal(panelDeFundo);

            foreach (var i in email)
            {
                Elementos.CriarLbl($"Email: {i}", 30, 50, 12, p);
            }
            int n = 50;
            foreach (var i in dados)
            {
                if (n == 50) 
                {
                    Elementos.CriarLbl($"Cpf: {i}", 30, n += 50, 12, p);
                }
                else if (n == 100)
                {
                    Elementos.CriarLbl($"Data Nascimento: {i}", 30, n += 50, 12, p);
                }
                else if (n == 150)
                {
                    Elementos.CriarLbl($"Sexo: {i}", 30, n += 50, 12, p);
                }
                else if (n == 200)
                {
                    Elementos.CriarLbl($"Função: {i}", 30, n += 50, 12, p);
                }
                
            }
        }

        public static void CadastrarProdutos(Panel panelDeFundo)
        {
            Panel p = Elementos.CriarPanelPrincipal(panelDeFundo);

            Elementos.CriarLbl("Nome:", 70, 50, 12, p);
            nome = Elementos.CriarTxtBox(75,90,p);

            Elementos.CriarLbl("Preço:", 475, 50, 12, p);
            preco = Elementos.CriarTxtBox(480, 90,p);

            Elementos.CriarLbl("Quantidade:", 70, 160, 12, p);
            quantidade = Elementos.CriarTxtBox(75, 200, p);

            Elementos.CriarLbl("Categoria:", 475, 160, 12, p);
            categorioa = Elementos.CriarTxtBox(480, 200,p);

            
            Elementos.CriarLbl("Descição:", 70, 270, 12, p);
            descricao = Elementos.CriarTxtBox(75, 310, p);
            descricao.Multiline = true;
            descricao.Size = new Size(300, 125);

            btnImg = Elementos.CriarBtn("Selecione img", 475, 340, 220, 50, 10, p, () =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(150, 150);
                    pictureBox.Location = new Point(510, 300);
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Controls.Add(pictureBox);
                    btnImg.Visible = false;
                }
            });
            btnImg.BackColor = Color.Gray;

            btnCadastrar = Elementos.CriarBtn("Cadastrar", 310, 500, 170, 70, 10, p, () => MessageBox.Show("ok"));
            btnCadastrar.BackColor = Color.Green;
        }

        public static void VerProdutos(Panel panelDeFundo)
        {
            Panel p = Elementos.CriarPanelPrincipal(panelDeFundo);
        }

        public static void Fornecedores(Panel panelDeFundo)
        {
            Panel p = Elementos.CriarPanelPrincipal(panelDeFundo);
        }

        public static void Configurações(Panel panelDeFundo)
        {
            Panel p = Elementos.CriarPanelPrincipal(panelDeFundo);
        }



        public static void AddEmail(String dado)
        {
            email.Add(dado);
        }

        public static void AddDados(string dado)
        {
            dados.Add(dado);
        }
    }
}
