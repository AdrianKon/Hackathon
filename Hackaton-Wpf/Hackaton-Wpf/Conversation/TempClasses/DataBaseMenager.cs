using System.Collections.Generic;
using Hackaton_Wpf.Conversation.ConversetionAnswers;

namespace Hackaton_Wpf.Conversation.TempClasses
{
    public class DataBaseMenager : DataBaseMenagerIntrerface
    {
        public List<string> getTypesOfConversation()
        {
            throw new System.NotImplementedException();
        }

        public List<ConversetionAnswers.Conversation> GetConversations(string typeOfConversation)
        {
            throw new System.NotImplementedException();
        }

        public List<AnswerOfFirstLevel> GetAnswersOfFirstLevel(string typeOfConversation)
        {
            throw new System.NotImplementedException();
        }

        public List<AnswerOfSecondLvl> GetAnswersOfSecndLevel(string typeOfConversation)
        {
            throw new System.NotImplementedException();
        }

        public List<AnswerOfThirdLevel> GetAnswerOfThirdLevels(string typeOfConversation)
        {
            throw new System.NotImplementedException();
        }
    }
}