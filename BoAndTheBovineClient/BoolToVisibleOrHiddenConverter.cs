using System;
using System.Windows;
using System.Windows.Data;

namespace BoAndTheBovineClient
{
    /// <summary>
    /// http://www.rhyous.com/2011/02/22/binding-visibility-to-a-bool-value-in-wpf/
    /// </summary>
    public class BoolToVisibleOrHidden : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var bValue = (bool)value;
            return bValue ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var visibility = (Visibility)value;
            return visibility == Visibility.Visible;
        }

        #endregion
    }
}
