using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.UWP.Converters{
    public class IfValueConverter{
        #region IValueConverter Members


        public object Convert(object value, Type targetType, object parameter, string language)
        {

            string parameterString = parameter as string;
            /*
            if (!string.IsNullOrEmpty(parameterString))
            {

                string[] parameters = parameterString.Split(new char[] { ';' });

                Debug.WriteLine(parameters[0]);
                Debug.WriteLine(parameters[1]);
                Debug.WriteLine(parameters[2]);


                if (parameters.Count() == 3)
                {

                    if ((string)value == parameters[0])
                    {
                        Debug.WriteLine("Oi");

                        return parameters[1];
                    }
                    else
                    {
                        Debug.WriteLine("Xau");

                        return parameters[2];
                    }
                }else{
                    Debug.WriteLine("Fumou Size");
                    return false;
                }

            }else{
                Debug.WriteLine("Fumou Feio");
                return false;
            }      
            */
            return "0|1";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
