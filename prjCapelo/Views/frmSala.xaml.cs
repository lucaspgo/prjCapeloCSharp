using prjCapelo.DAL;
using prjCapelo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prjCapelo.Views
{
    /// <summary>
    /// Interaction logic for frmSalaa.xaml
    /// </summary>
    public partial class frmSala : Window
    {
        private List<dynamic> salas = new List<dynamic>();
        private Sala sala;

        public frmSala()
        {
            InitializeComponent();
        }
        private void PopularDataGrid()
        {

            foreach (Sala sala in SalaDAO.Listar())
            {
                dynamic item = new
                {
                    Id = sala.Id,
                    Nome = sala.Nome,
                };
                salas.Add(item);
            }
            dgSala.ItemsSource = salas;
            dgSala.Items.Refresh();

            salas = new List<dynamic>();
        }
        private void dgSala_Initialized(object sender, EventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularDataGrid();
        }


        //Por algum motivo doubleclick da erro, ver depois
        private void dgSala_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic sala = (dynamic)dgSala.SelectedItem;

            if (sala != null)
            {
                txtNome.Text = sala.Nome.ToString();
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

            if (dgSala.SelectedItem != null)
            {
                sala = SalaDAO.BuscarPorId(((dynamic)dgSala.SelectedItem).Id);
                if (txtNome.Text != null)
                {
                    sala.Nome = txtNome.Text;
                    if (SalaDAO.Alterar(sala))
                    {
                        PopularDataGrid();
                        MessageBox.Show("Sala alterada com sucesso!!!", "Capelo",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                            
                    }
                    else
                    {
                        MessageBox.Show("Algo deu errado, contacte o time de desenvolvimento.", "Capelo",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um dado na tabela para a alteração.", "Capelo",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (dgSala.SelectedItem != null)
            {
                sala = SalaDAO.BuscarPorId(((dynamic)dgSala.SelectedItem).Id);

                if (MessageBox.Show($"Deseja realmente excluir a Sala '{sala.Nome}'?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (SalaDAO.Remover(sala))
                    {
                        PopularDataGrid();
                        MessageBox.Show("Sala removida com sucesso!!!", "Capelo",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Algo deu errado, contacte o time de desenvolvimento.", "Capelo",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Selecione um dado na tabela para a alteração.", "Capelo",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                sala = new Sala
                {
                    Nome = txtNome.Text,
                };

                if (SalaDAO.Cadastrar(sala))
                {
                    PopularDataGrid();
                    MessageBox.Show("Sala cadastrada com sucesso!!!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    

                }
                else
                {

                    MessageBox.Show("Algo deu errado, contacte o time de desenvolvimento.", "Capelo",
                      MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o nome!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
    }
}
