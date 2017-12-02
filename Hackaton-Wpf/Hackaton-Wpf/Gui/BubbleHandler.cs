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


namespace Hackaton_Wpf
{
    public class BubbleHandler
    {

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
            image.Source = new BitmapImage(new System.Uri(imagePath));
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(textBlock2);

            //return textBlock;
        }

        List<TextBlock> choises = new List<TextBlock>();
        StackPanel stackPanel;

        /// <summary>
        /// create stack pannel with choises
        /// </summary>
        /// <param name="question"></param>
        /// <param name="ans"></param>
        /// <returns></returns>
        public void createBubbleContentChoice(StackPanel stackPanel ,string question, List<string> ans)
        {
            TextBlock textBlock = new TextBlock();
            this.stackPanel = stackPanel;
            //List<TextBlock> choises = new List<TextBlock>();
            //StackPanel stackPanel = new StackPanel();
            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = question;
            textBlock2.Margin = new Thickness(10, 0, 0, 0);
            stackPanel.Children.Add(textBlock2);
            for (int i = 0; i < 4; i++)
            {
                choises.Add(new TextBlock());
                choises[choises.Count - 1].Margin = new Thickness(5, 0, 0, 0);
                choises[choises.Count - 1].Text = ans[i];
                choises[choises.Count - 1].MouseLeftButtonDown += choicesHandler;
                stackPanel.Children.Add(choises[choises.Count - 1]);
            }

            //return stackPanel;
        }

        private void choicesHandler(object sender, MouseButtonEventArgs e)
        {
            //throw new System.NotImplementedException();
            TextBlock tb = new TextBlock();
            tb.Text = "mouse clicked";

            choises.Add(tb);
            stackPanel.Children.Add(choises[choises.Count - 1]);
        }
    }
}
