using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TCC.app;
using TCC.entities;
using TCC.exception;

namespace TCC.dbConexion
{
    internal class DBConexionProdutos
    {
        private static string connectionString = "server=localhost;database=users_db;uid=root;pwd=;";

        public static void salvarProdutos(Produtos produto)
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

                    string query = @"INSERT INTO produtos 
                                    (nome, preco, quantidade, categoria, descricao, img) 
                                    VALUES 
                                    (@nome, @preco, @quantidade, @categoria, @descricao, @img);
                                    SELECT LAST_INSERT_ID();";


                    try
                    {


                        MySqlCommand command = new MySqlCommand(query, connection);

                        command.Parameters.AddWithValue("@nome", ValidarNome(produto.Nome));
                        command.Parameters.AddWithValue("@preco", ValidarPreco(produto.Preco) );
                        command.Parameters.AddWithValue("@quantidade", ValidarQuantidade(produto.Quantidade) );
                        command.Parameters.AddWithValue("@categoria", ValidarCategoria(produto.Categoria) );
                        command.Parameters.AddWithValue("@descricao", ValidarDescricao(produto.Descricao));
                        command.Parameters.AddWithValue("@img", ValidarImg(produto.Img));
                        int newId = Convert.ToInt32(command.ExecuteScalar());


                        
                        MessageBox.Show($"Cadastro realizado com sucesso!\nID: {newId}", "Sucesso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (PreecherCamposException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
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
            catch (Exception ex)
            {
                MessageBox.Show("executar a operação", ex.Message);
            }
        }

        private static string ValidarNome(TextBox txt)
        {
            BuscarDadosProtutos.BuscarProdutos();

            string textoFormatado = txt.Text.Trim();

            foreach (var i in TelaInicial.produtos)
            {
                if (string.IsNullOrWhiteSpace(txt.Text) || i.NomeT.ToLower() == textoFormatado.ToLower())
                {
                    throw new PreecherCamposException("Nome obrigatório ou já existente !");
                }
            }
            return textoFormatado;
        }

        private static string ValidarPreco(TextBox txt)
        {
            if (int.TryParse(txt.Text, out int n))
            {
                return txt.Text.Trim();
            }
            else
            {
                txt.Clear();
                throw new PreecherCamposException("Somente numero no campo Preço !");
            }
        }

        private static string ValidarQuantidade(TextBox txt)
        {
            if (int.TryParse(txt.Text, out int n))
            {
                return txt.Text.Trim();
            }
            else
            {
                txt.Clear();
                throw new PreecherCamposException("Somente numero no campo Quantidade !");
            }
        }

        private static string ValidarCategoria(TextBox txt)
        {
            if (!string.IsNullOrWhiteSpace(txt.Text))
            {
                return txt.Text.Trim();
            }
            else
            {
                throw new PreecherCamposException("Categoria obrigatório !");
            }
        }

        private static string ValidarDescricao(TextBox txt)
        {
            if (!string.IsNullOrWhiteSpace(txt.Text))
            {
                return txt.Text.Trim();
            }
            else
            {
                throw new PreecherCamposException("Descrição obrigatório !");
            }
        }

        private static string ValidarImg(string txt)
        {
            BuscarDadosProtutos.BuscarProdutos();

            foreach (var i in TelaInicial.produtos)
            {
                if (string.IsNullOrWhiteSpace(txt) || i.Img.ToLower() == txt.ToLower())
                {
                    throw new PreecherCamposException("Imagem obrigatório ou já existente!");
                }
            }
            return txt.Trim();
        }
    }
}
