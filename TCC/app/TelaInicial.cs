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

            Elementos.CriarBtn("Cadastrar Produtos", 400, 200, 400, 200, panelDeFundo, () => MessageBox.Show("Clicou !"));
            Elementos.CriarBtn("Ver Produtos", 1100, 200, 400, 200, panelDeFundo, () => MessageBox.Show("Clicou !"));
            Elementos.CriarBtn("Fornecedores", 400, 600, 400, 200, panelDeFundo, () => MessageBox.Show("Clicou !"));
            Elementos.CriarBtn("Configurações", 1100, 600, 400, 200, panelDeFundo, () => MessageBox.Show("Clicou !"));
        }

        public static void AddEmail(String dado)
        {
            email.Add(dado);
        }
    }
}
