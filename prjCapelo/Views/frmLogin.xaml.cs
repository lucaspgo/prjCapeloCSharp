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
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        private Aluno aluno;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAcessar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLogin.Text) && !string.IsNullOrWhiteSpace(txtSenha.Password))
            {
                int digitoVerificador = Convert.ToInt32(txtLogin.Text.Substring(0, 1));

                
                if (digitoVerificador == 1)
                {
                    Aluno aluno = AlunoDAO.BuscarPorMatricula(Convert.ToInt32(txtLogin.Text));

                    if (aluno != null)
                    {
                        if (txtSenha.Password.Equals(aluno.Senha))
                        {
                            frmAula frm = new frmAula();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Login ou Senha Inválido!", "Capelo",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login ou Senha Inválido!", "Capelo",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if(digitoVerificador == 2)
                {
                    Professor professor = ProfessorDAO.BuscarPorMatricula(Convert.ToInt32(txtLogin.Text));

                    if (professor != null)
                    {
                        if (txtSenha.Password.Equals(professor.Senha))
                        {
                            frmPainelProfessor frm = new frmPainelProfessor();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Login ou Senha Inválido!", "Capelo",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login ou Senha Inválido!", "Capelo",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }                
            }
            else
            {
                MessageBox.Show("Login ou senha não preenchidos!", "Capelo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
