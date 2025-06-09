using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TCC.app;
using TCC.entities;

namespace TCC.dbConexion
{
    internal class DeletarDoBancoDeDados
    {
        private static string connectionString = "server=localhost;database=users_db;uid=root;pwd=;";
        public static void Deletar(Produtos p)
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



                    string query = "DELETE FROM Produtos WHERE nome = @nome";

                    try
                    {

                        MySqlCommand command = new MySqlCommand(query, connection);

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@nome", p.NomeT);

                            int linhasAfetadas = cmd.ExecuteNonQuery();

                            MessageBox.Show($"Linhas deletadas: {linhasAfetadas}");
                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Buscar os dados no banco", ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"processar a operação {ex}", ex.Message);
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
