using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Automation;
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
using Frontend.Pages;
using Frontend.RequestSenders;
using Frontend.Windows;
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
        KitchenRequests KitchenRequestMaker = new KitchenRequests();

        ObservableCollection<ProductRef> ProductList = new ObservableCollection<ProductRef>();
        ObservableCollection<Product> InventoryList = new ObservableCollection<Product>();

        List<ClassLibrary.Objects.Binding> AllBindings = new List<ClassLibrary.Objects.Binding>();

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
            createKitchenTabs();
            MenuTabControl.Visibility = Visibility.Visible;
        }

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = ProductList;
            ProductdataGrid.ItemsSource = InventoryList;
            OpenLoginWindow();
        }
        public async Task<int> getAllBindings()
        {
            AllBindings.Clear();
            List<ClassLibrary.Objects.Binding> newBindList = await KitchenRequestMaker.getBindingsByUser(LoggedInUserID);
            
            foreach(ClassLibrary.Objects.Binding bind in newBindList)
            {
                AllBindings.Add(bind);
            }

            return AllBindings.Count();
            
        }

        public async void createKitchenTabs()
        {
            int test = await getAllBindings();
            KitchenTabControl.Items.Clear();

            foreach (ClassLibrary.Objects.Binding bind in AllBindings)
            {
                Frame frame = new Frame();
                KitchenPage kitchenPage = new KitchenPage(bind.KitchenId);
                frame.Navigate(kitchenPage); // Navigieren zur Page

                TabItem newKitchenTab = new TabItem
                {
                    Header = "Kitchen",
                    Content = frame
                };

                // Hinzufügen des TabItems zum TabControl
                KitchenTabControl.Items.Add(newKitchenTab);
            }
        }
        public void CreateNewKitchen(object sender, RoutedEventArgs e)
        {
            AddNewKitchen AddItemDialog = new AddNewKitchen(LoggedInUserID);

            bool? result = AddItemDialog.ShowDialog();

            if (result == true)
            {
                createKitchenTabs();
            }
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
            newProductRef.Type = testType.Text;

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
        public async void takeProduct(object sender, RoutedEventArgs e)
        {

        }
    }
}