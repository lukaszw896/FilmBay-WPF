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
        public static int filmid;
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

        /*Functino which loads data from database to filmpage gui  */
        public async void start()
        {
            filmid = StartWindow.Chosenfilmid;
            DirectorBlock.Text = "";
            WriterBlock.Text = "";
            ProducerBlock.Text = "";
            YearBlock.Text = "";
            ComposerBlock.Text = "";
            StudioBlock.Text = "";

            //    MyLINQDataContext con = new MyLINQDataContext();
            film_table ft =await DBAccess.LoadFilmFromId(filmid);

            string path;
            path = ft.poster_url;
            Poster.Source = new BitmapImage(new Uri(path));

            List<actor_table> Actors = await DBAccess.GetActors(filmid);

            foreach (actor_table at in Actors)
            {

                Image myimage = new Image();

                string apath;
                if (at.actor_photo_url != null)
                {
                    apath = at.actor_photo_url;
                }
                else
                {
                    apath = AppDomain.CurrentDomain.BaseDirectory + "ActorPhotos\\" + "stockphoto.jpg";
                }
                string title = at.actor_name + " " + at.actor_surname;
                string director = "";
                string year = "";

                myimage.Source = new BitmapImage(new Uri(path));
                Img img = new Img(apath, year, title, director);
                filmactors.Add(img);

            }
            // Read Writers from db

            List<writers_table> Writers = await DBAccess.GetWriters(filmid);

            foreach (writers_table writer in Writers)
            {
                if (Writers.Count > 1)
                {
                    WriterBlock.Text = WriterBlock.Text + " " + writer.writer_name + " " + writer.writer_surname + ",";
                }
                else
                    WriterBlock.Text = WriterBlock.Text + " " + writer.writer_name + " " + writer.writer_surname;
            }


            //Read Composers from DB

            List<music_creator_table> Composers = await DBAccess.GetComposers(filmid);

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
            List<producer_table> Producers =  await DBAccess.GetProducers(filmid);
            foreach (producer_table p in Producers)
            {
                if (Producers.Count > 1)
                {
                    ProducerBlock.Text = ProducerBlock.Text + " " + p.producer_name + " " + p.producer_surname + ",";
                }
                else
                    ProducerBlock.Text = ProducerBlock.Text + " " + p.producer_name + " " + p.producer_surname;

            }

            //List photos from the movie stored in local folder
            List<photos_table> Photos = await DBAccess.GetPhotos(filmid);

            foreach (photos_table p in Photos)
            {
                Image myimage = new Image();
                string apath = p.photo_url;

                //   MessageBox.Show(path);
                myimage.Source = new BitmapImage(new Uri(path));

                Img img = new Img(apath, "", "", "");

                moviephotos.Add(img);

            }

            //Look for users that added comments, display comments
           
            List<comment_table> Comments = await DBAccess.GetComments(filmid);
            foreach (comment_table comment in Comments)
            {

               String Comment = comment.comment;
               user_table user = await DBAccess.LoadUserFromId(comment.id_user);
               String Name = user.login + ":";
               UserComment c = new UserComment(Name, Comment);
               usercomments.Add(c);
            }
            //Post basic info about the movie from the movie table

            YearBlock.Text = ft.release_date.Value.ToShortDateString();

            Title.Content = ft.title;
            Story.Text = ft.storyline;
            StudioBlock.Text = ft.film_studio;
            DirectorBlock.Text = ft.director_name + " " + ft.director_surname;

            ratingLoadFunction();
 
        }
        /*Function reloading film rating*/
        private async void ratingLoadFunction()
        {
            film_table ft = await DBAccess.LoadFilmFromId(filmid);
            if (ft.rating != null)
            {
                double rating = Double.Parse(Math.Round(ft.rating.Value, 2).ToString());
                if (ft.nuber_of_votes > 0)
                {
                    RatingBox.Content = rating;
                }
                if (rating > 0.99)
                {
                    OneStarImage.Source = new BitmapImage(new Uri(@"Icons/fullStar.png", UriKind.RelativeOrAbsolute));
                    if (rating > 1.99)
                    {
                        TwoStarImage.Source = new BitmapImage(new Uri(@"Icons/fullStar.png", UriKind.RelativeOrAbsolute));
                        if (rating > 2.99)
                        {
                            ThreeStarImage.Source = new BitmapImage(new Uri(@"Icons/fullStar.png", UriKind.RelativeOrAbsolute));
                            if (rating > 3.99)
                            {
                                FourStarImage.Source = new BitmapImage(new Uri(@"Icons/fullStar.png", UriKind.RelativeOrAbsolute));
                                if (rating > 4.75)
                                {
                                    FiveStarImage.Source = new BitmapImage(new Uri(@"Icons/fullStar.png", UriKind.RelativeOrAbsolute));
                                }
                                else if (rating > 4.4)
                                {
                                    FiveStarImage.Source = new BitmapImage(new Uri(@"Icons/halfStar.png", UriKind.RelativeOrAbsolute));
                                }
                            }
                            else if (rating > 3.49)
                            {
                                FourStarImage.Source = new BitmapImage(new Uri(@"Icons/halfStar.png", UriKind.RelativeOrAbsolute));
                            }
                        }
                        else if (rating > 2.49)
                        {
                            ThreeStarImage.Source = new BitmapImage(new Uri(@"Icons/halfStar.png", UriKind.RelativeOrAbsolute));
                        }
                    }
                    else if (rating > 1.49)
                    {
                        TwoStarImage.Source = new BitmapImage(new Uri(@"Icons/halfStar.png", UriKind.RelativeOrAbsolute));
                    }
                }
                else if (rating > 0.49)
                {
                    OneStarImage.Source = new BitmapImage(new Uri(@"Icons/halfStar.png", UriKind.RelativeOrAbsolute));
                }
            }
        }

    

        /*Constructor*/
        public FilmPage()
        {
            Myself = StartWindow.Myself;
            this.DataContext = this;
            InitializeComponent();
            this.start();

           
        }


        /*Even handler for add comment button*/
        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow cw = new CommentWindow(this);
            this.IsEnabled = false;
            cw.ShowDialog();
           
            
        }
      


        // An event to buy a movie, checks users id and adds the film to users bought movies list
        private async void  BuyFilm_Click(object sender, RoutedEventArgs e)
        {
            bool check = await DBAccess.BuyFilm(filmid, Myself.id_user);
            if (check==true)
            {
                MessageBox.Show("You can't buy this movie");
            }
            else
                MessageBox.Show("Have a nice day!");
     
        }

     //Function to vote for the movie, depending on which star you clicked
       
        private async void FiveStars_Click(object sender, RoutedEventArgs e)
        {
           Boolean canvote =await DBAccess.VoteForFilm(filmid,Myself.id_user);
            if(canvote==false){
            DBAccess.vote(5,filmid);
            ratingLoadFunction();
            StartWindow.SetPage(new FilmPage());
        }
            else
            {
                MessageBox.Show("You can't vote");
            }
        }

        private async  void FourStars_Click(object sender, RoutedEventArgs e)
        {
                     Boolean canvote =await DBAccess.VoteForFilm(filmid,Myself.id_user);
            if(canvote==false){
            DBAccess.vote(4,filmid);
            ratingLoadFunction();
            StartWindow.SetPage(new FilmPage());
        }
            else
            {
                MessageBox.Show("You can't vote");
            }
        }

        private async void ThreeStars_Click(object sender, RoutedEventArgs e)
        {
                     Boolean canvote =await DBAccess.VoteForFilm(filmid,Myself.id_user);
            if(canvote==false){
            DBAccess.vote(3,filmid);
            ratingLoadFunction();
            StartWindow.SetPage(new FilmPage());
        }
            else
            {
                MessageBox.Show("You can't vote");
            }
        }

        private async  void TwoStars_Click(object sender, RoutedEventArgs e)
        {
                      Boolean canvote =await DBAccess.VoteForFilm(filmid,Myself.id_user);
            if(canvote==false){
            DBAccess.vote(2,filmid);
            ratingLoadFunction();
            StartWindow.SetPage(new FilmPage());
        }
            else
            {
                MessageBox.Show("You can't vote");
            }
        }

        private async void OneStar_Click(object sender, RoutedEventArgs e)
        {
                   Boolean canvote =await DBAccess.VoteForFilm(filmid,Myself.id_user);
            if(canvote==false){
            DBAccess.vote(1,filmid);
            ratingLoadFunction();
            StartWindow.SetPage(new FilmPage());
        }
            else
            {
                MessageBox.Show("You can't vote");
            }
        }

        /* Event handler setting changing window page to search page */
        private void BackToSearchPage_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.SetPage(new SearchPage());
        }

        /*Event handler which caches on page click to hide logout button if it is not hidden yet */
        private void filmPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            disposeControl.logOutButton.Visibility = Visibility.Hidden;
            disposeControl.visibility = true;
        }

        
    }
}
