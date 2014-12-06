using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DotNetProjectOne.TMDB_Api_helper_classes;
namespace DotNetProjectOne
{
    class TMDbApi
    {
        //method for searching movies by title in TMDb database
        public static List<MovieSearchReturnObject> movieSearch(String title)
        {
            var request = System.Net.WebRequest.Create("http://api.themoviedb.org/3/search/movie?api_key=7b5e30851a9285340e78c201c4e4ab99&query="+title) as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentLength = 0;
            string responseContent=null;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse) {
            using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                 responseContent = reader.ReadToEnd();
                 }
            }
            List<string> moviesIDs;
            List<string> moviesTitles;
            List<string> moviesReleaseDate;
            List<string> moviesPosterPath;
            List<string> moviesOrginalTitle;
            List<string> moviesPopularity;

            moviesIDs = TMDbHelper.FindString(@"""id"":", @",""", responseContent.ToString());
     

            moviesTitles = TMDbHelper.FindString(@"""title"":""", @""",""", responseContent.ToString());
            moviesReleaseDate = TMDbHelper.FindString(@"""release_date"":", @",""", responseContent.ToString());
            moviesPosterPath = TMDbHelper.FindString(@"""poster_path"":", @",""", responseContent.ToString());
            //"original_title":"The Avengers"
            moviesOrginalTitle = TMDbHelper.FindString(@"""original_title"":", @",""", responseContent.ToString());
            moviesPopularity = TMDbHelper.FindString(@"""popularity"":", @",""", responseContent.ToString());
            List<MovieSearchReturnObject> movieSearchResult = new List<MovieSearchReturnObject>();
            for (int i = 0; i < moviesIDs.Count(); i++)
            {
                String posterPath = "http://image.tmdb.org/t/p/w500" + moviesPosterPath[i].Substring(1, moviesPosterPath[i].Length - 2);
                float popularity = float.Parse(moviesPopularity[i], System.Globalization.CultureInfo.InvariantCulture);
                MovieSearchReturnObject tmpMovieObj =new  MovieSearchReturnObject(int.Parse(moviesIDs[i]),moviesTitles[i],moviesReleaseDate[i],posterPath,moviesOrginalTitle[i],popularity);
                movieSearchResult.Add(tmpMovieObj);
            }
            return movieSearchResult;


        }
        public static List<string> MovieObject(int id)
        {
            var request = System.Net.WebRequest.Create("http://api.themoviedb.org/3/movie/"+id+"?api_key=7b5e30851a9285340e78c201c4e4ab99") as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentLength = 0;
            string responseContent=null;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse) {
            using (var reader = new System.IO.StreamReader(response.GetResponseStream())) {
                 responseContent = reader.ReadToEnd();
                 }
            }
  
            List<string> genres;
            string storyline;
            string studio;
            List<string> languages;
            string duration;

         string title = TMDbHelper.FindSingleString(@"""title"":""", @""",""", responseContent.ToString());
                                 //"genres":[{"id":28,"name":"Action"}]
            genres = TMDbHelper.FindString(@"""name"":""", @"""", responseContent.ToString());
           
           storyline = TMDbHelper.FindSingleString(@"""overview"":""", @""",""", responseContent.ToString());
           studio = TMDbHelper.FindSingleString(@"""production_companies"":""", @""",""", responseContent.ToString());
           languages= TMDbHelper.FindString(@"""spoken_languages"":""", @""",""", responseContent.ToString());

            duration = TMDbHelper.FindSingleString(@"""runtime"":", @",""", responseContent.ToString());
 
           return genres;
        }
        public static List<DotNetProjectOne.ObjectClasses.Actor> GetCast(int id)
        {
            var request = System.Net.WebRequest.Create("http://api.themoviedb.org/3/movie/" + id +"/credits"+"?api_key=7b5e30851a9285340e78c201c4e4ab99") as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "GET";
            request.Accept = "application/json";
            request.ContentLength = 0;
            string responseContent = null;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                }
            }
            List<string> fullnames = TMDbHelper.FindString(@"""name"":""", @"""", responseContent.ToString());
            List<DotNetProjectOne.ObjectClasses.Actor> actors = new List<DotNetProjectOne.ObjectClasses.Actor>();
            foreach(string fullname in fullnames)
            {
                DotNetProjectOne.ObjectClasses.Actor a = new DotNetProjectOne.ObjectClasses.Actor();
                String[] split = fullname.Split(' ');
                string name = split[0];
                string surname = "";
                if(split.Count()>=2)
                 surname = split[1];
                a.Name = name;
                a.Surname = surname;
                actors.Add(a);
            }
            return actors;

        }
   

    }
}
