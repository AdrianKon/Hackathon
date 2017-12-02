using System.IO;
using Hackathon;
using Hackaton_Wpf;


namespace Hackaton_Wpf.Conversation.ConversetionAnswers
{
    public class ReactionToChos
    {
        public string tag { get; set; }
        private DBManager dbMenager;

        public ReactionToChos(string tag)
        {
            this.tag = tag;
            dbMenager = DBManager.GetInstance;
        }

        public void react()
        {
            
            switch (tag)
            {
                case "addOrStronger":
                    break;
                case "showNews":
                    break;
                case "schowMeme":
                    break;
            }
        }

        private void addOrStronger()
        {
           
        }
    }
}