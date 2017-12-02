using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hackaton_Wpf.Conversation.Shared;

namespace Hackaton_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            NewsHandler nwHandler = new NewsHandler(new List<Tag>());
            var news = nwHandler.GetNews();
            InitializeComponent();
            MemeFace.ToolTip = "hello ya little sh";
            TextBlock textBlock = new TextBlock();

            BubbleHandler bubble = new BubbleHandler();
            //textBlock = bubble.createBubbleContentEvents(@"C:\Users\mono\source\repos\Hackathon\Hackaton-Wpf\Hackaton-Wpf\Res\trollface.png", "BSOD's won the game");
            List<string> ans = new List<string>();
            ans.Add("good");
            ans.Add("ok");
            ans.Add("bad");
            ans.Add("w4 student");


            textBlock = bubble.createBubbleContentChoice("How do you feel?", ans);
            bubble.createMemeFace(MemeFace, @"C:\Users\mono\source\repos\Hackathon\Hackaton-Wpf\Hackaton-Wpf\Res\trollface.png", textBlock);
            
        }
    }
}
