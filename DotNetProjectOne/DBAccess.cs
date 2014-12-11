using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DotNetProjectOne
{
    public static class DBAccess
    {
        public static Semaphore photoSem = new Semaphore(1, 1);


        public async static Task<int> CreateFilm(String directorname, String directorsurname, double price, string studio, string story,
            string title, string originaltitle, string originallanguage, TimeSpan duration, string posterurl,
            int agerestriction, string publisher, DateTime releasedate,FilmWindow filmWindow)
        {
               return await Task.Run( () =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
            film_table dane = new film_table();
            bool nameinDB = (con.film_tables.AsParallel().Where(s => s.title == title && s.release_date==releasedate).Count()) > 0;
            if (nameinDB == false)
            {
               
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
            con.Dispose();
            return dane.id_film;
        
                      }
                else
                {
                   /* dane= con.film_tables.AsParallel().Where(s => s.title == title && s.release_date==releasedate).FirstOrDefault();
                    con.Dispose();
                    return dane.id_film;*/
                     con.Dispose();
                MessageBox.Show("A film you are trying to add already exist in the database. Our system doesn't allow to alter or modify already existing films (Avaliable in next version)");

               
                        return -1;
                 
                }
            });
          
        }




        public async static Task<int> CreateWriter(String Name, String Surname)
        {
            return await Task.Run(() =>
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
            });

        }

        public async static Task<int> CreateActor(String Name, String Surname, String Photourl)
        {
            return await Task.Run(() =>
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
            });
        }

        public async static Task<int> CreateGenre(String Name)
        {
            return await Task.Run(() =>
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
            });
        }
        public async static Task<int> CreateComposer(String Name, String Surname)
        {
            return await Task.Run(() =>
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
            });
        }


        public async static Task<int> CreateLanguage(String Name)
        {
            return await Task.Run(() =>
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
            });

        }

        public async static Task<int> CreatePhoto(String url)
        {
            return await Task.Run(() =>
            {
                photoSem.WaitOne();
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
                photoSem.Release();
                return photoid;
            });
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
        public static film_photos_table CreatePhotosFilmTable(int filmid, int photoid)
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
        public static void UpdateVote(vote_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                vote_table table = conn.vote_tables.AsParallel().Where(s => s.id_film == t.id_film && s.id_user == t.id_user).FirstOrDefault();

                table.vote = t.vote;
                conn.SubmitChanges();
                conn.Dispose();

            }
        }
        public static void AddVote(vote_table t)
        {
            using (MyLINQDataContext conn = new MyLINQDataContext())
            {
                conn.vote_tables.InsertOnSubmit(t);
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

        public async static Task<List<actor_table>> GetActors(int filmid)
        {
            return await Task.Run(() =>
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
            });

        }
        public async static Task<List<writers_table>> GetWriters(int filmid)
        {
            return await Task.Run(() =>
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
            });


        }
        public async static Task<List<music_creator_table>> GetComposers(int filmid)
        {
            return await Task.Run(() =>
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
            });

        }
        public async static Task<List<producer_table>> GetProducers(int filmid)
        {
            return await Task.Run(() =>
            {
                List<producer_table> Producers = new List<producer_table>();
                MyLINQDataContext con = new MyLINQDataContext();
                Producers = (from a in con.producer_tables
                             join f in con.film_tables on a.id_film equals f.id_film
                             where f.id_film == filmid
                             select a).ToList();
                con.Dispose();
                return Producers;
            });

        }
        public async static Task<List<photos_table>> GetPhotos(int filmid)
        {
            return await Task.Run(() =>
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
            });

        }
        public async static Task<List<comment_table>> GetComments(int filmid)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                List<comment_table> Comments = new List<comment_table>();
                Comments = (from a in con.comment_tables
                            join u in con.user_tables on a.id_user equals u.id_user
                            join f in con.film_tables on a.id_film equals f.id_film
                            where f.id_film == filmid
                            select a).ToList();
                con.Dispose();
                return Comments;
            });
        }
        public async static Task<film_table> LoadFilmFromId(int filmid)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                film_table ft;
                ft = con.film_tables.AsParallel().Where(s => s.id_film == filmid).FirstOrDefault();
                return ft;
            });
        }


        public async static Task<writers_table> LoadWriterFromId(int writerid)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                writers_table tab;
                tab = con.writers_tables.AsParallel().Where(s => s.id_writer == writerid).FirstOrDefault();
                return tab;
            });

        }

        public async static Task<genere_table> LoadGenreFromId(int genreid)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                genere_table tab;
                tab = con.genere_tables.AsParallel().Where(s => s.id_genere == genreid).FirstOrDefault();
                return tab;
            });

        }
        public async static Task<music_creator_table> LoadComposerFromId(int id)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                music_creator_table tab;
                tab = con.music_creator_tables.AsParallel().Where(s => s.id_music_creator == id).FirstOrDefault();
                return tab;
            });

        }
        public async static Task<user_table> LoadUserFromId(int id)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
               user_table tab;
                tab = con.user_tables.AsParallel().Where(s => s.id_user == id).FirstOrDefault();
                return tab;
            });

        }
        public async static Task<actor_table> LoadActorFromId(int id)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                actor_table tab;
                tab = con.actor_tables.AsParallel().Where(s => s.id_actor == id).FirstOrDefault();
                return tab;
            });
        }
        public async static Task<other_language_table> LoadLanguageFromId(int id)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                other_language_table tab;
                tab = con.other_language_tables.AsParallel().Where(s => s.id_other_language == id).FirstOrDefault();
                return tab;
            });
        }



        public async static Task<bool> BuyFilm(int filmid, int userid)
        {
            return await Task.Run(() =>
           {
               MyLINQDataContext con = new MyLINQDataContext();
               user_table x = new user_table();
               x = (con.user_tables.AsParallel().Where(s => s.id_user==userid).FirstOrDefault());
               bought_films_table bft = new bought_films_table();
               bool Alreadybought = (con.bought_films_tables.AsParallel().Where(s => s.id_film == filmid && s.id_user == userid).Count()) > 0;
               bool isAdmin = (x.is_admin)==1;
               if (Alreadybought == true || isAdmin==true)
               {
                   con.Dispose();
                   return true ;
               }
               else
               {
                   bft.id_film = filmid;
                   bft.id_user = userid;
                   DBAccess.AddToBoughtFilms(bft);
                   con.Dispose();
                   return false;
               }

           });
        }
        public async static Task<int> VoteForFilm(int filmid, int userid, int vote)
        {
            // 6- admin
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                user_table x = new user_table();
                x = (con.user_tables.AsParallel().Where(s => s.id_user == userid).FirstOrDefault());
                vote_table bft = new vote_table();
                bool Alreadyvoted = (con.vote_tables.AsParallel().Where(s => s.id_film == filmid && s.id_user == userid).Count()) > 0;
                bool isAdmin = (x.is_admin) == 1;

                if (isAdmin == true) { return 6; }

                if (Alreadyvoted == true )
                {
                    bft = con.vote_tables.AsParallel().Where(s => s.id_film == filmid && s.id_user == userid).FirstOrDefault();
                    int old = bft.vote;
         
                    con.Dispose();
                    vote_table update = bft;
                    update.vote = vote;
                    DBAccess.UpdateVote(update);
      
                    return old;
                }
                else
                {
                    bft.id_film = filmid;
                    bft.id_user = userid;
                    bft.vote = vote;
                     DBAccess.AddVote(bft);
                    
                    con.Dispose();
                    return 0;
                }


            });
        }


        public async static void vote(int rating, int filmid, int voteforfilmresult)
        {
            //0 - no vote 1- voted 2- admin
            MyLINQDataContext con = new MyLINQDataContext();
            film_table ft = await DBAccess.LoadFilmFromId(filmid);

            if (ft.nuber_of_votes == null)
            {
                ft.nuber_of_votes = 1;
            }

            else
            { 
                if(voteforfilmresult==0)
                ft.nuber_of_votes++; 
            }

            if (ft.rating == null)
            { 
                ft.rating = rating;
              //  MessageBox.Show("ftrating is null");
            }
            else
            {
                if(voteforfilmresult==0)
                { 
                ft.rating = (ft.rating * (ft.nuber_of_votes - 1) + rating) / ft.nuber_of_votes;
              //  MessageBox.Show("DUPA:" +ft.rating.ToString());
                DBAccess.UpdateRating(ft);
                con.Dispose();
                }
                else
                {
                 //   MessageBox.Show(voteforfilmresult.ToString());
                    ft.rating= ((ft.nuber_of_votes*ft.rating)-voteforfilmresult+rating)/ft.nuber_of_votes;
                   // MessageBox.Show("Poprawnosc!:" +ft.rating.ToString());
                    DBAccess.UpdateRating(ft);
                    con.Dispose();

                }
               
            }
            DBAccess.UpdateRating(ft);
            
        }

        public static async Task<user_table> Userlogin(String login, String password)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            user_table x = new user_table();
            return await Task.Run(() =>
            {
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
                        return x;

                    }

                }
                x.name = "Wrong";
                return x;
            });

        }
        public static async Task<user_table> FBlogin( String name, String surname, String email)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            user_table x = new user_table();
            return await Task.Run(() =>
            {
                bool logininDB = (from p in con.user_tables where p.e_mail == email select p).Count() > 0;
                if (logininDB == false)
                {

                   x = CreateFBuser(name, surname, email);
                   return x;
                }
                else 
                {
                    x = (from p in con.user_tables where p.e_mail == email select p).FirstOrDefault();
                    return x;
                }
         
            });

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
            if(login=="Admin" && password=="Superpower")
            {
                user.is_admin = 1;
            }
            DBAccess.AddUser(user);
            return user;

        }
        public static user_table CreateFBuser( string name, string surname, string email)
        {
            string login = name + surname;
            user_table user = new user_table();
            user.name = name;
            user.surname = surname;
            user.e_mail = email;
            user.login = login;
            DBAccess.AddUser(user);
            return user;

        }
        public static async Task<string> registercheck(string login, string email)
        {
            return await Task.Run(() =>
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
            });

        }
        public async static Task<List<film_table>> GetBoughtFilms(int id)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                List<film_table> FilmTables = (from u in con.user_tables
                                               join bf in con.bought_films_tables on u.id_user equals bf.id_user
                                               join f in con.film_tables on bf.id_film equals f.id_film
                                               where bf.id_user == id
                                               select f).ToList();
                con.Dispose();
                return FilmTables;
            });

        }

        public async static Task<List<film_table>> GetTopFilms(int low, int top)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                List<film_table> FilmTables = new List<film_table>();
                FilmTables = con.film_tables.AsParallel().Where(s => s.rating > low && s.rating <= top).ToList();
                con.Dispose();
                return FilmTables;
            });
        }

        public async static Task<List<film_table>> SearchedByTitle(string searchedtitle)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();

                List<film_table> FilmTables = new List<film_table>();

                FilmTables = (from p in con.film_tables where p.title.Contains(searchedtitle) select p).ToList();
                con.Dispose();
                return FilmTables;
            });
        }

        public async static Task<List<film_table>> SearchedByDirector(string name, string surname)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                List<film_table> FilmTables = new List<film_table>();
                FilmTables = (from p in con.film_tables
                              where p.director_name.Contains(name) || p.director_surname.Contains(surname)
                              select p).ToList();
                con.Dispose();
                return FilmTables;
            });
        }
        public async static Task<List<film_table>> SearchedByActor(string name, string surname)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                List<film_table> FilmTables = new List<film_table>();
                FilmTables = (from a in con.actor_tables
                              join at in con.actor_film_tables on a.id_actor equals at.id_actor
                              join f in con.film_tables on at.id_film equals f.id_film
                              where a.actor_name.Contains(name) || a.actor_surname.Contains(name)
                              select f).ToList();
                con.Dispose();
                return FilmTables;
            });

        }
        public async static Task<List<film_table>> SearchedByGenre(string name)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                List<film_table> FilmTables = new List<film_table>();
                FilmTables = (from a in con.genere_tables
                              join at in con.film_genere_tables on a.id_genere equals at.id_genere
                              join f in con.film_tables on at.id_film equals f.id_film
                              where a.genere_name.Contains(name)
                              select f).ToList();
                con.Dispose();
                return FilmTables;
            });

        }

        public async static Task<List<film_table>> SearchedByWriter(string name, string surname)
        {
            return await Task.Run(() =>
            {

                MyLINQDataContext con = new MyLINQDataContext();
                List<film_table> FilmTables = new List<film_table>();
                FilmTables = (from a in con.writers_tables
                              join at in con.film_writers_tables on a.id_writer equals at.id_writer
                              join f in con.film_tables on at.id_film equals f.id_film
                              where a.writer_name == name && a.writer_surname == surname
                              select f).ToList();
                con.Dispose();
                return FilmTables;
            });
        }

        public async static Task<List<film_table>> SearchedByProducer(string name, string surname)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                List<film_table> FilmTables = new List<film_table>();
                FilmTables = (from a in con.producer_tables
                              join f in con.film_tables on a.id_film equals f.id_film
                              where a.producer_name == name && a.producer_surname == surname
                              select f).ToList();
                con.Dispose();
                return FilmTables;
            });
        }

        public async static Task<List<film_table>> SearchedByComposer(string name, string surname)
        {
            return await Task.Run(() =>
            {
                MyLINQDataContext con = new MyLINQDataContext();
                List<film_table> FilmTables = new List<film_table>();
                FilmTables = (from a in con.music_creator_tables
                              join at in con.film_music_creators on a.id_music_creator equals at.id_music_creator
                              join f in con.film_tables on at.id_film equals f.id_film
                              where a.music_creator_name == name && a.music_creator_surname == surname
                              select f).ToList();
                con.Dispose();
                return FilmTables;
            });
        }


        public static int ChosenFilm(string FilmName)
        {
            MyLINQDataContext con = new MyLINQDataContext();
            film_table ft = con.film_tables.AsParallel().Where(s => s.title == FilmName).First();
            con.Dispose();
            return ft.id_film;
        }



    }
}
