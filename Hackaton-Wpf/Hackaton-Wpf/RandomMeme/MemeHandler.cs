using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton_Wpf.RandomMeme
{
    class MemeHandler
    {
        private Random random;
        public List<string> MemeList { get; set; }
        public MemeHandler()
        {
            random = new Random();
            MemeList = Directory.GetFiles("../../RandomMeme/Memes/", "*").ToList();
        }

        public string GetRandomMeme()
        {
            
            return MemeList[random.Next(0, MemeList.Count)];
        }
    }
}
