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
        private int _currentPageIndex;
        private int _currentPageNumber;

        // Определяем свойства для вычисления и хранения данных
        public int BooksCount => _books.Count;
        public int TotalPages => BooksCount + PAGE_SIZE - 1;
        public List<Book> CurrentPageOfBooks => _books.Skip(_currentPageIndex * PAGE_SIZE).Take(PAGE_SIZE).ToList();
    }
}
