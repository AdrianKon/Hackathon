using System;
using System.Collections.Generic;

namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class Conversation
    {
        public string typeOfConversation { get; set; }
        public string botLine { get; set; } 
        public List<AnswerOfFirstLevel> answers { get; set; }

        public static implicit operator Conversation(List<Conversation> v)
        {
            throw new NotImplementedException();
        }
    }
}