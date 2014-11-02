using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : UserControl
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPopUp.IsOpen = true;
        }

        private void LoginSignInButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPopUp.IsOpen = false;
            
            StartWindow.SetPage(StartWindow.pages.searchPage);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPopUp.IsOpen = true;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPopUp.IsOpen = false;
        }

        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            FilmWindow w = new FilmWindow();
            w.Show();
        }
    }
}
