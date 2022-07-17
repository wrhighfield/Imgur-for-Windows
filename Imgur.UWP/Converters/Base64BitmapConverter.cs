using Imgur.API.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;


namespace Imgur.UWP.Converters
{
    class Base64BimapConverter : IValueConverter{
        #region IValueConverter Members


        public object Convert(object value, Type targetType, object parameter, string language)
        {
            byte[] bytes = System.Convert.FromBase64String((String)value);

           
            using (MemoryStream ms = new MemoryStream(bytes))
            {
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}
