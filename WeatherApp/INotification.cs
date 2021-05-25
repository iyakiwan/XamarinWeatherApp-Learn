using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    public interface INotification
    {
        void CreateNotification(String title, String message, String[] data);
    }
}
