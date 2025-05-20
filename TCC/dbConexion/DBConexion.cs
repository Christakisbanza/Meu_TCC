using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TCC.entities;
using TCC.exception;

namespace TCC.dbConexion
{
    internal class DBConexion
    {
        static List<User> users = new List<User>();
        static List<Empresa> empresas = new List<Empresa>();

        private static string connectionString = "server=localhost;database=users_db;uid=root;pwd=;";

        public static void salvarDadosNoBancoDeDados()
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("conectar ao banco de dados", ex.Message);
                        return;
                    }

                    string query = @"INSERT INTO users 
                                    (email, senha, cpf, data_nascimento, sexo, funcao) 
                                    VALUES 
                                    (@email, @senha, @cpf, @data_nascimento, @sexo, @funcao);
                                    SELECT LAST_INSERT_ID();";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        try
                        {
                            foreach (var i in users)
                            {
                                command.Parameters.AddWithValue("@email", ValidarEmail(i.Email));
                                command.Parameters.AddWithValue("@senha", ValidarSenha(i.Senha));
                                command.Parameters.AddWithValue("@cpf", ValidarCpf(i.Cpf));
                                command.Parameters.AddWithValue("@data_nascimento", i.DataNascimento.Value.ToString("yyyy/MM/dd"));
                                command.Parameters.AddWithValue("@sexo", ValidarSexo(i.SexoM, i.SexoF));
                                command.Parameters.AddWithValue("@funcao", ValidarFuncao(i.Funcao));
                            }
                            

                            int newId = Convert.ToInt32(command.ExecuteScalar());

                            MessageBox.Show($"Cadastro realizado com sucesso!\nID: {newId}", "Sucesso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (PreecherCamposException ex)
                        {
                            MessageBox.Show("Preecha todos os campos !");
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("inserir os dados no banco", ex.Message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("processar a operação", ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("executar a operação", ex.Message);
            }
        }

        public static void AddUser(User user)
        {
            users.Add(user);
        }

        public static void RemoveUser(User user)
        {
            users.Remove(user);
        }

        public static void AddEmpresa(Empresa empresa)
        {
            empresas.Add(empresa);
        }

        public static void RemoveEmpresa(Empresa empresa)
        {
            empresas.Remove(empresa);
        }

        private static string ValidarEmail(TextBox txt)
        {
            if (txt.Text != "Digite seu E-mail" && txt.Text.Contains('@'))
            {
                return txt.Text;
            }
            else
            {
                return "";
                throw new PreecherCamposException();
            }
        }

        private static string ValidarSenha(TextBox txt)
        {
            if (txt.Text != "Crie sua Senha")
            {
                return txt.Text;
            }
            else
            {
                return "";
                throw new PreecherCamposException();
            }
        }

        private static string ValidarCpf(TextBox txt)
        {
            if (txt.Text != "Digite seu CPF" && int.TryParse(txt.Text, out int n))
            {
                return txt.Text;
            }
            else
            {
                return "";
                throw new PreecherCamposException() ;
            }
        }

        private static string ValidarSexo(RadioButton sexoM, RadioButton sexoF)
        {
            if (sexoM.Checked)
            {
                return sexoM.Text;
            }
            else if (sexoF.Checked)
            {
                return sexoF.Text;
            }
            else 
            {
                return "";
                throw new PreecherCamposException();
            }
        }

        private static string ValidarFuncao(CheckBox check)
        {
            if (check.Checked)
            {
                return check.Text;
            }
            else
            {
                return "";
                throw new PreecherCamposException();
            }
        }
    }
}
