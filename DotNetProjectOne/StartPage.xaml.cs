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

        //private void LoginSignInButton_Click(object sender, RoutedEventArgs e)
        //{
        //    LoginPopUp.IsOpen = false;
        //    MyLINQDataContext con = new MyLINQDataContext();
        //    user_table x = new user_table();
        //    bool logininDB = (from p in con.user_tables where p.login == CheckLogin.Text select p).Count() > 0;
        //    if(logininDB==false)
        //    {
        //        MessageBox.Show("Wrong login");
        //    }
        //    else if (logininDB == true)
        //    {
        //        x = (from p in con.user_tables where p.login == CheckLogin.Text select p).First();
        //        if (x.password != CheckPassword.Text)
        //        {

        //            MessageBox.Show("Wrong Password");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Hello!");
        //            Myself= x;
        //            Pages page = new Pages();
        //            StartWindow.SetPage(page.searchPage);

        //        }
        //    }
         
           
        //}

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            this.IsEnabled = false;
            rw.ShowDialog();
        }



        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            FilmWindow w = new FilmWindow();
            w.Show();
        }

        private void Age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.SetPage(StartWindow.pages.filmPage);
        }
    }
}
