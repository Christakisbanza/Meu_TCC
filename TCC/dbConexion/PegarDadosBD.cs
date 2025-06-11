using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TCC.app;
using TCC.elementos;
using TCC.entities;
using TCC.exception;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TCC.dbConexion
{
    internal class PegarDadosBD
    {

        private static string connectionString = "server=localhost;database=users_db;uid=root;pwd=;";

        public static void BuscarDados(Panel panelOverlay, Panel panelFlutuante, TextBox txtEmail, TextBox txtSenha, Form1 form)
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



                    string query = "SELECT email, senha, cpf, data_nascimento, sexo, funcao" +
                                    " FROM users";

                    try
                    {

                        MySqlCommand command = new MySqlCommand(query, connection);


                        MySqlDataReader reader = command.ExecuteReader();

                        bool validacao = false;

                        while (reader.Read())
                        {
                            string email = reader.GetString(0);
                            string senha = reader.GetString(1);
                            string cpf = reader.GetString(2);
                            DateTime data = reader.GetDateTime(reader.GetOrdinal("data_nascimento"));
                            string sexo = reader.GetString(4);
                            string funcao = reader.GetString(5);

                            if (txtEmail.Text.Trim() == email && txtSenha.Text.Trim() == senha)
                            {
                                MessageBox.Show($"Enail: {email}, Senha: {senha}\n" +
                                    $"Validação com sucesso !");

                                panelOverlay.Visible = false;
                                panelFlutuante.Visible = false;
                                panelFlutuante.Controls.Clear();

                                validacao = true;

                                TelaInicial.AddDados(cpf);
                                TelaInicial.AddDados(data.ToString("yyyy/MM/dd"));
                                TelaInicial.AddDados(sexo);
                                TelaInicial.AddDados(funcao);
                                TelaInicial.CriarTelaInicial(form);
                            }           
                        }

                        if (validacao == false)
                        {
                            MessageBox.Show("Email ou senha inválido !");
                        }

                        txtEmail.Clear();
                        txtSenha.Clear();

                        reader.Close();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Buscar os dados no banco", ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("processar a operação", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("executar a operação", ex.Message);
            }
        }
    }
}
