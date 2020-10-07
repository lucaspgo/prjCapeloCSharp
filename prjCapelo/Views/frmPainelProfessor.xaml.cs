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
    /// Interaction logic for frmPainelProfessor.xaml
    /// </summary>
    public partial class frmPainelProfessor : Window
    {
        private List<dynamic> aulas = new List<dynamic>();
        Aula aula;
        public frmPainelProfessor()
        {
            InitializeComponent();
        }
        //((frmLogin)Application.Current.MainWindow).txtLogin.Text código que puxa a matricula        
        private void btnCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarUsuario1 frm = new frmCadastrarUsuario1();
            frm.ShowDialog();
        }


        private void menuCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarUsuario1 frm = new frmCadastrarUsuario1();
            frm.ShowDialog();
        }
        private void menuCadastrarDisciplina_Click(object sender, RoutedEventArgs e)
        {
            frmDisciplina frm = new frmDisciplina();
            frm.ShowDialog();
        }
        private void menuCadastrarSala_Click(object sender, RoutedEventArgs e)
        {
            frmSala frm = new frmSala();
            frm.ShowDialog();
        }

        private void menuBuscarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            frmBuscarUsuarios frm = new frmBuscarUsuarios();
            frm.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopularDataGrid();
        }

        private void PopularDataGrid()
        {
            aulas = new List<dynamic>();
            List<Aula> aulaTeste = AulaDAO.BuscarPorMatriculaProfessor(Convert.ToInt32(((frmLogin)Application.Current.MainWindow).txtLogin.Text));
            foreach (Aula aula in aulaTeste)
            {
                dynamic item = new
                {
                    Id = aula.Id,
                    Aluno = aula.Aluno.NomeCompleto,
                    Data = aula.Data.ToString("dd/MM/yyyy"),
                    Inicio = aula.DataInicio.ToString("HH:mm"),
                    Fim = aula.DataFim.ToString("HH:mm"),
                    Sala = aula.Sala.Nome
                };
                aulas.Add(item);
            }
            dgAulas.ItemsSource = aulas;
            dgAulas.Items.Refresh();
        }
    }
}
