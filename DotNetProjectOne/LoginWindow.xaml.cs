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
using System.Windows.Shapes;

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        
        private void CheckIfNumeric(TextCompositionEventArgs e)
        {
            int result;
            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }

        }
        public  LoginWindow()
        {
            InitializeComponent();
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
        }



        private async void LoginSignInButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            MyLINQDataContext con = new MyLINQDataContext();
           // user_table x = new user_table();
            bool logininDB = (from p in con.user_tables where p.login == CheckLogin.Text select p).Count() > 0;
            if (logininDB == false)
            {
                MessageBox.Show("Wrong login");
            }
            else if (logininDB == true)
            {
                x = (from p in con.user_tables where p.login == CheckLogin.Text select p).First();
                if (x.password != CheckPassword.Text)
                    MessageBox.Show("Wrong Password");
                {

                }
                else
                {
                    MessageBox.Show("Hello!");
                    StartWindow.Myself = x;
                    Pages page = new Pages();
                    StartWindow.SetPage(page.searchPage);
                    this.Close();

                }
            }
            */
            user_table x = new user_table();
             x = await DBAccess.Userlogin(CheckLogin.Text, CheckPassword.Text);
            if(x.name!="Wrong")
            {
                StartWindow.Myself = x;
                MessageBox.Show(StartWindow.Myself.login);
                //Pages page = new Pages();
                StartWindow.SetPage(StartWindow.pages.searchPage);
                // !!!!!!!!!!!!!!!!
                this.Close();
            }


        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void CloseLoginPopup_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.pages.startPage.IsEnabled = true;
            this.Close();
        }
    }
}
