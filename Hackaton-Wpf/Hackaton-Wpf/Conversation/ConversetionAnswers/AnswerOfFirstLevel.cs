using System.Collections.Generic;
using System.Windows.Documents;

namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class AnswerOfFirstLevel
    {
        public string typeOfConversation { get; set; }
        public List<string> tags { get; set; }
        public string content { get; set; }
        public List<AnswerOfSecondLvl> anserws { get; set; }
        public ReactionToChos reaction { get; set; }




    }
}