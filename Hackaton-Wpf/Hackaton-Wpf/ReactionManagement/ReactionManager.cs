using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

    }
}
