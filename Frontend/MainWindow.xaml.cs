using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KitchenIO.Objects;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void testFunc(object sender, RoutedEventArgs e)
        {
            KitchenIO.Objects.Product product = new KitchenIO.Objects.Product();
            product.Id = Guid.NewGuid();
            product.name = testbarcode.Text.ToString();
            product.barcode = Convert.ToInt32(product.name);
            product.amount = 5;
            product.price = 12.50;
            product.weight = 120;

            testLabel.Content = "success";
        }
    }
}