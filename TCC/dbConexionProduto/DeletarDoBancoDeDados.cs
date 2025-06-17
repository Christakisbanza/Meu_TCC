using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TCC.app;
using TCC.elementos.elementosMsg;
using TCC.entities;

namespace TCC.dbConexionProduto
{
    internal class DeletarDoBancoDeDados
    {
        private static string connectionString = "server=localhost;database=users_db;uid=root;pwd=;";
        public static void Deletar(Produtos produto, Panel pContainer, Panel panel)
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



                    string query = "DELETE FROM produtos WHERE nome = @nome";

                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@nome", produto.NomeT);

                            TelaInicial.RemoveProduto(produto);

                            pContainer.Controls.Clear();
                            panel.Controls.Remove(pContainer);

                            int linhasAfetadas = cmd.ExecuteNonQuery();

                            new MsgTemporaria($"ID:{produto.Id} - Deletado com sucesso !").Show();
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
