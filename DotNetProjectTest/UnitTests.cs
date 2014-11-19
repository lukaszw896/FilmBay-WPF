using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetProjectOne;
using System.Threading.Tasks;

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
        }
        [TestMethod]
        public void AddLanguageTest()
        {
            String Name = "Name";
            int id = DBAccess.CreateLanguage(Name).Result;
            other_language_table sample = new other_language_table();
            sample = DBAccess.LoadLanguageFromId(id).Result;
            Assert.AreEqual<string>(sample.other_language_name, Name);
        }
        [TestMethod]
        public void AddGenreTest()
        {
            String Name = "Name";
            int id = DBAccess.CreateGenre(Name).Result;
            genere_table sample = new genere_table();
            sample = DBAccess.LoadGenreFromId(id).Result;
            Assert.AreEqual<string>(sample.genere_name, Name);
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
                "posterurl", 13, "publisher", releasedate);
            film_table sample = new film_table();
            sample = DBAccess.LoadFilmFromId(filmid).Result;
            Assert.AreEqual(Name, "G");

        }

    }
}
    
    
    
    
    
    
    