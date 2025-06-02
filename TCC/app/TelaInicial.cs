using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.elementos;

namespace TCC.app
{
    internal class TelaInicial
    {
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

            Button btn1 = Elementos.CriarBtn("Cadastrar Produtos", 50, 50, 300, 80, 10, panelDeFundo, () => CadastrarProdutos(panelDeFundo));
            Button btn2 = Elementos.CriarBtn("Ver Produtos", 50, 180, 300, 80, 10, panelDeFundo, () => VerProdutos(panelDeFundo));
            Button btn3 = Elementos.CriarBtn("Fornecedores", 50, 310, 300, 80, 10, panelDeFundo, () => Fornecedores(panelDeFundo));
            Button btn4 = Elementos.CriarBtn("Configurações", 50, 440, 300, 80, 10, panelDeFundo, () => Configurações(panelDeFundo));

            Panel btns = Elementos.CriarPanelContainerBtnsIniciais(panelDeFundo, [btn1,btn2,btn3,btn4]);
        }

        public static void ClicouNoPerfil(Panel panelDeFundo)
        {
            Panel p = Elementos.CriarPanelPrincipal(panelDeFundo);

            foreach (var i in email)
            {
                Elementos.CriarLbl($"Email: {i}", 30, 30, 12, p);
            }
            int n = 0;
            foreach (var i in dados)
            {
                if (n == 0) 
                {
                    Elementos.CriarLbl($"Cpf: {i}", 30, n += 30, 12, p);
                }
                else if (n == 30)
                {
                    Elementos.CriarLbl($"Data Nascimento: {i}", 30, n += 30, 12, p);
                }
                else if (n == 60)
                {
                    Elementos.CriarLbl($"Sexo: {i}", 30, n += 30, 12, p);
                }
                else if (n == 90)
                {
                    Elementos.CriarLbl($"Função: {i}", 30, n += 30, 12, p);
                }
                
            }
        }

        public static void CadastrarProdutos(Panel panelDeFundo)
        {
            Panel p = Elementos.CriarPanelPrincipal(panelDeFundo);
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
