using Bookmaster.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Bookmaster.AppData
{
    public class PaginationService
    {
        // Определяем поля для хранения данных
        private const int PAGE_SIZE = 50;
        private readonly List<Book> _books;
        private int _currentPageIndex = 0;
        private int _currentPageNumber = 1;

        // Определяем свойства для вычисления и хранения данных
        public int CurrentPageNumber
        {
            get
            {
                return _currentPageNumber = _currentPageIndex + 1;
            }
            set
            {
                _currentPageNumber = value;
                _currentPageIndex = value - 1;
            }
        }
        public int BooksCount => _books.Count;
        public int TotalPages => (BooksCount + PAGE_SIZE - 1) / PAGE_SIZE;
        public List<Book> CurrentPageOfBooks => _books.Skip(_currentPageIndex * PAGE_SIZE).Take(PAGE_SIZE).ToList();

        // Определяем конструктор класса для создания объекта. В конструктор передаем полный список книг

        public PaginationService(List<Book> books)
        {
            _books = books;
        }

        // Определяем методы класса для реализации действий объекта.
        public List<Book> NextPage()
        {
            if (_currentPageIndex < TotalPages - 1)
            {
                _currentPageIndex++;
            }
            return CurrentPageOfBooks;

        }
        public List<Book> PreviousPage()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
            }
            return CurrentPageOfBooks;
        }

        public void UpdatePaginationButtons(Button nextBtn, Button previousBtn)
        {
            nextBtn.IsEnabled = _currentPageIndex < TotalPages - 1;
            previousBtn.IsEnabled = _currentPageIndex > 0;
        }

        public List<Book> SetCurrentPage(int pageNumber)
        {
            CurrentPageNumber = pageNumber;
            return CurrentPageOfBooks;
        }
    }
}
