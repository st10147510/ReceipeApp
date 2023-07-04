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
using System.Windows.Shapes;

namespace ReceipeApp.Views
{
    /// <summary>
    /// Interaction logic for AddReceipe.xaml
    /// </summary>
    public partial class AddReceipe : Window
    {
        public AddReceipe()
        {
            InitializeComponent();
            AddReceipeViewModel addReceipeViewModel = new AddReceipeViewModel();
            this.DataContext = addReceipeViewModel;
        }
    }
}
