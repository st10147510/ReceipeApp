using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ReceipeApp.Commands;
using ReceipeApp.Models;
using ReceipeApp.Views;
using ReceipeApp.Services;

namespace ReceipeApp.ModelViews
{
    public class MainViewModel
    {

        private ReceipeService receipeService = new ReceipeService();
        public ObservableCollection<Receipe> Receipes { get; set; }

        public ICommand ShowWindowCommand { get; set; }



        public MainViewModel()
        {
            Receipes = receipeService.GetAllRecipes();

            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);

        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;

            AddReceipe addReceipeWin = new AddReceipe();
            addReceipeWin.Owner = mainWindow;
            addReceipeWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addReceipeWin.Show();


        }
    }
}
