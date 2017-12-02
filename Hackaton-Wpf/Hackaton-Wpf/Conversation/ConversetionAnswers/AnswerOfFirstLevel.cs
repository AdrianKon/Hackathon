using System.Collections.Generic;
using System.Windows.Documents;

namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class AnswerOfFirstLevel
    {
        public string typeOfConversation { get; set; }
        public string tagForAnswers { get; set; }
        public string userLine { get; set; }
        public List<AnswerOfSecondLvl> anserws { get; set; }
    }
}