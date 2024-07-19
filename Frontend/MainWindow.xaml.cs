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
        TestRequests testRequestMaker = new TestRequests();
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void testFunc(object sender, RoutedEventArgs e)
        {

            Product newProduct = await testRequestMaker.TestProductCreation();
            testLabel.Content = newProduct.name.ToString();
        }
    }
}