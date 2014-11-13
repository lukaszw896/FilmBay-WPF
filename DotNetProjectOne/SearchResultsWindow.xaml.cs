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
using System.Windows.Shapes;

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for SearchResultsWindow.xaml
    /// </summary>
    public partial class SearchResultsWindow : Window
    {
        public static int filmid;
        private ObservableCollection<Img> _mymovies = new ObservableCollection<Img>();
        public ObservableCollection<Img> mymovies
        {
            get { return _mymovies; }
            set { _mymovies = value; }
        }

        private ObservableCollection<Img> _searchmovies = new ObservableCollection<Img>();
        public ObservableCollection<Img> searchmovies
        {
            get { return _searchmovies; }
            set { _searchmovies = value; }
        }

        private ObservableCollection<Img> _topmovies = new ObservableCollection<Img>();
        public ObservableCollection<Img> topmovies
        {
            get { return _topmovies; }
            set { _topmovies = value; }
        }



        //public user_table Myself = new user_table();
        int myid;
        public static int Chosenfilmid;
        public SearchResultsWindow(String selected,String Search)
        {
            InitializeComponent();
            this.DataContext = this;

            if (searchmovies.Count > 0)
            {

                searchmovies.Clear();
            }
            MyLINQDataContext con = new MyLINQDataContext();

            
            


            if (selected == "Title")
            {
                string searchedtitle = Search;

                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = (from p in con.film_tables where p.title == searchedtitle select p).ToList();
                foreach (film_table ft in FilmTables)
                {

                    try
                    {
                        Image myimage = new Image();
                        string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                        string title = ft.title;
                        string director = ft.director_name + " " + ft.director_surname;
                        string year = ft.release_date.Value.ToShortDateString();
                        //   MessageBox.Show(path);
                        myimage.Source = new BitmapImage(new Uri(path));

                        Img img = new Img(path, year, title, director);

                        searchmovies.Add(img);
                    }
                    catch { }
                }

            }
            if (selected == "Director")
            {
                String[] split = Search.Split(' ');
                // MessageBox.Show(Search.Text);
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = (from p in con.film_tables
                              where p.director_name == split[0] && p.director_surname == split[1]

                              select p).ToList();
                foreach (film_table ft in FilmTables)
                {
                    try
                    {
                        Image myimage = new Image();
                        string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                        string title = ft.title;
                        string director = ft.director_name + " " + ft.director_surname;
                        string year = ft.release_date.Value.ToShortDateString();
                        //  MessageBox.Show(path);
                        myimage.Source = new BitmapImage(new Uri(path));

                        Img img = new Img(path, year, title, director);

                        searchmovies.Add(img);
                    }
                    catch { }
                }

            }
            if (selected == "Actor")
            {
                String[] split = Search.Split(' ');
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = (from a in con.actor_tables
                              join at in con.actor_film_tables on a.id_actor equals at.id_actor
                              join f in con.film_tables on at.id_film equals f.id_film
                              where a.actor_name == split[0] && a.actor_surname == split[1]
                              select f).ToList();
                foreach (film_table ft in FilmTables)
                {
                    // MessageBox.Show("LOL");
                    try
                    {
                        Image myimage = new Image();
                        string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                        string title = ft.title;
                        string director = ft.director_name + " " + ft.director_surname;
                        string year = ft.release_date.Value.ToShortDateString();

                        myimage.Source = new BitmapImage(new Uri(path));

                        Img img = new Img(path, year, title, director);

                        searchmovies.Add(img);
                    }
                    catch { }
                }

            }
            if (selected == "Writer")
            {
                String[] split = Search.Split(' ');
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = (from a in con.writers_tables
                              join at in con.film_writers_tables on a.id_writer equals at.id_writer
                              join f in con.film_tables on at.id_film equals f.id_film
                              where a.writer_name == split[0] && a.writer_surname == split[1]
                              select f).ToList();
                foreach (film_table ft in FilmTables)
                {
                    // MessageBox.Show("LOL");
                    try
                    {
                        Image myimage = new Image();
                        string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                        string title = ft.title;
                        string director = ft.director_name + " " + ft.director_surname;
                        string year = ft.release_date.Value.ToShortDateString();

                        myimage.Source = new BitmapImage(new Uri(path));

                        Img img = new Img(path, year, title, director);

                        searchmovies.Add(img);
                    }
                    catch { }
                }

            }

            if (selected == "Producer")
            {
                String[] split = Search.Split(' ');
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = (from a in con.producer_tables
                              join f in con.film_tables on a.id_film equals f.id_film
                              where a.producer_name == split[0] && a.producer_surname == split[1]
                              select f).ToList();

                foreach (film_table ft in FilmTables)
                {
                    // MessageBox.Show("LOL");
                    try
                    {
                        Image myimage = new Image();
                        string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                        string title = ft.title;
                        string director = ft.director_name + " " + ft.director_surname;
                        string year = ft.release_date.Value.ToShortDateString();

                        myimage.Source = new BitmapImage(new Uri(path));

                        Img img = new Img(path, year, title, director);

                        searchmovies.Add(img);
                    }
                    catch { }
                }

            }
            if (selected == "Composer")
            {
                String[] split = Search.Split(' ');
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = (from a in con.music_creator_tables
                              join at in con.film_music_creators on a.id_music_creator equals at.id_music_creator
                              join f in con.film_tables on at.id_film equals f.id_film
                              where a.music_creator_name == split[0] && a.music_creator_surname == split[1]
                              select f).ToList();

                foreach (film_table ft in FilmTables)
                {
                    // MessageBox.Show("LOL");
                    try
                    {
                        Image myimage = new Image();
                        string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                        string title = ft.title;
                        string director = ft.director_name + " " + ft.director_surname;
                        string year = ft.release_date.Value.ToShortDateString();

                        myimage.Source = new BitmapImage(new Uri(path));

                        Img img = new Img(path, year, title, director);

                        searchmovies.Add(img);
                    }
                    catch { }
                }
                
            }
        }

        private void SelectionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            Img x = (Img)SelectionList.SelectedItem;


            string FilmName = x.Name;
            film_table ft = con.film_tables.AsParallel().Where(s => s.title == FilmName).First();
            Chosenfilmid = ft.id_film;
            StartWindow.SetPage(StartWindow.pages.filmPage);         
            //   MessageBox.Show(ft.title);

        }    

    }
}
