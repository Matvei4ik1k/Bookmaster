using Bookmaster.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowserCatalogPage.xaml
    /// </summary>
    public partial class BrowserCatalogPage : Page
    {
        List<Book> _books = App.context.Book.ToList();
        public BrowserCatalogPage()
        {
            InitializeComponent();
            BookAuthorLv.ItemsSource = _books;
        }

        private void SearchBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _books.Where(book =>
            book.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) &&
            book.Authors.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower()));
        }
    }
}
