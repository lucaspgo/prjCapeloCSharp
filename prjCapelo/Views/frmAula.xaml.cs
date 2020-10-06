using prjCapelo.DAL;
using prjCapelo.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for frmAula.xaml
    /// </summary>
    public partial class frmAula : Window
    {
        public frmAula()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            CarregarComboBoxes();
        }

        private void CarregarComboBoxes()
        {
            CarregarData();

            List<Disciplina> disciplinas = DisciplinaDAO.Listar();
            cboDisciplina.ItemsSource = disciplinas;
            cboDisciplina.DisplayMemberPath = "Nome";
            cboDisciplina.SelectedValuePath = "Id";

            if (disciplinas != null)
            {
                cboDisciplina.SelectedIndex = 0;
            }

            List<Sala> salas = SalaDAO.Listar();
            cboProfessor.ItemsSource = salas;
            cboProfessor.DisplayMemberPath = "Nome";
            cboProfessor.SelectedValuePath = "Id";            
        }

        private void CarregarData()
        {
            List<string> listaDates = new List<string>();
            listaDates.Add("07:00");
            listaDates.Add("07:30");
            listaDates.Add("08:00");
            listaDates.Add("08:30");
            listaDates.Add("09:00");
            listaDates.Add("09:30");
            listaDates.Add("10:00");
            listaDates.Add("10:30");
            listaDates.Add("11:00");
            listaDates.Add("11:30");
            listaDates.Add("12:00");
            listaDates.Add("12:30");
            listaDates.Add("13:00");
            listaDates.Add("13:30");
            listaDates.Add("14:00");
            listaDates.Add("14:30");
            listaDates.Add("15:00");
            listaDates.Add("15:30");
            listaDates.Add("16:00");
            listaDates.Add("16:30");
            listaDates.Add("17:00");
            listaDates.Add("17:30");
            listaDates.Add("18:00");

            foreach(string hora in listaDates)
            {
                cboHoraInicio.Items.Add(hora);
                cboHoraInicio.SelectedIndex = 0;
                cboHoraFim.Items.Add(hora);
                cboHoraFim.SelectedIndex = 0;
            }
            
        }

        private void cboDisciplina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            List<Professor> professores = ProfessorDAO.BuscarPorDisciplina(Convert.ToInt32(cboDisciplina.SelectedValue));
            cboProfessor.ItemsSource = professores;
            cboProfessor.DisplayMemberPath = "Pessoa.NomeCompleto";
            cboProfessor.SelectedValuePath = "Matricula";

            if (professores != null)
            {
                cboProfessor.SelectedIndex = 0;

            }
        }

        private void cboProfessor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void dpData_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
