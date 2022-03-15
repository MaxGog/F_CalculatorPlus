using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Calculator_Plus
{
    public class Functionality
    {
        public string Icon { get; set; }
        public string Name_str { get; set; }
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //ContentView.Navigate(typeof(CalculatePage));
        }

        private void NavPanel_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == Home_Page)
            {
                ContentView.Content = SelectPage;
            }
            else if (args.SelectedItem == Calculator_Page)
            {
                ContentView.Navigate(typeof(CalculatePage));
            }
            else if (args.SelectedItem == Money_Page)
            {
                ContentView.Navigate(typeof(MoneyPage));
            }
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            Functionality selectedFunctional = (Functionality)e.ClickedItem;
            if (selectedFunctional == calculate)
            {
                ContentView.Navigate(typeof(CalculatePage));
                NavPanel.SelectedItem = Calculator_Page;
            }
            else if (selectedFunctional == money)
            {
                ContentView.Navigate(typeof(MoneyPage));
                NavPanel.SelectedItem = Money_Page;
            }
        }
    }
}
