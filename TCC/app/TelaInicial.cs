﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCC.dbConexion;
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

        static List<String> email = new List<String>();
        static List<String> dados = new List<String>();

        public static HashSet<Produtos> produtos = new HashSet<Produtos>();
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
            
            MudarCorBtns(btn1,btn2, btn3, btn4);

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


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            btnImg = Elementos.CriarBtn("Selecione img", 475, 340, 220, 50, 10, p, () =>
            {
                

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

            btnCadastrar = Elementos.CriarBtn("Cadastrar", 310, 500, 170, 70, 10, p, () => DBConexionProdutos.salvarProdutos(new Produtos(nome, preco,quantidade,categorioa,descricao, openFileDialog.FileName) ));
            btnCadastrar.BackColor = Color.Green;
            
        }

        public static void VerProdutos(Panel panelDeFundo)
        {
            Panel p = Elementos.CriarPanelPrincipal(panelDeFundo);
            p.BackColor = Color.LightGray;
            p.AutoScroll = true;
            
            BuscarDadosProtutos.BuscarProdutos();

            Label nome = null;
            Label preco = null;
            Label quantidade = null;
            Label categoria = null;
            Label descricao = null;

            int xPanel = 50;

            foreach (var i in produtos)
            {
               
                nome = Elementos.CriarLbl($"Nome: {i.NomeT}", 50, 100, 12);
               
                preco = Elementos.CriarLbl($"Preço: R${i.PrecoT}", 50, 170, 12);
                
                quantidade = Elementos.CriarLbl($"Quantidade: {i.QuantidadeT}", 50, 240, 12);
                
                categoria = Elementos.CriarLbl($"Categoria: {i.CategoriaT}", 50, 310, 12);
                
                descricao = Elementos.CriarLbl($"Descrição: {i.DescricaoT}", 50, 380, 12);
                
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(250, 200);
                pictureBox.Location = new Point(400, 150);
                pictureBox.Image = Image.FromFile(i.Img);

                Panel pContainer = Elementos.CriarPanelContainer(p, xPanel, 50);
                pContainer.Controls.Add(nome);
                pContainer.Controls.Add(preco);
                pContainer.Controls.Add(quantidade);
                pContainer.Controls.Add(categoria);
                pContainer.Controls.Add(descricao);
                pContainer.Controls.Add(pictureBox);

                xPanel += 800;
                
            }
            Elementos.CriarPanelMargin(p, xPanel);
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

        public static void AddProdutos(Produtos produto)
        {
            produtos.Add(produto);
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
