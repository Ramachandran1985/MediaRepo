using System.Collections.Generic;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MediaRepo.Models;

namespace MediaRepo.Controllers
{
    public class VideoController : Controller
    {
        public ActionResult Search()
        {
            ViewBag.Title = "SearchVideo";
            return View();
        }
        
        public ActionResult GetVideo()
        {
            var searchText = Request["SearchText"];
            ViewBag.Title = "GetVideo";

            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyCI2UDParSTfUFs48x7mZFLP8D-nNq1Lvo",
                ApplicationName = GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchText; 
            searchListRequest.MaxResults = 50;

            var searchListResponse = searchListRequest.Execute();

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();

            List<Video> videolists = new List<Video>();
            ListOfLists listofList = new ListOfLists();
            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add($"{searchResult.Snippet.Title} ({searchResult.Id.VideoId})");
                        Video videoObj = new Video()
                        {
                            Id = searchResult.Id.VideoId,
                            ETag = searchResult.Id.ETag,
                            Kind = searchResult.Id.Kind,
                            SourceUrl = "http://www.youtube.com/embed/" + searchResult.Id.VideoId,
                        };
                        if(videolists.Count <= 2)
                         videolists.Add(videoObj);
                        else
                        {

                            listofList.ListOfList.Add(videolists);
                            videolists = new List<Video>();
                            videolists.Add(videoObj);                            
                        }
                        break;

                    case "youtube#channel":
                        channels.Add($"{searchResult.Snippet.Title} ({searchResult.Id.ChannelId})");
                        break;

                    case "youtube#playlist":
                        playlists.Add($"{searchResult.Snippet.Title} ({searchResult.Id.PlaylistId})");
                        break;
                }
            }
            return View(listofList);
        }
    }
}