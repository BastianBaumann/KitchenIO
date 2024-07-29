using ClassLibrary.Objects;
using KitchenIO.Objects;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Frontend.Windows
{
    public partial class AddItemReference : Window
    {
        ProductRequests ProductRequestMaker = new ProductRequests();
        string sentBarcode;
        bool continueL = true;
        string result;

        public AddItemReference(string Barcode)
        {
            InitializeComponent();
            sentBarcode = Barcode;
            BarcodeTextBox.Text = sentBarcode;
            BarcodeTextBox.IsManipulationEnabled = false;
        }

        string CheckAllAllergies()
        {
            List<CheckBox> checkBoxes = new List<CheckBox>
            {
                (CheckBox)FindName("GrainsCheck"),
                (CheckBox)FindName("DairyCheck"),
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
                        case "DairyCheck":
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
        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ProductRef newProductRef = new ProductRef();
            newProductRef.Id = Guid.NewGuid();
            newProductRef.Name = NameTextBox.Text;
            newProductRef.Barcode = sentBarcode;
            newProductRef.Price = Convert.ToDouble(PriceTextBox.Text);
            string Allergents = CheckAllAllergies();
            newProductRef.Type = Allergents;

            if (grammsCheck.IsChecked == true && piecesCheck.IsChecked == true)
            {
                grammsCheck.IsChecked = false;
                piecesCheck.IsChecked = false;
                continueL = false;
            }
            if (grammsCheck.IsChecked == true)
            {
                newProductRef.meassurement = "g";
                continueL = true;
            }
            else if (piecesCheck.IsChecked == true)
            {
                newProductRef.meassurement = "pc's";
                continueL = true;
            }
            
            if(continueL)
            {
                result = await ProductRequestMaker.PushProductRef(newProductRef);
            }
            
            if (result == "succuess")
            {
                DialogResult = true; 
                Close();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
