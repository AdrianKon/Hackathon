using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Hackaton_Wpf.Conversation.ConversetionAnswers;
namespace Hackathon
{
    class DBManager
    {

        private static DBManager dbmPointer = null;


        public static DBManager GetInstance
        {
            get
            {
                if (dbmPointer == null)
                {
                    dbmPointer = new DBManager();
                }
                return dbmPointer;
            }
        }
        public void CreateOrUpdateProfile<T>(string fileName,T objectOfProfile)
        {

            using (var db = new LiteDatabase(@"E:\Hackathon\Hackathon\Hackathon\" + fileName + ".db"))
            {
                var collection = db.GetCollection<T>(fileName);
                try
                {
                    collection.Insert(1, objectOfProfile);
                }
                catch
                {
                    ///
                }
            }
        }

        public UserProfile GetUserProfile(string userName)
        {
            UserProfile userProfile = new UserProfile(userName);
            using (var db = new LiteDatabase(@"E:\Hackathon\Hackathon\Hackathon\UserProfile.db"))
            {
                var collection = db.GetCollection<UserProfile>("userProfile");
                try
                {
                    userProfile = collection.FindById(1);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return userProfile;
        }

        public BotProfile GetBotProfile()
        {
            BotProfile botProfile = new BotProfile();
            using (var db = new LiteDatabase(@"E:\Hackathon\Hackathon\Hackathon\BotProfile.db"))
            {
                var collection = db.GetCollection<BotProfile>("botProfile");
                try
                {
                    botProfile = collection.FindById(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return botProfile;
        }
        public Conversation GetConversationProfile()
        {
            Conversation conversationProfile = new Conversation();
            using (var db = new LiteDatabase(@"E:\Hackathon\Hackathon\Hackathon\ConversationProfile.db"))
            {
                var collection = db.GetCollection<Conversation>("conversationProfile");
                try
                {
                    conversationProfile = collection.FindById(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return conversationProfile;
        }
        public AnswerOfFirstLevel GetFirstAnswerProfile()
        {
            AnswerOfFirstLevel answerOfFirstLevel = new AnswerOfFirstLevel();
            using (var db = new LiteDatabase(@"E:\Hackathon\Hackathon\Hackathon\FirstAnswerProfile.db"))
            {
                var collection = db.GetCollection<AnswerOfFirstLevel>("firstAnswerProfile");
                try
                {
                    answerOfFirstLevel = collection.FindById(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return answerOfFirstLevel;
        }

        public AnswerOfSecondLvl GetSecondAnswerProfile()
        {
            AnswerOfSecondLvl answerOfSecondLevel = new AnswerOfSecondLvl();
            using (var db = new LiteDatabase(@"E:\Hackathon\Hackathon\Hackathon\FirstAnswerProfile.db"))
            {
                var collection = db.GetCollection<AnswerOfSecondLvl>("firstAnswerProfile");
                try
                {
                    answerOfSecondLevel = collection.FindById(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return answerOfSecondLevel;
        }

        public AnswerOfThirdLevel GetThirdAnswerProfile()
        {
            AnswerOfThirdLevel answerOfThirdLevel = new AnswerOfThirdLevel();
            using (var db = new LiteDatabase(@"E:\Hackathon\Hackathon\Hackathon\FirstAnswerProfile.db"))
            {
                var collection = db.GetCollection<AnswerOfThirdLevel>("firstAnswerProfile");
                try
                {
                    answerOfThirdLevel = collection.FindById(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return answerOfThirdLevel;
        }
    }
}
