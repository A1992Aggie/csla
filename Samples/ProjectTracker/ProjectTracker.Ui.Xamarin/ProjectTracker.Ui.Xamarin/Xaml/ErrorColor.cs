using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjectTracker.Ui.Xamarin.Xaml
{
    public class ErrorColor : IValueConverter
    {
    public bool Invert { get; set; }

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      var condition = (bool)value;
      if (Invert) condition = !condition;
      if (condition)
        return "Black";
      else
        return "Red";
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      return value;
    }
  }
}