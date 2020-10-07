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
using prjCapelo.Models;
using prjCapelo.DAL;
using prjCapelo.Utils;

namespace prjCapelo.Views
{
    /// <summary>
    /// Interaction logic for frmCadastroUsuarioProf.xaml
    /// </summary>
    public partial class frmCadastroUsuarioProf : Window
    {
        private Pessoa pessoa;
        private Professor professor;
        public frmCadastroUsuarioProf()
        {
            InitializeComponent();
            LimparFormulario();
        }

        public void LimparFormulario()
        {
            txtNome.Clear();
            dpDataNascimento.SelectedDate = null;
            txtNacionalidade.Clear();
            txtCPF.Clear();
            txtSexo.Clear();
            txtEmail.Clear();
            dpDataNascimento.SelectedDate = null;
            txtSenha.Clear();
            professor = new Professor();
            pessoa = new Pessoa();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(txtNome.Text) &&
                dpDataNascimento.SelectedDate != null &&
                !string.IsNullOrWhiteSpace(txtNacionalidade.Text) &&
                !string.IsNullOrWhiteSpace(txtCPF.Text) &&
                !string.IsNullOrWhiteSpace(txtSexo.Text) &&
                !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                dpDataIngresso.SelectedDate != null &&
                !string.IsNullOrWhiteSpace(txtSenha.Text)
                )
            {
                if (Validacao.ValidarCpf(txtCPF.Text.Trim()))
                {
                    int id = (int)cboDisciplina.SelectedValue;
                    Disciplina disciplina = DisciplinaDAO.BuscarPorId(id);

                    Random randNum = new Random();
                    string matricula = $"2{randNum.Next(10, 99)}";
                    while (AlunoDAO.BuscarPorMatricula(Convert.ToInt32(matricula)) != null)
                    {
                        matricula = $"2{randNum.Next(10, 99)}";
                    }

                    professor = new Professor
                    {
                        Matricula = Convert.ToInt32(matricula),
                        DataIngresso = dpDataIngresso.SelectedDate.Value,
                        Senha = txtSenha.Text,
                        NomeCompleto = txtNome.Text,
                        DataNascimento = dpDataNascimento.SelectedDate.Value,
                        Nacionalidade = txtNacionalidade.Text,
                        Cpf = txtCPF.Text,
                        Sexo = txtSexo.Text,
                        Email = txtEmail.Text,
                        Disciplina = disciplina
                    };


                    if (ProfessorDAO.Cadastrar(professor))
                    {
                        MessageBox.Show($"Usuário cadastrado com sucesso! Matricula: {matricula}", "Cadastrar Usuário",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Usuário já existe!", "Cadastrar Usuário",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("CPF INválido.", "Cadastrar Usuário",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha as informações de cadastro!", "Cadastrar Usuário",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cboDisciplina_Loaded(object sender, RoutedEventArgs e)
        {
            cboDisciplina.ItemsSource = DisciplinaDAO.Listar();
            cboDisciplina.DisplayMemberPath = "Nome";
            cboDisciplina.SelectedValuePath = "Id";
        }
    }
}
