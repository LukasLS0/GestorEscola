﻿using System;
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
using ProjetoEscola.Views;
using MySql.Data.MySqlClient;

namespace ProjetoEscola
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            EscolaFormWindow escolaFormWindow = new EscolaFormWindow();
            escolaFormWindow.ShowDialog();
           
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
