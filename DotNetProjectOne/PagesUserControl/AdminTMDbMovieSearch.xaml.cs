﻿using DotNetProjectOne.TMDB_Api_helper_classes;
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
            this.DataContext = this;
            InitializeComponent();
        }

        private async void SearchTMDbMovie_Click(object sender, RoutedEventArgs e)
        {
             movies.Clear();
             String search = TextBoxTMDbSearch.Text.ToString();
             canvasName.Visibility = Visibility.Visible;
             progressRing.IsActive = true;
                
             await Task.Run(() =>
            {
               
            List<MovieSearchReturnObject> tmpList = TMDbApi.movieSearch(search);
            /*
             * 
             * DAŁEM SORTOWANIE POPULARNOŚCI ZA POMOCĄ BUBBLE SORTA. TRZEBA ZMIENIĆ!!!!!
             * 
             * */
            MovieSearchReturnObject tmp;
            for (int i = 0; i < tmpList.Count(); i++)
            {
                for (int j = 0; j < tmpList.Count() - 1; j++)
                {
                    if (tmpList[j].popularity < tmpList[j + 1].popularity)
                    {
                        tmp = tmpList[j];
                        tmpList[j] = tmpList[j + 1];
                        tmpList[j + 1] = tmp;
                    }
                }

            }
                 this.Dispatcher.BeginInvoke(new Action(() =>
                 {
                for (int i = 0; i < tmpList.Count(); i++)
                {
                    movies.Add(tmpList[i]);
                }
                canvasName.Visibility = Visibility.Hidden;
                progressRing.IsActive = false;
                 }));
            });

        }
        private void MyMovieList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            MovieSearchReturnObject x = (MovieSearchReturnObject)MyMoviesList.SelectedItem;
            if (x != null)
            { 
            FilmWindow filmWindow = new FilmWindow(x);
            filmWindow.ShowDialog();
            }
            MyMoviesList.UnselectAll();

            
        }
        private void AdminTMDbMovieSearchWindow_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                searchButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }

        }

        private void backToLoginWindow_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.pages.startPage.IsEnabled = true;
            StartWindow.SetPage(StartWindow.pages.startPage);
            
        }

        private void adminSearchPanelButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.SetPage(new SearchPage());
        }
    }
}
