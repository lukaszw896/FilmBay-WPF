using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DotNetProjectOne
{
   public static class DBAccess
    {
       public static int CreateFilm(String directorname, String directorsurname, double price, string studio, string story,
           string title, string originaltitle, string originallanguage, TimeSpan duration, string posterurl,
           int agerestriction, string publisher, DateTime releasedate)
       {
           film_table dane = new film_table();

           if (studio.Trim() != "")
           {
               dane.film_studio = studio;
           }
           if (story.Trim() != "")
           {
               dane.storyline = story;
           }

           dane.director_name = directorname;
           dane.director_surname = directorsurname;
           dane.film_price = price;

           dane.title = title;
           dane.title_orginal = originaltitle;
           dane.orginal_language = originallanguage;
           dane.duration = duration;

           if (posterurl == null)
           {
               posterurl = "stockphoto.jpg";
           }

           dane.poster_url = posterurl;
           dane.age_restriction = agerestriction;
           dane.publisher = publisher;
           dane.release_date = releasedate;
           DBAccess.AddFilm(dane);
           return dane.id_film;
       }




        public static int CreateWriter(String Name, String Surname)
        {
            writers_table writer = new writers_table();
            writer.writer_name = Name;
            writer.writer_surname = Surname;
            int writerid;
            MyLINQDataContext con = new MyLINQDataContext();
            //    bool nameinDB = (from p in con.writers_tables where p.writer_name == w.WName && p.writer_surname == w.WSurname select p).Count() > 0;
            bool nameinDB = (con.writers_tables.AsParallel().Where(s => s.writer_name == Name && s.writer_surname == Surname).Count()) > 0;

            if (nameinDB == false)
            {
              AddWriter(writer);
                writerid = writer.id_writer;
            }
            else
            {
                // writers_table x = (from p in con.writers_tables where p.writer_name == w.WName && p.writer_surname == w.WSurname select p).First();
                writers_table x = con.writers_tables.AsParallel().Where(s => s.writer_name == Name && s.writer_surname == Surname).First();
                writerid = x.id_writer;
            }
            con.Dispose();
            return writerid;


        }

        public static int CreateActor(String Name, String Surname, String Photourl)
        {
            actor_table actor = new actor_table();
            actor.actor_name = Name;
            actor.actor_surname = Surname;

            actor.actor_photo_url = Photourl;
            int actorid;
            int n;
            MyLINQDataContext con = new MyLINQDataContext();
            //   bool nameinDB = (from p in con.actor_tables where p.actor_name == a.Name && p.actor_surname == a.Surname select p).Count() > 0;
            bool nameinDB = (con.actor_tables.AsParallel().Where(s => s.actor_name == Name && s.actor_surname == Surname).Count()) > 0;

            //  MessageBox.Show(nameinDB.ToString());
            if (nameinDB == false)
            {
                AddActor(actor);
                actorid = actor.id_actor;
            }
            else
            {
                actor_table x = new actor_table();
                //  x = (from p in con.actor_tables where p.actor_name == a.Name && p.actor_surname == a.Surname select p).First();
                actor_table z = con.actor_tables.AsParallel().Where(s => s.actor_name == Name && s.actor_surname == Surname).First();
                n = z.id_actor;
                actorid = n;
            }
            con.Dispose();
            return actorid;

        }

        public static int CreateGenre(String Name)
        {
            genere_table tab = new genere_table();
            tab.genere_name = Name;
            int genreid;
            MyLINQDataContext con = new MyLINQDataContext();
            //   bool nameinDB = (from p in con.genere_tables  where p.genere_name == c.GName select p).Count() > 0;
            bool nameinDB = (con.genere_tables.AsParallel().Where(s => s.genere_name == Name).Count()) > 0;
            if (nameinDB == false)
            {
                AddGenre(tab);
                genreid = tab.id_genere;
            }
            else
            {
                //    genere_table x = (from p in con.genere_tables where p.genere_name == c.GName select p).First();
                genere_table x = con.genere_tables.AsParallel().Where(s => s.genere_name == Name).First();
                genreid = x.id_genere;
            }
            con.Dispose();
            return genreid;
        }
        public static int CreateComposer(String Name, String Surname)
        {
            music_creator_table composer = new music_creator_table();
            composer.music_creator_name = Name;
            composer.music_creator_surname = Surname;
            int composerid;
            MyLINQDataContext con = new MyLINQDataContext();
            //   bool nameinDB = (from p in con.music_creator_tables where p.music_creator_name == c.CName && p.music_creator_surname == c.CSurname select p).Count() > 0;
            bool nameinDB = (con.music_creator_tables.AsParallel().Where(s => s.music_creator_name == Name && s.music_creator_surname == Surname).Count()) > 0;
            //  MessageBox.Show(nameinDB.ToString());
            if (nameinDB == false)
            {
                AddComposer(composer);
                composerid = composer.id_music_creator;
            }
            else
            {
                //  music_creator_table x = (from p in con.music_creator_tables where p.music_creator_name == c.CName && p.music_creator_surname == c.CSurname select p).First();
                music_creator_table x = con.music_creator_tables.AsParallel().Where(s => s.music_creator_name == Name && s.music_creator_surname == Surname).First();
                composerid = x.id_music_creator;
            }
            return composerid;

        }
        public static void CreateFilm()
        {

        }

        public static int CreateLanguage(String Name)
        {
            other_language_table tab = new other_language_table();
            tab.other_language_name = Name;
            int langid;
            MyLINQDataContext con = new MyLINQDataContext();
            //  bool nameinDB = (from p in con.other_language_tables where p.other_language_name == Lang.Name select p).Count() > 0;
            bool nameinDB = (con.other_language_tables.AsParallel().Where(s => s.other_language_name == Name).Count()) > 0;

            if (nameinDB == false)
            {
              AddOLang(tab);
                langid = tab.id_other_language;
            }
            else
            {
                // other_language_table x = (from p in con.other_language_tables where p.other_language_name == c.LName select p).First();
                other_language_table x = con.other_language_tables.AsParallel().Where(s => s.other_language_name == Name).First();
                langid = x.id_other_language;
            }
            return langid;


        }

        public static int CreatePhoto(String url)
        {
            photos_table photos = new photos_table();

            photos.photo_url = url;
            int photoid;
            MyLINQDataContext con = new MyLINQDataContext();
            // bool nameinDB = (from p in con.photos_tables where p.photo_url == x select p).Count() > 0;
            bool nameinDB = (con.photos_tables.AsParallel().Where(s => s.photo_url == url).Count()) > 0;

            if (nameinDB == false)
            {
                AddMPhoto(photos);
                photoid = photos.id_photo;
            }
            else
            {
                //  photos_table z = (from p in con.photos_tables where p.photo_url == x select p).First();
                photos_table z = con.photos_tables.AsParallel().Where(s => s.photo_url == url).First();
                photoid = z.id_photo;
            }
            con.Dispose();
            return photoid;
        }
        public static void CreateProducer(String Name, String Surname, int filmid)
        {
            producer_table producer = new producer_table();
            producer.producer_name = Name;
            producer.producer_surname = Surname;
            producer.id_film = filmid;
            MyLINQDataContext con = new MyLINQDataContext();
            //  bool nameinDB = (from x in con.producer_tables where x.producer_name == p.PName && x.producer_surname == p.PSurname select x).Count() > 0;
            bool nameinDB = (con.producer_tables.AsParallel().Where(s => s.producer_name == Name && s.producer_surname == Surname).Count()) > 0;

            if (nameinDB == false)
            {
               AddProducer(producer);
            }

        }




        public static actor_film_table CreateActorFilmTable(int filmid, int actorid)
        {
            actor_film_table table = new actor_film_table();
            table.id_film = filmid;

            table.id_actor = actorid;
            AddToActorFilmTable(table);

            return table;
        }


        public static film_writers_table CreateWriterFilmTable(int filmid, int writerid)
        {
            film_writers_table table = new film_writers_table();
            table.id_film = filmid;
            table.id_writer = writerid;
            AddToWriterFilmTable(table);

            return table;

        }
        public static film_music_creator CreateComposerFilmTable(int filmid, int composerid)
        {
            film_music_creator table = new film_music_creator();
            table.id_film = filmid;
            table.id_music_creator = composerid;
            AddToComposerFilmTable(table);

            return table;



        }
        public static  film_photos_table CreatePhotosFilmTable(int filmid, int photoid)
        {
            film_photos_table filmphoto = new film_photos_table();
            filmphoto.id_film = filmid;
            filmphoto.id_photo = photoid;
            AddToFilmPhotosTable(filmphoto);

            return filmphoto;
        }

        public static film_genere_table CreateGenreFilmTable(int filmid, int genreid)
        {
            film_genere_table table = new film_genere_table();
            table.id_film = filmid;
            table.id_genere = genreid;
            AddToFilmGenre(table);

            return table;


        }
        public static film_other_language_table CreateFilmLanguageTable(int filmid, int languageid)
        {
            film_other_language_table table = new film_other_language_table();
            table.id_film = filmid;
            table.id_other_language = languageid;
            AddToFilmOtherLangTable(table);

            return table;


        }




        #region
        public static void AddFilm(film_table t)
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

        public static List<actor_table> GetActors(int filmid)
        {
            List<actor_table> Actors = new List<actor_table>();
            MyLINQDataContext con = new MyLINQDataContext();
            Actors = (from a in con.actor_tables
                      join at in con.actor_film_tables on a.id_actor equals at.id_actor
                      join f in con.film_tables on at.id_film equals f.id_film
                      where f.id_film == filmid
                      select a).ToList();
            con.Dispose();
            return Actors;


        }
        public static List<writers_table> GetWriters(int filmid)
        {

            List<writers_table> Writers = new List<writers_table>();
            MyLINQDataContext con = new MyLINQDataContext();
            Writers = (from a in con.writers_tables
                       join at in con.film_writers_tables on a.id_writer equals at.id_writer
                       join f in con.film_tables on at.id_film equals f.id_film
                       where f.id_film == filmid
                       select a).ToList();
            con.Dispose();
            return Writers;


        }
        public static List<music_creator_table> GetComposers(int filmid)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            List<music_creator_table> Composers = new List<music_creator_table>();
            Composers = (from a in con.music_creator_tables
                         join at in con.film_music_creators on a.id_music_creator equals at.id_music_creator
                         join f in con.film_tables on at.id_film equals f.id_film
                         where f.id_film == filmid
                         select a).ToList();
            con.Dispose();
            return Composers;

        }
        public static List<producer_table> GetProducers(int filmid)
        {
            List<producer_table> Producers = new List<producer_table>();
            MyLINQDataContext con = new MyLINQDataContext();
            Producers = (from a in con.producer_tables
                         join f in con.film_tables on a.id_film equals f.id_film
                         where f.id_film == filmid
                         select a).ToList();
            con.Dispose();
            return Producers;

        }
        public static List<photos_table> GetPhotos(int filmid)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            List<photos_table> Photos = new List<photos_table>();
            Photos = (from a in con.photos_tables
                      join at in con.film_photos_tables on a.id_photo equals at.id_photo
                      join f in con.film_tables on at.id_film equals f.id_film
                      where f.id_film == filmid
                      select a).ToList();
            con.Dispose();
            return Photos;

        }
        public static List<comment_table> GetComments(int filmid)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            List<comment_table> Comments = new List<comment_table>();
            Comments = (from a in con.comment_tables
                        join u in con.user_tables on a.id_film equals u.id_user
                        join f in con.film_tables on a.id_film equals f.id_film
                        where f.id_film == filmid
                        select a).ToList();
            con.Dispose();
            return Comments;

        }
        public static film_table LoadFilmFromId(int filmid)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            film_table ft;
            ft = con.film_tables.AsParallel().Where(s => s.id_film == filmid).FirstOrDefault();
            return ft;
        }
       public static void BuyFilm(int filmid, int userid)
        {

            MyLINQDataContext con = new MyLINQDataContext();
            bought_films_table bft = new bought_films_table();
            bool Alreadybought = (con.bought_films_tables.AsParallel().Where(s => s.id_film == filmid && s.id_user == userid).Count()) > 0;
            if (Alreadybought == true)
            {
                MessageBox.Show("You already have this movie!");
                con.Dispose();
            }
            else
            {
                bft.id_film = filmid;
                bft.id_user = userid;
                DBAccess.AddToBoughtFilms(bft);
                MessageBox.Show("Have a nice day!");
                con.Dispose();
            }
        }
       public static void vote(int rating, int filmid)
       {
           MyLINQDataContext con = new MyLINQDataContext();
           film_table ft = DBAccess.LoadFilmFromId(filmid);

           if (ft.nuber_of_votes == null)
           {
               ft.nuber_of_votes = 1;
           }
           else
           { ft.nuber_of_votes++; }
           if (ft.rating == null)
           { ft.rating = rating; }
           else
           { ft.rating = (ft.rating * (ft.nuber_of_votes - 1) + rating) / ft.nuber_of_votes; }

           DBAccess.UpdateRating(ft);
           con.Dispose();
       }

       public static  user_table Userlogin(String login, String password)
       {
           MyLINQDataContext con = new MyLINQDataContext();
           user_table x = new user_table();
           bool logininDB = (from p in con.user_tables where p.login == login select p).Count() > 0;
           if (logininDB == false)
           {
               MessageBox.Show("Wrong login");
           }
           else if (logininDB == true)
           {
               x = (from p in con.user_tables where p.login == login select p).First();
               if (x.password != password)
               {

                   MessageBox.Show("Wrong Password");
                   x.name = "Wrong";
                   return x;
               }
               else
               {
                   MessageBox.Show("Hello!");
                   return x;

               }

           }
           x.name = "Wrong";
           return x;
       }

       public static user_table CreateUser(string password, string name, string surname, string login, string email, int age)
       {
           user_table user = new user_table();
           user.password = password;
           user.name = name;
           user.surname = surname;
           user.login = login;
           user.e_mail = email;
           user.age = age;
           DBAccess.AddUser(user);
           return user;

       }
       public static string registercheck(string login, string email)
       {
           MyLINQDataContext con = new MyLINQDataContext();

           //check if login in DB
           bool logininDB = (from p in con.user_tables where p.login == login select p).Count() > 0;
           bool emailinDB = (from p in con.user_tables where p.e_mail == email select p).Count() > 0;
           string problem = "";
           con.Dispose();
           if (logininDB == true)
           {
               problem = "login";
               return problem;
           }
           else if (emailinDB == true)
           {
               problem = "email";
               return problem;
           }
           return problem;


       }





    }
}
