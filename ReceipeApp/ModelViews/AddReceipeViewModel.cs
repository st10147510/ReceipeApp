using ReceipeApp.Commands;
using ReceipeApp.Models;
using ReceipeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReceipeApp.ModelViews
{
    class AddReceipeViewModel
    {
        private ReceipeService receipeService;

        public ICommand AddReceipeCommand { get; set; }

        public string? Name { get; set; }
        public string? CookTime { get; set; }
        public string? Serves { get; set; }
        //public List<Ingredient>? Ingredients { get; set; }
        //public List<Step>? Steps { get; set; }

        public AddReceipeViewModel()
        {
            receipeService = new ReceipeService();
            AddReceipeCommand = new RelayCommand(AddReceipe, CanAddReceipe);
        }

        private bool CanAddReceipe(object obj)
        {
            return true;
        }

        private void AddReceipe(object obj)
        {
            Receipe receipe = new Receipe() { Name = Name, CookTime = CookTime, Serves = Serves };
            receipeService.CreateReceipe(receipe);

        }
    }
}
