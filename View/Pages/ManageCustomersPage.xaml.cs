using Bookmaster.View.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        public ManageCustomersPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditCustomer editCustomer = new EditCustomer();
            editCustomer.Show();
        }
    }
}
