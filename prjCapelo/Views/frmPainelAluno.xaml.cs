﻿using prjCapelo.Models;
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
    /// Interaction logic for frmPainelAluno.xaml
    /// </summary>
    public partial class frmPainelAluno : Window
    {
        public frmPainelAluno()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblMatricula.Content = ((frmLogin)Application.Current.MainWindow).txtLogin.Text;
        }

        private void menuAula_Click(object sender, RoutedEventArgs e)
        {
            frmAula frm = new frmAula();
            frm.ShowDialog();
        }
    }
}