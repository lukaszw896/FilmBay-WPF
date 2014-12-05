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
using MahApps.Metro.Controls;

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public  partial class StartWindow : MetroWindow
    {
        public static user_table Myself = new user_table();
        public static StartPage _startPage = new StartPage();
        public static  StartWindow window;
        public static Pages pages;
        public static int Chosenfilmid;
        public StartWindow()
        {
            InitializeComponent();
            this.Content = _startPage;
            window = this;
            pages = new Pages();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Left = (screenWidth / 2) - (this.Width / 2);
            this.Top = (screenHeight / 2) - (this.Height / 2);
                
        }

        public static void SetPage(UserControl page)
        {
            window.Content = page;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                /*
                 * TRZEBA USUNAC TRY
                 */
                try
                {
                    this.DragMove();
                }catch{}
        }
    }
}
