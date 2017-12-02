using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Hackaton_Wpf.Conversation.ConversetionAnswers;
using Hackathon;

namespace Hackaton_Wpf.Conversation
{
    public class ConversationMenager : ConversationMenagerInterface
    {
        private DBManager dataBaseMenager;
        private Random rand;

        private List<AnswerOfFirstLevel> firstLvl;
        private List<AnswerOfSecondLvl> secondLvl;
        private List<AnswerOfThirdLevel> thirdLvl;

        public ConversationMenager()
        {
            dataBaseMenager = DBManager.GetInstance;
            rand = new Random();
        }

        /*public ConversetionAnswers.Conversation GetConversation()
        {
            string typeOfConversation =
                dataBaseMenager.GetConversationType()[
                    rand.Next(0, dataBaseMenager.GetConversationType().Count)];

            firstLvl = new List<AnswerOfFirstLevel>(dataBaseMenager.GetFirstAnswerProfile(typeOfConversation));
            secondLvl = new List<AnswerOfSecondLvl>(dataBaseMenager.GetSecondAnswerProfile(typeOfConversation));
            thirdLvl = new List<AnswerOfThirdLevel>(dataBaseMenager.GetThirdAnswerProfile(typeOfConversation));

            ConversetionAnswers.Conversation conversation = dataBaseMenager
                .GetConversationProfile(typeOfConversation)[rand.Next(0, dataBaseMenager.GetConversationProfile(typeOfConversation).Count)];

            if (conversation.answers == null)
                conversation.answers = new List<AnswerOfFirstLevel>();

            for (int i = 0; i < 4; i++)
            {
                var answer = firstLvl[rand.Next(0, firstLvl.Count)];
                firstLvl.Remove(answer);
                answer.reaction = new ReactionToChos("addOrStronger");
                conversation.answers.Add(answer);
            }

            return conversation;
        }*/


        private void addToFirstLvl(AnswerOfFirstLevel firstLvl)
        {
            if(firstLvl.anserws == null)
                firstLvl.anserws = new List<AnswerOfSecondLvl>();
            for (int i = 0; i < 4; i++ )
            {
                var answer = secondLvl[rand.Next(0, secondLvl.Count)];
                secondLvl.Remove(answer);
                addToSecondLvl(answer);
                answer.reaction = new ReactionToChos("addOrStronger");
                firstLvl.anserws.Add(answer);
            }
            
        }

        private void addToSecondLvl(AnswerOfSecondLvl secondLvl)
        {
            if (secondLvl.answers == null)
                secondLvl.answers = new List<AnswerOfThirdLevel>();
            for (int i = 0; i < 4; i++)
            {
                var answer = thirdLvl[rand.Next(0, thirdLvl.Count)];
                thirdLvl.Remove(answer);
                if (rand.Next(0, 100) % 2 != 0)
                {
                    answer.reaction = new ReactionToChos("schowMeme");
                }
                else
                {
                    answer.reaction = new ReactionToChos("schowNews");
                }
            }
        }

       

    }
}