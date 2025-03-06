using System.Linq;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowserCatalogPage.xaml
    /// </summary>
    public partial class BrowserCatalogPage : Page
    {
        public BrowserCatalogPage()
        {
            InitializeComponent();
            BookAuthorLv.ItemsSource = App.context.BookAuthor.ToList();


        }

    }
}
