using Bookmaster.AppData;
using Bookmaster.Model;
using Bookmaster.View.Windows;
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
            // BookAuthorLv.ItemsSource = _books;
        }

        private void SearchBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchByBookTitleTb.Text) && string.IsNullOrWhiteSpace(SearchByBookTitleTb.Text))
            {
                _booksPagination = new PaginationService(_books);
                // BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfBooks;
            }
            else
            {
                List<Book> SearchResults = _books.Where(book =>
                           book.Title.ToLower().Contains(SearchByBookTitleTb.Text.ToLower()) &&
                           book.Authors.ToLower().Contains(SearchByAuthorNameTb.Text.ToLower())).ToList();
                _booksPagination = new PaginationService(SearchResults);

            }
            BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfBooks;
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
            TotalPagesTbl.DataContext = TotalBooksTbl.DataContext = _booksPagination;
            _booksPagination.UpdatePaginationButtons(NextBookBtn, PreviousBookBtn);

            SearchResultsGrid.Visibility = Visibility.Visible;
        }

        private void PreviousBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.PreviousPage();
            _booksPagination.UpdatePaginationButtons(NextBookBtn, PreviousBookBtn);
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();

        }


        private void NextBookBtn_Click(object sender, RoutedEventArgs e)
        {

            BookAuthorLv.ItemsSource = _booksPagination.NextPage();
            _booksPagination.UpdatePaginationButtons(NextBookBtn, PreviousBookBtn);
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();

        }
        private void CurrentPageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(CurrentPageTb.Text, out int pageNumber) && pageNumber >= 1 && pageNumber <= _booksPagination.TotalPages)
            {
                BookAuthorLv.ItemsSource = _booksPagination.SetCurrentPage(pageNumber);
                _booksPagination.UpdatePaginationButtons(NextBookBtn, PreviousBookBtn);
            }
        }

        private void BookAuthorLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = BookAuthorLv.SelectedItem as Book;
            BookDetailsGrid.DataContext = selectedBook;
        }

        private void AuthorDetailHl_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow();
            bookAuthorsDetailsWindow.ShowDialog();
        }
    }
}
