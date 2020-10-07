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
using prjCapelo.DAL;
using prjCapelo.Models;

namespace prjCapelo.Views
{
    /// <summary>
    /// Interaction logic for frmBuscarUsuarios.xaml
    /// </summary>
    public partial class frmBuscarUsuarios : Window
    {
        private List<dynamic> professores = new List<dynamic>();
        private List<dynamic> alunos = new List<dynamic>();
        private Aluno aluno;
        private Professor professor;
        public frmBuscarUsuarios()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            cboUsuario.SelectedIndex = 0;
        }

        private void cboUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopularDataGrid();
        }

        private void PopularDataGrid()
        {

            if (cboUsuario.Text.Equals("Alunos"))
            {
                foreach (Aluno aluno in AlunoDAO.Listar())
                {
                    dynamic item = new
                    {
                        Id = aluno.Id,
                        Matricula = aluno.Matricula,
                        Nome = aluno.NomeCompleto,
                        Email = aluno.Email
                    };
                    alunos.Add(item);
                }
                dgUsuarios.ItemsSource = alunos;
                dgUsuarios.Items.Refresh();

                alunos = new List<dynamic>();
            }
            else if (cboUsuario.Text.Equals("Professores"))
            {
                foreach (Professor professor in ProfessorDAO.Listar())
                {
                    dynamic item = new
                    {
                        Id = professor.Id,
                        Matricula = professor.Matricula,
                        Nome = professor.NomeCompleto,
                        Email = professor.Email
                    };
                    professores.Add(item);
                }
                dgUsuarios.ItemsSource = professores;
                dgUsuarios.Items.Refresh();
                professores = new List<dynamic>();
            }
        }

        private void dgUsuarios_Initialized(object sender, EventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularDataGrid();
        }
    }
}

