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
using ClickDummy.Models;
using ClickDummy.ViewModels;
using Windows.System;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace ClickDummy
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class TodoApp : Page
    {
        public TodoApp()
        {
            this.InitializeComponent();
        }

        // public enum MenuItems { MainPage, BlankPage1, BlankPange2, TodoApp, ClickDummy.View.Analysing.AnalysePage }

        private void GoToPrevPage(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(BlankPage2));

        private void NavigateBack(object sender, RoutedEventArgs e) => Frame.GoBack();

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button)) return;

            switch (button.Content)
            {
                case "Home":
                    Frame.Navigate(typeof(ClickDummy.MainPage));
                    Console.WriteLine("Default value...");
                    break;
                case "Page 1":
                    Frame.Navigate(typeof(ClickDummy.TodoApp));
                    Console.WriteLine("Default value...");
                    break;
                case "Page 2":
                    Frame.Navigate(typeof(ClickDummy.Views.Analysing.AnalysePage));
                    Console.WriteLine("Default value...");
                    break;
                default:
                    Frame.Navigate(typeof(MainPage));
                    Console.WriteLine("Default value...");
                    break;
            }
        }

        private void ItemClicked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var todo = checkBox?.DataContext as Todo;
            var isDone = checkBox?.IsChecked ?? false;
            (DataContext as MainPageViewModel)?.ChangeState(todo, isDone);
        }

        private void ChangeItem(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBlock textBlock)) return;
            if (!(textBlock.Tag is TextBox textBox)) return;

            textBox.Visibility = Visibility.Visible;
            textBlock.Visibility = Visibility.Collapsed;

            textBox.LostFocus += UpdateItem;
            textBox.Focus(FocusState.Programmatic); // give focus

            void UpdateItem(object _, RoutedEventArgs __)
            {
                textBox.Visibility = Visibility.Collapsed;
                textBlock.Visibility = Visibility.Visible;

                var newText = textBox.Text;
                var todo = textBlock?.DataContext as Todo;
                (DataContext as MainPageViewModel)?.ChangeText(todo, newText);

                textBox.LostFocus -= UpdateItem;
            }
        }

        private void ChangeItemBtn(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) ChangeItem(button.Tag, null);
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainPageViewModel vm)
            {
                var button = sender as FrameworkElement;
                var todo = button?.DataContext as Todo;

                vm.RemoveTodo(todo);
            }
        }

        private void OnNewTodoKey(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                if (sender is TextBox textBox)
                {
                    textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
                    (DataContext as MainPageViewModel)?.CreateNew.Execute(null);
                }
        }

        private void OnItemKey(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key != VirtualKey.Enter) return; // not an enter key

            Focus(FocusState.Programmatic);

            if (sender is TextBox textBox) textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }
    }
}
