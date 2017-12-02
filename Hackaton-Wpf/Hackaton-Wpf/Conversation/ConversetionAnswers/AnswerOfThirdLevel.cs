using System.Collections.Generic;
using Hackaton_Wpf.Conversation.Shared;

namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class AnswerOfThirdLevel
    {
        public string typeOfConversation { get; set; }
        public string tagOfQuestion { get; set; }
        public string botLine { get; set; }
        public List<Tag> tags { get; set; }
        public ReactionToChos reaction { get; set; }
    }
}