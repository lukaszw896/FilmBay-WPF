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

            moviesIDs = TMDbHelper.FindString(@"""id"":", @",""", responseContent.ToString());
            moviesTitles = TMDbHelper.FindString(@"""title"":""", @""",""", responseContent.ToString());
            moviesReleaseDate = TMDbHelper.FindString(@"""release_date"":", @",""", responseContent.ToString());
            moviesPosterPath = TMDbHelper.FindString(@"""poster_path"":", @",""", responseContent.ToString());
            
            List<MovieSearchReturnObject> movieSearchResult = new List<MovieSearchReturnObject>();
            for (int i = 0; i < moviesIDs.Count(); i++)
            {
                String tmp = "http://image.tmdb.org/t/p/w500" + moviesPosterPath[i].Substring(1, moviesPosterPath[i].Length - 2);
                MovieSearchReturnObject tmpMovieObj =new  MovieSearchReturnObject(int.Parse(moviesIDs[i]),moviesTitles[i],moviesReleaseDate[i],tmp);
                movieSearchResult.Add(tmpMovieObj);
            }
            return movieSearchResult;
        }
    }
}
