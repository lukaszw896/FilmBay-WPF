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
        public user_table Myself = new user_table();
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
            LoginPopUp.IsOpen = true;
        }

        private void LoginSignInButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPopUp.IsOpen = false;
            MyLINQDataContext con = new MyLINQDataContext();
            user_table x = new user_table();
            bool logininDB = (from p in con.user_tables where p.login == CheckLogin.Text select p).Count() > 0;
            if(logininDB==false)
            {
                MessageBox.Show("Wrong login");
            }
            else if (logininDB == true)
            {
                x = (from p in con.user_tables where p.login == CheckLogin.Text select p).First();
                if (x.password != CheckPassword.Text)
                {

                    MessageBox.Show("Wrong Password");
                }
                else
                {
                    MessageBox.Show("Hello!");
                    Myself= x;
                    Pages page = new Pages();
                    StartWindow.SetPage(page.searchPage);

                }
            }
         
           
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPopUp.IsOpen = true;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            //Rejestracja, dodawanie do bazy danych
      
            MyLINQDataContext con = new MyLINQDataContext();

            //check if login in DB
            bool logininDB = (from p in con.user_tables where p.login == Login.Text select p).Count() > 0;
            bool emailinDB = (from p in con.user_tables where p.e_mail == Email.Text select p).Count() > 0;
            con.Dispose();

            if ( UserName.Text == "Name")
            {
                MessageBox.Show("This isn't a name");
            }
            else  if (UserSurName.Text == "Name")
            {
                MessageBox.Show("This isn't a surname");
            }
            else if (string.IsNullOrWhiteSpace(this.Login.Text) || Login.Text=="Login")
            {
                MessageBox.Show("Login is mandatory");
            }
            else if (string.IsNullOrWhiteSpace(this.Password.Text) ||Password.Text=="Password")
            {
                MessageBox.Show("Password is mandatory");
            }
            else if (string.IsNullOrWhiteSpace(this.Email.Text) || Email.Text == "Email")
            {
                MessageBox.Show("Email is mandatory");
            }
            else if (string.IsNullOrWhiteSpace(this.Age.Text) || Age.Text == "Age")
            {
                MessageBox.Show("Age is mandatory");
            }
            else if(logininDB==true)
            {
                MessageBox.Show("Login in use");
            }
            else  if (emailinDB == true)
            {
                MessageBox.Show("Email already in use");
            }
           
            else   if(Password.Text!=PasswordConfirm.Text)
                {
                    MessageBox.Show("Passwords do not match");
                }
            else  if(Email.Text!=EmailConfirm.Text)
                {
                    MessageBox.Show("Passwords do not match");
                }
                else
                  {
                      user_table user = new user_table();

                user.password = Password.Text;
                user.name = UserName.Text;
                user.surname = UserSurName.Text;
                user.login = Login.Text;
                user.e_mail = Email.Text;
                user.age = int.Parse(Age.Text);
              MainWindow.AddUser(user);
                RegisterPopUp.IsOpen = false;
                UserName.Text = "Name";
                UserSurName.Text = "Surname";
                Login.Text = "Login";
                Email.Text = "E-mail";
                Password.Text = "Password";
                PasswordConfirm.Text = "Confirm Password";
                EmailConfirm.Text = "Confirm E-mail";
                Age.Text = "Age";

                   }


 
          
          
          
                //check if email in db
       
        
            

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
    }
}
