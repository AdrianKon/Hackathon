namespace Hackaton_Wpf.Conversation.Shared
{
    public class Tag
    {
        public string name { get; set; }
        public int strength { get; set; }

        public Tag(string iname, string istrength)
        {
            name = iname;
            int.TryParse(istrength, out var tmpStrength);
            strength = tmpStrength;
        }

        public Tag()
        {
        }
    }
}