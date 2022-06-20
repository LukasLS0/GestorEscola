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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetinhoEscola.Views;

namespace ProjetinhoEscola
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnProvisorio_Click(object sender, RoutedEventArgs e)
        {
            EscolaFormWindow window = new EscolaFormWindow();
            window.ShowDialog();
        }

        private void btnProvisorio3_Click(object sender, RoutedEventArgs e)
        {
            CursoFormWindow window = new CursoFormWindow();
            window.ShowDialog();
        }

        private void btnProvisorio1_Click(object sender, RoutedEventArgs e)
        {
            EscolaListWindow window = new EscolaListWindow();
            window.ShowDialog();
        }

        private void btnProvisorio2_Click(object sender, RoutedEventArgs e)
        {
            CursoListWindow window = new CursoListWindow();
            window.ShowDialog();
        }
    }
}
