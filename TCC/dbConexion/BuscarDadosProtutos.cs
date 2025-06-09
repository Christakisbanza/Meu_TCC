﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TCC.app;
using TCC.entities;

namespace TCC.dbConexion
{
    internal class BuscarDadosProtutos
    {
        private static string connectionString = "server=localhost;database=users_db;uid=root;pwd=;";

        public static void BuscarProdutos()
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



                    string query = "SELECT id, nome, preco, quantidade, categoria, descricao, img" +
                                    " FROM produtos";

                    try
                    {

                        MySqlCommand command = new MySqlCommand(query, connection);


                        MySqlDataReader reader = command.ExecuteReader();


                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nome = reader.GetString(1);
                            string preco = reader.GetString(2);
                            string quantidade = reader.GetString(3);
                            string categoria = reader.GetString(4);
                            string descricao = reader.GetString(5);
                            string img = reader.GetString(6);

                            TelaInicial.AddProdutos(new Produtos(id,nome,preco,quantidade,categoria,descricao,img));
                        }

                        reader.Close();

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
