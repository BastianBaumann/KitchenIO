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
using Frontend.RequestSenders;
using KitchenIO.Objects;



namespace Frontend
{
    /// <summary>
    /// Interaction logic for AccountScreen.xaml
    /// </summary>
    public partial class AccountScreen : Window
    {
        public event Action<Guid> GuidReturned;

        UserRequests userRequests = new UserRequests();
        public AccountScreen()
        {
            InitializeComponent();
        }

        private string CheckAllAllergies()
        {
            List<CheckBox> checkBoxes = new List<CheckBox>
            {
                (CheckBox)FindName("GrainsCheck"),
                (CheckBox)FindName("DairyChecl"),
                (CheckBox)FindName("EggCheck"),
                (CheckBox)FindName("NutsCheck"),
                (CheckBox)FindName("SeedCheck"),
                (CheckBox)FindName("FishCheck"),
                (CheckBox)FindName("ShellfishCheck"),
                (CheckBox)FindName("SoyCheck"),
                (CheckBox)FindName("FruitCheck"),
                (CheckBox)FindName("VegetablesCheck"),
                (CheckBox)FindName("LegumesCheck"),
                (CheckBox)FindName("SweetenersCheck"),
                (CheckBox)FindName("FatsOilsCheck"),
                (CheckBox)FindName("SpicesHerbsCheck"),
                (CheckBox)FindName("AddativesCheck"),
                (CheckBox)FindName("FermentedCheck")
            };

            List<string> allergies = new List<string>();

            foreach (var checkBox in checkBoxes)
            {
                if (checkBox.IsChecked == true)
                {
                    // Add allergy code based on CheckBox name
                    switch (checkBox.Name)
                    {
                        case "GrainsCheck":
                            allergies.Add("1"); // or appropriate value
                            break;
                        case "DairyChecl":
                            allergies.Add("2");
                            break;
                        case "EggCheck":
                            allergies.Add("3");
                            break;
                        case "NutsCheck":
                            allergies.Add("4");
                            break;
                        case "SeedCheck":
                            allergies.Add("5");
                            break;
                        case "FishCheck":
                            allergies.Add("6");
                            break;
                        case "ShellfishCheck":
                            allergies.Add("7");
                            break;
                        case "SoyCheck":
                            allergies.Add("8");
                            break;
                        case "FruitCheck":
                            allergies.Add("9");
                            break;
                        case "VegetablesCheck":
                            allergies.Add("10");
                            break;
                        case "LegumesCheck":
                            allergies.Add("11");
                            break;
                        case "SweetenersCheck":
                            allergies.Add("12");
                            break;
                        case "FatsOilsCheck":
                            allergies.Add("13");
                            break;
                        case "SpicesHerbsCheck":
                            allergies.Add("14");
                            break;
                        case "AddativesCheck":
                            allergies.Add("15");
                            break;
                        case "FermentedCheck":
                            allergies.Add("16");
                            break;
                    }
                }
            }
            return string.Join(",", allergies);
        }

        public async void LoginUser(object sender, RoutedEventArgs e)
        {
            User userToLogin = new User();
            userToLogin.Name = LoginName.Text;
            userToLogin.Password = LoginPassword.Text;

            Guid userGuid = await userRequests.Login(userToLogin.Name, userToLogin.Password);

            IDLabel.Content = userGuid.ToString();

            if(userGuid != Guid.Empty)
            {
                Guid returnedGuid = userGuid;
                GuidReturned?.Invoke(returnedGuid);
                Close();
            }
        }

        public async void RegisterUser(object sender, RoutedEventArgs e)
        {
            User RegisterUser = new User();

            RegisterUser.Id = Guid.NewGuid();
            RegisterUser.Name = RegisterName.Text;
            RegisterUser.Password = RegisterPassword.Text;
            RegisterUser.Allergies = CheckAllAllergies();

            string test = await userRequests.PushUser(RegisterUser);
        }
    }
}
