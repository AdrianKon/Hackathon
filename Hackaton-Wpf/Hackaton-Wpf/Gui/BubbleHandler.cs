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
    class BubbleHandler
    {
        public
        void createMemeFace(Image image, string imagePath)
        {
            image.Source = new BitmapImage(new System.Uri(imagePath));
            //image.ToolTip = textBlock.ToolTip;
        }


        public void createBubble(Popup popup, TextBlock textBlock)
        {
            popup.Child = textBlock;
        }

        public TextBlock createBubbleContentEvents( string imagePath, string newsContent) {
            Image image = new Image();
            TextBlock textBlock = new TextBlock();
            TextBlock textBlock2 = new TextBlock();
            StackPanel stackPanel = new StackPanel();
            textBlock2.Margin = new Thickness(40,0,0,0);
            textBlock2.Text = newsContent;
            image.Source = new BitmapImage(new System.Uri(imagePath));
            stackPanel.Children.Add(image);
            stackPanel.Children.Add(textBlock2);
            textBlock.ToolTip = stackPanel;

            return textBlock;
        }
        public void createBubbleContentChoice(Popup popup ,string question, List<string> ans)
        {
            TextBlock textBlock = new TextBlock();
            List<TextBlock> choises = new List<TextBlock>();
            StackPanel stackPanel = new StackPanel();
            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = question;
            stackPanel.Children.Add(textBlock2);
            for (int i = 0; i < 4; i++)
            {
                choises.Add(new TextBlock());
                choises[choises.Count - 1].Text = ans[i];
                stackPanel.Children.Add(choises[choises.Count - 1]);
            }
            //stackPanel.Background = Color.;
            popup.Child = stackPanel;
            //return textBlock;
        }
    }
}
