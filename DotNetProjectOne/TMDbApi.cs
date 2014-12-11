using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DotNetProjectOne.TMDB_Api_helper_classes;
using System.Globalization;
namespace DotNetProjectOne
{
    public static class TMDbApi
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
        /*movie details accepts movie id which has been found by movie search function and returns informations such as generes,overview(storyline),
        *production_companies,runtime,spoken languages
         *sample request:http://api.themoviedb.org/3/movie/120?api_key=7b5e30851a9285340e78c201c4e4ab99
        */
        public static FoundMovieDetails movieDetails(int id)
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
            string ageRestriction;
            

            // string title = TMDbHelper.FindSingleString(@"""title"":""", @""",""", responseContent.ToString());
            //"genres":[{"id":28,"name":"Action"}]
            genres = TMDbHelper.FindStringWithOneUknownWord(@"{""id"":", @",""name"":""", @"""}", responseContent.ToString());   
            storyline = TMDbHelper.FindSingleString(@"""overview"":""", @""",""", responseContent.ToString());
            studio = TMDbHelper.FindSingleString(@"""production_companies"":[{""name"":""", @""",""", responseContent.ToString());
            languages= TMDbHelper.FindString(@"""spoken_languages"":[", @"}]", responseContent.ToString());
            duration = TMDbHelper.FindSingleString(@"""runtime"":", @",""", responseContent.ToString());
            ageRestriction = TMDbHelper.FindSingleString(@"""adult"":", @",""", responseContent.ToString());
            if (studio == null) { studio = ""; }
           return new FoundMovieDetails(genres,storyline,int.Parse(duration),languages,ageRestriction,studio);
        }
        public static List<Actor> GetActors(int id)
        {
            var request = System.Net.WebRequest.Create("http://api.themoviedb.org/3/movie/" + id +"/credits?api_key=7b5e30851a9285340e78c201c4e4ab99") as System.Net.HttpWebRequest;
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
            /*character string consists of name and profile pic (which might be null)*/
            List<string> characterStringList = TMDbHelper.FindString(@"""character"":""", @"}", responseContent.ToString());
            List<Actor> actors = new List<Actor>();
            foreach(string characterString in characterStringList)
            {
                Actor a = new Actor();
                String fullname = TMDbHelper.FindSingleString(@"""name"":""", @""",""", characterString);
                String photoPath = TMDbHelper.FindSingleString(@"profile_path"":""", @"""", characterString);
                if(photoPath!="null")
                {
                    if(photoPath!=null)
                    a.photoPath="http://image.tmdb.org/t/p/w500" + photoPath;
                    
                    
                }
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

        public static CastInformation getCast(int id){
            var request = System.Net.WebRequest.Create("http://api.themoviedb.org/3/movie/" + id + "/credits?api_key=7b5e30851a9285340e78c201c4e4ab99") as System.Net.HttpWebRequest;
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

            List<string> writers = new List<string>();
            List<string> producers = new List<string>();
            List<string> composers = new List<string>();
            string director = "";
            writers = TMDbHelper.FindString(@"""Screenplay"",""name"":""", @""",""", responseContent.ToString());
            producers = TMDbHelper.FindString(@"""Producer"",""name"":""", @""",""", responseContent.ToString());
            composers = TMDbHelper.FindString(@"""Original Music Composer"",""name"":""", @""",""", responseContent.ToString());
            director = TMDbHelper.FindSingleString(@"""Director"",""name"":""", @""",""", responseContent.ToString());

            return new CastInformation(writers, producers, composers,director);

        }

        public static List<string> getFilmPictures(int id)
        {
            var request = System.Net.WebRequest.Create("http://api.themoviedb.org/3/movie/" + id + "/images?api_key=7b5e30851a9285340e78c201c4e4ab99") as System.Net.HttpWebRequest;
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
            
            List<string> picturesPaths = new List<string>();
            List<string> picturesRatio = new List<string>();
            List<string> picturesPathsFinal = new List<string>();
            picturesPaths = TMDbHelper.FindString(@"""file_path"":""", @""",""", responseContent.ToString());
            picturesRatio = TMDbHelper.FindString(@"""aspect_ratio"":", @",""", responseContent.ToString());
            for (int i = 0; i < picturesPaths.Count;i++)
            {
                string tmpString = picturesRatio[i].ToString();
                Double tmp = Double.Parse(tmpString, CultureInfo.InvariantCulture);
                if (tmp > 1.2)
                {
                    picturesPathsFinal.Add("http://image.tmdb.org/t/p/w500" + picturesPaths[i]);
                }
                i++;
            }
            return picturesPathsFinal;
            
        }




        

       
      
    }
}
