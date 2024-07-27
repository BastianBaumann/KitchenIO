using Frontend.RequestSenders;
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

namespace Frontend.Windows
{
    /// <summary>
    /// Interaction logic for TakeItemWindow.xaml
    /// </summary>
    public partial class TakeItemWindow : Window
    {
        InventoryRequests ItemRequests = new InventoryRequests();
        ClassLibrary.Objects.Product currentProduct = new ClassLibrary.Objects.Product();

        public TakeItemWindow(ClassLibrary.Objects.Product UpdateProduct)
        {
            InitializeComponent();
            currentProduct = UpdateProduct;
        }

        public async void CheckAmount(object sender, RoutedEventArgs e)
        {
            double amountLeft = currentProduct.Amount - Convert.ToInt32(AmountTextBox.Text);

            if (amountLeft > 0)
            {
                currentProduct.Amount = amountLeft;
                string result = await ItemRequests.updateItem(currentProduct);

                if (result == "succuess")
                {
                    DialogResult = true; // Close the dialog with DialogResult set to true
                    Close();
                }
            }
            else
            {
                string result = await ItemRequests.deleteItem(currentProduct.Id);

                if (result == "succuess")
                {
                    DialogResult = true; // Close the dialog with DialogResult set to true
                    Close();
                }
            }
        }
    }
}
