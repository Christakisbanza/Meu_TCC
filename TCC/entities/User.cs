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

        public string EmailString { get; set; }
        public string SenhaString { get; set; }
        public string CpfString { get; set; }
        public string DataNascimentoString { get; set; }
        public string SexoString { get; set; }
        public string FuncaoString { get; set; }

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

        public User(int id, string emial, string senha, string cpf, string dataNascimento, string sexo, string funcao)
        {
            Id = id;
            EmailString = emial;
            SenhaString = senha;
            CpfString = cpf;
            DataNascimentoString = dataNascimento;
            SexoString = sexo;
            FuncaoString = funcao;
        }
    }
}
