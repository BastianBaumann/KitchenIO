using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary.Objects;
using Frontend.RequestSenders;
using KitchenIO.Objects;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Guid LoggedInUserID = Guid.NewGuid();

        ProductRequests ProductRequestMaker = new ProductRequests();
        InventoryRequests InventoryerquestMaker = new InventoryRequests();

        ObservableCollection<ProductRef> ProductList = new ObservableCollection<ProductRef>();
        ObservableCollection<Product> InventoryList = new ObservableCollection<Product>();

        private void OpenLoginWindow()
        {

            AccountScreen loginWindow = new AccountScreen();
            loginWindow.GuidReturned += OnGuidReturned;
            loginWindow.Show();
        }

        private void OnGuidReturned(Guid returnedGuid)
        {
            LoggedInUserID = returnedGuid;
            UpdateProductRefs();
            UpdateInventory();
            MenuTabControl.Visibility = Visibility.Visible;
        }

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = ProductList;
            ProductdataGrid.ItemsSource = InventoryList;
            OpenLoginWindow();
        }

        public async void UpdateProductRefs()
        {
            ProductList.Clear();
            List<ProductRef> PL = await ProductRequestMaker.PullProductRefs();
            foreach(ProductRef product in PL)
            {
                ProductList.Add(product);
            }
        }

        public async void UpdateInventory()
        {
            InventoryList.Clear();
            List<Product> ProductL = await InventoryerquestMaker.GetInventoryByOwner(LoggedInUserID);

            foreach(Product product in ProductL)
            {
                InventoryList.Add(product);
            }
        }

        public async void createProductRefButton(object sender, RoutedEventArgs e)
        {
            ProductRef newProductRef = new ProductRef();
            newProductRef.Id = Guid.NewGuid();
            newProductRef.Name = testName.Text;
            newProductRef.Barcode = testbarcode.Text;
            newProductRef.Price = Convert.ToDouble(testPrice.Text);
            newProductRef.Type = Convert.ToInt32(testType.Text);

            string result = await ProductRequestMaker.PushProductRef(newProductRef);

            testName.Text = "";
            testbarcode.Text = "";
            testPrice.Text = "";
            testType.Text = "";


            UpdateProductRefs();
        }

        public async void AddProductButton(object sender, RoutedEventArgs e)
        {

            Product newProduct = new Product();

            //int Barcode = Convert.ToInt32(newProductbarcode.Text);
            ProductRef foundProductRef = await ProductRequestMaker.GetProductRefByBarcode(newProductbarcode.Text);

            if(foundProductRef.Id.ToString() != "")
            {
                newProduct.ProductId = foundProductRef.Id;
                newProduct.Id = Guid.NewGuid();
                newProduct.Amount = Convert.ToDouble(newProductAmount.Text);
                newProduct.Weight = Convert.ToDouble(newProductWeight.Text);
                DateTime newDate = EpDate.SelectedDate.Value;
                newProduct.EP = newDate;
                newProduct.Owner = LoggedInUserID;

                string result = await InventoryerquestMaker.AddToInventorie(newProduct);

                newProductbarcode.Text = "";
                newProductAmount.Text = "";
                newProductWeight.Text = "";
            }
            UpdateInventory();
        }

    }
}