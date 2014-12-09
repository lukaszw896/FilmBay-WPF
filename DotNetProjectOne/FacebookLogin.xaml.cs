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
using Facebook;
using System.Windows.Navigation;
namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for FacebookLogin.xaml
    /// </summary>
    public partial class FacebookLogin : Window
    {
        private static FacebookClient client;

        public static string AccessToken { get; set; }
        private FacebookClient FBClient;
        public FacebookLogin()
        {
            InitializeComponent();
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
            WebB.Navigate(new Uri("https://graph.facebook.com/oauth/authorize?client_id=539157589554568&redirect_uri=http://www.facebook.com/connect/login_success.html&type=user_agent&display=popup").AbsoluteUri);
        }
        private async void WebB_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Uri.ToString().StartsWith("http://www.facebook.com/connect/login_success.html"))
            {

                AccessToken = e.Uri.Fragment.Split('&')[0].Replace("#access_token=", "");
                //   MessageBox.Show(AccessToken.ToString());
                FBClient = new FacebookClient(AccessToken);

                dynamic me = FBClient.Get("me");

             //   MessageBox.Show(me.name.ToString());
 
                String[] split = me.name.ToString().Split(' ');
                string name;
                string surname;
                name = me.first_name.ToString();
                surname = me.last_name.ToString();
              //  MessageBox.Show(name);
              //  MessageBox.Show(surname);
                string email;
                email = me.email.ToString();
                this.Close();
                user_table x = new user_table();
                x = await DBAccess.FBlogin(name, surname, email);
                    StartWindow.Myself = x;
                    //MessageBox.Show(StartWindow.Myself.login);
                    //Pages page = new Pages();
                    StartWindow.SetPage(new SearchPage());
                    // StartWindow.pages.searchPage.BeginInit();
                    // !!!!!!!!!!!!!!!!
                
                
            }

        }
        IntPtr webB_MessageHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //msg = 130 is the last call for when the window gets closed on a window.close() in javascript
            if (msg == 130)
            {
                this.Close();
            }
            return IntPtr.Zero;
        }
        private void WebB_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.Uri.LocalPath == "/r.php")
            {
                // MessageBox.Show("To create a new account go to www.facebook.com", "Could Not Create Account", MessageBoxButton.OK, MessageBoxImage.Error);
                //  e.Cancel = true;
            }
        }
    }
}
