using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml;
using System.Windows;

namespace ClasesBase
{
    public class ConversorDeEstados : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int duracionEnMinutos;
                if (int.TryParse(value.ToString(), out duracionEnMinutos))
                {
                    if (duracionEnMinutos == 0)
                    {
                        return new SolidColorBrush(Colors.Green);
                    }
                    else if (duracionEnMinutos > 0 && duracionEnMinutos <= 30)
                    {
                        return new SolidColorBrush(Colors.LightCoral);
                    }
                    else if (duracionEnMinutos > 30 && duracionEnMinutos <= 60)
                    {
                        return new SolidColorBrush(Colors.OrangeRed);
                    }
                    else
                    {
                        return new SolidColorBrush(Colors.DarkRed);
                    }
                }
            }

            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
