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
        SearchPage searchPage;

        string selected;
        string Search;

        //public user_table Myself = new user_table();
 
        public async Task start(string selected,string Search)
        {
            canvasName.Visibility = Visibility.Visible;

           await  Task.Run(async () =>
            {
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
                    FilmTables = await DBAccess.SearchedByTitle(searchedtitle);
                    await this.Dispatcher.BeginInvoke(new Action(() =>
                   {
                     foreach (film_table ft in FilmTables)
                     {

                         //    try
                         {
                             Image myimage = new Image();
                             string path = ft.poster_url;
                             string title = ft.title;
                             string director = ft.director_name + " " + ft.director_surname;
                             string year = ft.release_date.Value.ToShortDateString();
                             //   MessageBox.Show(path);
                             myimage.Source = new BitmapImage(new Uri(path));

                             Img img = new Img(path, year, title, director);

                             searchmovies.Add(img);
                         }
                         //    catch { }
                     }
                 }));

                }
                if (selected == "Director")
                {
                    String[] split = Search.Split(' ');
                    string name = split[0];
                    string surname = split[split.Count()-1];
                    MessageBox.Show(name + " " + surname);
                    List<film_table> FilmTables = new List<film_table>();
                    //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                    FilmTables = await DBAccess.SearchedByDirector(name, surname);
                    await this.Dispatcher.BeginInvoke(new Action(() =>
                   {
                       foreach (film_table ft in FilmTables)
                       {
                           //   try
                           {
                               Image myimage = new Image();
                               string path = ft.poster_url;
                               string title = ft.title;
                               string director = ft.director_name + " " + ft.director_surname;
                               string year = ft.release_date.Value.ToShortDateString();
                               //  MessageBox.Show(path);
                               myimage.Source = new BitmapImage(new Uri(path));

                               Img img = new Img(path, year, title, director);

                               searchmovies.Add(img);
                           }
                           //     catch { }
                       }
                   }));

                }
                if (selected == "Actor")
                {
                    String[] split = Search.Split(' ');
                    string name = split[0];
                    string surname = split[split.Count()-1];
                    List<film_table> FilmTables = new List<film_table>();
                    //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                    FilmTables = await DBAccess.SearchedByActor(name, surname);
                    await this.Dispatcher.BeginInvoke(new Action(() =>
                   {
                       foreach (film_table ft in FilmTables)
                       {
                           // MessageBox.Show("LOL");
                           //   try
                           {
                               Image myimage = new Image();
                               string path = ft.poster_url;
                               string title = ft.title;
                               string director = ft.director_name + " " + ft.director_surname;
                               string year = ft.release_date.Value.ToShortDateString();

                               myimage.Source = new BitmapImage(new Uri(path));

                               Img img = new Img(path, year, title, director);

                               searchmovies.Add(img);
                           }
                           //  catch { }
                       }
                   }));

                }
                if (selected == "Writer")
                {
                    String[] split = Search.Split(' ');
                    string name = split[0];
                    string surname = split[split.Count()-1];
                    List<film_table> FilmTables = new List<film_table>();
                    //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                    FilmTables = await DBAccess.SearchedByWriter(name, surname);
                    await this.Dispatcher.BeginInvoke(new Action(() =>
                   {
                       foreach (film_table ft in FilmTables)
                       {
                           // MessageBox.Show("LOL");
                           //  try
                           {
                               Image myimage = new Image();
                               string path = ft.poster_url;
                               string title = ft.title;
                               string director = ft.director_name + " " + ft.director_surname;
                               string year = ft.release_date.Value.ToShortDateString();

                               myimage.Source = new BitmapImage(new Uri(path));

                               Img img = new Img(path, year, title, director);

                               searchmovies.Add(img);
                           }
                           //  catch { }
                       }
                   }));

                }

                if (selected == "Producer")
                {
                    String[] split = Search.Split(' ');
                    string name = split[0];
                    string surname = split[split.Count()-1];
                    List<film_table> FilmTables = new List<film_table>();
                    //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                    FilmTables = await DBAccess.SearchedByProducer(name, surname);
                    await this.Dispatcher.BeginInvoke(new Action(() =>
                   {
                       foreach (film_table ft in FilmTables)
                       {
                           // MessageBox.Show("LOL");
                           //    try
                           {
                               Image myimage = new Image();
                               string path = ft.poster_url;
                               string title = ft.title;
                               string director = ft.director_name + " " + ft.director_surname;
                               string year = ft.release_date.Value.ToShortDateString();

                               myimage.Source = new BitmapImage(new Uri(path));

                               Img img = new Img(path, year, title, director);

                               searchmovies.Add(img);

                           }
                           //      catch { }
                       }
                   }));

                }
                if (selected == "Composer")
                {
                    String[] split = Search.Split(' ');
                    string name = split[0];
                    string surname = split[split.Count()-1];
                    List<film_table> FilmTables = new List<film_table>();
                    //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
                    FilmTables = await DBAccess.SearchedByComposer(name, surname);
                    await this.Dispatcher.BeginInvoke(new Action(() =>
                   {
                       foreach (film_table ft in FilmTables)
                       {

                           //    try
                           {
                               Image myimage = new Image();
                               string path = ft.poster_url;
                               string title = ft.title;
                               string director = ft.director_name + " " + ft.director_surname;
                               string year = ft.release_date.Value.ToShortDateString();

                               myimage.Source = new BitmapImage(new Uri(path));

                               Img img = new Img(path, year, title, director);

                               searchmovies.Add(img);
                           }
                           //       catch { }
                       }
                   }));

                }

                if (selected == "Genre")
                {

                    string name = Search;
                    List<film_table> FilmTables = new List<film_table>();

                    FilmTables = await DBAccess.SearchedByGenre(name);
                    await this.Dispatcher.BeginInvoke(new Action(() =>
                   {
                       foreach (film_table ft in FilmTables)
                       {

                           //    try
                           {
                               Image myimage = new Image();
                               string path = ft.poster_url;
                               string title = ft.title;
                               string director = ft.director_name + " " + ft.director_surname;
                               string year = ft.release_date.Value.ToShortDateString();

                               myimage.Source = new BitmapImage(new Uri(path));

                               Img img = new Img(path, year, title, director);

                               searchmovies.Add(img);
                           }
                           //       catch { }
                       }
                   }));

                }
            });
        }




        public SearchResultsWindow(String selected,String Search,SearchPage sp)
        {
            InitializeComponent();
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
            this.DataContext = this;
            this.selected=selected;
            this.Search=Search;
            searchPage = sp;
           
        }

        private void SelectionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Img x = (Img)SelectionList.SelectedItem;


            string FilmName = x.Name;
            //   film_table ft = con.film_tables.AsParallel().Where(s => s.title==FilmName).First();
            StartWindow.Chosenfilmid = DBAccess.ChosenFilm(FilmName);
            StartWindow.SetPage(new FilmPage());
            StartWindow.pages.searchPage.IsEnabled = true;
            this.Close();
            //   MessageBox.Show(ft.title);

        } 
private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void CloseSearchPopup_Click(object sender, RoutedEventArgs e)
        {
            searchPage.IsEnabled = true;
            this.Close();
        }

        private async void SearchPopUp_Loaded(object sender, RoutedEventArgs e)
        {
            await start(selected,Search);
        }   

    }
}
