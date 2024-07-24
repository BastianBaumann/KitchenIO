using ClassLibrary.Objects;
using Frontend.RequestSenders;
using KitchenIO.Objects;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for AddItemScreen.xaml
    /// </summary>
    public partial class AddItemScreen : Window
    {
        ProductRequests ProductRequestMaker = new ProductRequests();
        InventoryRequests InventoryerquestMaker = new InventoryRequests();

        Guid KitchenId;

        public AddItemScreen(Guid KitchenID)
        {
            KitchenId = KitchenID;
            InitializeComponent();
        }

        public string Barcode { get; private set; }
        public double Amount { get; private set; }
        public double Weight { get; private set; }
        public DateTime ExDate { get; private set; }

        
        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Barcode = BarcodeTextBox.Text;
            ProductRef foundProductRef = await ProductRequestMaker.GetProductRefByBarcode(Barcode);

            if(foundProductRef.Id != Guid.Empty)
            {
                Product newProduct = new Product();

                newProduct.Id = Guid.NewGuid();
                newProduct.ProductId = foundProductRef.Id;
                newProduct.Amount = Convert.ToDouble(AmountTextBox.Text);
                newProduct.Weight = Convert.ToDouble(WeightTextBox.Text);
                DateTime newDate = EPDatePicker.SelectedDate.Value;
                newProduct.EP = newDate;
                newProduct.Owner = KitchenId;

                string result = await InventoryerquestMaker.AddToInventorie(newProduct);

                if(result == "succuess")
                {
                DialogResult = true; // Close the dialog with DialogResult set to true
                Close();
                }
                else
                {
                    MessageBox.Show("Error while adding new Product", "Alert", (MessageBoxButton)MessageBoxImage.Information);
                }
                
            }
            else
            {
                BarcodeTextBox.Text = "";
                AmountTextBox.Text = "";
                WeightTextBox.Text = "";
                MessageBox.Show("Please enter a Valid Barcode", "Alert", (MessageBoxButton)MessageBoxImage.Information);

            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Close the dialog with DialogResult set to false
            Close();
        }
    }
}

