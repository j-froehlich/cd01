using ClickDummy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ClickDummy
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public static readonly DependencyProperty IssueItemProperty =
        DependencyProperty.Register(nameof(Item), typeof(IssueItem), typeof(MainPage), new PropertyMetadata(default(IssueItem)));

        public BlankPage2()
        {
            this.InitializeComponent();
        }

        private void GotoNextPage(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(TodoApp));

        private void GoToPrevPage(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(BlankPage1));

        private void NavigateBack(object sender, RoutedEventArgs e) => Frame.GoBack();

        public IssueItem Item
        {
            get => (IssueItem)GetValue(IssueItemProperty);
            set => SetValue(IssueItemProperty, value);
        }

        public IssueStatus[] StatusList => new[]
        {
            IssueStatus.Icebox,
            IssueStatus.Planned,
            IssueStatus.WIP,
            IssueStatus.Done,
            IssueStatus.Removed
        };

        public IssueType[] IssueTypeList => new[]
        {
            IssueType.Bug,
            IssueType.Feature,
            IssueType.Issue,
            IssueType.Task
        };

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Item = new IssueItem
            {
                Id = 1232,
                Title = "Getting Started",
                Description = @"Create a page to enter Issues that we need to work on.

## Acceptance Criteria

- Display the issue Id
- Provide an ability to select the issue Type (i.e. Bug, Feature, etc)
- Include an Issue Title
- Include a full issue description with support for Markdown
- Include an issue effort
- Include an ability for a developer to update the Status (i.e Icebox, WIP, etc)

## Additional Comments

We would like to have a visual indicator for the type of issue as well as something to visualize the effort involved",
                Effort = 3,
                Status = IssueStatus.WIP,
                Type = IssueType.Feature,
                CreatedAt = new DateTimeOffset(2019, 04, 03, 08, 0, 0, TimeSpan.FromHours(-8)),
                StartedAt = new DateTimeOffset(2019, 04, 30, 08, 0, 0, TimeSpan.FromHours(-8))
            };
        }

        // Sets the time when we Complete or Start an issue.
        private void StatusPicker_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            switch (Item.Status)
            {
                case IssueStatus.Removed:
                case IssueStatus.Done:
                    if (Item.CompletedAt is null)
                        Item.CompletedAt = DateTimeOffset.Now.ToLocalTime();
                    break;
                case IssueStatus.WIP:
                    if (Item.StartedAt is null)
                        Item.StartedAt = DateTimeOffset.Now.ToLocalTime();
                    break;
                default:
                    Item.StartedAt = null;
                    Item.CompletedAt = null;
                    break;
            }
        }

        // Provides a unique color based on the type of Issue
        private void IssueType_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var color = Colors.Red;
            switch (IssueTypeBox.SelectedItem)
            {
                case IssueType.Feature:
                    color = Colors.Green;
                    break;
                case IssueType.Issue:
                    color = Colors.Blue;
                    break;
                case IssueType.Task:
                    color = Colors.Yellow;
                    break;
            }
            IssueTypeIndicator.Background = new SolidColorBrush(color);
        }

        // Provides the conversion for dates in the XAML through x:Bind
        public string FormatDate(string header, DateTimeOffset? dateTime)
            => $"{header} {dateTime:MMM dd, yyyy hh:mm tt}";
    }
}
