using Bookmaster.AppData;
using Bookmaster.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowserCatalogPage.xaml
    /// </summary>
    public partial class BrowserCatalogPage : Page
    {
        List<Book> _books = App.context.Book.ToList();

        // Определяем объект пагинации
        PaginationService _booksPagination;

        public BrowserCatalogPage()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchByBookTitleTb.Text) && string.IsNullOrWhiteSpace(SearchByBookTitleTb.Text))
            {
                _booksPagination = new PaginationService(_books);
                BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfBooks;
            }
            else
            {
                List<Book> SearchResults = _books.Where(book =>
                           book.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) &&
                           book.Authors.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower())).ToList();
                _booksPagination = new PaginationService(SearchResults);

            }
            BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfBooks;

            SearchResultsGrid.Visibility = Visibility.Visible;
        }
    }
}
