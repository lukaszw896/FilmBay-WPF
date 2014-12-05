using DotNetProjectOne.TMDB_Api_helper_classes;
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

namespace DotNetProjectOne.PagesUserControl
{
    /// <summary>
    /// Interaction logic for AdminTMDbMovieSearch.xaml
    /// </summary>
    public partial class AdminTMDbMovieSearch : UserControl
    {
        private ObservableCollection<MovieSearchReturnObject> _movies = new ObservableCollection<MovieSearchReturnObject>();
        public ObservableCollection<MovieSearchReturnObject> movies
        {
            get { return _movies; }
            set { _movies = value; }
        }

        public AdminTMDbMovieSearch()
        {
            InitializeComponent();
        }

        private void SearchTMDbMovie_Click(object sender, RoutedEventArgs e)
        {
            List<MovieSearchReturnObject> tmpList = TMDbApi.movieSearch(TextBoxTMDbSearch.Text.ToString());
            for(int i=0;i<tmpList.Count();i++){
                movies.Add(tmpList[i]);
               
            }
             MyMoviesList = MyMoviesList;
        }
        private void MyMovieList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //Img x = (Img)MyMoviesList.SelectedItem;


            //string FilmName = x.Name;
            //StartWindow.Chosenfilmid = DBAccess.ChosenFilm(FilmName);
            ////   film_table ft = con.film_tables.AsParallel().Where(s => s.title==FilmName).First();
            //Chosenfilmid = DBAccess.ChosenFilm(FilmName);
            //StartWindow.SetPage(new FilmPage());


            //   MessageBox.Show(ft.title);

        }
    }
}
