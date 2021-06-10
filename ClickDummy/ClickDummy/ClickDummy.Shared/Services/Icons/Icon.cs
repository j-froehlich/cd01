using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace ClickDummy.Services
{
    public static class Icon
    {
        public static string GetIcon(string name)
        {
            return (string)Application.Current.Resources[name];
        }
    }
}
