using Bookmaster.Model;
using System.Collections.Generic;
using System.Linq;

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
        public int BooksCount => _books.Count;
        public int TotalPages => (BooksCount + PAGE_SIZE - 1) / PAGE_SIZE;
        public List<Book> CurrentPageOfBooks => _books.Skip(_currentPageIndex * PAGE_SIZE).Take(PAGE_SIZE).ToList();

        // Определяем конструктор класса для создания объекта. В конструктор передаем полный список книг

        public PaginationService(List<Book> books)
        {
            _books = books;
        }
    }
}
