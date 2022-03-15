using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Calculator_Plus
{
    public sealed partial class CalculatePage : Page
    {
        string leftop = "";
        string operation = "";
        string rightop = "";
        public CalculatePage()
        {
            this.InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            Text_View.Text += s;
            int number;
            bool result = Int32.TryParse(s, out number);
            if (result == true)
            {
                if (operation == "")
                    leftop += s;
                else
                    rightop += s;
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    //if (Text_Finish.Text != null)
                    //    Text_Finish.Text = null;
                    Text_Finish.Text += rightop;
                    operation = "";
                }
                else if (s == "Clear")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    Text_View.Text = "";
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }
        private void Update_RightOp()
        {
            int number_one = Int32.Parse(leftop);
            int number_two = Int32.Parse(rightop);
            switch (operation)
            {
                case "+":
                    rightop = (number_one + number_two).ToString();
                    break;
                case "-":
                    rightop = (number_one - number_two).ToString();
                    break;
                case "×":
                    rightop = (number_one * number_two).ToString();
                    break;
                case "/":
                    rightop = (number_one / number_two).ToString();
                    break;
            }
        }
    }
}
