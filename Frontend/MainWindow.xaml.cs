using System.Collections.ObjectModel;
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
        TestRequests RequestMaker = new TestRequests();
        ObservableCollection<Product> ProductList = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = ProductList;
            getAllProducts();
        }

        /*
        public async void testFunc(object sender, RoutedEventArgs e)
        {

            Product newProduct = await RequestMaker.sendGetRequest("https://localhost:7135/API/GetTest");
            testLabel.Content = newProduct.Name.ToString();
        }
        */

        public async void getAllProducts()
        {
            ProductList.Clear();
            List<Product> PL = await RequestMaker.PullProducts();
            foreach(Product product in PL)
            {
                ProductList.Add(product);
            }
        }

        public async void createProduct(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product();
            newProduct.Id = Guid.NewGuid();
            newProduct.Name = testName.Text;
            newProduct.Barcode = Convert.ToInt32(testbarcode.Text);
            newProduct.Price = Convert.ToDouble(testPrice.Text);
            newProduct.Type = Convert.ToInt32(testType.Text);

            string result = await RequestMaker.PushProduct(newProduct);

            testName.Text = "";
            testbarcode.Text = "";
            testPrice.Text = "";
            testType.Text = "";

            getAllProducts();
        }
    }
}