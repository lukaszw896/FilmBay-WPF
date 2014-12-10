using DotNetProjectOne.TMDB_Api_helper_classes;
using MahApps.Metro.Controls;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace DotNetProjectOne
{
    /// <summary>
    /// Interaction logic for FilmWindow.xaml
    /// </summary>
    public partial class FilmWindow : MetroWindow
    {


        List<Actor> actors = new List<Actor>();
        List<Writer> writers = new List<Writer>();
        List<Producer> producers = new List<Producer>();
        List<Composer> composers = new List<Composer>();
        String APhoto;
        String Poster;
        List<String> MoviePhotos = new List<String>();
        List<ALanguage> Languages = new List<ALanguage>();
        List<Genre> genres = new List<Genre>();
        //searching movie variables
        MovieSearchReturnObject movie;
        FoundMovieDetails foundMovieDetails;
        public  FilmWindow(MovieSearchReturnObject movie)
        {
            this.movie = movie;
            InitializeComponent();
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
        }
        
        /*  METHOD FILLING ADMIN PANEL WITH DATA */

        public async void method()
        {
            await fillEverything();
        }
        public async Task fillEverything()
        {
              await Task.Run(() =>
             {
                 /* TEMPORARLY I'M EREASING  GENRE NAME WHICH IS LONGER THAN 30, IS SHOULD WORK ALL THE TIME BUT WE HAVE TO CHANGE THIS BEFORE HANDING THE PROJECT */
                 foundMovieDetails = TMDbApi.movieDetails(movie.id);
                 for (int i = 0; i < foundMovieDetails.genres.Count; i++)
                 {
                     if (foundMovieDetails.genres[i].Length > 30)
                     {
                         foundMovieDetails.genres.RemoveAt(i);
                     }
                 }
                 for (int i = 0; i < foundMovieDetails.languages.Count; i++)
                 {
                     foundMovieDetails.languages[i] = TMDbHelper.FindSingleString(@"""name"":""", @"""", foundMovieDetails.languages[i]);
                 }
                 /* adding actors */
                 actors = TMDbApi.GetActors(movie.id);

                 CastInformation castInformation = TMDbApi.getCast(movie.id);
                 List<string> photosPaths = new List<string>();
                 photosPaths = TMDbApi.getFilmPictures(movie.id);
                 this.Dispatcher.BeginInvoke(new Action(() =>
                 {
                     Title.Text = movie.title;
                     NTitle.Text = movie.orginalTitle;
                     Day.Text = movie.releaseDate.Substring(9, 2);
                     Month.Text = movie.releaseDate.Substring(6, 2);
                     Year.Text = movie.releaseDate.Substring(1, 4);

                     PosterImage.Source = new BitmapImage(new Uri(movie.posterPath));
                     Poster = movie.posterPath;

                     /*adding spoken languages*/
                     foreach (string a in foundMovieDetails.languages)
                     {
                         LanguageGrid.Items.Add(new ALanguage() { LName = a });
                         ALanguage l = new ALanguage();
                         l.LName = a;
                         Languages.Add(l);
                     }

                     /* adding genres to GenreGrid*/
                     foreach (string a in foundMovieDetails.genres)
                     {
                         GenreGrid.Items.Add(new Genre() { GName = a });
                         Genre g = new Genre();
                         g.GName = a;
                         genres.Add(g);
                     }
                     /* adding storyline */
                     Storyline.Text = foundMovieDetails.storyline;
                     /*adding duration (THERE IS NO SECONDS SO WE HAVE TO GET RID OF THIS */
                     Duration_H.Text = (foundMovieDetails.duration / 60).ToString();
                     Duration_M.Text = (foundMovieDetails.duration % 60).ToString();
                     Duration_S.Text = "0";
                     /*age restriction*/
                     // if (foundMovieDetails.ageRestriction == "true") { Age.SelectedIndex = 1; } else Age.SelectedIndex = 0;
                     /* Studio */
                     Studio.Text = foundMovieDetails.studio;
                     /* adding actors */
                     foreach (Actor a in actors)
                     {
                         ActorsGrid.Items.Add(a);
                     }

                     /*
                      * adding writers composers and producers        
                      */

                     foreach (string writer in castInformation.writers)
                     {
                         String[] split = writer.Split(' ');
                         string name = split[0];
                         string surname = "";
                         if (split.Count() >= 2)
                             surname = split[1];
                         Writer tmpWriter = new Writer() { WName = name, WSurname = surname };
                         WriterGrid.Items.Add(tmpWriter);
                         writers.Add(tmpWriter);
                     }
                     foreach (string composer in castInformation.composers)
                     {
                         String[] split = composer.Split(' ');
                         string name = split[0];
                         string surname = "";
                         if (split.Count() >= 2)
                             surname = split[1];
                         Composer tmpComposer = new Composer() { CName = name, CSurname = surname };
                         ComposerGrid.Items.Add(tmpComposer);
                         composers.Add(tmpComposer);
                     }

                     foreach (string producer in castInformation.producers)
                     {
                         String[] split = producer.Split(' ');
                         string name = split[0];
                         string surname = "";
                         if (split.Count() >= 2)
                             surname = split[1];
                         Producer tmpProducer = new Producer() { PName = name, PSurname = surname };
                         producers.Add(tmpProducer);
                         ProducerGrid.Items.Add(tmpProducer);
                     }

                     /* Adding photos to gallery  */

                     foreach (string path in photosPaths)
                     {
                         MoviePhotos.Add(path);
                     }
                     progressRing.IsActive=false;
                     canvasName.Visibility = Visibility.Hidden;
                 }));
             });

        }
        //function checking whether input is numeric
        private void CheckIfNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }

        }
        //checkiing whether input is in letters
        private void CheckIfLetters(TextCompositionEventArgs e)
        {
            int result;

            if ((int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }

        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
     
            //Checking if if information in textbox makes sense

            if (string.IsNullOrWhiteSpace(this.Title.Text))
            {
                MessageBox.Show("TextBox is empty");
            }
            else if (string.IsNullOrWhiteSpace(this.DName.Text))
            {
                MessageBox.Show("Must give name of Director!");
            }
            else if (string.IsNullOrWhiteSpace(this.DSubName.Text))
            {
                MessageBox.Show("Must give subname of Director!");
            }
            else if (string.IsNullOrWhiteSpace(this.Language.Text))
            {
                MessageBox.Show("Language is important");
            }
            else if (string.IsNullOrWhiteSpace(this.Price.Text))
            {
                MessageBox.Show("Must Give Price");
            }
            else if (string.IsNullOrWhiteSpace(Duration_H.Text) || int.Parse(Duration_H.Text) > 23)
            {
                MessageBox.Show("Must give duration in HH:MM:SS format and film has to be shorter than 24 hours");
                Duration_H.Clear();
            }
            else if (string.IsNullOrWhiteSpace(Duration_M.Text) || int.Parse(Duration_M.Text) > 59)
            {
                MessageBox.Show("Must give duration in HH:MM:SS format and film has to and if it's longer than 60 min than change minutes to hours");
                Duration_M.Clear();
            }
            else if (string.IsNullOrWhiteSpace(Duration_S.Text) || int.Parse(Duration_S.Text) > 59)
            {
                MessageBox.Show("Must give duration in HH:MM:SS format and film has to and SS thextbox cannot have more than 59 seconds");
                Duration_S.Clear();
            }
            else if (string.IsNullOrWhiteSpace(Day.Text) || string.IsNullOrWhiteSpace(Month.Text) || string.IsNullOrWhiteSpace(Year.Text))
            {
                MessageBox.Show("Must give date");
            }
            /*
             if (int.TryParse(Price.Text, out value))
            {
                if (value ==0)
                    MessageBox.Show("Price can't be 0");
            }
             if (int.TryParse(Month.Text, out value))
            {
                if (value >12)
                    MessageBox.Show("Invalid Month");
            }
              if (int.TryParse(Day.Text, out value))
            {
                 if (value >31 )
                    MessageBox.Show("Invalid Day Number");
            }
              if (int.TryParse(Year.Text, out value))
              {
                  if (value < 1890 && value!=1111)
                      MessageBox.Show("Films didn't exist back then");
              }
            */
            else
            {
                canvasName.Visibility = Visibility.Visible;
                canvasName.Opacity = 0.8;
                progressRing.IsActive = true;
                //passing info into a filmtable
                film_table dane = new film_table();

                String studio = "";
                if (Studio.Text.Trim() != "")
                {
                    studio = Studio.Text;
                }
                String storyline = "";
                if (Storyline.Text.Trim() != "")
                {
                    storyline = Storyline.Text;
                }

                TimeSpan duration = TimeSpan.Parse(Duration_H.Text + ":" + Duration_M.Text + ":" + Duration_S.Text);
                string posterurl;
                if (Poster == null)
                {
                    Poster = "stockphoto.jpg";
                }

                posterurl = Poster;
                int Ageres = 6;
                if (Age.SelectedItem != null)
                {
                    Ageres = int.Parse(((ComboBoxItem)Age.SelectedItem).Content.ToString());
                }
                string publisher = "";
                if (Publisher.Text.Trim() != "")
                {
                    publisher = Publisher.Text;
                }
                DateTime releasedate;
                try { 
                    releasedate = System.DateTime.Parse(Month.Text + "/" + Day.Text + "/" + Year.Text);
                }
                catch
                {
                    Month.Clear(); Day.Clear(); Year.Clear();
                    MessageBox.Show("Please insert proper date");
                    return;
                }
                int filmid = await DBAccess.CreateFilm(DName.Text, DSubName.Text, double.Parse(Price.Text), studio, storyline, Title.Text, NTitle.Text, Language.Text, duration, posterurl, Ageres, publisher, releasedate);

                foreach (Actor a in actors)
                {
                    int actorid = await DBAccess.CreateActor(a.Name, a.Surname, a.photoPath);
                    actor_film_table actorfilmtable = DBAccess.CreateActorFilmTable(filmid, actorid);

                }

                foreach (Writer w in writers)
                {

                    int writerid = await DBAccess.CreateWriter(w.WName, w.WSurname);

                    film_writers_table filmwriterstable = DBAccess.CreateWriterFilmTable(filmid, writerid);




                }

                //adding composers to music_creator table and to reference connected table film_music_creator table
                foreach (Composer c in composers)
                {
                    int composerid = await DBAccess.CreateComposer(c.CName, c.CSurname);
                    film_music_creator filmcomposer = DBAccess.CreateComposerFilmTable(filmid, composerid);



                }


                //adding producers to the producers table.
                foreach (Producer p in producers)
                {
                    DBAccess.CreateProducer(p.PName, p.PSurname, filmid);
                }

                //Adding photos to photos table and interconnecting table film_photos_table 
                List<int> photoIdTmpList = new List<int>();
                foreach (String x in MoviePhotos)
                {
                    bool b = true;
                    int photoid = await DBAccess.CreatePhoto(x);
                    foreach(int id in photoIdTmpList)
                    {
                        if (id == photoid) { b = false; }
                    }
                    if (b == true)
                    {
                        photoIdTmpList.Add(photoid);
                        film_photos_table filmphoto = DBAccess.CreatePhotosFilmTable(filmid, photoid);

                    }
                }
                //adding languages to language table and reference table
                foreach (ALanguage c in Languages)
                {

                    int langid = await DBAccess.CreateLanguage(c.LName);
                    film_other_language_table filmotherlanguage = DBAccess.CreateFilmLanguageTable(filmid, langid);


                }
                // adding genres to genre table
                foreach (Genre c in genres)
                {

                    int genreid = await DBAccess.CreateGenre(c.GName);
                    film_genere_table filmgenre = DBAccess.CreateGenreFilmTable(filmid, genreid);


                }
                progressRing.IsActive = false;
                MessageBox.Show("All is fine");
                canvasName.Visibility = Visibility.Hidden;
                canvasName.Opacity = 1;
                this.Close();
                
            }

            }
        

        private void Rating_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void Month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);

        }

        private void Day_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }



        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void Year_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void Duration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfNumeric(e);
        }

        private void AddActorButton_Click(object sender, RoutedEventArgs e)
        {
            ActorPopUp.IsOpen = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActorPopUp.IsOpen = false;
        }



        //Adding Actor to actorgrid
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Actor a = new Actor();
            a.Name = ActorName.Text;
            a.Surname = ActorSurname.Text;
            if(APhoto!=null)
            { a.photoPath = APhoto; }
            else
            { a.photoPath = "stockphoto.jpg"; }
           
            bool alreadyExists = actors.Any(x => x.Name == ActorName.Text && x.Surname == ActorSurname.Text);
            if (alreadyExists == false)
            {
                ActorsGrid.Items.Add(a);
                actors.Add(a);
                ActorName.Text = "";
                ActorSurname.Text = "";
                APhoto = null;
                ActorPhoto.Source = null;
            }
            else
            {
                MessageBox.Show("Already added");
                ActorName.Text = "";
                ActorSurname.Text = "";
               APhoto = null;
               ActorPhoto.Source = null;
            }


            //   MainWindow.AddActor(actor);
        }

        //Adding Writers to DataGrid
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Writer w = new Writer();
            w.WName = WriterName.Text;
            w.WSurname = WriterSurname.Text;
            bool alreadyExists = writers.Any(x => x.WName == WriterName.Text && x.WSurname == WriterSurname.Text);
            if (alreadyExists == false)
            {
                WriterGrid.Items.Add(w);
                writers.Add(w);
                WriterName.Text = "";
                WriterSurname.Text = "";
            }
            else
            {
                MessageBox.Show("Already added");
                WriterName.Text = "";
                WriterSurname.Text = "";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WriterPopUp.IsOpen = false;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WriterPopUp.IsOpen = true;
        }

        private void WriterName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfLetters(e);
        }

        private void WriterSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIfLetters(e);
        }

        private void ProducerPopUpOpen(object sender, RoutedEventArgs e)
        {
            ProducerPopUp.IsOpen = true;
        }
        //Adding Producers to DataGrid
        private void AddProducer(object sender, RoutedEventArgs e)
        {
            Producer a = new Producer();
            a.PName = ProducerName.Text;
            a.PSurname = ProducerSurname.Text;
            bool alreadyExists = producers.Any(x => x.PName == ProducerName.Text && x.PSurname == ProducerSurname.Text);
            if (alreadyExists == false)
            {
                ProducerGrid.Items.Add(a);
                producers.Add(a);
                ProducerName.Text = "";
                ProducerSurname.Text = "";
            }
            else
            {
                MessageBox.Show("Already added");
                ProducerName.Text = "";
                ProducerSurname.Text = "";
            }

        }
        
        private void AddProducerPopUpClose(object sender, RoutedEventArgs e)
        {
            ProducerPopUp.IsOpen = false;
        }
//Adding Composers to DataGrid
        private void AddComposerButton(object sender, RoutedEventArgs e)
        {
            Composer c = new Composer();
            c.CName = ComposerName.Text;
            c.CSurname = ComposerSurname.Text;
            bool alreadyExists = composers.Any(x => x.CName == ComposerName.Text && x.CSurname == ComposerSurname.Text);
            if (alreadyExists == false)
            {
                ComposerGrid.Items.Add(c);
                composers.Add(c);
                ComposerName.Text = "";
                ComposerSurname.Text = "";
            }
            else
            {
                MessageBox.Show("Already added");
                ComposerName.Text = "";
                ComposerSurname.Text = "";
            }
        }

        private void ComposerPopUpClose(object sender, RoutedEventArgs e)
        {
            ComposerrPopUp.IsOpen = false;
        }

        private void ComposerPopUpOpen(object sender, RoutedEventArgs e)
        {
            ComposerrPopUp.IsOpen = true;
        }


        //adding an actor Photo
        private void AddActorPhoto(object sender, RoutedEventArgs e)
        {

  

            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
            // op.Multiselect = true;
            if (op.ShowDialog() == true)
            {

                string path = op.FileName;
                string name = op.SafeFileName;
                MessageBox.Show(path);
             
                {
                    try
                    {
                        Image myimage = new Image();
                       myimage.Source = new BitmapImage(new Uri(path));
                        ActorPhoto.Source = myimage.Source;
                        APhoto = name;
                       
        
                    }
                    catch
                    {
                        MessageBox.Show("Please choose correct actor image");
                    }
                }
            }
        }

        //adding screenshots from the movie
        private void addGallery_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("You clicked 'New...'");

            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
            op.Multiselect = true;
            if (op.ShowDialog() == true)
            {
                string[] filePath = op.SafeFileNames;
                foreach (string name in op.SafeFileNames)
                {

                    MoviePhotos.Add(name);
                }
            }
        }

        private void AddLanguagePopUpOpen(object sender, RoutedEventArgs e)
        {
            LanguagePopUp.IsOpen = true;
        }

        private void AddLanguagePopUpClose(object sender, RoutedEventArgs e)
        {
            LanguagePopUp.IsOpen = false;
        }


        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            ALanguage a = new ALanguage();
            a.LName = Lang.Text;
            bool alreadyExists = Languages.Any(x => x.LName == Lang.Text);
            if (alreadyExists == false)
            {

                LanguageGrid.Items.Add(a);
                Languages.Add(a);
                Lang.Text = "";

            }
            else
            {
                MessageBox.Show("Already added");
                Lang.Text = "";
            }
        }


        //adding a Poster for the movie
        private void Poster_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {

                string path = op.FileName;
                string name = op.SafeFileName;
                MessageBox.Show(name);
                {
                    try
                    {
                        Image myimage = new Image();
                        myimage.Source = new BitmapImage(new Uri(path));
                        PosterImage.Source = myimage.Source;
                        Poster = name;
                    }
                    catch
                    {
                        MessageBox.Show("Please choose correct poster image");
                    }
                }
            }

        }

        private void GenreMenuClick(object sender, RoutedEventArgs e)
        {
            GenrePopUp.IsOpen=true;
        }

        private void AddGenre(object sender, RoutedEventArgs e)
        {
            Genre g = new Genre();
            g.GName= GenreName.Text;

            bool alreadyExists = genres.Any(x => x.GName == GenreName.Text);
            if (alreadyExists == false)
            {
                GenreGrid.Items.Add(g);
                genres.Add(g);
                GenreName.Text = "";
 
            }
            else
            {
                MessageBox.Show("Already added");
                GenreName.Text = "";
            }
        }

        private void AddGenreClose(object sender, RoutedEventArgs e)
        {
            GenrePopUp.IsOpen=false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            StartWindow.pages.startPage.IsEnabled = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StartWindow.pages.startPage.IsEnabled = true;
        }
        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await fillEverything();  
        }
    }
}