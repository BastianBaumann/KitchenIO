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
using System.Windows.Forms;
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

        List<string> allergieList = new List<string>();
        List<User> userList = new List<User>();

        Guid KitchenId;

        InventoryRequests InventoryerquestMaker = new InventoryRequests();
        KitchenRequests KitchenRequestMaker = new KitchenRequests();
        RecipeRequests RecipeRequestMaker = new RecipeRequests();
        ProductRequests ProductRequestMaker = new ProductRequests();

        public KitchenPage(Guid KId)
        {
            KitchenId = KId;

            InitializeComponent();

            RecipeGrid.ItemsSource = recipeList;

            InventoryGrid.ItemsSource = productList;
            UpdateInventory();
            setUserString();
        }
        public async void setUserString()
        {
            userList.Clear();
            userList = await KitchenRequestMaker.GetUserByKitchen(KitchenId);
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
        public async void GetRecipes(object sender, RoutedEventArgs e)
        {
            string food = "Pork";

            foreach (User user in userList)
            {
                allergieList.Add(user.Allergies);
            }
            string res = string.Join(",", allergieList);

            recipeList.Clear();
            List<Recipe> newRecipeList = new List<Recipe>();
            newRecipeList = await RecipeRequestMaker.getRecipeWithAllergies(food, res);

            foreach (Recipe rec in newRecipeList)
            {
                recipeList.Add(rec);
            }
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
        public async void ValidateFoodItems(object sender, RoutedEventArgs e)
        {
            List<Product> FoodsToCheck = new List<Product>();
            FoodsToCheck = await ProductRequestMaker.validateKitchenFoods(KitchenId);

            CheckItems AddItemDialog = new CheckItems(FoodsToCheck);

            bool? result = AddItemDialog.ShowDialog();

            if (result == true)
            {
                Console.WriteLine("product");
            }
        }

        public async void TakeItem(object sender, RoutedEventArgs e)
        {
            if (InventoryGrid.SelectedItem != null)
            {
                Product ProductToTake = InventoryGrid.SelectedItem as Product;
                Console.WriteLine(ProductToTake.Id);

                TakeItemWindow TakeDialog = new TakeItemWindow(ProductToTake);

                bool? result = TakeDialog.ShowDialog();

                if (result == true)
                {
                    UpdateInventory();
                }
            }
        }
    }
}
    