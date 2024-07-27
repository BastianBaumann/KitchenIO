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
    /// <summary>
    /// Interaction logic for DeleteUserScreen.xaml
    /// </summary>
    public partial class DeleteUserScreen : Window
    {
        KitchenRequests KitchenRequestMaker = new KitchenRequests();
        UserRequests UserRequestMaker = new UserRequests();


        Guid IDToDelete;
        public DeleteUserScreen(Guid KitchenId)
        {
            InitializeComponent();
            IDToDelete = KitchenId;
        }

        public async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ClassLibrary.Objects.Binding newBind = new ClassLibrary.Objects.Binding();

            newBind.KitchenId = IDToDelete;
            newBind.UserId = await UserRequestMaker.getUserIdByName(NameTextBox.Text);

            if (newBind.UserId != Guid.Empty)
            {
                var res = await KitchenRequestMaker.DeleteBind(newBind.UserId, IDToDelete);
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
