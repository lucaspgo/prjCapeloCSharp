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
    /// Interaction logic for frmCadastroUsuarioAlu.xaml
    /// </summary>
    public partial class frmCadastroUsuarioAlu : Window
    {
        private Pessoa pessoa;
        private Aluno aluno;
        public frmCadastroUsuarioAlu()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                pessoa = new Pessoa
                {
                    NomeCompleto = txtNome.Text,
                    DataNascimento = Convert.ToDateTime(txtDataDeNasc.Text),
                    Nacionalidade = txtNacionalidade.Text,
                    Cpf = txtCPF.Text,
                    Sexo = txtSexo.Text,
                    Email = txtEmail.Text,

                };

                aluno = new Aluno
                {
                    DataIngresso = Convert.ToDateTime(txtDataIngresso.Text),
                    Senha = txtSenha.Text,
                    Pessoa = pessoa

                };

               
                if (AlunoDAO.Cadastrar(aluno))
                {
                    MessageBox.Show("Usuário cadastrado com sucesso!", "Cadastrar Usuário",
                        MessageBoxButton.OK, MessageBoxImage.Information);
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
    }
}
