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
            Loaded += EscolaFormWindow_Loaded;
        }

        public EscolaFormWindow(Escola escola)
        {
                InitializeComponent();

                _escola = escola;
                Loaded += EscolaFormWindow_Loaded;
        }
        private void EscolaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeFantasia.Text = _escola.NomeFantasia;
            txtRazaoSocial.Text = _escola.RazaoSocial;
            txtCNPJ.Text = _escola.Cnpj;
            txtInscEstadual.Text = _escola.InscEstadual;
            if (_escola.Tipo == "Pública")
            {
                rdbPublica.IsChecked = true;
            }
            else
            {
                rdbParticular.IsChecked = true;
            }
            dtCriacao.SelectedDate = _escola.DataCriacao;
            txtResp.Text = _escola.Responsavel;
            txtRespTelefone.Text = _escola.ResponsavelTelefone;
            txtEmail.Text = _escola.Email;
            txtTelefone.Text = _escola.Telefone;
            txtRua.Text = _escola.Rua;
            txtNumero.Text = _escola.Numero;
            txtBairro.Text = _escola.Bairro;
            txtComplemento.Text = _escola.Complemento;
            txtCEP.Text = _escola.CEP;
            txtCidade.Text = _escola.Cidade;
            

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
            _escola.CEP = txtCEP.Text;
            _escola.Cidade=   txtCidade.Text;
            _escola.Estado = cbbEstado.Text;
            
       

            try
            {
                var dao = new EscolaDAO();

                if (_escola.Id > 0 )
                {
                    dao.Update(_escola);
                    MessageBox.Show("Registro de escola atualizados com sucesso!");
                }
                else
                {
                    dao.Insert(_escola);
                    MessageBox.Show("Registro de escola cadastrado com sucesso!");
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
