using System.Collections.Generic;
using System.IO;
using Hackathon;
using Hackaton_Wpf;
using Hackaton_Wpf.Conversation.Shared;


namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class ReactionToChos
    {
        public string raction { get; set; }
        private DBManager dbMenager;

        public ReactionToChos(string raction)
        {
            this.raction = raction;
            dbMenager = DBManager.GetInstance();
        }

        public void react( List<Tag> tags)
        {
            
            switch (raction)
            {
                case "addOrStronger":
                    addOrStronger(tags);
                    break;
                case "showNews":
                    break;
                case "schowMeme":
                    break;
            }
        }

        private void addOrStronger(List<Tag> tags)
        {
           dbMenager.CreateOrUpdateUserProfile(tags);
        }

        private void showNews(List<Tag> tags)
        {
            //TO DO
        }


        private void showMeme(List<Tag> tags)
        {
            //TO DO
        }
    }
}