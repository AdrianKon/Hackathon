using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackaton_Wpf.Conversation.ConversetionAnswers;
using Hackaton_Wpf.Conversation.Shared;
namespace Hackathon
{
    public class UserProfile
    {

        public string Username { get; set; }
        public string Longi { get; set; }
        public string Lati { get; set; }

        /// <summary>
        /// Tags for searching e.g. news
        /// </summary>
        public List<Tag> SearchTags { get; set; }
        /// protectedsummary>
        /// Dictionary of words for autocorrect
        /// </summary>
        public List<string> DictionaryOfWords { get; set; }


        public UserProfile(string userName)
        {
            this.Username = userName;
            SearchTags = new List<Tag>();
            DictionaryOfWords = new List<string>();
        }

        public UserProfile()
        {
            try
            {
                SearchTags = new List<Tag>();
                ReadConfigFromFile();
            }
            catch (Exception e)
            {
              
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"userProfile.cfg"))
                {
                    file.WriteLine("newUser");
                    file.WriteLine("16.851780");
                    file.WriteLine("51.127209");
                    file.WriteLine("Sport:2");
                    file.WriteLine("Trump:10");
                    file.WriteLine("Poland:3");
                    file.Close();
                }
                ReadConfigFromFile();
            }
            

        }

        private void ReadConfigFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"userProfile.cfg");
            Username = lines[0];
            Longi = lines[1];
            Lati = lines[2];
            for (int i = 3; i < lines.Length; i++)
            {
                var line = lines[i].Split(':');
                SearchTags.Add(new Tag(line[0], line[1]));

            }
        }
    }
}
