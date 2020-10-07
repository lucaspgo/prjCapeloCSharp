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
        private List<dynamic> aulas = new List<dynamic>();
        Aula aula;
        public frmAula()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            PopularDataGrid();
            CarregarComboBoxes();
        }

        private void PopularDataGrid()
        {
            aulas = new List<dynamic>();
            List<Aula> aulaTeste = AulaDAO.BuscarPorMatriculaAluno(Convert.ToInt32(((frmLogin)Application.Current.MainWindow).txtLogin.Text));
            foreach (Aula aula in aulaTeste)
            {
                dynamic item = new
                {
                    Id = aula.Id,
                    Disciplina = aula.Professor.Disciplina.Nome,
                    NomeProfessor = aula.Professor.NomeCompleto,
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
            cboSala.ItemsSource = salas;
            cboSala.DisplayMemberPath = "Nome";
            cboSala.SelectedValuePath = "Id";
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

            foreach (string hora in listaDates)
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
            cboProfessor.DisplayMemberPath = "NomeCompleto";
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

        private void btnMarcarAula_Click(object sender, RoutedEventArgs e)
        {
            if (cboDisciplina.Text != null && cboProfessor != null && cboHoraInicio != null
                && cboHoraFim != null && dpData != null && cboSala != null)
            {
                bool datasLiberadas = true;
                DateTime dataInicio = Convert.ToDateTime($"{dpData.SelectedDate.Value.ToString("dd/MM/yyyy")} {cboHoraInicio.Text}");
                DateTime dataFim = Convert.ToDateTime($"{dpData.SelectedDate.Value.ToString("dd/MM/yyyy")} {cboHoraFim.Text}");

                foreach (Aula aula in AulaDAO.BuscarPorProfessoreData(Convert.ToInt32(cboProfessor.SelectedValue), Convert.ToDateTime(dpData.SelectedDate)))
                {
                    
                    if ((dataInicio >= aula.DataInicio && dataInicio < aula.DataFim))
                    {
                        datasLiberadas = false;
                    }
                }

                if(dataInicio > DateTime.Now)
                {
                    if (dataInicio < dataFim)
                    {
                        if (datasLiberadas)
                        {
                            int idProfessor = (int)cboProfessor.SelectedValue;
                            Professor professor = ProfessorDAO.BuscarPorMatricula(idProfessor);

                            int idSala = (int)cboSala.SelectedValue;
                            Sala sala = SalaDAO.BuscarPorId(idSala);

                            Aluno aluno = AlunoDAO.BuscarPorMatricula(Convert.ToInt32(((frmLogin)Application.Current.MainWindow).txtLogin.Text));

                            aula = new Aula
                            {
                                Aluno = aluno,
                                Professor = professor,
                                Sala = sala,
                                Data = Convert.ToDateTime($"{dpData.SelectedDate.Value.ToString("dd/MM/yyyy")} 00:00:00"),
                                DataInicio = Convert.ToDateTime($"{dpData.SelectedDate.Value.ToString("dd/MM/yyyy")} {cboHoraInicio.Text}"),
                                DataFim = Convert.ToDateTime($"{dpData.SelectedDate.Value.ToString("dd/MM/yyyy")} {cboHoraFim.Text}")
                            };

                            if (AulaDAO.Cadastrar(aula))
                            {
                                PopularDataGrid();
                                MessageBox.Show("Aula Cadastrada com Sucesso", "Agendar Aula",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este horario ja esta reservado", "Agendar Aula",
                                MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O horário de inicio não pode ser maior ou igual o horário final.", "Agendar Aula",
                                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Você não pode marcar data e horário menor que a data e hora atuais.", "Agendar Aula",
                                    MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                
                
            }
            else
            {
                MessageBox.Show("Preencha todos os dados para continuar", "Agendar Aula",
                        MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnCancelarAula_Click(object sender, RoutedEventArgs e)
        {
            if (dgAulas.SelectedItem != null)
            {
                aula = AulaDAO.BuscarPorId(((dynamic)dgAulas.SelectedItem).Id);

                if (MessageBox.Show($"Deseja realmente cancelar sua Aula?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (AulaDAO.Remover(aula))
                    {
                        PopularDataGrid();
                        MessageBox.Show("Aula removida com sucesso!", "Capelo",
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
                MessageBox.Show("Selecione um dado na tabela para a exclusão.", "Capelo",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
