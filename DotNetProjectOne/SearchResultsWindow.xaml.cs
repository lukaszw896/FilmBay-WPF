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
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
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
                FilmTables = DBAccess.SearchedByTitle(searchedtitle);
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
                    string name = split[0];
                string surname = split[1];
                // MessageBox.Show(Search.Text);
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = DBAccess.SearchedByDirector(name, surname);
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
                string name = split[0];
                string surname = split[1];
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = DBAccess.SearchedByActor(name, surname);
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
                string name = split[0];
                string surname = split[1];
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = DBAccess.SearchedByWriter(name, surname);
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
                string name = split[0];
                string surname = split[1];
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = DBAccess.SearchedByProducer(name, surname);

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
                string name = split[0];
                string surname = split[1];
                List<film_table> FilmTables = new List<film_table>();
                //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                FilmTables = DBAccess.SearchedByComposer(name, surname);

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
            Img x = (Img)SelectionList.SelectedItem;


            string FilmName = x.Name;
            //   film_table ft = con.film_tables.AsParallel().Where(s => s.title==FilmName).First();
            Chosenfilmid = DBAccess.ChosenFilm(FilmName);
            StartWindow.SetPage(StartWindow.pages.filmPage);
            this.Close();
            //   MessageBox.Show(ft.title);

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void CloseLoginPopup_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.pages.startPage.IsEnabled = true;
            this.Close();
        }

    }
}
