using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetProjectOne.TMDB_Api_helper_classes
{
    class TMDbHelper
    {
        public static List<string> FindString(String start, String end, String input)
        {
            var results = new List<string>();

            string pattern = string.Format(
                "{0}({1}){2}",
                Regex.Escape(start),
                ".+?",
                 Regex.Escape(end));

            foreach (Match m in Regex.Matches(input, pattern))
            {
                results.Add(m.Groups[1].Value);
                Console.WriteLine(m.Groups[1].Value);
            }
            return results;
        }
     
        public static string FindSingleString(String start, String end, String input)
        {
            List<string> results = new List<string>();

            string pattern = string.Format(
                "{0}({1}){2}",
                Regex.Escape(start),
                ".+?",
                 Regex.Escape(end));

            foreach (Match m in Regex.Matches(input, pattern))
            {
                results.Add(m.Groups[1].Value);
                Console.WriteLine(m.Groups[1].Value);
            }
            return results.FirstOrDefault();
        }
        public static List<string> FindStringWithOneUknownWord(String start,String middle, String end, String input)
        {
            var results = new List<string>();

            string pattern = string.Format(
                "{0}{1}{2}({3}){4}",
                Regex.Escape(start),
                "[0-9a-zA-Z]{1,20}",
                Regex.Escape(middle),
                ".+?",
                 Regex.Escape(end));

            foreach (Match m in Regex.Matches(input, pattern))
            {
                results.Add(m.Groups[1].Value);
                Console.WriteLine(m.Groups[1].Value);
            }
            return results;
        }


    }
    public class MovieSearchReturnObject
    {
        public int id { get; set; }
        public string title { get; set; }
        public string releaseDate { get; set; }
        public string posterPath { get; set; }
        public string orginalTitle { get; set; }
        public float popularity { get; set; }
      public   MovieSearchReturnObject(int id, string title, string releaseDate, string posterPath,string orginalTitle,float popularity)
        {
            this.id = id;
            this.title = title;
            this.releaseDate = releaseDate;
            this.posterPath = posterPath;
            this.orginalTitle = orginalTitle;
            this.popularity = popularity;
        }

    }
    public class FoundMovieDetails
    {
        public List<string> genres { get; set; }
        public string storyline { get; set; }

        public string studio { get; set; }
        public int duration { get; set; }
        public List<string> languages { get; set; }
        public string ageRestriction { get; set; }
        public FoundMovieDetails( List<string> genres, string storyline, int duration, List<string> languages ,string ageRestriction, string studio)
        {
            this.genres = genres;
            this.storyline = storyline;
            this.studio = studio;
            this.duration = duration;
            this.languages = languages;
            this.ageRestriction = ageRestriction;
        }
    }
    public class CastInformation
    {
        public List<string> writers { get; set; }
        public List<string> producers { get; set; }
        public List<string> composers { get; set; }

        public CastInformation(List<string> writers, List<string> producers, List<string> composers)
        {
            this.writers = writers;
            this.producers = producers;
            this.composers = composers;
        }
    }
    public class Actor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string photoPath { get; set; }
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

      

}
