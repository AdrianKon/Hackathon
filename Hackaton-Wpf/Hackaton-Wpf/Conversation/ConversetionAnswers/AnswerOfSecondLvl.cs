using System.Collections.Generic;
using System.Windows.Documents;
using Hackaton_Wpf.Conversation.Shared;

namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class AnswerOfSecondLvl
    {
        public string typeOfConversation { get; set; }
        public string tagOfAnswers { get; set; }
        public string tagOfQuestion { get; set; }
        public string botLine { get; set; }
        public string userLine { get; set; }
        public List<Tag> tags { get; set; }
        public List<AnswerOfThirdLevel> answers { get; set; }
        public ReactionToChos reaction { get; set; }
    }
}