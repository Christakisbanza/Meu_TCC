using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.entities
{
    internal class Produtos
    {
        public int Id { get; set; }
        public TextBox Nome { get; set; }
        public TextBox Preco { get; set; }
        public TextBox Quantidade { get; set; }
        public TextBox Categoria { get; set; }
        public TextBox Descricao { get; set; }
        public string Img { get; set; }

        public Produtos(TextBox nome, TextBox preco, TextBox quantidade, TextBox categoria, TextBox descricao, string img)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            Categoria = categoria;
            Descricao = descricao;
            Img = img;
        }
    }
}
