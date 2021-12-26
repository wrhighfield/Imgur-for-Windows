using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Imgur.UWP.Converters
{
    public class BoolValueConverter : IValueConverter
    {
        #region IValueConverter Members


        public object Convert(object value, Type targetType, object parameter, string language){

            string parameterString = parameter as string;
            if (!string.IsNullOrEmpty(parameterString))
            {

                string[] parameters = parameterString.Split(new char[] { '|' });
                if (parameters.Count() == 2)
                {
                    if ((bool)value)
                    {
                        Debug.WriteLine("Oi");

                        return parameters[0];
                    }
                    else
                    {
                        Debug.WriteLine("Xau");

                        return parameters[1];
                    }
                }
                else
                {
                    Debug.WriteLine("Fumou");
                    return false;

                }
            }else{
                Debug.WriteLine("Fumou");
                return false;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
