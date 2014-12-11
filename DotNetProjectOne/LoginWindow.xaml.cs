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
        /* Constructor */
        public  LoginWindow()
        {
            InitializeComponent();
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
        }


        /* Login button event */
        private async void LoginSignInButton_Click(object sender, RoutedEventArgs e)
        {

            user_table x = new user_table();
             x = await DBAccess.Userlogin(CheckLogin.Text, CheckPassword.Text);
            if(x.name!="Wrong" )
            {
                StartWindow.Myself = x;
                //MessageBox.Show(StartWindow.Myself.login);
                //Pages page = new Pages();

                StartWindow.SetPage(new SearchPage());
                this.Close();
            }


        }
        /*login window dragging event*/
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        /* Lgin window closing event */
        private void CloseLoginPopup_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.pages.startPage.IsEnabled = true;
            this.Close();
        }
        /* ereasing textbox after first entering into in*/
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Clear();
            tb.GotFocus -= TextBox_GotFocus;
        }
        /*window dragging event*/
        private void LoginWindow_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                loginButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

        }
    }
}
