using DotNetProjectOne.PagesUserControl;
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
        public static user_table Myself = new user_table();
        private void CheckIfNumeric(TextCompositionEventArgs e)
        {
            int result;
            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }

        }
        public StartPage()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            this.IsEnabled = false;
            lw.ShowDialog();

        }
        private void LoginFacebook_Click(object sender, RoutedEventArgs e)
        {
           FacebookLogin lw = new FacebookLogin();
            this.IsEnabled = false;
            lw.ShowDialog();

        }

    

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            this.IsEnabled = false;
            rw.ShowDialog();
        }



        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
           // FilmWindow w = new FilmWindow();
            AdminLogin admin = new AdminLogin();
            admin.Show();
            startPage.IsEnabled = false;
           
     //       startPage.IsEnabled = false;
           // w.ShowDialog();
        }

        private void Age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

    }
}
