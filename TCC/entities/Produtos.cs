﻿using System;
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


        public string NomeT { get; set; }
        public string PrecoT { get; set; }
        public string QuantidadeT { get; set; }
        public string CategoriaT { get; set; }
        public string DescricaoT { get; set; }


        public Produtos(TextBox nome, TextBox preco, TextBox quantidade, TextBox categoria, TextBox descricao, string img)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            Categoria = categoria;
            Descricao = descricao;
            Img = img;
        }

        public Produtos(string nome, string preco, string quantidade, string categoria, string descricao, string img)
        {
            NomeT = nome;
            PrecoT = preco;
            QuantidadeT = quantidade;
            CategoriaT = categoria;
            DescricaoT = descricao;
            Img = img;
        }
    }
}
