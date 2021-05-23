using System;
using Windows.UI.Xaml.Data;
using ClickDummy.Models;

namespace ClickDummy.Converters
{
    public class FromStateItemsRemainingToPluralConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is State state)
            {
                var amountRemaining = state.RemainingTodos;
                return amountRemaining == 1 ? $"{amountRemaining} item left" : $"{amountRemaining} items left";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}