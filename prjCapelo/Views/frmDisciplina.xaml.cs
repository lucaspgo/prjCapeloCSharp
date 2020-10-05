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
    /// Interaction logic for frmDisciplina.xaml
    /// </summary>
    public partial class frmDisciplina : Window
    {
        private List<dynamic> disciplinas = new List<dynamic>();
        private Disciplina disciplina;

        public frmDisciplina()
        {
            InitializeComponent();
        }

        private void PopularDataGrid()
        {

            foreach(Disciplina disciplina in DisciplinaDAO.Listar())
            {
                dynamic item = new
                {
                    Id = disciplina.Id,
                    Nome = disciplina.Nome,
                    Sigla = disciplina.Sigla
                };
                disciplinas.Add(item);                
            }
            dgDisciplina.ItemsSource = disciplinas;
            dgDisciplina.Items.Refresh();

            disciplinas = new List<dynamic>();
        }

        private void dgDisciplina_Initialized(object sender, EventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularDataGrid();
        }
        //Por algum motivo doubleclick da erro, ver depois
        private void dgDisciplina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic disciplina = (dynamic)dgDisciplina.SelectedItem;

            if (disciplina != null)
            {
                txtNome.Text = disciplina.Nome.ToString();
                txtSigla.Text = disciplina.Sigla.ToString();
            }            
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

            if(dgDisciplina.SelectedItem != null){
                disciplina = DisciplinaDAO.BuscarPorId(((dynamic)dgDisciplina.SelectedItem).Id);
                if (txtNome.Text != null && txtSigla.Text != null)
                {
                    disciplina.Nome = txtNome.Text;
                    disciplina.Sigla = txtSigla.Text;
                    if (DisciplinaDAO.Alterar(disciplina))
                    {
                        PopularDataGrid();
                        MessageBox.Show("Disciplina alterada com sucesso!!!", "Capelo",
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
            if (dgDisciplina.SelectedItem != null)
            {
                disciplina = DisciplinaDAO.BuscarPorId(((dynamic)dgDisciplina.SelectedItem).Id);
                
                if (MessageBox.Show($"Deseja realmente excluir a Disciplina '{disciplina.Nome}'?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes){
                    if (DisciplinaDAO.Remover(disciplina))
                    {
                        PopularDataGrid();
                        MessageBox.Show("Disciplina cadastrada com sucesso!!!", "Capelo",
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
                disciplina = new Disciplina
                {
                    Nome = txtNome.Text,
                    Sigla = txtSigla.Text
                };

                if (DisciplinaDAO.Cadastrar(disciplina))
                {
                    PopularDataGrid();
                    MessageBox.Show("Disciplina cadastrada com sucesso!!!", "Vendas WPF",
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
