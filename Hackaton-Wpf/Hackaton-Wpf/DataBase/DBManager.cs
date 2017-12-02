using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Hackaton_Wpf.Conversation.ConversetionAnswers;
using Hackaton_Wpf.Conversation.Shared;
using System.Configuration;
namespace Hackathon
{
    class DBManager
    {

        private static DBManager dbmPointer = null;
        private string filePath;
        private Dictionary<string, string> fileNames = new Dictionary<string, string>();

        public string FilePath { get => filePath; set => filePath = value; }
        public Dictionary<string, string> FileNames { get => fileNames; set => fileNames = value; }

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

            using (var db = new LiteDatabase(filePath))
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
            using (var db = new LiteDatabase(filePath))
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
            using (var db = new LiteDatabase(filePath))
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
        public List<Conversation> GetConversationProfile(string typeOfConversation)
        {
            using (var db = new LiteDatabase(filePath))
            {
                var collection = db.GetCollection<Conversation>("conversationProfile");
                    return collection.Find(c => c.typeOfConversation == typeOfConversation).ToList();
            }
        }
        public List<AnswerOfFirstLevel> GetFirstAnswerProfile(string typeOfConversation)
        {
            using (var db = new LiteDatabase(filePath))
            {
                var collection = db.GetCollection<AnswerOfFirstLevel>("firstAnswerProfile");
                return collection.Find(c => c.typeOfConversation == typeOfConversation).ToList();

            }
        }

        public List<AnswerOfSecondLvl> GetSecondAnswerProfile(string typeOfConversation)
        {
            using (var db = new LiteDatabase(filePath))
            {
                var collection = db.GetCollection<AnswerOfSecondLvl>("firstAnswerProfile");
                return collection.Find(c => c.typeOfConversation == typeOfConversation).ToList();
            }
        }
        public List<AnswerOfThirdLevel> GetThirdAnswerProfile(string typeOfConversation)
        {
                using (var db = new LiteDatabase(filePath))
                {
                    var collection = db.GetCollection<AnswerOfThirdLevel>("firstAnswerProfile");
                    return collection.Find(c => c.typeOfConversation == typeOfConversation).ToList();
                }
        }
        public List<Tag> GetTagProfile()
        {
            using (var db = new LiteDatabase(filePath))
            {
                var collection = db.GetCollection<Tag>("firstAnswerProfile");
                return collection.FindAll().ToList();
            }
        }
        public string GetConversationType()
        {
            using (var db = new LiteDatabase(filePath))
            {
                return db.GetCollection<string>("conversationType").ToString();            
            }
        }
    }
}
