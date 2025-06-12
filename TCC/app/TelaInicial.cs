using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC.dbConexionProduto;
using TCC.elementos;
using TCC.entities;

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
        static Button btnSaidaPorVenda;
        static Button btnOutrasSaidas;

        static Label filtrarLbl;
        static TextBox filtrarNome;
        static ListBox filtrarCategoria;
        static ListBox filtrarQuantidade;

        static List<String> dados = new List<String>();
        public static List<Produtos> produtos = new List<Produtos>();





        public static void CriarTelaInicial(Form1 form)
        {
            Panel panelDeFundo = Elementos.CriarPanelEntrar(form);
            Panel panelPerfil = Elementos.CriarPanelPrincipal(panelDeFundo);
            Panel panelCadastrarProduto = Elementos.CriarPanelPrincipal(panelDeFundo);
            Panel panelVerProdutos = Elementos.CriarPanelPrincipal(panelDeFundo);
            Panel panelFornecedores = Elementos.CriarPanelPrincipal(panelDeFundo);
            Panel panelConfiguracao = Elementos.CriarPanelPrincipal(panelDeFundo);

            Elementos.CriarImgPerfil(275, 50, panelDeFundo, () => ClicouNoPerfil(panelPerfil, [panelCadastrarProduto, panelVerProdutos,panelFornecedores,panelConfiguracao]));

            Button btn1 = Elementos.CriarBtn("Cadastrar Produtos", 50, 50, 300, 80, 12, panelDeFundo, () => CadastrarProdutos(panelCadastrarProduto, [panelPerfil,panelVerProdutos, panelFornecedores,panelConfiguracao]));
            Button btn2 = Elementos.CriarBtn("Ver Produtos", 50, 180, 300, 80, 12, panelDeFundo, () => VerProdutos(panelVerProdutos, [panelPerfil,panelCadastrarProduto,panelFornecedores,panelConfiguracao]));
            Button btn3 = Elementos.CriarBtn("Fornecedores", 50, 310, 300, 80, 12, panelDeFundo, () => Fornecedores(panelFornecedores, [panelPerfil,panelCadastrarProduto,panelVerProdutos,panelConfiguracao]));
            Button btn4 = Elementos.CriarBtn("Configurações", 50, 440, 300, 80, 12, panelDeFundo, () => Configurações(panelConfiguracao, [panelPerfil,panelCadastrarProduto, panelVerProdutos,panelFornecedores]));
            MudarCorBtns(btn1, btn2, btn3, btn4);

            ElementosDinamicosEmVerProdutos(panelDeFundo);

            Panel btns = Elementos.CriarPanelContainerBtnsIniciais(panelDeFundo, [btn1,btn2,btn3,btn4]);
        }

        public static void ClicouNoPerfil(Panel panelPerfil, List<Panel> panelList)
        {
            foreach (var i in panelList)
            {
                i.Visible = false;
            }
            panelPerfil.Controls.Clear();
            panelPerfil.Visible = true;

            btnSaidaPorVenda.Visible = false;
            btnOutrasSaidas.Visible=false;
            filtrarLbl.Visible = false;
            filtrarNome.Visible = false;
            filtrarCategoria.Visible = false;

            int n = 50;
            foreach (var i in dados)
            {
                if (n == 50) 
                {
                    Elementos.CriarLbl($"Cpf: {i}", 30, n += 50, 12, panelPerfil);
                }
                else if (n == 100)
                {
                    Elementos.CriarLbl($"Data Nascimento: {i}", 30, n += 50, 12, panelPerfil);
                }
                else if (n == 150)
                {
                    Elementos.CriarLbl($"Sexo: {i}", 30, n += 50, 12, panelPerfil);
                }
                else if (n == 200)
                {
                    Elementos.CriarLbl($"Função: {i}", 30, n += 50, 12, panelPerfil);
                }
                
            }
        }

        public static void CadastrarProdutos(Panel panelCadastrarProduto, List<Panel> panelList)
        {
            foreach (var i in panelList)
            {
                i.Visible = false;
            }
            panelCadastrarProduto.Controls.Clear();
            panelCadastrarProduto.Visible = true;

            btnSaidaPorVenda.Visible = false;
            btnOutrasSaidas.Visible = false;
            filtrarLbl.Visible = false;
            filtrarNome.Visible = false;
            filtrarCategoria.Visible = false;

            Elementos.CriarLbl("Nome:", 70, 50, 12, panelCadastrarProduto);
            nome = Elementos.CriarTxtBox(75, 90, panelCadastrarProduto);

            Elementos.CriarLbl("Preço:", 475, 50, 12, panelCadastrarProduto);
            preco = Elementos.CriarTxtBox(480, 90, panelCadastrarProduto);

            Elementos.CriarLbl("Quantidade:", 70, 160, 12, panelCadastrarProduto);
            quantidade = Elementos.CriarTxtBox(75, 200, panelCadastrarProduto);

            Elementos.CriarLbl("Categoria:", 475, 160, 12, panelCadastrarProduto);
            categorioa = Elementos.CriarTxtBox(480, 200, panelCadastrarProduto);


            Elementos.CriarLbl("Descição:", 70, 270, 12, panelCadastrarProduto);
            descricao = Elementos.CriarTxtBox(75, 310, panelCadastrarProduto);
            descricao.Multiline = true;
            descricao.Size = new Size(300, 125);


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            PictureBox pictureBox = null;

            btnImg = Elementos.CriarBtn("Selecione img", 475, 340, 220, 50, 10, panelCadastrarProduto, () =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox = new PictureBox();
                    pictureBox.Size = new Size(150, 150);
                    pictureBox.Location = new Point(510, 300);
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    panelCadastrarProduto.Controls.Add(pictureBox);
                    btnImg.Visible = false;
                }
            });
            btnImg.BackColor = Color.Gray;

            btnCadastrar = Elementos.CriarBtn("Cadastrar", 310, 500, 170, 70, 10, panelCadastrarProduto, () => {
                DBConexionProdutos.salvarProdutos(new Produtos(nome, preco, quantidade, categorioa, descricao, openFileDialog.FileName));

                nome.Clear();
                preco.Clear();
                quantidade.Clear();
                categorioa.Clear();
                descricao.Clear();

                panelCadastrarProduto.Controls.Remove(pictureBox);
                btnImg.Visible = true;

                nome.Focus();
            });
            btnCadastrar.BackColor = Color.Green;
            
        }

        public static void VerProdutos(Panel panelVerProdutos, List<Panel> panelList)
        {
            foreach (var i in panelList)
            {
                i.Visible = false;
            }
            panelVerProdutos.Controls.Clear();
            panelVerProdutos.Visible = true;
            panelVerProdutos.BackColor = Color.LightGray;
            panelVerProdutos.AutoScroll = true;

            btnSaidaPorVenda.Visible = true;
            btnSaidaPorVenda.BringToFront();
            btnOutrasSaidas.Visible = true;
            btnOutrasSaidas.BringToFront();
            filtrarLbl.Visible = true;
            filtrarLbl.BringToFront();
            filtrarNome.Visible = true;
            filtrarNome.BringToFront();
            filtrarCategoria.Visible = true;
            filtrarCategoria.BringToFront();

            BuscarDadosProtutos.BuscarProdutos();


            int xPanel = 50;

            foreach (var i in produtos)
            {
                Label idTxt = Elementos.CriarLbl("ID: ", 25, 25, 10);
                Label id = Elementos.CriarLblRegular($"{i.Id}", 65, 25, 10);

                Label nomeTxt = Elementos.CriarLbl("Nome: ", 50, 100, 12);
                Label nome = Elementos.CriarLblRegular($"{i.NomeT}", 140, 100, 12);

                Label precoTxt = Elementos.CriarLbl("Preço: ", 50, 170, 12);
                Label preco = Elementos.CriarLblRegular($"R${i.PrecoT}", 140, 170, 12);

                Label quantidadeTxt = Elementos.CriarLbl("Quantidade: ", 50, 240, 12);
                Label quantidade = Elementos.CriarLblRegular($"{i.QuantidadeT}", 205, 240, 12);

                Label categoriaTxt = Elementos.CriarLbl("Categoria: ", 50, 310, 12);
                Label categoria = Elementos.CriarLblRegular($"{i.CategoriaT}", 185, 310, 12);

                Label descricaoTxt = Elementos.CriarLbl("Descrição: ", 50, 380, 12);
                Label descricao = Elementos.CriarLblRegular($"{i.DescricaoT}", 185, 380, 12);
                
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(250, 200);
                pictureBox.Location = new Point(400, 150);
                pictureBox.Image = Image.FromFile(i.Img);

                Panel pContainer = Elementos.CriarPanelContainer(panelVerProdutos, xPanel, 50);
                pContainer.Controls.AddRange(new Control[] {idTxt,nomeTxt, precoTxt, quantidadeTxt, categoriaTxt, descricaoTxt});
                pContainer.Controls.AddRange(new Control[] {id,nome, preco, quantidade, categoria, descricao, pictureBox });
       

                Elementos.CriarImgDeletar(650, 10, pContainer, () => Deletar(i, pContainer, panelVerProdutos));
                Elementos.CriarImgEditar(580, 10, pContainer, () => MessageBox.Show("ok"));
                
                xPanel += 800;
                
            }
            Elementos.CriarPanelMargin(panelVerProdutos, xPanel);
        }

        public static void Fornecedores(Panel panelFornecedores, List<Panel> panelList)
        {
            foreach (var i in panelList)
            {
                i.Visible = false;
            }
            panelFornecedores.Controls.Clear();
            panelFornecedores.Visible = true;

            btnSaidaPorVenda.Visible = false;
            btnOutrasSaidas.Visible = false;
            filtrarLbl.Visible = false;
            filtrarNome.Visible = false;
            filtrarCategoria.Visible = false;
        }

        public static void Configurações(Panel panelConfiguracao, List<Panel> panelList)
        {
            foreach (var i in panelList)
            {
                i.Visible = false;
            }
            panelConfiguracao.Controls.Clear();
            panelConfiguracao.Visible = true;

            btnSaidaPorVenda.Visible = false;
            btnOutrasSaidas.Visible = false;
            filtrarLbl.Visible = false;
            filtrarNome.Visible = false;
            filtrarCategoria.Visible = false;
        }



        public static void ElementosDinamicosEmVerProdutos(Panel panelDeFundo)
        {
            filtrarLbl = Elementos.CriarLblRegular("Filtrar por Nome, Categoria ou Quantidade:", 700, 650, 12);
            filtrarLbl.Visible = false;
            filtrarLbl.BackColor = Color.LightGray;
            panelDeFundo.Controls.Add(filtrarLbl);

            filtrarNome = Elementos.CriarTxtBox(705, 700, panelDeFundo);
            filtrarNome.Visible = false;

            filtrarCategoria = Elementos.CriarListBox(panelDeFundo);
            filtrarCategoria.Visible = false;

            btnSaidaPorVenda = Elementos.CriarBtn("Saída Por Venda", 1285, 820, 240, 65, 12, panelDeFundo, () => MessageBox.Show("Ok"));
            btnSaidaPorVenda.Visible = false;
            btnSaidaPorVenda.BackColor = Color.Green;

            btnOutrasSaidas = Elementos.CriarBtn("Outras Saídas", 1575, 820, 240, 65, 12, panelDeFundo, () => MessageBox.Show("Ok"));
            btnOutrasSaidas.Visible = false;
            btnOutrasSaidas.BackColor = Color.DarkRed;
        }






        public static void Deletar(Produtos produto, Panel pContainer, Panel panel)
        {
            DialogResult res = MessageBox.Show("Deseja deletar ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes) 
            {
                DeletarDoBancoDeDados.Deletar(produto, pContainer, panel);
            }
        }

        public static void AddDados(string dado)
        {
            dados.Add(dado);
        }

        public static void AddProdutos(Produtos produto)
        {
            if (produtos.Any(p => p.NomeT.Equals(produto.NomeT, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Produto com nome '{produto.NomeT}' já existe.");
            }
            else
            {
                produtos.Add(produto);
            }
        }
        public static void RemoveProduto(Produtos p)
        {
            produtos.Remove(p);
        }

        public static void MudarCorBtns(Button btn1, Button btn2, Button btn3, Button btn4)
        {
            btn1.BackColor = Color.LightBlue;
            btn2.BackColor = Color.LightBlue;
            btn3.BackColor = Color.LightBlue;
            btn4.BackColor = Color.LightBlue;
            btn1.ForeColor = Color.Black;
            btn2.ForeColor = Color.Black;
            btn3.ForeColor = Color.Black;
            btn4.ForeColor = Color.Black;
        }
    }
}
