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
        private LiteDatabase liteDB;
        private static DBManager dbmPointer;
        private string filePath;
        private Dictionary<string, string> fileNames;
        private UserProfile user;
        private BotProfile bot;

        public string FilePath { get => filePath; set => filePath = value; }
        public Dictionary<string, string> FileNames { get => fileNames; set => fileNames = value; }

        public DBManager()
        {
            if (System.IO.File.Exists(filePath))
            {
                liteDB = new LiteDatabase(filePath);
            }
            else
            {
                liteDB = CreateDB();
            }

            fileNames = new Dictionary<string, string>();
        }
        

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

        public void CreateOrUpdateUserProfile(List<Tag> tags)
        {
            if (user == null)
            {
                user = new UserProfile("Janek");
                user.SearchTags = new List<Tag>(tags);
            }
            else
            {
                foreach (var element in tags)
                {
                    var el = user.SearchTags.Find(x => x.name == element.name);
                    if (el != null)
                    {
                        el.strength = element.strength;
                    }
                    else
                    {
                        user.SearchTags.Add(element);
                    }
                }
            }
        }

        public void CreateOrUpdateBotProfile()
        {
            if (bot == null)
            {
                bot = new BotProfile();
            }
        }

        public UserProfile GetUserProfile()
        {
            return user;
        }

        public BotProfile GetBotProfile()
        {
            return bot;               
        }

        public List<Conversation> GetConversationProfile(string typeOfConversation)
        {
            var collection = liteDB.GetCollection<Conversation>("conversationProfile");
            return collection.Find(c => c.typeOfConversation == typeOfConversation).ToList();
        }

        public List<AnswerOfFirstLevel> GetFirstAnswerProfile(string typeOfConversation)
        {
            var collection = liteDB.GetCollection<AnswerOfFirstLevel>("firstAnswerProfile");
            return collection.Find(c => c.typeOfConversation == typeOfConversation).ToList();
        }

        public List<AnswerOfSecondLvl> GetSecondAnswerProfile(string typeOfConversation)
        {
                var collection = liteDB.GetCollection<AnswerOfSecondLvl>("firstAnswerProfile");
                return collection.Find(c => c.typeOfConversation == typeOfConversation).ToList();
        }

        public List<AnswerOfThirdLevel> GetThirdAnswerProfile(string typeOfConversation)
        {
            var collection = liteDB.GetCollection<AnswerOfThirdLevel>("firstAnswerProfile");
            return collection.Find(c => c.typeOfConversation == typeOfConversation).ToList();
        }

        public List<Tag> GetTagProfile()
        {
             var collection = liteDB.GetCollection<Tag>("firstAnswerProfile");
             return collection.FindAll().ToList();
        }

        public List<string> GetConversationType()
        {

             var collection = liteDB.GetCollection<string>("conversationType");
             return collection.FindAll().ToList();

        }
           
        private LiteDatabase CreateDB()
        {
            CreateOrUpdateUserProfile(new List<Tag>()
            {
                new Tag(){name="memes", strength = 0 },
                new Tag(){name="hack", strength = 0 },
                new Tag(){name="it", strength = 0 },
                new Tag(){name="git", strength = 0 },
                new Tag(){name="troll", strength = 0 },
                new Tag(){name="bot", strength = 0 },
                new Tag(){name="ten", strength = 0 }
            });

            CreateOrUpdateBotProfile();

            var dataBase = new LiteDatabase(filePath);

            return dataBase;
        }
    }
}
