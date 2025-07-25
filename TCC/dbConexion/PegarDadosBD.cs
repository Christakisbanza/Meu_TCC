using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TCC.app;
using TCC.elementos;
using TCC.elementos.elementosMsg;
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



                    string query = "SELECT id, email, senha, cpf, data_nascimento, sexo, funcao" +
                                    " FROM users";

                    try
                    {

                        MySqlCommand command = new MySqlCommand(query, connection);


                        MySqlDataReader reader = command.ExecuteReader();

                        bool validacao = false;

                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string email = reader.GetString(1);
                            string senha = reader.GetString(2);
                            string cpf = reader.GetString(3);
                            string data = reader.GetString(4);
                            string sexo = reader.GetString(5);
                            string funcao = reader.GetString(6);

                            if (txtEmail.Text.Trim() == email && txtSenha.Text.Trim() == senha)
                            {
                                new MsgTemporaria("Bem vindo !").Show();

                                panelOverlay.Visible = false;
                                panelFlutuante.Visible = false;
                                panelFlutuante.Controls.Clear();

                                validacao = true;

                                TelaInicial.AddUser(new User(id, email, senha, cpf, data,sexo,funcao));
                                TelaInicial.CriarTelaInicial(form);
                            }           
                        }

                        if (validacao == false)
                        {
                            new MsgTemporaria("Email ou Senha inválido !").Show();
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
