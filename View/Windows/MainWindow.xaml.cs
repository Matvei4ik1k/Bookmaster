using Bookmaster.View.Pages;
using System.Windows;

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
        }

        private void LogOutMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseCatalogMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new BrowserCatalogPage());
        }

        private void ManageCustomersMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new ManageCustomersPage());

        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new CirculationPage());

        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new ReportsPage());

        }
    }
}


// #Способы навигации в WPF
#region 1) Оконная навигация
// Осуществляет открытие нового экземпляра окна из другого окна или страницы.
// Алгоритм для реализации (окно называется TestWindows.xaml):

// - создать экземпляр окна TestWindows.xaml
// - у экземпляра окна вызываем метод Show() данный метод открывает модальное окно ( будет возможность взаимодействовать с предыдущим окном ). - Иначе вызываем метод ShowDialog, данный метод открывает диалоговое окно ( нельзя взаимодействовать с предыдущим окном )

// TestWindow testWindow = new TestWindow();
// testWindow.Show();
#endregion

#region 2) Страничная навигация
//Осуществляет окртытие страниц внутри элемента Fram.
//// Алгоритм для реализации (страница называется TestPage.xaml):
// - определить место для элемента Frame (данный элемент принимает и отображает страницы)
// - дать имя фрэйму (MainFrame) в XAML - коде
// - для навигации обратиться к фрэйму, вызвать метод Navigate и передать в качестве значения экземпляр страницы 
// => MainFrm.Navigate(new TestPage());
#endregion