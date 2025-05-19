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
                                command.Parameters.AddWithValue("@email", i.Email.Text);
                                command.Parameters.AddWithValue("@senha", i.Senha.Text);
                                command.Parameters.AddWithValue("@cpf", i.Cpf.Text);
                                command.Parameters.AddWithValue("@data_nascimento", i.DataNascimento.Text);
                                command.Parameters.AddWithValue("@sexo", i.Sexo.Text);
                                command.Parameters.AddWithValue("@funcao", i.Funcao.Text);
                            }
                            

                            int newId = Convert.ToInt32(command.ExecuteScalar());

                            MessageBox.Show($"Cadastro realizado com sucesso!\nID: {newId}", "Sucesso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
