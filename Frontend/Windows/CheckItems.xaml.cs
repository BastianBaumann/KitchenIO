using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClassLibrary.Objects;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Frontend.Windows
{
    public partial class CheckItems : Window
    {
        public CheckItems(List<Product> products)
        {
            InitializeComponent();
            CheckFoodGrid.ItemsSource = products;
        }
        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            DialogResult = true; 
            Close();
        }
    }
}
