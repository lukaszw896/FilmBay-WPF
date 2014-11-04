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
    /// Interaction logic for FilmPage.xaml
    /// </summary>
    /// 
    public partial class FilmPage : UserControl
    {
        int filmid = 1;
        public FilmPage()
        {
            InitializeComponent();
             MyLINQDataContext con = new MyLINQDataContext();
             film_table ft;
             ft = con.film_tables.AsParallel().Where(s => s.id_film == filmid).First();
             string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
           
            
             Poster.Source = new BitmapImage(new Uri(path));
             Title.Content = ft.title;
             Story.Text = ft.storyline;
             con.Dispose();
        }

        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow cw = new CommentWindow();
            this.IsEnabled = false;
            cw.ShowDialog();
           
            
        }

        
    }
}
