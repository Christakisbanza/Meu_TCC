using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.entities
{
    internal class Empresa
    {
        public TextBox NomeEmpresa { get; set; }
        public TextBox Cnpj { get; set; }

        public Empresa(TextBox nome, TextBox cnpj) 
        {
            NomeEmpresa = nome;
            Cnpj = cnpj;
        }
    }
}
