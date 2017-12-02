using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    public class BotProfile
    {
        /// <summary>
        /// Tags for searching e.g. news
        /// </summary>
        public List<string> SearchTags { get; set; }
        /// protectedsummary>
        /// Dictionary of words for autocorrect
        /// </summary>
        public List<string> DictionaryOfWords { get; set; }
    }
}
