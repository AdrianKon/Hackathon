using Hackaton_Wpf;

class NewsHandler
{
    public NewsRequest NewsRequest { get; set; }

    public NewsHandler(string tag)
    {
        
    }

    public string GetJson(string tag)
    {
        var url = "http://newsapi.org/v2/top-headlines?" +
            + 
        var json = ; //TODO

        return json;
    }

    public NewsRequest DeserializeJson(string json)
    {
        
    }
}