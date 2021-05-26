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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClickDummy.Shared.Views.Shared
{
    public sealed partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            this.InitializeComponent();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button)) return;

            switch (button.Content)
            {
                case "Projekt Management":
                    // Frame.Navigate(typeof(ClickDummy.MainPage));
                    Console.WriteLine("Default value..." + button.Content);
                    break;
                case "Session Management":
                    // Frame.Navigate(typeof(ClickDummy.TodoApp));
                    Console.WriteLine("Default value..." + button.Content);
                    break;
                case "Monitoring":
                    // Frame.Navigate(typeof(ClickDummy.Views.Analysing.AnalysePage));
                    Console.WriteLine("Default value..." + button.Content);
                    break;
                case "Reporting":
                    // Frame.Navigate(typeof(ClickDummy.Views.Analysing.AnalysePage));
                    Console.WriteLine("Default value..." + button.Content);
                    break;
                case "Analyse":
                    // Frame.Navigate(typeof(ClickDummy.Views.Analysing.AnalysePage));
                    Console.WriteLine("Default value..." + button.Content);
                    break;
                case "Signal":
                    // Frame.Navigate(typeof(ClickDummy.Views.Analysing.AnalysePage));
                    Console.WriteLine("Default value..." + button.Content);
                    break;
                default:
                    // Frame.Navigate(typeof(MainPage));
                    Console.WriteLine("Default value..." + button.Content);
                    break;
            }
        }
    }
}
