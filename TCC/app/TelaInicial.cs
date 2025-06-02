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
        public static void CriarTelaInicial(Form1 form)
        {
            Panel panelDeFundo = Elementos.CriarPanelEntrar(form);

            
            foreach (var i in email)
            {
                Elementos.CriarLbl($"Olá, {i}", 400, 30, 20, panelDeFundo);
            }

            Button btn1 = Elementos.CriarBtn("Cadastrar Produtos", 50, 50, 300, 80, 10, panelDeFundo, () => MessageBox.Show("Clicou !"));
            Button btn2 = Elementos.CriarBtn("Ver Produtos", 50, 180, 300, 80, 10, panelDeFundo, () => MessageBox.Show("Clicou !"));
            Button btn3 = Elementos.CriarBtn("Fornecedores", 50, 310, 300, 80, 10, panelDeFundo, () => MessageBox.Show("Clicou !"));
            Button btn4 = Elementos.CriarBtn("Configurações", 50, 440, 300, 80, 10, panelDeFundo, () => MessageBox.Show("Clicou !"));

            Panel btns = Elementos.CriarPanelContainerBtnsIniciais(panelDeFundo, [btn1,btn2,btn3,btn4]);
        }

        public static void AddEmail(String dado)
        {
            email.Add(dado);
        }
    }
}
