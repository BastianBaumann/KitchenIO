using ClassLibrary.Objects;
using Frontend.RequestSenders;
using Frontend.Windows;
using KitchenIO.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for KitchenPage.xaml
    /// </summary>
    public partial class KitchenPage : Page
    {
        ObservableCollection<Recipe> recipeList = new ObservableCollection<Recipe>();
        ObservableCollection<Product> productList = new ObservableCollection<Product>();
        List<User> userList = new List<User>();

        Guid KitchenId;

        InventoryRequests InventoryerquestMaker = new InventoryRequests();
        KitchenRequests KitchenRequestMaker = new KitchenRequests();

        public KitchenPage(Guid KId)
        {
            KitchenId = KId;
            
            InitializeComponent();

            RecipeGrid.ItemsSource = recipeList;

            InventoryGrid.ItemsSource= productList;
            UpdateInventory();
            setUserString();
        }

        public async void setUserString()
        {
            List<User> userList = await KitchenRequestMaker.GetUserByKitchen(KitchenId);
            List<string> nameList = new List<string>();

            foreach (User user in userList)
            {
                nameList.Add(user.Name);
            }

            UserListLabel.Content = string.Join(",", nameList);
        }
        public async void UpdateInventory()
        {
            productList.Clear();
            List<Product> ProductL = await InventoryerquestMaker.GetInventoryByOwner(KitchenId);

            foreach (Product product in ProductL)
            {
                productList.Add(product);
            }
        }

        public void AddNewItem(object sender, RoutedEventArgs e)
        {
            AddItemScreen AddItemDialog = new AddItemScreen(KitchenId);

            bool? result = AddItemDialog.ShowDialog();

            if (result == true)
            {
                UpdateInventory();
            }
        }
        public void GetRecipes(object sender, RoutedEventArgs e)
        {

        }
        public void AddUserB(object sender, RoutedEventArgs e)
        {
            AddUserScreen AddUserDialog = new AddUserScreen(KitchenId);

            bool? result = AddUserDialog.ShowDialog();

            if (result == true)
            {
                setUserString();
            }
        }
    }
}
