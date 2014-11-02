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


        List<Actor> actors = new List<Actor>();
        List<Writer> writers = new List<Writer>();
        List<Producer> producers = new List<Producer>();
        List<Composer> composers = new List<Composer>();
        String APhoto;
        String Poster;
        List<String> MoviePhotos = new List<String>();
        List<ALanguage> Languages = new List<ALanguage>();
        List<Genre> genres = new List<Genre>();
        public FilmWindow()
        {
            InitializeComponent();
        }

        private void CheckIfNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }

        }
        private void CheckIfLetters(TextCompositionEventArgs e)
        {
            int result;

            if ((int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }

        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int value;




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
            else if (string.IsNullOrWhiteSpace(this.Duration_M.Text))
            {
                MessageBox.Show("Must give duration in minutes");
            }
            else if (string.IsNullOrWhiteSpace(this.Duration_H.Text))
            {
                MessageBox.Show("Must give duration in minutes");
            }
            else if (string.IsNullOrWhiteSpace(this.Duration_S.Text))
            {
                MessageBox.Show("Must give duration in minutes");
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
                MessageBox.Show("All is fine");

                film_table dane = new film_table();

                dane.director_name = DName.Text;
                dane.director_surname = DSubName.Text;
                dane.film_price = double.Parse(Price.Text);
                if (Studio.Text.Trim() != "")
                {
                    dane.film_studio = Studio.Text;
                }
                dane.title = Title.Text;
                dane.title_orginal = NTitle.Text;
                dane.orginal_language = Language.Text;
                dane.duration = TimeSpan.Parse(Duration_H.Text+":"+Duration_M.Text+":"+Duration_S.Text);
                dane.poster_url = Poster;
                if (Age.SelectedItem != null)
                {
                    dane.age_restriction = int.Parse(((ComboBoxItem)Age.SelectedItem).Content.ToString());
                }
                if (Publisher.Text.Trim() != "")
                {
                    dane.publisher = Publisher.Text;

                    if (Month.Text.Trim() != "" && Day.Text.Trim() != "" && Year.Text.Trim() != "")
                    {
                        dane.release_date = System.DateTime.Parse(Month.Text + "/" + Day.Text + "/" + Year.Text);
                    }
                    MainWindow.AddFilm(dane);
                    int filmid;
                    filmid = dane.id_film;

                    //      actorfilmtable.film_table = dane;


                    foreach (Actor a in actors)
                    {
                        actor_table actor = new actor_table();
                        actor.actor_name = a.Name;
                        actor.actor_surname = a.Surname;

                        actor.actor_photo_url = APhoto;
                        int actorid;
                        MyLINQDataContext con = new MyLINQDataContext();
                        bool nameinDB = (from p in con.actor_tables where p.actor_name == a.Name && p.actor_surname == a.Surname select p).Count() > 0;
                        //  MessageBox.Show(nameinDB.ToString());
                        if (nameinDB == false)
                        {
                            MainWindow.AddActor(actor);
                            actorid = actor.id_actor;
                        }
                        else
                        {
                            actor_table x = new actor_table();
                            x = (from p in con.actor_tables where p.actor_name == a.Name && p.actor_surname == a.Surname select p).First();
                            actorid = x.id_actor;
                        }
                        actor_film_table actorfilmtable = new actor_film_table();
                        actorfilmtable.id_film = filmid;

                        actorfilmtable.id_actor = actorid;
                        MainWindow.AddToActorFilmTable(actorfilmtable);
                    }
                    foreach (Writer w in writers)
                    {
                        writers_table writer = new writers_table();
                        writer.writer_name = w.WName;
                        writer.writer_surname = w.WSurname;
                        int writerid;
                        MyLINQDataContext con = new MyLINQDataContext();
                        bool nameinDB = (from p in con.writers_tables where p.writer_name == w.WName && p.writer_surname == w.WSurname select p).Count() > 0;
                        //  MessageBox.Show(nameinDB.ToString());
                        if (nameinDB == false)
                        {
                            MainWindow.AddWriter(writer);
                            writerid = writer.id_writer;
                        }
                        else
                        {
                            writers_table x = (from p in con.writers_tables where p.writer_name == w.WName && p.writer_surname == w.WSurname select p).First();
                            writerid = x.id_writer;
                        }
                        film_writers_table filmwriterstable = new film_writers_table();
                        filmwriterstable.id_film = filmid;
                        //  actorfilmtable.actor_table = actor;
                        filmwriterstable.id_writer = writerid;
                        MainWindow.AddToWriterFilmTable(filmwriterstable);
                        con.Dispose();

                    }
                    foreach (Composer c in composers)
                    {
                        music_creator_table composer = new music_creator_table();
                        composer.music_creator_name = c.CName;
                        composer.music_creator_surname = c.CSurname;
                        int composerid;
                        MyLINQDataContext con = new MyLINQDataContext();
                        bool nameinDB = (from p in con.music_creator_tables where p.music_creator_name == c.CName && p.music_creator_surname == c.CSurname select p).Count() > 0;
                        //  MessageBox.Show(nameinDB.ToString());
                        if (nameinDB == false)
                        {
                            MainWindow.AddComposer(composer);
                            composerid = composer.id_music_creator;
                        }
                        else
                        {
                            music_creator_table x = (from p in con.music_creator_tables where p.music_creator_name == c.CName && p.music_creator_surname == c.CSurname select p).First();
                            composerid = x.id_music_creator;
                        }
                        film_music_creator filmcomposer = new film_music_creator();
                        filmcomposer.id_film = filmid;
                        //  actorfilmtable.actor_table = actor;
                        filmcomposer.id_music_creator = composerid;
                        MainWindow.AddToComposerFilmTable(filmcomposer);
                        con.Dispose();
                    }



                    foreach (Producer p in producers)
                    {
                        producer_table producer = new producer_table();
                        producer.producer_name = p.PName;
                        producer.producer_surname = p.PSurname;
                        producer.id_film = filmid;
                        MyLINQDataContext con = new MyLINQDataContext();
                        bool nameinDB = (from x in con.producer_tables where x.producer_name == p.PName && x.producer_surname == p.PSurname select x).Count() > 0;
                        //  MessageBox.Show(nameinDB.ToString());
                        if (nameinDB == false)
                        {
                            MainWindow.AddProducer(producer);
                        }
                    }
                    foreach (String x in MoviePhotos)
                    {
                        photos_table photos = new photos_table();

                        photos.photo_url = x;
                        int photoid;
                        MyLINQDataContext con = new MyLINQDataContext();
                        bool nameinDB = (from p in con.photos_tables where p.photo_url == x select p).Count() > 0;
                        //  MessageBox.Show(nameinDB.ToString());
                        if (nameinDB == false)
                        {
                            MainWindow.AddMPhoto(photos);
                            photoid = photos.id_photo;
                        }
                        else
                        {
                            photos_table z = (from p in con.photos_tables where p.photo_url == x select p).First();
                            photoid = z.id_photo;
                        }
                        film_photos_table filmphoto = new film_photos_table();
                        filmphoto.id_film = filmid;
                        filmphoto.id_photo = photoid;
                        MainWindow.AddToFilmPhotosTable(filmphoto);
                        con.Dispose();
                    }

                    foreach (ALanguage c in Languages)
                    {
                        other_language_table tab = new other_language_table();
                        tab.other_language_name = c.LName;
                        int langid;
                        MyLINQDataContext con = new MyLINQDataContext();
                        bool nameinDB = (from p in con.other_language_tables where p.other_language_name == Lang.Name select p).Count() > 0;
                        //  MessageBox.Show(nameinDB.ToString());
                        if (nameinDB == false)
                        {
                            MainWindow.AddOLang(tab);
                            langid = tab.id_other_language;
                        }
                        else
                        {
                            other_language_table x = (from p in con.other_language_tables where p.other_language_name == c.LName select p).First();
                            langid = x.id_other_language;
                        }
                        film_other_language_table filmotherlanguage = new film_other_language_table();
                        filmotherlanguage.id_film = filmid;
                        //  actorfilmtable.actor_table = actor;
                        filmotherlanguage.id_other_language = langid;
                        MainWindow.AddToFilmOtherLangTable(filmotherlanguage);
                        con.Dispose();
                    }
                    foreach (Genre c in genres)
                    {
                        genere_table tab = new genere_table();
                        tab.genere_name = c.GName;
                        int genreid;
                        MyLINQDataContext con = new MyLINQDataContext();
                        bool nameinDB = (from p in con.genere_tables  where p.genere_name == c.GName select p).Count() > 0;
                        if (nameinDB == false)
                        {
                            MainWindow.AddGenre(tab);
                            genreid = tab.id_genere;
                        }
                        else
                        {
                            genere_table x = (from p in con.genere_tables where p.genere_name == c.GName select p).First();
                            genreid = x.id_genere;
                        }
                        film_genere_table filmgenre = new film_genere_table();
                        filmgenre.id_film = filmid;
                        //  actorfilmtable.actor_table = actor;
                        filmgenre.id_genere= genreid;
                       MainWindow.AddToFilmGenre(filmgenre);
                        con.Dispose();
                    }


                }

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
        public class Actor
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }

        public class Writer
        {
            public string WName { get; set; }
            public string WSurname { get; set; }
        }
        public class Producer
        {
            public string PName { get; set; }
            public string PSurname { get; set; }
        }

        public class Composer
        {
            public string CName { get; set; }
            public string CSurname { get; set; }
        }
        public class ALanguage
        {
            public string LName { get; set; }
        }
        public class Genre
        {
            public string GName { get; set; }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Actor a = new Actor();
            a.Name = ActorName.Text;
            a.Surname = ActorSurname.Text;

            bool alreadyExists = actors.Any(x => x.Name == ActorName.Text && x.Surname == ActorSurname.Text);
            if (alreadyExists == false)
            {
                ActorsGrid.Items.Add(a);
                actors.Add(a);
                ActorName.Text = "";
                ActorSurname.Text = "";
            }
            else
            {
                MessageBox.Show("Already added");
                ActorName.Text = "";
                ActorSurname.Text = "";
                APhoto = null;
            }


            //   MainWindow.AddActor(actor);
        }

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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ProducerPopUp.IsOpen = true;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
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

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ProducerPopUp.IsOpen = false;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
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

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            ComposerrPopUp.IsOpen = false;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            ComposerrPopUp.IsOpen = true;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("You clicked 'New...'");

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

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            GenrePopUp.IsOpen=false;
        }
    }
}