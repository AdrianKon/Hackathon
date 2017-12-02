using System.Collections.Generic;

namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class Conversation
    {
        public string typeOfConversation { get; set; }
        public string content { get; set; } 
        public List<AnswerOfFirstLevel> answers { get; set; }



    }
}