using ClassLibrary.Objects;
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
    public partial class AddNewKitchen : Window
    {
        Guid UserId;

        KitchenRequests KitchenRequestMaker = new KitchenRequests();
        public AddNewKitchen(Guid UserID)
        {
            UserId = UserID;
            InitializeComponent();
        }

        public async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Kitchen newKitchen = new Kitchen();

            newKitchen.Id = Guid.NewGuid();
            newKitchen.Name = NameTextBox.Text;
            newKitchen.Description = DescriptionTextBox.Text;

            ClassLibrary.Objects.Binding newBind = new ClassLibrary.Objects.Binding();

            newBind.Id = Guid.NewGuid();
            newBind.KitchenId = newKitchen.Id;
            newBind.UserId = UserId;

            string result = await KitchenRequestMaker.CreateKitchen(newKitchen);
            string newResult = await KitchenRequestMaker.CreateBind(newBind);
            DialogResult = true; 
            Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; 
            Close();
        }
    }
}
