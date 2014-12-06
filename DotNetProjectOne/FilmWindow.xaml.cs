using DotNetProjectOne.TMDB_Api_helper_classes;
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
    public partial class FilmWindow : Window
    {


        List<DotNetProjectOne.ObjectClasses.Actor> actors = new List<DotNetProjectOne.ObjectClasses.Actor>();
        List<DotNetProjectOne.ObjectClasses.Writer> writers = new List<DotNetProjectOne.ObjectClasses.Writer>();
        List<DotNetProjectOne.ObjectClasses.Producer> producers = new List<DotNetProjectOne.ObjectClasses.Producer>();
        List<DotNetProjectOne.ObjectClasses.Composer> composers = new List<DotNetProjectOne.ObjectClasses.Composer>();
        String APhoto;
        String Poster;
        List<String> MoviePhotos = new List<String>();
        List<DotNetProjectOne.ObjectClasses.ALanguage> Languages = new List<DotNetProjectOne.ObjectClasses.ALanguage>();
        List<DotNetProjectOne.ObjectClasses.Genre> genres = new List<DotNetProjectOne.ObjectClasses.Genre>();
        MovieSearchReturnObject movie;
        int SearchedMovieId;
        FoundMovieInfo movieinfo;
        public FilmWindow(MovieSearchReturnObject movie)
        {
            this.movie = movie;
            this.SearchedMovieId = movie.id;
            InitializeComponent();
            actors = TMDbApi.GetCast(movie.id);
         this.fillEverything();
            this.Left = StartWindow.window.Left + (StartWindow.window.Width - this.Width) / 2;
            this.Top = StartWindow.window.Top + (StartWindow.window.Height - this.Height) / 2;
          

        }
        
        /*  METHOD FILLING ADMIN PANEL WITH DATA */
      
        private void fillEverything()
        {
            Title.Text = movie.title;
            NTitle.Text = movie.orginalTitle;
            Day.Text = movie.releaseDate.Substring(9, 2);
            Month.Text = movie.releaseDate.Substring(6, 2);
            Year.Text = movie.releaseDate.Substring(1, 4);
         //   Studio.Text = movieinfo.studio;
         //   Storyline.Text = movieinfo.storyline;
           // MessageBox.Show(movie.id.ToString());
            foreach (DotNetProjectOne.ObjectClasses.Actor a in actors)
            {
                ActorsGrid.Items.Add(a);
            }
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
                int filmid = DBAccess.CreateFilm(DName.Text, DSubName.Text, double.Parse(Price.Text), studio, storyline, Title.Text, NTitle.Text, Language.Text, duration, posterurl, Ageres, publisher, releasedate);

                /*
                dane.director_name = DName.Text;
                dane.director_surname = DSubName.Text;
                dane.film_price = double.Parse(Price.Text);
                if (Studio.Text.Trim() != "")
                {
                    dane.film_studio = Studio.Text;
                }
                if (Storyline.Text.Trim() != "")
                {
                    dane.storyline = Storyline.Text;
                }
                dane.title = Title.Text;
                dane.title_orginal = NTitle.Text;
                dane.orginal_language = Language.Text;
                dane.duration = TimeSpan.Parse(Duration_H.Text+":"+Duration_M.Text+":"+Duration_S.Text);
                if (Poster == null)
                {
                    Poster = "stockphoto.jpg";
                }
                    dane.poster_url = Poster;
               
                if (Age.SelectedItem != null)
                {
                    dane.age_restriction = int.Parse(((ComboBoxItem)Age.SelectedItem).Content.ToString());
                }
                if (Publisher.Text.Trim() != "")
                {
                    dane.publisher = Publisher.Text;
                }
                    if (Month.Text.Trim() != "" && Day.Text.Trim() != "" && Year.Text.Trim() != "")
                    {
                        dane.release_date = System.DateTime.Parse(Month.Text + "/" + Day.Text + "/" + Year.Text);
                    }
                    DBAccess.AddFilm(dane);
                    int filmid;
                 * */




                //      actorfilmtable.film_table = dane;

                //adding actors from the grid to the list, adding currents film ID to these actors.
                foreach (DotNetProjectOne.ObjectClasses.Actor a in actors)
                {
                    int actorid = await DBAccess.CreateActor(a.Name, a.Surname, a.Photo);
                    actor_film_table actorfilmtable = DBAccess.CreateActorFilmTable(filmid, actorid);

                }

                foreach (DotNetProjectOne.ObjectClasses.Writer w in writers)
                {

                    int writerid = await DBAccess.CreateWriter(w.WName, w.WSurname);

                    film_writers_table filmwriterstable = DBAccess.CreateWriterFilmTable(filmid, writerid);




                }

                //adding composers to music_creator table and to reference connected table film_music_creator table
                foreach (DotNetProjectOne.ObjectClasses.Composer c in composers)
                {
                    int composerid = await DBAccess.CreateComposer(c.CName, c.CSurname);
                    film_music_creator filmcomposer = DBAccess.CreateComposerFilmTable(filmid, composerid);



                }


                //adding producers to the producers table.
                foreach (DotNetProjectOne.ObjectClasses.Producer p in producers)
                {
                    DBAccess.CreateProducer(p.PName, p.PSurname, filmid);
                }

                //Adding photos to photos table and interconnecting table film_photos_table 
                foreach (String x in MoviePhotos)
                {
                    int photoid = await DBAccess.CreatePhoto(x);
                    film_photos_table filmphoto = DBAccess.CreatePhotosFilmTable(filmid, photoid);



                }
                //adding languages to language table and reference table
                foreach (DotNetProjectOne.ObjectClasses.ALanguage c in Languages)
                {

                    int langid = await DBAccess.CreateLanguage(c.LName);
                    film_other_language_table filmotherlanguage = DBAccess.CreateFilmLanguageTable(filmid, langid);


                }
                // adding genres to genre table
                foreach (DotNetProjectOne.ObjectClasses.Genre c in genres)
                {

                    int genreid = await DBAccess.CreateGenre(c.GName);
                    film_genere_table filmgenre = DBAccess.CreateGenreFilmTable(filmid, genreid);


                }

                MessageBox.Show("All is fine");

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

            DotNetProjectOne.ObjectClasses.Actor a = new DotNetProjectOne.ObjectClasses.Actor();
            a.Name = ActorName.Text;
            a.Surname = ActorSurname.Text;
            if(APhoto!=null)
            { a.Photo = APhoto; }
            else
            { a.Photo = "stockphoto.jpg"; }
           
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
            DotNetProjectOne.ObjectClasses.Writer w = new DotNetProjectOne.ObjectClasses.Writer();
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ProducerPopUp.IsOpen = true;
        }
        //Adding Producers to DataGrid
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            DotNetProjectOne.ObjectClasses.Producer a = new DotNetProjectOne.ObjectClasses.Producer();
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
        
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ProducerPopUp.IsOpen = false;
        }
//Adding Composers to DataGrid
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            DotNetProjectOne.ObjectClasses.Composer c = new DotNetProjectOne.ObjectClasses.Composer();
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

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            ComposerrPopUp.IsOpen = false;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            ComposerrPopUp.IsOpen = true;
        }


        //adding an actor Photo
        private void Button_Click_11(object sender, RoutedEventArgs e)
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

                    }
                }
            }
        }

        //adding screenshots from the movie
        private void Button_Click_12(object sender, RoutedEventArgs e)
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
                    try
                    {
                        MoviePhotos.Add(name);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            LanguagePopUp.IsOpen = true;
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            LanguagePopUp.IsOpen = false;
        }


        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            DotNetProjectOne.ObjectClasses.ALanguage a = new DotNetProjectOne.ObjectClasses.ALanguage();
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

                    }
                }
            }

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            GenrePopUp.IsOpen=true;
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            DotNetProjectOne.ObjectClasses.Genre g = new DotNetProjectOne.ObjectClasses.Genre();
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

        private void Button_Click_18(object sender, RoutedEventArgs e)
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
    }
}