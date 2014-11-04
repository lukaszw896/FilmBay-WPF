using System;
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
        public static void AddUser(user_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.user_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddGenre(genere_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.genere_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddToFilmGenre(film_genere_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.film_genere_tables.InsertOnSubmit(t);
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
        public static void AddMPhoto(photos_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.photos_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddOLang(other_language_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.other_language_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddToFilmOtherLangTable(film_other_language_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.film_other_language_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddToFilmPhotosTable(film_photos_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.film_photos_tables.InsertOnSubmit(t);
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
        public static void AddToBoughtFilms(bought_films_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.bought_films_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void AddComment(comment_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.comment_tables.InsertOnSubmit(t);
                conn.SubmitChanges();
                conn.Dispose();
            }
        }
        public static void UpdateComment(comment_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
               comment_table table = conn.comment_tables.AsParallel().Where(s => s.id_film == t.id_film && s.id_user == t.id_user).FirstOrDefault();
               
                table.comment = t.comment;
                    conn.SubmitChanges();
                conn.Dispose();
                
            }
        }
        public static void UpdateRating(film_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                film_table table = conn.film_tables.AsParallel().Where(s => s.id_film == t.id_film).FirstOrDefault();
                table.rating = t.rating;
                table.nuber_of_votes = t.nuber_of_votes;
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

        private void Registration_Click(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new Uri("registrationPage.xaml", UriKind.Relative));
        }
    }
}
