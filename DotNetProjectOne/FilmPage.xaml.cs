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
    /// Interaction logic for FilmPage.xaml
    /// </summary>
    /// 
    public partial class FilmPage : UserControl
    {
        public static int filmid = SearchResultsWindow.Chosenfilmid;
      // public static int filmid = 1;



        //Collection of Actors and their names
        private ObservableCollection<Img> _filmactors= new ObservableCollection<Img>();
        public ObservableCollection<Img> filmactors
        {
            get { return _filmactors; }
            set { _filmactors = value; }
        }

        //Collection of photos from the movie
        private ObservableCollection<Img> _moviephotos = new ObservableCollection<Img>();
        public ObservableCollection<Img> moviephotos
        {
            get { return _moviephotos; }
            set { _moviephotos= value; }
        }


        //collection of comments
        private ObservableCollection<UserComment> _usercomments = new ObservableCollection<UserComment>();
        public ObservableCollection<UserComment> usercomments
        {
            get { return _usercomments; }
            set { _usercomments = value; }
        }
        public user_table Myself = new user_table();



    


        public FilmPage()
        {

            Myself = StartWindow.Myself;
            this.DataContext = this;
            InitializeComponent();
            DirectorBlock.Text = "";
            WriterBlock.Text = "";
            ProducerBlock.Text = "";
            YearBlock.Text = "";
            ComposerBlock.Text = "";
            StudioBlock.Text = "";

         //    MyLINQDataContext con = new MyLINQDataContext();
             film_table ft = DBAccess.LoadFilmFromId(filmid);
     
             string path;
               path=  AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
              Poster.Source = new BitmapImage(new Uri(path));

              List<actor_table> Actors = DBAccess.GetActors(filmid);

                          foreach(actor_table at in Actors)
            {

                Image myimage = new Image();

                string apath;
                              if(at.actor_photo_url!=null)
                              { 
                apath = AppDomain.CurrentDomain.BaseDirectory + "ActorPhotos\\" + at.actor_photo_url;
                              }
                              else
                              {
                 apath = AppDomain.CurrentDomain.BaseDirectory + "ActorPhotos\\" + "stockphoto.jpg";
                              }
                string title = at.actor_name + " "+ at.actor_surname;
                string director = "";
                string year = "";
 
                myimage.Source = new BitmapImage(new Uri(path));
                Img img = new Img(apath, year, title, director);
                filmactors.Add(img);

            }
            // Read Writers from db

            List<writers_table> Writers = DBAccess.GetWriters(filmid);

            foreach(writers_table writer in Writers)
            {
                if (Writers.Count > 1)
                {
                    WriterBlock.Text = WriterBlock.Text + " " + writer.writer_name + " " + writer.writer_surname + ",";
                }
                else
                    WriterBlock.Text = WriterBlock.Text + " " + writer.writer_name + " " + writer.writer_surname;
            }


            //Read Composers from DB

            List<music_creator_table> Composers = DBAccess.GetComposers(filmid);
    
               foreach (music_creator_table composer in Composers)
               {
                   if (Writers.Count > 1)
                   {
                       ComposerBlock.Text = ComposerBlock.Text + " " + composer.music_creator_name + " " + composer.music_creator_surname + ",";
                   }
                   else
                      ComposerBlock.Text = ComposerBlock.Text + " " + composer.music_creator_name + " " + composer.music_creator_surname;
               }

            //Read Producers from DB
               List<producer_table> Producers = DBAccess.GetProducers(filmid);
            foreach(producer_table p in Producers)
            {
                if(Producers.Count>1)
                {
                    ProducerBlock.Text = ProducerBlock.Text + " " + p.producer_name+ " " + p.producer_surname + ",";
                }
                else
                    ProducerBlock.Text = ProducerBlock.Text + " " + p.producer_name + " " + p.producer_surname;

            }

            //List photos from the movie stored in local folder
            List<photos_table> Photos = DBAccess.GetPhotos(filmid);
          
            foreach(photos_table p in Photos)
            {
                Image myimage = new Image();
                string apath = AppDomain.CurrentDomain.BaseDirectory + "Photos\\" + p.photo_url;
           
                //   MessageBox.Show(path);
                myimage.Source = new BitmapImage(new Uri(path));

                Img img = new Img(apath, "", "", "");

                moviephotos.Add(img);

            }

            //Look for users that added comments, display comments
            /*
            List<comment_table> Comments = DBAccess.GetComments(filmid);
            foreach(comment_table comment in Comments)
            {
                String Comment = comment.comment;
                String Name = comment.user_table.login+":";
               
            //    UserComment c = new UserComment(Name, Comment);
            //    usercomments.Add(c);
            
            //}
            */
            //Post basic info about the movie from the movie table

            YearBlock.Text = ft.release_date.Value.ToShortDateString();

             Title.Content = ft.title;
             Story.Text = ft.storyline;
             StudioBlock.Text = ft.film_studio;
             DirectorBlock.Text = ft.director_name + " " + ft.director_surname;
            if(ft.nuber_of_votes>0)
            { 
             RatingBox.Content = Math.Round(ft.rating.Value,2).ToString() ;
            }
 
        }

        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow cw = new CommentWindow();
            this.IsEnabled = false;
            cw.ShowDialog();
           
            
        }
      


        // An event to buy a movie, checks users id and adds the film to users bought movies list
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            MyLINQDataContext con = new MyLINQDataContext();
            bought_films_table bft = new bought_films_table();
            bool Alreadybought= (con.bought_films_tables.AsParallel().Where(s => s.id_film == filmid && s.id_user==Myself.id_user).Count()) > 0;
            if(Alreadybought==true)
            {
                MessageBox.Show("You already have this movie!");
                     con.Dispose();
            }
            else
            { 
            bft.id_film = filmid;
            bft.id_user = Myself.id_user;
            DBAccess.AddToBoughtFilms(bft);
            MessageBox.Show("Have a nice day!");
            con.Dispose();
            }
             * */
           DBAccess.BuyFilm(filmid, Myself.id_user);
        }

     //Function to vote for the movie, depending on which star you clicked
       
        private void FiveStars_Click(object sender, RoutedEventArgs e)
        {
            DBAccess.vote(5,filmid);
        }

        private void FourStars_Click(object sender, RoutedEventArgs e)
        {
            DBAccess.vote(4,filmid);
        }

        private void ThreeStars_Click(object sender, RoutedEventArgs e)
        {
            DBAccess.vote(3,filmid);
        }

        private void TwoStars_Click(object sender, RoutedEventArgs e)
        {
            DBAccess.vote(2,filmid);
        }

        private void OneStar_Click(object sender, RoutedEventArgs e)
        {
            DBAccess.vote(1,filmid);
        }

        
    }
}
