using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Linq;
using System.Threading;
using Hackaton_Wpf.Conversation.ConversetionAnswers;
using Hackaton_Wpf.Conversation.Shared;
using Hackaton_Wpf.RandomMeme;


namespace Hackaton_Wpf
{
    public class BubbleHandler
    {
        //public BubbleHandler()
        //{
        //    NewsHandler nsHandler = new NewsHandler(new List<Tag>());
        //    var news = nsHandler.GetNews();
        //    //KeyLogger.KeyLogger.delegates += createBubbleContentEvents2(news.UrlToImage, news.Description);
        //}

        private BubbleHandler pointer;

        public BubbleHandler getInstance()
        {
            if(pointer == null)
            {
                pointer = new BubbleHandler();
            }
            return pointer;
        }

        public
        void createMemeFace(Image image, string imagePath)
        {
            image.Source = new BitmapImage(new System.Uri(imagePath));
            //image.ToolTip = "cos";
        }


        public void createBubble(Popup popup, TextBlock textBlock)
        {
            popup.Child = textBlock;
        }

        public void createBubbleContentEvents( StackPanel stackPanel, string imagePath, string newsContent) {
            Image image = new Image();
            TextBlock textBlock = new TextBlock();
            TextBlock textBlock2 = new TextBlock();
            this.stackPanel = stackPanel;
            textBlock2.Margin = new Thickness(40,0,0,0);
            textBlock2.Text = newsContent;
            image.Source = new BitmapImage(new System.Uri(imagePath, UriKind.RelativeOrAbsolute));
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(textBlock2);

            //return textBlock;
        }

        public void createBubbleContentEvents2( string imagePath, string newsContent)
        {
            Image image = new Image();
            TextBlock textBlock = new TextBlock();
            TextBlock textBlock2 = new TextBlock();
            textBlock2.Margin = new Thickness(40, 0, 0, 0);
            textBlock2.Text = newsContent;
            image.Source = new BitmapImage(new System.Uri(imagePath, UriKind.RelativeOrAbsolute));
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(textBlock2);

            //return textBlock;
        }

        List<TextBlock> choises = new List<TextBlock>();
        StackPanel stackPanel;
        private Conversation.ConversetionAnswers.Conversation conv;

        private Conversation.ConversetionAnswers.Conversation question;

        /// <summary>
        /// create stack pannel with choises
        /// </summary>
        /// <param name="question"></param>
        /// <param name="ans"></param>
        /// <returns></returns>
        public void createBubbleContentChoice(StackPanel stackPanel , Conversation.ConversetionAnswers.Conversation question)
        {
            this.question = question;
            TextBlock textBlock = new TextBlock();
            this.stackPanel = stackPanel;
            //List<TextBlock> choises = new List<TextBlock>();
            //StackPanel stackPanel = new StackPanel();
            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = question.botLine;
            textBlock2.Margin = new Thickness(10, 0, 0, 0);
            textBlock2.FontSize = 20;
            stackPanel.Children.Add(textBlock2);
            for (int i = 0; i < 4; i++)
            {
                choises.Add(new TextBlock());
                choises[choises.Count - 1].FontSize = 20;
                choises[choises.Count - 1].Margin = new Thickness(5, 0, 0, 0);
                choises[choises.Count - 1].Text = question.answers[i].userLine;
                choises[choises.Count - 1].MouseLeftButtonDown += choicesHandler;
                stackPanel.Children.Add(choises[choises.Count - 1]);
            }

            //return stackPanel;
        }

        private void choicesHandler(object sender, MouseButtonEventArgs e)
        {
            //throw new System.NotImplementedException
            this.nextMet(this.stackPanel, this.question.answers.First());
        }

        private void nextMet(StackPanel stackPanel, AnswerOfFirstLevel answerOfFirstLevel)
        {
            TextBlock textBlock = new TextBlock();
            this.stackPanel = stackPanel;

            TextBlock textBlock2 = new TextBlock();
            textBlock2.FontSize = 20;
            textBlock2.Text = answerOfFirstLevel.anserws.First().botLine;
            for (int i = 0; i < 3; i++)
            {
                choises.Add(new TextBlock());
                choises[choises.Count - 1].FontSize = 20;
                choises[choises.Count - 1].Margin = new Thickness(5, 0, 0, 0);
                choises[choises.Count - 1].Text = answerOfFirstLevel.anserws[i].userLine;
                choises[choises.Count - 1].MouseLeftButtonDown += choicesHandler2;
                stackPanel.Children.Clear();
                stackPanel.Children.Add(choises[choises.Count - 1]);
            }
        }

        private void choicesHandler2(object sender, MouseButtonEventArgs e)
        {
            TextBlock tbb = new TextBlock();
            tbb.FontSize = 20;
            tbb.Text = "Super :) \n Skoro ci sie to spodobalo to moze zainteresuje cie to: ";
            stackPanel.Children.Clear();
            stackPanel.Children.Add(tbb);
            tbb.MouseLeftButtonDown += chisesHandler3;

        }

        private void chisesHandler3(object sender, MouseButtonEventArgs e)
        {
            RandomMeme.MemeHandler meme = new MemeHandler();
            stackPanel.Children.Clear();

            this.createBubbleContentEvents(stackPanel,meme.GetRandomMeme(),"");
            this.stackPanel.MouseLeftButtonUp += showNews;
        }

        public void showNews(object sender, MouseButtonEventArgs e)
        {
            stackPanel.Children.Clear();
            TextBlock tbb = new TextBlock();

            tbb.FontSize = 20;
            WeatherAPI.WeatherAPI weatherApi = new WeatherAPI.WeatherAPI("51.127209", "16.851780");
            tbb.Text = "Pogoda: " + weatherApi.WeatherForecast.Currently.Temperature + " st. C," + weatherApi.WeatherForecast.Currently.Summary;
            stackPanel.Children.Add(tbb);
            stackPanel.MouseLeftButtonUp += hand4;

        }

        private void hand4(object sender, MouseButtonEventArgs e)
        {
            stackPanel.Children.Clear();
            this.createBubbleContentEvents(stackPanel, "../../Res/bsod.png", "");
            this.stackPanel.MouseLeftButtonUp += exit; ;
        }

        private void exit(object sender, MouseButtonEventArgs e)
        {

            
        }
    }
}
