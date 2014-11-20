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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        RegisterWindow registerWindow;
        private void CheckIfNumeric(TextCompositionEventArgs e)
        {
            int result;
            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }


        }
        public RegisterWindow()
        {
            InitializeComponent();
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
            registerWindow = this;
        }


        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            //Rejestracja, dodawanie do bazy danych
            string problem = await DBAccess.registercheck(Login.Text, Email.Text);
            if (UserName.Text == "Name")
            {
                MessageBox.Show("This isn't a name");
                return;
            }
            else if (UserSurName.Text == "Name")
            {
                MessageBox.Show("This isn't a surname");
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.Login.Text) || Login.Text == "Login")
            {
                MessageBox.Show("Login is mandatory");
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.Password.Text) || Password.Text == "Password")
            {
                MessageBox.Show("Password is mandatory");
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.Email.Text) || Email.Text == "Email")
            {
                MessageBox.Show("Email is mandatory");
                return;
            }
            else if (string.IsNullOrWhiteSpace(this.Age.Text) || Age.Text == "Age")
            {
                MessageBox.Show("Age is mandatory");
                return;
            }
            else if (problem=="login")
            {
                MessageBox.Show("Login in use");
                return;
            }
            else if (problem == "email")
            {
                MessageBox.Show("Email already in use");
                return;
            }

            else if (Password.Text != PasswordConfirm.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            else if (Email.Text != EmailConfirm.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            else
            {
                user_table user = DBAccess.CreateUser(Password.Text, UserName.Text, UserSurName.Text, Login.Text,Email.Text, int.Parse(Age.Text));
                /*
                user.password = Password.Text;
                user.name = UserName.Text;
                user.surname = UserSurName.Text;
                user.login = Login.Text;
                user.e_mail = Email.Text;
                user.age = int.Parse(Age.Text);

                DBAccess.AddUser(user);
                */

                UserName.Text = "Name";
                UserSurName.Text = "Surname";
                Login.Text = "Login";
                Email.Text = "E-mail";
                Password.Text = "Password";
                PasswordConfirm.Text = "Confirm Password";
                EmailConfirm.Text = "Confirm E-mail";
                Age.Text = "Age";

            }
            StartWindow.pages.startPage.IsEnabled = true;
            this.Close();
            //check if email in d

        }

    
        private void Age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void CloseRegisterPopup_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.pages.startPage.IsEnabled = true;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ScrollViewer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                registerWindow.DragMove();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Clear();
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void RegisterWindow_KeyDown(object sender, KeyEventArgs e)
        {
     
              if (e.Key == Key.Return)
                {
                    signUpButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }

        }
    }
}
