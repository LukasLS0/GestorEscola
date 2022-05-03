using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Lógica interna para EscolaFormWindow.xaml
    /// </summary>
    public partial class EscolaFormWindow : Window
    {

        public EscolaFormWindow()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
            //string Estado = cbEstado.Text;
            //MessageBox.Show(Estado);

            string nomeFantasia = txtbNome.Text;
            string razaoSocial = txtbRazaoSocial.Text;
            string tipo = "Privada";
            var data_criacao = dpPropriedade.SelectedDate?.ToString("yyyy-MM-dd");
=======
>>>>>>> Stashed changes
            string nomeFantasia = txtbNome.Text;
            string razaoSocial = txtbRazaoSocial.Text;
            string tipo;
            var data_criacao = dpDataCriacao.SelectedDate?.ToString("yyyy-MM-dd");
<<<<<<< Updated upstream
=======
>>>>>>> main
>>>>>>> Stashed changes
            string cnpj = txtbCnpj.Text;
            string inscricao = txtbInscEstudantil.Text;
            string resp = txtbResponsavel.Text;
            string respTel = txtbTelResponsavel.Text;
            string email = txtbEmail.Text;
            string numero = txtbNumero.Text;
            string bairro = txtbBairro.Text;
            string complemento = txtbComplemento.Text;
            string cep = txtbCep.Text;
            string cidade = txtbCidade.Text;
            string estado = Convert.ToString(cbEstado.Text);
<<<<<<< Updated upstream
            string telefone = txtbTelefone.Text;
            string rua = txtbRua.Text;

=======
<<<<<<< HEAD
           
=======
            string telefone = txtbTelefone.Text;
            string rua = txtbRua.Text;

>>>>>>> main
>>>>>>> Stashed changes

            if ((bool)rbPublico.IsChecked)
            {
                tipo = "Pública";
            }
<<<<<<< Updated upstream
=======
<<<<<<< HEAD

            var conexao = new MySqlConnection("server=localhost;database=bd_escola;port=3360;user=root;password=root");

            
=======
>>>>>>> Stashed changes
            else {
                tipo = "Privada";
            }

            var conexao = new MySqlConnection("server=localhost;database=bd_escola;port=3360;user=root;password=root");


<<<<<<< Updated upstream
=======
>>>>>>> main
>>>>>>> Stashed changes
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Escola values (null, @nome, @razao, @cnpj, @inscricao, @tipo, @data_criacao, @resp, @resp_tel, @email, @telefone, @rua, @numero, @bairro, @complemento,@cep, @cidade, @estado);";

                comando.Parameters.AddWithValue("@nome", nomeFantasia);
                comando.Parameters.AddWithValue("@razao", razaoSocial);
                comando.Parameters.AddWithValue("@cnpj", cnpj);
                comando.Parameters.AddWithValue("@inscricao", inscricao);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@data_criacao", data_criacao);
                comando.Parameters.AddWithValue("@resp", resp);
                comando.Parameters.AddWithValue("@resp_tel", respTel);
                comando.Parameters.AddWithValue("@email", email);
<<<<<<< Updated upstream
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@rua", rua);
=======
<<<<<<< HEAD
=======
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@rua", rua);
>>>>>>> main
>>>>>>> Stashed changes
                comando.Parameters.AddWithValue("@numero", numero);
                comando.Parameters.AddWithValue("@bairro", bairro);
                comando.Parameters.AddWithValue("@complemento", complemento);
                comando.Parameters.AddWithValue("@cep", cep);
                comando.Parameters.AddWithValue("@cidade", cidade);
                comando.Parameters.AddWithValue("@estado", estado);
<<<<<<< Updated upstream
                
=======
<<<<<<< HEAD
=======
                
>>>>>>> main
>>>>>>> Stashed changes

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Registro salvo com sucesso");
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
    
}
