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

  


        public SearchPage()
        {
            this.DataContext = this;
            InitializeComponent();
            Myself = StartWindow.Myself;
   
            myid = Myself.id_user;
   
            List<film_table> FilmTables = DBAccess.GetBoughtFilms(myid);

    foreach (film_table ft in FilmTables)
    {

        Image myimage = new Image();
        string path = AppDomain.CurrentDomain.BaseDirectory+"Posters\\"+ft.poster_url;
        string title = ft.title;
        string director = ft.director_name +" "+ ft.director_surname;
        string year = ft.release_date.Value.ToShortDateString();
        myimage.Source = new BitmapImage(new Uri(path));
     
        Img img = new Img(path, year, title, director);

          _mymovies.Add(img);
   

        }
            
            //filling up our top movies table

    FilmTables = DBAccess.GetTopFilms(4, 5);
          foreach(film_table ft in FilmTables)
          {
              string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
              string title = ft.title;
              string director = ft.director_name + " " + ft.director_surname;
              string year = ft.release_date.Value.ToShortDateString();
               Img film = new Img(path, year, title, director);
             
               topmovies.Add(film);
          }
            if(topmovies.Count<6)
            {
                FilmTables = DBAccess.GetTopFilms(3, 4);
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
                FilmTables = DBAccess.GetTopFilms(2, 3);
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
                FilmTables = DBAccess.GetTopFilms(1, 2);
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
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if(searchmovies.Count>0)
            {
              
                    searchmovies.Clear();
            }
           // MyLINQDataContext con = new MyLINQDataContext();
            
           // SearchPopUp.IsOpen = true;
            string selected = ((ComboBoxItem)SearchCombo.SelectedItem).Content.ToString();

            SearchResultsWindow srw = new SearchResultsWindow(selected, Search.Text);
            srw.ShowDialog();

          //  if (selected=="Title")
          //  {
          //      string searchedtitle = Search.Text;

          //      List<film_table> FilmTables = new List<film_table>();
          ////      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
          //      FilmTables = (from p in con.film_tables where p.title == searchedtitle select p).ToList();
          //      foreach (film_table ft in FilmTables)
          //      {
              
          //          try
          //          {
          //              Image myimage = new Image();
          //              string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
          //              string title = ft.title;
          //              string director = ft.director_name + " " + ft.director_surname;
          //              string year = ft.release_date.Value.ToShortDateString();
          //           //   MessageBox.Show(path);
          //              myimage.Source = new BitmapImage(new Uri(path));

          //              Img img = new Img(path, year, title, director);

          //              searchmovies.Add(img);
          //          }
          //          catch { }
          //      }

          //  }
          //  if (selected == "Director")
          //  {
          //      String[] split = Search.Text.Split(' ');
          //     // MessageBox.Show(Search.Text);
          //      List<film_table> FilmTables = new List<film_table>();
          //      //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
          //      FilmTables = (from p in con.film_tables where p.director_name == split[0] && p.director_surname==split[1]
                              
          //                    select p).ToList();
          //      foreach (film_table ft in FilmTables)
          //      {
          //          try
          //          {
          //              Image myimage = new Image();
          //              string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
          //              string title = ft.title;
          //              string director = ft.director_name + " " + ft.director_surname;
          //              string year = ft.release_date.Value.ToShortDateString();
          //            //  MessageBox.Show(path);
          //              myimage.Source = new BitmapImage(new Uri(path));

          //              Img img = new Img(path, year, title, director);

          //              searchmovies.Add(img);
          //          }
          //          catch { }
          //      }

          //  }
          //  if (selected == "Actor")
          //  {
          //      String[] split = Search.Text.Split(' ');
          //      List<film_table> FilmTables = new List<film_table>();
          //      //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
          //      FilmTables = (from a in con.actor_tables
          //                    join at in con.actor_film_tables on a.id_actor equals at.id_actor
          //                    join f in con.film_tables on at.id_film equals f.id_film
          //                    where a.actor_name == split[0] && a.actor_surname==split[1] 
          //                    select f).ToList();
          //      foreach (film_table ft in FilmTables)
          //      {
          //         // MessageBox.Show("LOL");
          //          try
          //          {
          //              Image myimage = new Image();
          //              string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
          //              string title = ft.title;
          //              string director = ft.director_name + " " + ft.director_surname;
          //              string year = ft.release_date.Value.ToShortDateString();
         
          //              myimage.Source = new BitmapImage(new Uri(path));

          //              Img img = new Img(path, year, title, director);

          //              searchmovies.Add(img);
          //          }
          //          catch { }
          //      }

          //  }
          //  if (selected == "Writer")
          //  {
          //      String[] split = Search.Text.Split(' ');
          //      List<film_table> FilmTables = new List<film_table>();
          //      //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
          //      FilmTables = (from a in con.writers_tables
          //                    join at in con.film_writers_tables on a.id_writer equals at.id_writer 
          //                    join f in con.film_tables on at.id_film equals f.id_film
          //                    where a.writer_name == split[0] && a.writer_surname==split[1] 
          //                    select f).ToList(); 
          //      foreach (film_table ft in FilmTables)
          //      {
          //          // MessageBox.Show("LOL");
          //          try
          //          {
          //              Image myimage = new Image();
          //              string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
          //              string title = ft.title;
          //              string director = ft.director_name + " " + ft.director_surname;
          //              string year = ft.release_date.Value.ToShortDateString();

          //              myimage.Source = new BitmapImage(new Uri(path));

          //              Img img = new Img(path, year, title, director);

          //              searchmovies.Add(img);
          //          }
          //          catch { }
          //      }

          //  }
      
          //  if (selected == "Producer")
          //  {
          //      String[] split = Search.Text.Split(' ');
          //      List<film_table> FilmTables = new List<film_table>();
          //      //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
          //      FilmTables = (from a in con.producer_tables
          //                    join f in con.film_tables on a.id_film equals f.id_film
          //                    where a.producer_name == split[0] && a.producer_surname==split[1]
          //                    select f).ToList();
            
          //      foreach (film_table ft in FilmTables)
          //      {
          //          // MessageBox.Show("LOL");
          //          try
          //          {
          //              Image myimage = new Image();
          //              string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
          //              string title = ft.title;
          //              string director = ft.director_name + " " + ft.director_surname;
          //              string year = ft.release_date.Value.ToShortDateString();

          //              myimage.Source = new BitmapImage(new Uri(path));

          //              Img img = new Img(path, year, title, director);

          //              searchmovies.Add(img);
          //          }
          //          catch { }
          //      }

          //  }
          //  if (selected == "Composer")
          //  {
          //      String[] split = Search.Text.Split(' ');
          //      List<film_table> FilmTables = new List<film_table>();
          //      //      FilmTables = con.film_tables.AsParallel().Where(s => s.title == Search.Text).ToList();
          //      FilmTables = (from a in con.music_creator_tables
          //                    join at in con.film_music_creators on a.id_music_creator equals at.id_music_creator
          //                    join f in con.film_tables on at.id_film equals f.id_film
          //                    where a.music_creator_name == split[0] && a.music_creator_surname==split[1]
          //                    select f).ToList();

          //      foreach (film_table ft in FilmTables)
          //      {
          //          // MessageBox.Show("LOL");
          //          try
          //          {
          //              Image myimage = new Image();
          //              string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
          //              string title = ft.title;
          //              string director = ft.director_name + " " + ft.director_surname;
          //              string year = ft.release_date.Value.ToShortDateString();

          //              myimage.Source = new BitmapImage(new Uri(path));

          //              Img img = new Img(path, year, title, director);

          //              searchmovies.Add(img);
          //          }
          //          catch { }
          //      }

          //  }



        
       //   List<actor_table> at;
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
   


        private void SelectionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
     
            Img x = (Img)SelectionList.SelectedItem;
          
           
          string FilmName = x.Name;
        //   film_table ft = con.film_tables.AsParallel().Where(s => s.title==FilmName).First();
          Chosenfilmid = DBAccess.ChosenFilm(FilmName);
           StartWindow.SetPage(StartWindow.pages.filmPage);

           SearchPopUp.IsOpen = false;
         //   MessageBox.Show(ft.title);
        
        }

      


        }    
}
