using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetProjectOne;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotNetProjectTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void AddWriterTest()
        {
            String Name = "Name";
            String Surname = "Surname";
            int id = DBAccess.CreateWriter(Name, Surname).Result;
            writers_table samplewriter = new writers_table();
            samplewriter = DBAccess.LoadWriterFromId(id).Result;
            Assert.AreEqual<string>(samplewriter.writer_name, Name);

            int filmid = SampleFilm();
            film_writers_table tab = new film_writers_table();
            tab = DBAccess.CreateWriterFilmTable(filmid, samplewriter.id_writer);

            Assert.AreEqual(tab.id_film, filmid);
            Assert.AreEqual(tab.id_writer, samplewriter.id_writer);


        }

        [TestMethod]
        public void AddComposerTest()
        {
            String Name = "Name";
            String Surname = "Surname";
            int id = DBAccess.CreateComposer(Name, Surname).Result;
            music_creator_table sample = new music_creator_table();
            sample = DBAccess.LoadComposerFromId(id).Result;
            Assert.AreEqual<string>(sample.music_creator_name, Name);

            int filmid = SampleFilm();
            film_music_creator tab = new film_music_creator();
            tab = DBAccess.CreateComposerFilmTable(filmid, sample.id_music_creator);

            Assert.AreEqual(tab.id_film, filmid);
            Assert.AreEqual(tab.id_music_creator, sample.id_music_creator);

        }
        [TestMethod]
        public void AddActorTest()
        {
            String Name = "Name";
            String Surname = "Surname";
            int id = DBAccess.CreateActor(Name, Surname, "").Result;
            actor_table sample = new actor_table();
            sample = DBAccess.LoadActorFromId(id).Result;
            Assert.AreEqual<string>(sample.actor_name, Name);

            int filmid = SampleFilm();
            actor_film_table tab = new actor_film_table();
            tab = DBAccess.CreateActorFilmTable(filmid, sample.id_actor);

            Assert.AreEqual(tab.id_film, filmid);
            Assert.AreEqual(tab.id_actor, sample.id_actor);
        }
        [TestMethod]
        public void AddLanguageTest()
        {
            String Name = "Name";
            int id = DBAccess.CreateLanguage(Name).Result;
            other_language_table sample = new other_language_table();
            sample = DBAccess.LoadLanguageFromId(id).Result;
            Assert.AreEqual<string>(sample.other_language_name, Name);

            int filmid = SampleFilm();
           film_other_language_table tab = new film_other_language_table();
            tab = DBAccess.CreateFilmLanguageTable(filmid, sample.id_other_language);

            Assert.AreEqual(tab.id_film, filmid);
            Assert.AreEqual(tab.id_other_language, sample.id_other_language);
        }
        [TestMethod]
        public void AddGenreTest()
        {
            String Name = "Name";
            int id = DBAccess.CreateGenre(Name).Result;
            genere_table sample = new genere_table();
            sample = DBAccess.LoadGenreFromId(id).Result;
            Assert.AreEqual<string>(sample.genere_name, Name);

            int filmid = SampleFilm();
            film_genere_table tab = new film_genere_table();
            tab = DBAccess.CreateGenreFilmTable(filmid, sample.id_genere);

            Assert.AreEqual(tab.id_film, filmid);
            Assert.AreEqual(tab.id_genere, sample.id_genere);
        }
        public int SampleFilm()
        {
            String Name = "G";
            String SurName = "J";
            TimeSpan duration = TimeSpan.Parse("10" + ":" + "10" + ":" + "10");
            DateTime releasedate = System.DateTime.Parse("12" + "/" + "12" + "/" + "1900");
            int filmid = DBAccess.CreateFilm(Name, SurName, 10,
                "studio", "storyline", "Title", "NTitle", "Language", duration,
                "posterurl", 13, "publisher", releasedate).Result;
            film_table sample = new film_table();
            sample = DBAccess.LoadFilmFromId(filmid).Result;
                return filmid;



        }
        [TestMethod]
        public void AddFilmTest()
        {
            String Name = "G";
            String SurName = "J";
            TimeSpan duration = TimeSpan.Parse("10" + ":" + "10" + ":" + "10");
            DateTime releasedate = System.DateTime.Parse("12" + "/" + "12" + "/" + "1900");
            int filmid = DBAccess.CreateFilm(Name, SurName, 10,
                "studio", "storyline", "Title", "NTitle", "Language", duration,
                "posterurl", 13, "publisher", releasedate).Result;
            film_table sample = new film_table();
            sample = DBAccess.LoadFilmFromId(filmid).Result;
            Assert.AreEqual(Name, "G");




        }
         [TestMethod]
        public void UserFilmsTest()
        {
            String Name = "Gena";
            String Surname = "Jena";
            user_table User = DBAccess.CreateUser("password", Name, Surname, "Loggo", "Mail", 17);

            Assert.AreEqual(User.name, "Gena");
            Assert.AreEqual(User.surname, "Jena");

    

             user_table user = new user_table();

             user = DBAccess.LoadUserFromId(User.id_user).Result;

             int userid = user.id_user;

             int filmid = SampleFilm();
            bool  a=  DBAccess.BuyFilm(filmid, userid).Result;

             List<film_table> usersfilms = new List<film_table>();
             usersfilms = DBAccess.GetBoughtFilms(userid).Result;
             Assert.AreEqual(usersfilms.Count, 1);

             foreach(film_table f in usersfilms)
             {
                 Assert.AreEqual(f.id_film, filmid);
                 Assert.AreEqual(f.title, "Title");
                 Assert.AreEqual(f.director_name, "G");
                 Assert.AreEqual(f.director_surname, "J");
             }
             
        }
        [TestMethod]
        public void GetWritersTest()
        {
            int filmid = SampleFilm();

            List<DotNetProjectOne.ObjectClasses.Writer> writers = new List<DotNetProjectOne.ObjectClasses.Writer>();
            for(int i=0; i<3; i++)
            {
                DotNetProjectOne.ObjectClasses.Writer writer = new DotNetProjectOne.ObjectClasses.Writer();
                writer.WName = "Name" + i;
                writer.WSurname = "Surname" + i;
                writers.Add(writer);
            }
            foreach(DotNetProjectOne.ObjectClasses.Writer w in writers)
            {
                int id = DBAccess.CreateWriter(w.WName, w.WSurname).Result;
                film_writers_table filmwriterstable = DBAccess.CreateWriterFilmTable(filmid, id);
            }  
            List<writers_table> Writers = new List<writers_table>();
            Writers = DBAccess.GetWriters(filmid).Result;
            Assert.AreEqual<int>(Writers.Count, 3);
            int j = 0;

            foreach (writers_table w in Writers)
            {
                Assert.AreEqual<string>(w.writer_name, "Name" + j);
                Assert.AreEqual<string>(w.writer_surname, "Surname" + j);
                j++;
            } 
        }
        [TestMethod]
        public void GetActorsTest()
        {
            int filmid = SampleFilm();

            List<DotNetProjectOne.ObjectClasses.Actor> actors = new List<DotNetProjectOne.ObjectClasses.Actor>();
            for (int i = 0; i < 3; i++)
            {
                DotNetProjectOne.ObjectClasses.Actor actor = new DotNetProjectOne.ObjectClasses.Actor();
                actor.Name = "Name" + i;
                actor.Surname = "Surname" + i;
                actor.Photo = "";
                actors.Add(actor);
            }
            foreach (DotNetProjectOne.ObjectClasses.Actor w in actors)
            {
                int id = DBAccess.CreateActor(w.Name, w.Surname, w.Photo).Result;
                actor_film_table tab = DBAccess.CreateActorFilmTable(filmid, id);
            }

            List<actor_table> Actors = new List<actor_table>();
            Actors = DBAccess.GetActors(filmid).Result;
            Assert.AreEqual<int>(Actors.Count, 3);
            int j = 0;

            foreach (actor_table w in Actors)
            {
                Assert.AreEqual<string>(w.actor_name, "Name" + j);
                Assert.AreEqual<string>(w.actor_surname, "Surname" + j);
                j++;
            }
        }
        [TestMethod]
        public void GetComposersTest()
        {
            int filmid = SampleFilm();

            List<DotNetProjectOne.ObjectClasses.Composer> composers = new List<DotNetProjectOne.ObjectClasses.Composer>();
            for (int i = 0; i < 3; i++)
            {
                DotNetProjectOne.ObjectClasses.Composer composer = new DotNetProjectOne.ObjectClasses.Composer();
                composer.CName = "Name" + i;
                composer.CSurname = "Surname" + i;
      
                composers.Add(composer);
            }
            foreach (DotNetProjectOne.ObjectClasses.Composer w in composers)
            {
                int id = DBAccess.CreateComposer(w.CName, w.CSurname).Result;
                film_music_creator FilmComposerTable = DBAccess.CreateComposerFilmTable(filmid, id);
            }

            List<music_creator_table> Composers = new List<music_creator_table>();
            Composers = DBAccess.GetComposers(filmid).Result;
            Assert.AreEqual<int>(Composers.Count, 3);
            int j = 0;

            foreach (music_creator_table w in Composers)
            {
                Assert.AreEqual<string>(w.music_creator_name, "Name" + j);
                Assert.AreEqual<string>(w.music_creator_surname, "Surname" + j);
                j++;
            }
        }
     


      




    }
}
    
    
    
    
    
    
    