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
        private  string filePath = @"\Resources";
        private  string filename = @"database.db";
        private string fullDirectory = @"\Resources" + @"\database.db";
        private Dictionary<string, string> filenames;
        private UserProfile user;
        private BotProfile bot;


        private List<string> typeOfConverastionCollections; 
        private List<Conversation> conversationCollection; 
        private List<AnswerOfFirstLevel> firstLvlCollection;
        private List<AnswerOfSecondLvl> secondLvlAnswers;
        private List<AnswerOfThirdLevel> thirdLvlAnswers; 

        //public string FilePath { get => filePath; set => filePath = value; }
        public Dictionary<string, string> Filenames { get => filenames; set => filenames = value; }

        public DBManager()
        {
            CreateDB();
        }
        

        public static DBManager GetInstance()
        {
                if (dbmPointer == null)
                {
                    dbmPointer = new DBManager();
                }
                return dbmPointer;
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
                        el.strength++;
                    }
                    else
                    {
                        user.SearchTags.Add(element);
                    }
                }
            }
        }

        public void softenTagForUser(Tag tag)
        {
            user.SearchTags.Find(x => x.name == tag.name).strength--;
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

        public List<Conversation> GetConversation(string typeOfConversation)
        {
            return conversationCollection.FindAll(c => c.typeOfConversation == typeOfConversation).ToList();
        }

        public List<AnswerOfFirstLevel> GetFirstAnswerLVL(string typeOfConversation)
        {
            return firstLvlCollection.FindAll(c => c.typeOfConversation == typeOfConversation).ToList();
        }

        public List<AnswerOfSecondLvl> GetSecondAnswerLVL(string typeOfConversation)
        {
                return secondLvlAnswers.FindAll(c => c.typeOfConversation == typeOfConversation).ToList();
        }

        public List<AnswerOfThirdLevel> GetThirdAnswerLVL(string typeOfConversation)
        {
            return thirdLvlAnswers.FindAll(c => c.typeOfConversation == typeOfConversation).ToList();
        }

        public List<string> GetConversationType()
        {
             return typeOfConverastionCollections.ToList();

        }
           
        private void CreateDB()
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
            

            typeOfConverastionCollections = new List<string>();
            conversationCollection = new List<Conversation>();
            firstLvlCollection = new List<AnswerOfFirstLevel>();
            secondLvlAnswers = new List<AnswerOfSecondLvl>();
            thirdLvlAnswers = new List<AnswerOfThirdLevel>();

            //TypeOfConversations
            
            typeOfConverastionCollections.Add("Jak minal dzien");
            typeOfConverastionCollections.Add("Jak ci sie pracowalo");

            //Add Conversation
            
            conversationCollection.Add(new Conversation {typeOfConversation = "Jak minal dzien", botLine = "Jak Ci minal dzien " + user.Username + "?"});
            conversationCollection.Add(new Conversation { typeOfConversation = "Jak ci sie pracowalo", botLine = "Jak tam w pracy " + user.Username + "?" });

                //Add FirstLvLAnswers To Jak minal dzien
            
                firstLvlCollection.Add(new AnswerOfFirstLevel
                {
                    typeOfConversation = "Jak minal dzien",
                    tagForAnswers = "dobrze",
                    userLine = "Calkiem niezle"
                });
                firstLvlCollection.Add(new AnswerOfFirstLevel
                {
                    typeOfConversation = "Jak minal dzien",
                    tagForAnswers = "srednio",
                    userLine = "Srednio"
                });
                firstLvlCollection.Add(new AnswerOfFirstLevel
                {
                    typeOfConversation = "Jak minal dzien",
                    tagForAnswers = "zle",
                    userLine = "Zle"
                });
                firstLvlCollection.Add(new AnswerOfFirstLevel
                {
                    typeOfConversation = "Jak minal dzien",
                    tagForAnswers = "najgorszy",
                    userLine = "Najgorszy dzien jaki mialem"
                });

                    //add SecondLvLAnswers for dobrze

                    secondLvlAnswers.Add(new AnswerOfSecondLvl
                    {
                        tagOfQuestion = "dobrze",
                        typeOfConversation = "Jak minal dzien",
                        botLine = "Milo to slyszec :) A co ci sie przytrafilo?",
                        userLine = "Mile spotkanie z przyjaciolmi",
                        tags = new List<Tag>
                        {
                            new Tag
                            {
                                name = "events",
                                strength = 0
                            }
                        },
                        tagOfAnswers = "dobrzeDzien"
                    });
                    secondLvlAnswers.Add(new AnswerOfSecondLvl
                    {
                        tagOfQuestion = "dobrze",
                        typeOfConversation = "Jak minal dzien",
                        botLine = "Milo to slyszec :) A co ci sie przytrafilo?",
                        userLine = "Mialem dobry obiad z miesem",
                        tags = new List<Tag>
                        {
                            new Tag
                            {
                                name = "meat",
                                strength = 0
                            },
                            new Tag
                            {
                                name = "food",
                                strength = 0
                            }
                        },
                        tagOfAnswers = "dobrzeDzien"
                    });
                    secondLvlAnswers.Add(new AnswerOfSecondLvl
                    {
                        tagOfQuestion = "dobrze",
                        typeOfConversation = "Jak minal dzien",
                        botLine = "Milo to slyszec :) A co ci sie przytrafilo?",
                        userLine = "Dobrze mi minal dzien w pracy",
                        tags = new List<Tag>
                        {
                            new Tag
                            {
                                name = "work",
                                strength = 0
                            }
                        },
                        tagOfAnswers = "dobrzeDzien"
                    });
                    secondLvlAnswers.Add(new AnswerOfSecondLvl
                    {
                        tagOfQuestion = "dobrze",
                        typeOfConversation = "Jak minal dzien",
                        botLine = "Milo to slyszec :) A co ci sie przytrafilo?",
                        userLine = "Byla ladna pogoda",
                        tags = new List<Tag>
                        {
                            new Tag
                            {
                                name = "weather",
                                strength = 0
                            }
                        },
                        tagOfAnswers = "dobrzeDzien"
                    });
                    secondLvlAnswers.Add(new AnswerOfSecondLvl
                    {
                        tagOfQuestion = "dobrze",
                        typeOfConversation = "Jak minal dzien",
                        botLine = "Milo to slyszec :) A co ci sie przytrafilo?",
                        userLine = "Nie bylo korkow na miescie",
                        tags = new List<Tag>
                        {
                            new Tag
                            {
                                name = "traffic",
                                strength = 0
                            }
                        },
                        tagOfAnswers = "dobrzeDzien"
                    });
                    secondLvlAnswers.Add(new AnswerOfSecondLvl
                    {
                        tagOfQuestion = "dobrze",
                        typeOfConversation = "Jak minal dzien",
                        botLine = "Milo to slyszec :) A co ci sie przytrafilo?",
                        userLine = "A jakos tak milo przelecial",
                        tags = new List<Tag>
                        {
                            new Tag
                            {
                                name = "good day",
                                strength = 0
                            }
                        },
                        tagOfAnswers = "dobrzeDzien"
                    });

                        //add thirdLvlAnswer For dobrze
                        thirdLvlAnswers.Add(new AnswerOfThirdLevel
                        {
                            typeOfConversation = "Jak minal dzien",
                            tagOfQuestion = "dobrzeDzien",
                            botLine = "Super :) Skoro ci sie to spodobalo to moze zainteresuje cie to: "
                        });

                        thirdLvlAnswers.Add(new AnswerOfThirdLevel
                        {
                            typeOfConversation = "Jak minal dzien",
                            tagOfQuestion = "dobrzeDzien",
                            botLine = "Milo Slyszec :) Skoro ci sie to spodobalo to moze zainteresuje cie to: "
                        });

            //add secondLvlAnswers for srednio

            secondLvlAnswers.Add(new AnswerOfSecondLvl
                    {
                        tagOfQuestion = "srednio",
                        typeOfConversation = "Jak minal dzien",
                        botLine = "Ale chyba nie bylo tak zle?",
                        userLine = "Mozna przezyc",
                        tags = new List<Tag>
                        {
                            new Tag
                            {
                                name = "asd",
                                strength = 0
                            }
                        },
                        tagOfAnswers = "dobrzeDzien"
                    });
            
        }
    }
}
