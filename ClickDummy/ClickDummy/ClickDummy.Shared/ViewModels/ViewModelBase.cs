using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClickDummy.ViewModels
{
    internal class ViewModelBase : BindableBase
    {
        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppSecondMenu = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> Menu => AppMenu;

        public ObservableCollection<MenuItem> SecondMenu => AppSecondMenu;
    }
}
