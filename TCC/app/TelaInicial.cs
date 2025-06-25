﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC.dbConexionProduto;
using TCC.elementos;
using TCC.elementos.elementosMsg;
using TCC.entities;

namespace TCC.app
{
    internal class TelaInicial
    {
        static TextBox nome;
        static TextBox preco;
        static TextBox precoCompra;
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
        static ComboBox filtrarQuantidade;
        static PictureBox imgSearch;

        public static List<Produtos> produtos = new List<Produtos>();
        static List<User> dadosUser = new List<User>();




        public static void CriarTelaInicial(Form1 form)
        {
            Panel panelDeFundo = Elementos.CriarPanelEntrar(form);

            Panel panelPerfil = Elementos.CriarPanelPrincipal(panelDeFundo);
            panelPerfil.Size = new Size(500,400);
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
            ExibirPanel(panelPerfil, panelList);

            OcultarElementosDinamicos();

            foreach (var dado in dadosUser)
            {
                Label idTxt = Elementos.CriarLbl("ID: ", 50, 50, 10);
                Label id = Elementos.CriarLblRegular($"{dado.Id}", 90, 50, 12);

                Label emailTxt = Elementos.CriarLbl("Email: ", 50, 100, 10);
                Label email = Elementos.CriarLblRegular($"{dado.EmailString}", 120, 100, 12);

                Label cpfTxt = Elementos.CriarLbl("Cpf: ", 50, 150, 10);
                Label cpf = Elementos.CriarLblRegular($"{dado.CpfString}", 100, 150, 12);

                Label dataTxt = Elementos.CriarLbl("Data de Nascimento: ", 50, 200, 10);
                Label data = Elementos.CriarLblRegular($"{dado.DataNascimentoString}", 260, 200, 12);

                Label sexoTxt = Elementos.CriarLbl("Sexo: ", 50, 250, 10);
                Label sexo = Elementos.CriarLblRegular($"{dado.SexoString}", 110, 250, 12);

                Label funcaoTxt = Elementos.CriarLbl("Função: ", 50, 300, 10);
                Label funcao = Elementos.CriarLblRegular($"{dado.FuncaoString}", 130, 300, 12);

                panelPerfil.Controls.AddRange(new Control[] {id, email, cpf, data, sexo, funcao });
                panelPerfil.Controls.AddRange(new Control[] { idTxt, emailTxt, cpfTxt, dataTxt, sexoTxt, funcaoTxt });
            }

        }

        public static void CadastrarProdutos(Panel panelCadastrarProduto, List<Panel> panelList)
        {
            ExibirPanel(panelCadastrarProduto, panelList);

            OcultarElementosDinamicos();

            Panel pContainer = Elementos.CriarPanelContainer(panelCadastrarProduto, 25, 25, 1150,600);

            Elementos.CriarLbl("Nome:", 30, 50, 12, pContainer);
            nome = Elementos.CriarTxtBox(35, 90, pContainer);

            Elementos.CriarLbl("Preço Unitário da Venda:", 435, 50, 12, pContainer);
            preco = Elementos.CriarTxtBox(440, 90, pContainer);
            preco.Size = new Size(300,35);

            Elementos.CriarLbl("Preço Unitário da Compra:", 435, 160, 12, pContainer);
            precoCompra = Elementos.CriarTxtBox(440, 200, pContainer);
            precoCompra.Size = new Size(300, 35);

            Elementos.CriarLbl("Quantidade:", 30, 160, 12, pContainer);
            quantidade = Elementos.CriarTxtBox(35, 200, pContainer);

            Elementos.CriarLbl("Categoria:", 435, 270, 12, pContainer);
            categorioa = Elementos.CriarTxtBox(440, 310, pContainer);
            categorioa.Size = new Size(300, 35);

            Elementos.CriarLbl("Descição:", 30, 270, 12, pContainer);
            descricao = Elementos.CriarTxtBox(35, 310, pContainer);
            descricao.Multiline = true;
            descricao.Size = new Size(300, 125);


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            PictureBox pictureBox = null;

            btnImg = Elementos.CriarBtn("Selecione img", 850, 200, 220, 50, 10, pContainer, () =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox = new PictureBox();
                    pictureBox.Size = new Size(250, 250);
                    pictureBox.Location = new Point(850, 125);
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pContainer.Controls.Add(pictureBox);
                    btnImg.Visible = false;
                }
            });
            btnImg.BackColor = Color.Gray;

            btnCadastrar = Elementos.CriarBtn("Cadastrar", 500, 500, 170, 70, 10, pContainer, () => {
                DBConexionProdutos.salvarProdutos(new Produtos(nome, preco, quantidade, categorioa, descricao, openFileDialog.FileName));

                nome.Clear();
                preco.Clear();
                quantidade.Clear();
                categorioa.Clear();
                descricao.Clear();

                pContainer.Controls.Remove(pictureBox);
                btnImg.Visible = true;

                nome.Focus();
            });
            btnCadastrar.BackColor = Color.Green;
            panelCadastrarProduto.BackColor = Color.LightGray; 
        }

        public static void VerProdutos(Panel panelVerProdutos, List<Panel> panelList)
        {
            ExibirPanel(panelVerProdutos, panelList);

            filtrarNome.Clear();
            filtrarQuantidade.Items.Clear();
            filtrarQuantidade.Items.Add("Maior Quantidade");
            filtrarQuantidade.Items.Add("Menor Quantidade");
            filtrarCategoria.Items.Clear();
            
            panelVerProdutos.BackColor = Color.LightGray;
            panelVerProdutos.AutoScroll = true;

            BuscarDadosProtutos.BuscarProdutos();

            int xPanel = 50;
            int x = 50;
            filtrarCategoria.MouseClick += (sender, e) =>
            {
                x = 50;
            };
            
            foreach (var i in produtos)
            {
                Label idTxt = Elementos.CriarLbl("ID: ", 25, 25, 10);
                Label id = Elementos.CriarLblRegular($"{i.Id}", 65, 25, 10);

                Label nomeTxt = Elementos.CriarLbl("Nome: ", 50, 100, 12);
                Label nome = Elementos.CriarLblRegular($"{i.NomeT}", 140, 100, 12);

                Label precoTxt = Elementos.CriarLbl("Preço da Venda: ", 50, 170, 12);
                Label preco = Elementos.CriarLblRegular($"R${i.PrecoT}", 250, 170, 12);

                Label quantidadeTxt = Elementos.CriarLbl("Quantidade: ", 50, 240, 12);
                Label quantidade = Elementos.CriarLblRegular($"{i.QuantidadeT}", 205, 240, 12);

                Label categoriaTxt = Elementos.CriarLbl("Categoria: ", 50, 310, 12);
                Label categoria = Elementos.CriarLblRegular($"{i.CategoriaT}", 185, 310, 12);

                Label descricaoTxt = Elementos.CriarLbl("Descrição: ", 50, 380, 12);
                Label descricao = Elementos.CriarLblRegular($"{i.DescricaoT}", 185, 380, 12);
                
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(250, 225);
                pictureBox.Location = new Point(400, 150);
                pictureBox.Image = Image.FromFile(i.Img);

                Panel pContainer = Elementos.CriarPanelContainer(panelVerProdutos, xPanel, 50);
                pContainer.Controls.AddRange(new Control[] {idTxt,nomeTxt, precoTxt, quantidadeTxt, categoriaTxt, descricaoTxt});
                pContainer.Controls.AddRange(new Control[] {id,nome, preco, quantidade, categoria, descricao, pictureBox });
       

                Elementos.CriarImgDeletar(650, 10, pContainer, () => Deletar(i, pContainer, panelVerProdutos));
                Elementos.CriarImgEditar(580, 10, pContainer, () => MessageBox.Show("ok"));
                
                
                if (!filtrarCategoria.Items.Contains(i.CategoriaT.ToUpper()))
                {
                    filtrarCategoria.Items.Add(i.CategoriaT.ToUpper());
                }

                filtrarCategoria.SelectedIndexChanged += (sender, e) =>
                {
                    if(filtrarCategoria.SelectedItem.ToString() == i.CategoriaT.ToUpper())
                    {
                        pContainer.Visible = true;
                        pContainer.Location = new Point(x, 50);
                        x += 800;
                    }
                    else
                    {
                        pContainer.Visible = false;
                    }
                };
                xPanel += 800;

            }
            Elementos.CriarPanelMargin(panelVerProdutos, xPanel);

            ExibirElementosDinamicos();
        }

        public static void Fornecedores(Panel panelFornecedores, List<Panel> panelList)
        {
            ExibirPanel(panelFornecedores, panelList);
            OcultarElementosDinamicos();
        }

        public static void Configurações(Panel panelConfiguracao, List<Panel> panelList)
        {
            ExibirPanel(panelConfiguracao, panelList);
            OcultarElementosDinamicos();
        }





        public static void ElementosDinamicosEmVerProdutos(Panel panelDeFundo)
        {
            filtrarLbl = Elementos.CriarLblRegular("Filtrar por Nome, Quantidade ou Categoria:", 700, 650, 12);
            filtrarLbl.Visible = false;
            filtrarLbl.BackColor = Color.LightGray;
            panelDeFundo.Controls.Add(filtrarLbl);

            imgSearch = Elementos.CriarImgSearch(705, 703, panelDeFundo);
            imgSearch.Visible = false;

            filtrarNome = Elementos.CriarTxtBox(735, 700, panelDeFundo);
            filtrarNome.Visible = false;

            filtrarCategoria = Elementos.CriarListBox(panelDeFundo);
            filtrarCategoria.Visible = false;

            filtrarQuantidade = Elementos.CriarComboBox(panelDeFundo);
            filtrarQuantidade.Visible = false;

            btnSaidaPorVenda = Elementos.CriarBtn("Saída Por Venda", 1285, 840, 240, 65, 12, panelDeFundo, () => MessageBox.Show("Ok"));
            btnSaidaPorVenda.Visible = false;
            btnSaidaPorVenda.BackColor = Color.Green;

            btnOutrasSaidas = Elementos.CriarBtn("Outras Saídas", 1575, 840, 240, 65, 12, panelDeFundo, () => MessageBox.Show("Ok"));
            btnOutrasSaidas.Visible = false;
            btnOutrasSaidas.BackColor = Color.DarkRed;
        }

        public static void OcultarElementosDinamicos()
        {
            btnSaidaPorVenda.Visible = false;
            btnOutrasSaidas.Visible = false;
            filtrarLbl.Visible = false;
            filtrarNome.Visible = false;
            filtrarCategoria.Visible = false;
            filtrarQuantidade.Visible = false;
            imgSearch.Visible = false;
        }

        public static void ExibirElementosDinamicos()
        {
            if (produtos.Count == 0)
            {
                new MsgTemporaria("Nenhum Produto Cadastrado !").Show();
            }
            else
            {
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
                filtrarQuantidade.Visible = true;
                filtrarQuantidade.BringToFront();
                imgSearch.Visible = true;
                imgSearch.BringToFront();
            }
        }

        public static void ExibirPanel(Panel panel, List<Panel> panelList)
        {
            foreach (var i in panelList)
            {
                i.Visible = false;
            }
            panel.Controls.Clear();
            panel.Visible = true;
        }

        public static void Deletar(Produtos produto, Panel pContainer, Panel panel)
        {
            DialogResult res = MessageBox.Show("Deseja deletar ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes) 
            {
                DeletarDoBancoDeDados.Deletar(produto, pContainer, panel);
                filtrarCategoria.Items.Remove(produto.CategoriaT);
            }
        }

        public static void AddUser(User dados)
        {
            dadosUser.Add(dados);
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
