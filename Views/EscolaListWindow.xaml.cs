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
using System.Windows.Shapes;
using ProjetinhoEscola.Models;

namespace ProjetinhoEscola.Views
{
    /// <summary>
    /// Lógica interna para EscolaListWindow.xaml
    /// </summary>
    public partial class EscolaListWindow : Window
    {
        public EscolaListWindow()
        {
            InitializeComponent();
            Loaded += EscolaListWindow_Loaded;
        }

        private void EscolaListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        
        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dataGridEscola.SelectedItem as Escola;

            var form = new EscolaFormWindow(escolaSelecionada);
            form.ShowDialog();
            CarregarListagem();
            
        }
        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dataGridEscola.SelectedItem as Escola;

            var resultado = MessageBox.Show("Você realmente deseja remover a escola " + escolaSelecionada.NomeFantasia + " ?" , 
                "Confirmação de Exclusao", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new EscolaDAO();
                    dao.Delete(escolaSelecionada);

                    MessageBox.Show("Registro removido com sucesso!");
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaEscolas = dao.List();

                dataGridEscola.ItemsSource = listaEscolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
