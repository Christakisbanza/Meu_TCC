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
        public static void CriarTelaInicial(Form1 form)
        {
            Panel panelDeFundo = Elementos.CriarPanelEntrar(form);

            Elementos.CriarLbl("Bem vindo", 155, 15, 17, panelDeFundo);
        }
    }
}
