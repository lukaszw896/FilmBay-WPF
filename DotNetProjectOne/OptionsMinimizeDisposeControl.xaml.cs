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
using System.Windows.Threading;

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for OptionsMinimizeDisposeControl.xaml
    /// </summary>
    public partial class OptionsMinimizeDisposeControl : UserControl
    {
        public bool visibility { get; set;}
        public OptionsMinimizeDisposeControl()
        {
            InitializeComponent();
            visibility = true;
        }

        private void optionsButton_click(object sender, RoutedEventArgs e)
        {
            if (visibility == true)
            {
                logOutButton.Visibility = Visibility.Visible;
                visibility = false;
            }
            else
            {
                logOutButton.Visibility = Visibility.Hidden;
                visibility = true;
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            
            StartWindow.pages.startPage.IsEnabled = true;
            StartWindow.SetPage(StartWindow.pages.startPage);
        }
    }
}
