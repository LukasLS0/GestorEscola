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
    /// Lógica interna para CursoFormWindow.xaml
    /// </summary>
    public partial class CursoFormWindow : Window
    {
        private Curso _curso = new Curso();

        public CursoFormWindow()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _curso.Nome = txtNome.Text;
            _curso.CargaHoraria = txtCargaHoraria.Text;
            if ((bool)rdbMatutino.IsChecked)
                _curso.Turno = "Matutino";
            else
            {
                if ((bool)rdbVespertino.IsChecked)
                    _curso.Turno = "Vespertino";
                else _curso.Turno = "Noturno";
            }
            _curso.Descricao = txtDescricao.Text;

            try
            {
                var dao = new CursoDAO();
                dao.Insert(_curso);

                MessageBox.Show("Registro de curso cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
