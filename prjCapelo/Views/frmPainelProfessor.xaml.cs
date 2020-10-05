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
        public frmPainelProfessor()
        {
            InitializeComponent();
        }

        private void btnCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarUsuario1 frm = new frmCadastrarUsuario1();
            frm.ShowDialog();
        }
    }
}
