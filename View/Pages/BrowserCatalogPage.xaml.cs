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
        List<BookAuthor> _bookAuthors = App.context.BookAuthor.ToList();
        public BrowserCatalogPage()
        {
            InitializeComponent();
            BookAuthorLv.ItemsSource = _bookAuthors;
        }

        private void SearchBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _bookAuthors.Where(bookAuthor =>
            bookAuthor.Book.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) &&
            bookAuthor.Author.Name.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower()));
        }
    }
}
