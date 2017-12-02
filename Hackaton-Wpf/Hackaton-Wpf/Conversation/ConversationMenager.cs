using System;
using Hackaton_Wpf.Conversation.ConversetionAnswers;
using Hackaton_Wpf.Conversation.TempClasses;

namespace Hackaton_Wpf.Conversation
{
    public class ConversationMenager : ConversationMenagerInterface
    {
        private DataBaseMenagerIntrerface dataBaseMenager;
        private Random rand;
        public ConversationMenager()
        {
            dataBaseMenager = new DataBaseMenager();
            rand = new Random();
        }

        public ConversetionAnswers.Conversation GetConversation()
        {
            string typeOfConversation =
                dataBaseMenager.getTypesOfConversation()[
                    rand.Next(0, dataBaseMenager.getTypesOfConversation().Count)];

            ConversetionAnswers.Conversation conversation = dataBaseMenager.GetConversations(typeOfConversation)[rand.Next(0, dataBaseMenager.GetConversations(typeOfConversation).Count)];

            return null;
        }
    }
}