using System.Collections.Generic;
using System.Windows.Documents;
using Hackaton_Wpf.Conversation.ConversetionAnswers;

namespace Hackaton_Wpf.Conversation.TempClasses
{
    public interface DataBaseMenagerIntrerface
    {
        List<string> getTypesOfConversation();
        List<ConversetionAnswers.Conversation> GetConversations(string typeOfConversation);
        List<AnswerOfFirstLevel> GetAnswersOfFirstLevel(string typeOfConversation);
        List<AnswerOfSecondLvl> GetAnswersOfSecndLevel(string typeOfConversation);
        List<AnswerOfThirdLevel> GetAnswerOfThirdLevels(string typeOfConversation);
    }
}