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

        public KitchenPage(Guid KId)
        {
            KitchenId = KId;
            
            InitializeComponent();

            RecipeGrid.ItemsSource = recipeList;

            InventoryGrid.ItemsSource= productList;
            UpdateInventory();

            userListLabel.Content = userList;


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

        public async void AddNewItem()
        {
            AddItemScreen AddItemDialog = new AddItemScreen(KitchenId);

            bool? result = AddItemDialog.ShowDialog();

            if (result == true)
            {
                UpdateInventory();
            }
        }
    }
}
