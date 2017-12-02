using System;
using System.Collections.Generic;
using System.Windows.Documents;
using Hackaton_Wpf.Conversation.ConversetionAnswers;
using Hackathon;
using Hackaton_Wpf.Conversation.Shared;

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
                var answer = firstLvl[i];
                //firstLvlLocal.Remove(answer);
                addToFirstLvl(answer);
                conversation.answers.Add(answer);
            }

            return conversation;
        }


        private void addToFirstLvl(AnswerOfFirstLevel firstLvlLocal)
        {
            if(firstLvlLocal.anserws == null)
                firstLvlLocal.anserws = new List<AnswerOfSecondLvl>();
            var answerList = secondLvl.FindAll(x => x.tagOfQuestion == firstLvlLocal.tagForAnswers);

            for (int i = 0; i < 4; i++ )
            {
                
                if (answerList.Count > 0)
                {
                    var answer = answerList[rand.Next(0, answerList.Count - 1)];
                    //secondLvlLocal.Remove(answer);
                    addToSecondLvl(answer);
                    answer.reaction = new ReactionToChos("addOrStronger");
                    if(!firstLvlLocal.anserws.Contains(answer))
                    firstLvlLocal.anserws.Add(answer);
                }
            }
            
        }

        private void addToSecondLvl(AnswerOfSecondLvl secondLvlLocal)
        {
            if (secondLvlLocal.answers == null)
                secondLvlLocal.answers = new List<AnswerOfThirdLevel>();
            var answerList = thirdLvl.FindAll(x => x.tagOfQuestion == secondLvlLocal.tagOfAnswers);
            for (int i = 0; i < 4; i++)
            {
                if (answerList.Count > 0)
                {
                    var answer = answerList[rand.Next(0, answerList.Count - 1)];
                    answer.tags = new List<Tag>(secondLvlLocal.tags);
                    if(!secondLvlLocal.answers.Contains(answer))
                    secondLvlLocal.answers.Add(answer);
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