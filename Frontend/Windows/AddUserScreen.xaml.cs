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
    /// Interaction logic for AddUserScreen.xaml
    /// </summary>
    public partial class AddUserScreen : Window
    {
        KitchenRequests KitchenRequestMaker = new KitchenRequests();
        UserRequests UserRequestMaker = new UserRequests();
        

        Guid KitchenId;

        public AddUserScreen(Guid KId)
        {
            InitializeComponent();
            KitchenId = KId;
        }

        public async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ClassLibrary.Objects.Binding newBind = new ClassLibrary.Objects.Binding();

            newBind.Id = Guid.NewGuid();
            newBind.KitchenId = KitchenId;
            newBind.UserId = await UserRequestMaker.getUserIdByName(NameTextBox.Text);

            if(newBind.UserId != Guid.Empty)
            {
                var res = await KitchenRequestMaker.CreateBind(newBind);
                DialogResult = true; // Close the dialog with DialogResult set to false
                Close();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Close the dialog with DialogResult set to false
            Close();
        }
    }
}
