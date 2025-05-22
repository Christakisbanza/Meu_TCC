using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TCC.entities;
using TCC.exception;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TCC.elementos
{
    internal class PegarDadosBD
    {

        private static string connectionString = "server=localhost;database=users_db;uid=root;pwd=;";

        public static void BuscarDados(Panel panelOverlay, Panel panelFlutuante, TextBox txtEmail, TextBox txtSenha)
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



                    string query = "SELECT email, senha FROM users";

                    try
                    {
                     
                        MySqlCommand command = new MySqlCommand(query, connection);

                       
                        MySqlDataReader reader = command.ExecuteReader();

                        int numeroDeValidacao = 0;

                        while (reader.Read()) 
                        {      
                            string email = reader.GetString(0);
                            string senha = reader.GetString(1);

                            if (txtEmail.Text.Trim() == email && txtSenha.Text.Trim() == senha)
                            {
                                MessageBox.Show($"Enail: {email}, Senha: {senha}\n" +
                                    $"Validação com sucesso !");
                                numeroDeValidacao++;
                            }
                        }

                        if (numeroDeValidacao == 0)
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
