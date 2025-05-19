using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.entities
{
    internal class User
    {
        public int Id { get; set; }
        public TextBox Email { get; set; }
        public TextBox Senha { get; set; }
        public TextBox Cpf { get; set; }
        public DateTimePicker DataNascimento { get; set; }
        public RadioButton Sexo { get; set; }
        public CheckBox Funcao { get; set; }

        public User(TextBox emial, TextBox senha, TextBox cpf, DateTimePicker dataNascimento, RadioButton sexo, CheckBox funcao) 
        {
            Email = emial;
            Senha = senha;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Funcao = funcao;
        }   
    }
}
