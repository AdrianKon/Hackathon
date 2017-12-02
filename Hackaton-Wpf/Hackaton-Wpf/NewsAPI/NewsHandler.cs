using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Hackaton_Wpf.Conversation.Shared;
using System.Linq;

/*
 *USER MANUAL
 *
 * 1)Create object passing list of tags (or empty list if you want get newest newses).
 * 2)Use GetNews to get top news or pass index to get specific news
 */
namespace Hackaton_Wpf
{
    class NewsHandler
    {
        private NewsRequest NewsRequest { get; set; }
        private List<Tag> TagList { get; set; }

        public NewsHandler(List<Tag> tags)
        {
            NewsRequest = new NewsRequest(); 
            TagList = tags.OrderBy(o => o.strength).ToList();
            var tagIterator = 0;
            while(NewsRequest.Articles.Count == 0 && tagIterator < tags.Count && TagList.Count != 0) //not allow empty raction list /indexoor exc.
            {
                NewsRequest = DeserializeJson(GetJsonByTag(TagList[tagIterator].name));
                tagIterator++;
            }
            
            if(NewsRequest.Articles.Count == 0)
            {
                NewsRequest = DeserializeJson(GetJson());
            }
        }

        private string GetJsonByTag(string tag)
        {
            var url = "http://newsapi.org/v2/top-headlines?" 
                      + "q="+tag+"&" +
                      "language=en&"+
                      "sortBy=popularity&" +
                      "apiKey=ba758fcc7781498a9fac390ce837a3f6";
            var json = new WebClient().DownloadString(url);
            return json;
        }

         private string GetJson()
        {
            var url = "http://newsapi.org/v2/top-headlines?" +
                      "language=en&" +
                      "sortBy=popularity&" +
                      "apiKey=ba758fcc7781498a9fac390ce837a3f6";
            var json = new WebClient().DownloadString(url);
            return json;
        }

        private NewsRequest DeserializeJson(string json)
        {
            var newsRequest = JsonConvert.DeserializeObject<NewsRequest>(json);
            return newsRequest;
        }

        public News GetNews(int index = 0)
        {
            if(index < NewsRequest.Articles.Count)
                return NewsRequest.Articles[index];
            return NewsRequest.Articles[0];
    
        }
    }
}