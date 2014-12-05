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
    }
    public class MovieSearchReturnObject
    {
        public int id { get; set; }
        public string title { get; set; }
        public string releaseDate { get; set; }
        public string posterPath { get; set; }
      public   MovieSearchReturnObject(int id, string title, string releaseDate, string posterPath)
        {
            this.id = id;
            this.title = title;
            this.releaseDate = releaseDate;
            this.posterPath = posterPath; 
        }
    }
}
