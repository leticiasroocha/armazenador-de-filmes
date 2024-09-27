using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Armazenador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
         
        }

        private void txbLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=filmes");
                conn.Open();
                MySqlCommand comando = new MySqlCommand("INSERT INTO `armazem` (`nome`, `data`, `classificacao`, `duracao`, `categoria`, `locacao`, `valorFilme`, `endereco`, `telefone`, `email`) VALUES (@nome, @data, @classificacao, @duracao, @categoria, @locacao, @valorFilme, @endereco, @telefone, @email);", conn);
                comando.Parameters.AddWithValue("@nome", txbNome.Text);
                comando.Parameters.AddWithValue("@data", txbData.Text);
                comando.Parameters.AddWithValue("@classificacao", txbClassificacao.Text);
                comando.Parameters.AddWithValue("@duracao", txbDuracao.Text);
                comando.Parameters.AddWithValue("@categoria", txbCategoria.Text);
                comando.Parameters.AddWithValue("@locacao", txbLocacao.Text);
                comando.Parameters.AddWithValue("@valorFilme", txbValor.Text);
                comando.Parameters.AddWithValue("@endereco", txbEndereco.Text);
                comando.Parameters.AddWithValue("@telefone", txbTelefone.Text);
                comando.Parameters.AddWithValue("@email", txbEmail.Text);


                comando.ExecuteNonQuery();
                conn.Close();


                txbData.Text = "";
                txbNome.Text = "";
                txbClassificacao.Text = "";
                txbDuracao.Text = "";
                txbCategoria.Text = "";
                txbLocacao.Text = "";
                txbValor.Text = "";
                txbEndereco.Text = "";
                txbTelefone.Text = "";
                txbEmail.Text = "";


            }
            catch (Exception ex)
            {
                lblErro.Text = ex.Message;
            }

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=filmes");
                conn.Open();
                MySqlCommand comandoo = new MySqlCommand("INSERT INTO `gerente` (`login`, `senha`) VALUES (@login, @senha);", conn);
                comandoo.Parameters.AddWithValue("@login", txbLogin.Text);
                comandoo.Parameters.AddWithValue("@senha", txbSenha.Text);

                comandoo.ExecuteNonQuery();
                conn.Close();

                txbLogin.Text = "";
                txbSenha.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection
                    ("server=127.0.0.1; userid=root; password=root; database=filmes");
                    conn.Open();
                    MySqlCommand comandooo = new MySqlCommand("SELECT * FROM `usuarios` WHERE `login` = @login AND `senha` = @senha; ", conn);
                    comandooo.Parameters.AddWithValue("@login", textBox1.Text);
                    comandooo.Parameters.AddWithValue("@senha", textBox2.Text);
                    object controle = comandooo.ExecuteScalar();
                    conn.Close();
                if (controle == null)
                {
                    MessageBox.Show("Algo de errado não está certo. \n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    //this.Close();
                    tabControl.TabPages.Add(tabPage1);
                    tabControl.TabPages.Add(tabPage2);
                    tabControl.TabPages.Add(tabPage3);
                }
                }
                catch (Exception erro) {
                    MessageBox.Show("ALgo de errado não está certo.\n" + erro.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();

                }
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabPage1);
            tabControl.TabPages.Remove(tabPage2);
            tabControl.TabPages.Remove(tabPage3);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection
                    ("server=127.0.0.1; userid=root; password=root; database=filmes");
                conn.Open();

                if (txbPesquisa.Text == "")
                {

                    MySqlCommand comandooo = new MySqlCommand("SELECT `nome`, `data`, `classificacao`, `duracao`, `categoria`, `locacao`, `valorFilme`, `endereco`, `telefone`, `email` FROM `armazem`;", conn);
                    var reader = comandooo.ExecuteReader();
                    
                    while (reader.Read())
                    {

                        lstFilmess.Text = ("Nome: " + reader.GetString(0) + "Data: " + reader.GetString(1) + "Classificação: " + reader.GetString(2)  + "Duração: " + reader.GetString(3) + "Categoria: " + reader.GetString(4) + "Locação: " + reader.GetString(5) + "Valor do Filme: " + reader.GetString(6) + "Endereço: " + reader.GetString(7) + "Telefone: " + reader.GetString(8) + "Email: " + reader.GetString(9));

                    }

                } 
                else
                {
                    MySqlCommand comandooo = new MySqlCommand("SELECT `nome`, `data`, `classificacao`, `duracao`, `categoria`, `locacao`, `valorFilme`, `endereco`, `telefone`, `email` FROM `armazem` WHERE `nome` = @nome;", conn);
                    comandooo.Parameters.AddWithValue("@nome", txbNome.Text);

                    var reader = comandooo.ExecuteReader();

                    while (reader.Read())
                    {

                        lstFilmess.Text = ("Nome: " + reader.GetString(0) + "Data: " + reader.GetString(1) + "Classificação: " + reader.GetString(2) + "Duração: " + reader.GetString(3) + "Categoria: " + reader.GetString(4) + "Locação: " + reader.GetString(5) + "Valor do Filme: " + reader.GetString(6) + "Endereço: " + reader.GetString(7) + "Telefone: " + reader.GetString(8) + "Email: " + reader.GetString(9));

                    }
                }
                if (conn.State.ToString() != "Close")
                {
                    conn.Close();
                }


            } catch (Exception ex)
            { 
             //lblErro.Text = ex.Message;
            }
        }

        private void lstFilmess_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

