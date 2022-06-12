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
using ProjetinhoEscola.Models;

namespace ProjetinhoEscola.Views
{
    /// <summary>
    /// Lógica interna para EscolaFormWindow.xaml
    /// </summary>
    public partial class EscolaFormWindow : Window
    {
        private Escola _escola = new Escola();

        public EscolaFormWindow()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _escola.NomeFantasia = txtNomeFantasia.Text;
            _escola.RazaoSocial = txtRazaoSocial.Text;
            _escola.Cnpj = txtCNPJ.Text;
            _escola.InscEstadual = txtInscEstadual.Text;
            _escola.Tipo = "Pública";
            if ((bool)rdbParticular.IsChecked)
                _escola.Tipo = "Particular";
            _escola.DataCriacao = dtCriacao.SelectedDate;
            _escola.Responsavel = txtResp.Text;
            _escola.ResponsavelTelefone = txtRespTelefone.Text;
            _escola.Email = txtEmail.Text;
            _escola.Telefone = txtTelefone.Text;
            _escola.Rua = txtRua.Text;
            _escola.Numero = txtNumero.Text;
            _escola.Bairro = txtBairro.Text;
            _escola.Complemento = txtComplemento.Text;
            //_escola.CEP = txtCEP.text;
            _escola.Cidade=   txtCidade.Text;
            _escola.Estado = cbbEstado.Text;

            try
            {
                var dao = new EscolaDAO();
                dao.Insert(_escola);

                MessageBox.Show("Registro de escola cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
