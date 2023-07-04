﻿using ReceipeApp.Models;
using ReceipeApp.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReceipeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReceipeList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            var receipe = (Receipe)obj;

            return receipe.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);


        }
    }
}
