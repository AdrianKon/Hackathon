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
            dataBaseMenager = DBManager.GetInstance();
            rand = new Random();
        }

        public ConversetionAnswers.Conversation GetConversation()
        {
            string typeOfConversation =
                dataBaseMenager.GetConversationType()[
                    rand.Next(0, dataBaseMenager.GetConversationType().Count -1 )];

            firstLvl = new List<AnswerOfFirstLevel>(dataBaseMenager.GetFirstAnswerLVL(typeOfConversation));
            secondLvl = new List<AnswerOfSecondLvl>(dataBaseMenager.GetSecondAnswerLVL(typeOfConversation));
            thirdLvl = new List<AnswerOfThirdLevel>(dataBaseMenager.GetThirdAnswerLVL(typeOfConversation));

            ConversetionAnswers.Conversation conversation = dataBaseMenager
                .GetConversation(typeOfConversation)[rand.Next(0, dataBaseMenager.GetConversation(typeOfConversation).Count - 1)];

            if (conversation.answers == null)
                conversation.answers = new List<AnswerOfFirstLevel>();

            for (int i = 0; i < 4; i++)
            {
                var answer = firstLvl[rand.Next(0, firstLvl.Count - 1)];
                //firstLvl.Remove(answer);
                addToFirstLvl(answer);
                conversation.answers.Add(answer);
            }

            return conversation;
        }


        private void addToFirstLvl(AnswerOfFirstLevel firstLvl)
        {
            if(firstLvl.anserws == null)
                firstLvl.anserws = new List<AnswerOfSecondLvl>();
            for (int i = 0; i < 4; i++ )
            {
                var answerList = secondLvl.FindAll(x => x.tagOfQuestion == firstLvl.tagForAnswers);
                if (answerList.Count > 0)
                {
                    var answer = answerList[rand.Next(0, answerList.Count - 1)];
                    //secondLvl.Remove(answer);
                    addToSecondLvl(answer);
                    answer.reaction = new ReactionToChos("addOrStronger");
                    firstLvl.anserws.Add(answer);
                }
            }
            
        }

        private void addToSecondLvl(AnswerOfSecondLvl secondLvl)
        {
            if (secondLvl.answers == null)
                secondLvl.answers = new List<AnswerOfThirdLevel>();
            for (int i = 0; i < 4; i++)
            {
                var answerList = thirdLvl.FindAll(x => x.tagOfQuestion == secondLvl.tagOfAnswers);
                if (answerList.Count > 0)
                {
                    var answer = answerList[rand.Next(0, answerList.Count - 1)];
                    secondLvl.answers.Add(answer);
                    //thirdLvl.Remove(answer);
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
}