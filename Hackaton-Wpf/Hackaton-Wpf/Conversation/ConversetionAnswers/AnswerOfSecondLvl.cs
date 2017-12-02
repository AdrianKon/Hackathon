using System.Collections.Generic;
using System.Windows.Documents;

namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class AnswerOfSecondLvl
    {
        public string typeOfConversation { get; set; }
        public string content { get; set; }
        public List<string> tags { get; set; }
        public ReactionToChos reaction { get; set; }
    }
}