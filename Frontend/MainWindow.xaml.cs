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
using ClassLibrary.Objects;
using KitchenIO.Objects;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestRequests RequestMaker = new TestRequests();
        ObservableCollection<ProductRef> ProductList = new ObservableCollection<ProductRef>();

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = ProductList;
            getAllProductRefs();
        }

        /*
        public async void testFunc(object sender, RoutedEventArgs e)
        {

            Product newProduct = await RequestMaker.sendGetRequest("https://localhost:7135/API/GetTest");
            testLabel.Content = newProduct.Name.ToString();
        }
        */

        public async void getAllProductRefs()
        {
            ProductList.Clear();
            List<ProductRef> PL = await RequestMaker.PullProductRefs();
            foreach(ProductRef product in PL)
            {
                ProductList.Add(product);
            }
        }

        public async void createProductRef(object sender, RoutedEventArgs e)
        {
            ProductRef newProductRef = new ProductRef();
            newProductRef.Id = Guid.NewGuid();
            newProductRef.Name = testName.Text;
            newProductRef.Barcode = Convert.ToInt32(testbarcode.Text);
            newProductRef.Price = Convert.ToDouble(testPrice.Text);
            newProductRef.Type = Convert.ToInt32(testType.Text);

            string result = await RequestMaker.PushProductRef(newProductRef);

            testName.Text = "";
            testbarcode.Text = "";
            testPrice.Text = "";
            testType.Text = "";


            getAllProductRefs();
        }

        public async void createInvProduct(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product();

            newProduct.Id = Guid.NewGuid();
            newProduct.Amount = 1;
            newProduct.Weight = 1;

        }
    }
}