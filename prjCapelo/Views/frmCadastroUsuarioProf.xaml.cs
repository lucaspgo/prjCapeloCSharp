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
            txtDataDeNasc.Clear();
            txtNacionalidade.Clear();
            txtCPF.Clear();
            txtSexo.Clear();
            txtEmail.Clear();
            txtDataIngresso.Clear();
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
            
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                int id = (int)cboDisciplina.SelectedValue;
                Disciplina disciplina = DisciplinaDAO.BuscarPorId(id);

                pessoa = new Pessoa
                {
                    NomeCompleto = txtNome.Text,
                    DataNascimento = Convert.ToDateTime(txtDataDeNasc.Text),
                    Nacionalidade = txtNacionalidade.Text,
                    Cpf = txtCPF.Text,
                    Sexo = txtSexo.Text,
                    Email = txtEmail.Text,

                };

                professor = new Professor
                {
                    DataIngresso = Convert.ToDateTime(txtDataIngresso.Text),
                    Senha = txtSenha.Text,
                    Pessoa = pessoa,
                    Disciplina = disciplina

                };


                if (ProfessorDAO.Cadastrar(professor))
                {
                    MessageBox.Show("Usuário cadastrado com sucesso!", "Cadastrar Usuário",
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
