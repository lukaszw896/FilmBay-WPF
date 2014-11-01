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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
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
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPopUp.IsOpen = true;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterPopUp.IsOpen = false;
        }
    }
}
