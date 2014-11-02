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
            MyLINQDataContext con = new MyLINQDataContext();
            List<film_table> ft ;
    //        List<actor_table> at;
        //    List<writers_table> wt;
        //    List<music_creator_table> ct;
        //    List<producer_table> pt;

          /*
           ft = con.film_tables.AsParallel().Where(s => s.title==Search.Text).ToList();
           ft = con.film_tables.AsParallel().Where(s => s.director_name == Search.Text).ToList();
           ft = con.film_tables.AsParallel().Where(s => s.film_studio == Search.Text).ToList();
           ft = (from a in con.actor_tables
                 join at in con.actor_film_tables on a.id_actor equals at.id_actor
                 join f in con.film_tables on at.id_film equals f.id_film
                 where a.actor_name == Search.Text
                 select f).ToList();

           ft = (from a in con.writers_tables
                 join at in con.film_writers_tables on a.id_writer equals at.id_writer
                 join f in con.film_tables on at.id_film equals f.id_film
                 where a.writer_name == Search.Text
                 select f).ToList();

           ft = (from a in con.music_creator_tables
                 join at in con.film_music_creators on a.id_music_creator equals at.id_music_creator
                 join f in con.film_tables on at.id_film equals f.id_film
                 where a.music_creator_name == Search.Text
                 select f).ToList();

           ft = (from a in con.producer_tables 
                 join f in con.film_tables on a.id_film equals f.id_film
                 where a.producer_name == Search.Text
                 select f).ToList();
            
           */



    }


        }    
}
