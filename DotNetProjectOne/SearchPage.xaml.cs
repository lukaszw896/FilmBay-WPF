using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : UserControl
    {
        private ObservableCollection<Img> _mymovies = new ObservableCollection<Img>();
        public ObservableCollection<Img> mymovies
        {
            get { return _mymovies; }
            set { _mymovies = value; }
        }


    public    user_table Myself=new user_table();
    int myid;
 

        public SearchPage()
        {
            this.DataContext = _mymovies;
            InitializeComponent();
         //   Myself = StartPage.Myself;
          //  MessageBox.Show(Myself.login);
            myid = Myself.id_user;
            MyLINQDataContext con = new MyLINQDataContext();
           List< film_table> FilmTables = (from u in con.user_tables join bf in con.bought_films_tables on u.id_user equals bf.id_user 
                            join f in con.film_tables on bf.id_film equals f.id_film
                            where bf.id_user==Myself.id_user  select  f).ToList();
    foreach (film_table ft in FilmTables)
    {
        Image myimage = new Image();
        string path = AppDomain.CurrentDomain.BaseDirectory+"Posters\\"+ft.poster_url;
        string title = ft.title;
        MessageBox.Show(path);
        myimage.Source = new BitmapImage(new Uri(path));
     
        Img img = new Img(path, myimage, title);
          mymovies.Add(img);
        con.Dispose();


        }
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
  


    }


        }    
}
