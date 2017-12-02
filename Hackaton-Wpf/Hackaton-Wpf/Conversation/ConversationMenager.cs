using System;
using System.Collections.Generic;
using System.Windows.Documents;
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

            List<AnswerOfFirstLevel> firstLvl = new List<AnswerOfFirstLevel>(dataBaseMenager.GetAnswersOfFirstLevel(typeOfConversation));
            List<AnswerOfSecondLvl> secondLvl = new List<AnswerOfSecondLvl>(dataBaseMenager.GetAnswersOfSecndLevel(typeOfConversation));
            List<AnswerOfThirdLevel> thirdLvl = new List<AnswerOfThirdLevel>(dataBaseMenager.GetAnswerOfThirdLevels(typeOfConversation));

            ConversetionAnswers.Conversation conversation = dataBaseMenager
                .GetConversations(typeOfConversation)[rand.Next(0, dataBaseMenager.GetConversations(typeOfConversation).Count)];

            if (conversation.answers == null)
                conversation.answers = new List<AnswerOfFirstLevel>();

            for (int i = 0; i < 4; i++)
            {
                conversation.answers.Add(
                        firstLvl[rand.Next(0, firstLvl.Count)].
                    );
            }
            



            return conversation;
        }

        private AnswerOfFirstLevel addToFirstLvl(AnswerOfFirstLevel firstLvl)
        {
            return firstLvl;
        }

        private AnswerOfSecondLvl addToSecondLvl(AnswerOfSecondLvl secondLvl)
        {
            return secondLvl;
        }

       

    }
}