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
        int filmid = 2;
      //  List<FilmWindow.Actor> actors = new List<FilmWindow.Actor>();
      //  List<FilmWindow.Writer> writers = new List<FilmWindow.Writer>();
      //  List<FilmWindow.Producer> producers = new List<FilmWindow.Producer>();
     //   List<FilmWindow.Composer> composers = new List<FilmWindow.Composer>();
        private ObservableCollection<Img> _filmactors= new ObservableCollection<Img>();
        public ObservableCollection<Img> filmactors
        {
            get { return _filmactors; }
            set { _filmactors = value; }
        }


        public FilmPage()
        {
            this.DataContext = this;
            InitializeComponent();
            DirectorBlock.Text = "";
            WriterBlock.Text = "";
            ProducerBlock.Text = "";
            YearBlock.Text = "";
            ComposerBlock.Text = "";
            StudioBlock.Text = "";

             MyLINQDataContext con = new MyLINQDataContext();
             film_table ft;
             ft = con.film_tables.AsParallel().Where(s => s.id_film == filmid).First();
             string path = AppDomain.CurrentDomain.BaseDirectory + "Posters\\" + ft.poster_url;
          //   String[] split = Search.Text.Split(' ');
             List<actor_table> Actors = new List<actor_table>();
            Actors = (      from a in con.actor_tables
                           join at in con.actor_film_tables on a.id_actor equals at.id_actor
                           join f in con.film_tables on at.id_film equals f.id_film
                           where f.id_film==filmid select a).ToList();
                          foreach(actor_table at in Actors)
            {
                //MessageBox.Show(at.actor_name);
                Image myimage = new Image();
                string apath = AppDomain.CurrentDomain.BaseDirectory + "ActorPhotos\\" + at.actor_photo_url;
                string title = at.actor_name;
                string director = ft.director_name + " " + ft.director_surname;
                string year = ft.release_date.Value.ToShortDateString();
                //   MessageBox.Show(path);
                myimage.Source = new BitmapImage(new Uri(path));

                Img img = new Img(apath, year, title, director);

                filmactors.Add(img);


            }
            // Read Writers from db


            List<writers_table> Writers = new List<writers_table>();

               Writers = (from a in con.writers_tables
                 join at in con.film_writers_tables on a.id_writer equals at.id_writer
                 join f in con.film_tables on at.id_film equals f.id_film
                 where f.id_film==filmid select a).ToList();
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


               List<music_creator_table> Composers = new List<music_creator_table>();
               Composers = (from a in con.music_creator_tables
                     join at in con.film_music_creators on a.id_music_creator equals at.id_music_creator
                     join f in con.film_tables on at.id_film equals f.id_film
                     where f.id_film==filmid
                     select a).ToList();
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
               List<producer_table> Producers = new List<producer_table>();
               Producers = (from a in con.producer_tables
                     join f in con.film_tables on a.id_film equals f.id_film
                     where f.id_film==filmid
                     select a).ToList();
            foreach(producer_table p in Producers)
            {
                if(Producers.Count>1)
                {
                    ProducerBlock.Text = ProducerBlock.Text + " " + p.producer_name+ " " + p.producer_surname + ",";
                }
                else
                    ProducerBlock.Text = ProducerBlock.Text + " " + p.producer_name + " " + p.producer_surname;

            }


            YearBlock.Text = ft.release_date.Value.ToShortDateString();
             Poster.Source = new BitmapImage(new Uri(path));
             Title.Content = ft.title;
             Story.Text = ft.storyline;
             StudioBlock.Text = ft.film_studio;
             DirectorBlock.Text = ft.director_name + " " + ft.director_surname;
             con.Dispose();
        }

        private void AddComment_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow cw = new CommentWindow();
            this.IsEnabled = false;
            cw.ShowDialog();
           
            
        }

        
    }
}
