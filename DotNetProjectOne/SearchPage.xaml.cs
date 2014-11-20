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



    public    user_table Myself=new user_table();
    int myid;
    public static int Chosenfilmid;
  //  List<Img> films = new List<Img>();
        public async void start()
    {
        Myself = StartWindow.Myself;
        myid = Myself.id_user;
        //MessageBox.Show(myid.ToString());
        List<film_table> FilmTables = await DBAccess.GetBoughtFilms(myid);
        foreach (film_table ft in FilmTables)
        {

            Image myimage = new Image();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
            string title = ft.title;
            string director = ft.director_name + " " + ft.director_surname;
            string year = ft.release_date.Value.ToShortDateString();
            myimage.Source = new BitmapImage(new Uri(path));

            Img img = new Img(path, year, title, director);

            _mymovies.Add(img);


        }

        //filling up our top movies table

        FilmTables = await DBAccess.GetTopFilms(4, 5);
        foreach (film_table ft in FilmTables)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
            string title = ft.title;
            string director = ft.director_name + " " + ft.director_surname;
            string year = ft.release_date.Value.ToShortDateString();
            Img film = new Img(path, year, title, director);

            topmovies.Add(film);
        }
        if (topmovies.Count < 6)
        {
            FilmTables = await DBAccess.GetTopFilms(3, 4);
            foreach (film_table ft in FilmTables)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                string title = ft.title;
                string director = ft.director_name + " " + ft.director_surname;
                string year = ft.release_date.Value.ToShortDateString();
                Img film = new Img(path, year, title, director);
                topmovies.Add(film);
            }
        }
        if (topmovies.Count < 6)
        {
            FilmTables = await DBAccess.GetTopFilms(2, 3);
            foreach (film_table ft in FilmTables)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                string title = ft.title;
                string director = ft.director_name + " " + ft.director_surname;
                string year = ft.release_date.Value.ToShortDateString();
                Img film = new Img(path, year, title, director);
                topmovies.Add(film);
            }
        }
        if (topmovies.Count < 6)
        {
            FilmTables = await DBAccess.GetTopFilms(1, 2);
            foreach (film_table ft in FilmTables)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
                string title = ft.title;
                string director = ft.director_name + " " + ft.director_surname;
                string year = ft.release_date.Value.ToShortDateString();
                Img film = new Img(path, year, title, director);
                topmovies.Add(film);
            }
        }

    }
  


        public  SearchPage()
        {
            this.DataContext = this;
            InitializeComponent();
            Myself = StartWindow.Myself;
            myid = Myself.id_user;
            start();

        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        { 
            this.IsEnabled = false;
            if(searchmovies.Count>0)
            {
              
                    searchmovies.Clear();
            }
           // MyLINQDataContext con = new MyLINQDataContext();
            
           // SearchPopUp.IsOpen = true;
            string selected = ((ComboBoxItem)SearchCombo.SelectedItem).Content.ToString();

            SearchResultsWindow srw = new SearchResultsWindow(selected, Search.Text,this);
            srw.ShowDialog();

    


    }
   


        private void MyMovieList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
     
            Img x = (Img)MyMoviesList.SelectedItem;
          
           
          string FilmName = x.Name;
          StartWindow.Chosenfilmid = DBAccess.ChosenFilm(FilmName);
        //   film_table ft = con.film_tables.AsParallel().Where(s => s.title==FilmName).First();
          Chosenfilmid = DBAccess.ChosenFilm(FilmName);
           StartWindow.SetPage(new FilmPage());

          
         //   MessageBox.Show(ft.title);
        
        }

        private void TopMovieList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Img x = (Img)TopMoviesList.SelectedItem;


            string FilmName = x.Name;
            StartWindow.Chosenfilmid = DBAccess.ChosenFilm(FilmName);
            //   film_table ft = con.film_tables.AsParallel().Where(s => s.title==FilmName).First();
            Chosenfilmid = DBAccess.ChosenFilm(FilmName);
            StartWindow.SetPage(new FilmPage());
        }

        private void searchPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            disposeControl.logOutButton.Visibility = Visibility.Hidden;
            disposeControl.visibility = true;
            
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Clear();
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void SearchWindow_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                searchButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

        }

      


        }    
}
