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
    /// Interaction logic for frmCadastrarUsuario1.xaml
    /// </summary>
    public partial class frmCadastrarUsuario1 : Window
    {
        public frmCadastrarUsuario1()
        {
            InitializeComponent();
        }

        private void btnFichaProfessor_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroUsuarioProf frm = new frmCadastroUsuarioProf();
            frm.ShowDialog();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnFichaAluno_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroUsuarioAlu frm = new frmCadastroUsuarioAlu();
            frm.ShowDialog();
        }
    }
}
