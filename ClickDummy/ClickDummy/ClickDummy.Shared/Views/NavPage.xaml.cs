using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ClickDummy.Shared.Helpers;
using ClickDummy.Shared.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClickDummy.Shared.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavPage : Page
    {
        private NavigationSyncHelper _navigationSyncHelper;

        public NavPage()
        {
            this.InitializeComponent();
            this.Loaded += NavPage_Loaded;

            _navigationSyncHelper = new NavigationSyncHelper(
                MainNavView,
                ContentFrame,
                new Dictionary<string, Type>()
                {
                    {"StartPage",        typeof(StartPage) },
                    {"DataOrganization",   typeof(DataOrganising.DataPage) },
                    {"Monitoring",     typeof(Monitoring.MonitorPage) },
                    {"Reporting",       typeof(Reporting.ReportPage) },
                    {"Signal",       typeof(Signal.SignalPage) },
                });
        }

        private void NavPage_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(DataOrganising.DataPage), null, new EntranceNavigationTransitionInfo());
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            // log errors
            // show error window
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            /* NOTE: for this function to work, every NavigationView must follow the same naming convention: nvSample# (i.e. nvSample3),
            and every corresponding content frame must follow the same naming convention: contentFrame# (i.e. contentFrame3) */

            // Get the sample number
            string sampleNum = (sender.Name).Substring(8);
            Debug.Print("num: " + sampleNum + "\n");

            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(Configuration.SettingsPage));
            }
            else
            {
                var selectedItem = (NavigationViewItem)args.SelectedItem;
                string selectedItemTag = ((string)selectedItem.Tag);
                sender.Header = "ClickDummy " + selectedItemTag.Substring(selectedItemTag.Length - 1);
                string pageName = "ClickDummy.Shared.Views." + selectedItemTag;
                Type pageType = Type.GetType(pageName);
                ContentFrame.Navigate(pageType);
            }
        }
    }
}
