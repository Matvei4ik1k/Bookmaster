using Bookmaster.Model;
using Bookmaster.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        List<Customer> _customer = App.context.Customer.ToList();

        public ManageCustomersPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditCustomer editCustomer = new EditCustomer();
            editCustomer.Show();
        }

        private void SearchBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchIDTb.Text) && string.IsNullOrWhiteSpace(SearchNameTb.Text))
            {
                CustomersLv.ItemsSource = _customer;
            }
            else
            {
                List<Customer> SearchResults = _customer.Where(customer =>
                           customer.Id.ToLower().Contains(SearchIDTb.Text.ToLower()) &&
                           customer.Name.ToLower().Contains(SearchNameTb.Text.ToLower())).ToList();
                CustomersLv.ItemsSource = SearchResults;
            }
        }
    }
}


