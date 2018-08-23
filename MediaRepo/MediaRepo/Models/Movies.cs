using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaRepo.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Season { get; set; }
        public string TotalSeasons { get; set; }
        public List<Episode> Episodes { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public string Response { get; set; }
    }

    public class Episode
    {
        public string Title { get; set; }
        public string Released { get; set; }
        public string EpisodeNum { get; set; }
        public string imdbRating { get; set; }
        public string imdbID { get; set; }
    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }

    public class SearchMedia
    {
        public string SearchText { get; set; }
    }

    public class Video
    {
        public string Id { get; set; }
        public string Kind { get; set; }
        public string ETag { get; set; }
        public string Snippet { get; set; }
        public string SourceUrl { get; set; }
    }

    public class Snippet
    {
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        public string Description { get; set; }
        public string LiveBroadcastContent { get; set; }
        public string PublishedAtRaw { get; set; }
        public string PublishedAt { get; set; }
        public string Thumbnails { get; set; }
        public string Title { get; set; }
        public string ETag { get; set; }

    }

    public class ListOfLists
    {
        private List<List<Video>> listOfList;
        public ListOfLists()
        {
            listOfList = new List<List<Video>>();
        }

        public List<List<Video>> ListOfList
        {
            get{return listOfList;}
            set{listOfList = value;}
        } 
    }
}