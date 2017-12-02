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

        public string UserName { get; set; } 

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
            UserName = userName;
            SearchTags = new List<Tag>();
            DictionaryOfWords = new List<string>();
        }
    }
}
