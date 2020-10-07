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
    /// Interaction logic for frmCadastroUsuarioAlu.xaml
    /// </summary>
    public partial class frmCadastroUsuarioAlu : Window
    {
        private Pessoa pessoa;
        private Aluno aluno;
        public frmCadastroUsuarioAlu()
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
            aluno = new Aluno();
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
                if (Validacao.ValidarCpf(txtCPF.Text.Trim()))
                {
                    Random randNum = new Random();
                    string matricula = $"1{randNum.Next(10, 99)}";
                    while (AlunoDAO.BuscarPorMatricula(Convert.ToInt32(matricula)) != null)
                    {
                        matricula = $"1{randNum.Next(10, 99)}";
                    }

                    aluno = new Aluno
                    {
                        Matricula = Convert.ToInt32(matricula),
                        DataIngresso = dpDataIngresso.SelectedDate.Value,
                        Senha = txtSenha.Text,
                        NomeCompleto = txtNome.Text,
                        DataNascimento = dpDataNascimento.SelectedDate.Value,
                        Nacionalidade = txtNacionalidade.Text,
                        Cpf = txtCPF.Text,
                        Sexo = txtSexo.Text,
                        Email = txtEmail.Text
                    };


                    if (AlunoDAO.Cadastrar(aluno))
                    {
                        MessageBox.Show($"Usuário cadastrado com sucesso! Matricula: {matricula}", "Cadastrar Usuário",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Usuário já existe", "Cadastrar Usuário",
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
    }
}
