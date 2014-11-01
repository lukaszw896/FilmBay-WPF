﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
           #region
        public static void AddFilm( film_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.film_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddActor(actor_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.actor_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddToActorFilmTable(actor_film_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.actor_film_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddWriter(writers_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.writers_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddProducer(producer_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.producer_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddComposer(music_creator_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.music_creator_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddToWriterFilmTable(film_writers_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.film_writers_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddToComposerFilmTable(film_music_creator t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.film_music_creators.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        #endregion*/
        public MainWindow()
        {
            InitializeComponent();
        }
     

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FilmWindow w = new FilmWindow();
            w.Show();
        }
    }
}
