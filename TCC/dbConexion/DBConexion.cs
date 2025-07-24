﻿using System;
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
using System.Diagnostics;

namespace TCC.dbConexion
{
    internal class DBConexion
    {

        private static string connectionString = "server=localhost;database=users_db;uid=root;pwd=;";

        public static void salvarDadosNoBancoDeDados(Panel panelOverlay, Panel panelFlutuante,Panel container, User user, Empresa empresa)
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

                    string queryEpresa = @"INSERT INTO empresas 
                                    (users_id, nome_empresa, cnpj) 
                                    VALUES 
                                    (@users_id, @nome_empresa, @cnpj);";

                    
                    try
                    {
                        MySqlTransaction transaction = connection.BeginTransaction();

                        MySqlCommand command = new MySqlCommand(query, connection, transaction);

                        command.Parameters.AddWithValue("@email", ValidarEmail(user.Email));
                        command.Parameters.AddWithValue("@senha", ValidarSenha(user.Senha));
                        command.Parameters.AddWithValue("@cpf", ValidarCpf(user.Cpf));
                        command.Parameters.AddWithValue("@data_nascimento", user.DataNascimento.Value.ToString("yyyy/MM/dd"));
                        command.Parameters.AddWithValue("@sexo", ValidarSexo(user.SexoM, user.SexoF));
                        command.Parameters.AddWithValue("@funcao", ValidarFuncao(user.Funcao));
                        int newId = Convert.ToInt32(command.ExecuteScalar());



                        MySqlCommand commandEmpresa = new MySqlCommand(queryEpresa, connection, transaction);

                        commandEmpresa.Parameters.AddWithValue("@users_id", newId);
                        commandEmpresa.Parameters.AddWithValue("@nome_empresa", ValidarNomeEmpresa(empresa.NomeEmpresa));
                        commandEmpresa.Parameters.AddWithValue("@cnpj", ValidarCnpj(empresa.Cnpj)); 
                        commandEmpresa.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show($"Cadastro realizado com sucesso!\nID: {newId}", "Sucesso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        panelOverlay.Visible = false;
                        panelFlutuante.Visible = false;
                        container.Visible = true; 
                        panelFlutuante.Controls.Clear();
                               
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

        private static string ValidarEmail(TextBox txt)
        {
            if (txt.Text.Contains('@') && txt.Text.Contains('.'))
            {
                return txt.Text.Trim();
            }
            else
            {
                txt.Clear();
                throw new PreecherCamposException("Email inválido !");
            }
        }

        private static string ValidarSenha(TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text)) throw new PreecherCamposException("Senha inválida !");

            if (txt.Text.Length < 8) throw new PreecherCamposException("Senha inválida !");
            if (!txt.Text.Any(char.IsUpper)) throw new PreecherCamposException("Senha inválida !");
            if (!txt.Text.Any(char.IsLower)) throw new PreecherCamposException("Senha inválida !");
            if (!txt.Text.Any(char.IsDigit)) throw new PreecherCamposException("Senha inválida !");
            if (!txt.Text.Any(c => "!@#$%^&*()_-+=<>?/{}[]|\\~`".Contains(c))) throw new PreecherCamposException("Senha inválida !");

            return txt.Text.Trim();
        }

        private static string ValidarCpf(TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text)) throw new PreecherCamposException("Cpf inválido !");
            if (txt.Text.Length != 11) throw new PreecherCamposException("Cpf inválido !");
            if (txt.Text.Distinct().Count() == 1) throw new PreecherCamposException("Cpf inválido !");
            if (int.TryParse(txt.Text, out int n)) throw new PreecherCamposException("Cpf inválido !");
            int soma = 0;
            for (int i = 0; i < 9; i++) soma += (txt.Text[i] - '0') * (10 - i);

            int digito1 = soma % 11;
            digito1 = digito1 < 2 ? 0 : 11 - digito1;

            soma = 0;
            for (int i = 0; i < 10; i++) soma += (txt.Text[i] - '0') * (11 - i);

            int digito2 = soma % 11;
            digito2 = digito2 < 2 ? 0 : 11 - digito2;

            if (txt.Text[9] - '0' == digito1 && txt.Text[10] - '0' == digito2)
            {
                return txt.Text.Trim();
            }
            else
            {
                txt.Clear();
                throw new PreecherCamposException("Cpf inválido !") ;
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
                sexoM.Checked = false;
                sexoF.Checked = false;
                throw new PreecherCamposException("Selecione um sexo !");
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
                check.Checked = false;
                throw new PreecherCamposException("Função obrigatória !");
            }
        }

        private static string ValidarNomeEmpresa(TextBox txt)
        {
            if (txt.Text != "Digite o Nome da Empresa")
            {
                return txt.Text.Trim();
            }
            else
            {
                txt.Clear();
                throw new PreecherCamposException("Nome da empresa obrigatório !");
            }
        }

        private static string ValidarCnpj(TextBox txt)
        {
            if (int.TryParse(txt.Text, out int n))
            {
                return txt.Text.Trim();
            }
            else
            {
                txt.Clear();
                throw new PreecherCamposException("Cnpj inválido !");
            }
        }
    }
}
