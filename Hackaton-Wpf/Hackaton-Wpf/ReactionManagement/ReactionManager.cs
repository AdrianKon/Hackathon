using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Hackaton_Wpf.Conversation.Shared;
using Hackaton_Wpf.Conversation;
using Hackathon;

namespace Hackaton_Wpf.ReactionManagement
{
    public class ReactionManager
    {
        private double delay;
        private bool noReaction;
        private int botCheer;
        private Thread threadForTimer;

        public bool NoReaction { get => noReaction; set => noReaction = value; }

        public ReactionManager(int delay)
        {
            this.delay = delay;
        }

        public void AwaitForUserReaction()
        {
            DateTime endTime;
            DateTime beginTime;
            ThreadStart starter = () => {
                NoReaction = true;
                beginTime = DateTime.Now;
                endTime = beginTime.AddSeconds(delay);
                while (NoReaction && DateTime.Now < endTime)
                {
                    if (!noReaction)
                    {
                        StartInteraction();
                        botCheer++;
                    }
                }
                if (NoReaction)
                {
                    //
                    botCheer--;
                    threadForTimer.Abort();
                }
            };
            threadForTimer = new Thread(starter);
            threadForTimer.Start();
        }

        private void StartInteraction()
        {
            Random rand = new Random();
            int interaction = rand.Next(1, 4);
            
            switch (interaction)
            {
                case 1:                  
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

    }
}
