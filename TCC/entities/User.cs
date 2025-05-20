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
        public RadioButton SexoM { get; set; }
        public RadioButton SexoF { get; set; }
        public CheckBox Funcao { get; set; }

        public User(TextBox emial, TextBox senha, TextBox cpf, DateTimePicker dataNascimento, RadioButton sexoM, RadioButton sexoF, CheckBox funcao) 
        {
            Email = emial;
            Senha = senha;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            SexoM = sexoM;
            SexoF = sexoF;  
            Funcao = funcao;
        }   
    }
}
