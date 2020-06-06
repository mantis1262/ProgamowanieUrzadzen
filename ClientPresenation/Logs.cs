using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientPresentation
{
    public static class Logs
    {
        public static void ProcessLog(string message)
        {
            string errorPrefix = "ERROR:";
            if (message.StartsWith(errorPrefix))
            {
                ShowErrorPopupWindow(message.Substring(errorPrefix.Length));
            }
            else
            {
                ShowInfoPopupWindow(message);
            }
        }

        public static Func<string, string, MessageBoxButton, MessageBoxImage, MessageBoxResult> MessageBoxShowDelegate { get; set; } = MessageBox.Show;

        private static void ShowErrorPopupWindow(string mesg)
        {
            MessageBoxShowDelegate(mesg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private static void ShowInfoPopupWindow(string mesg)
        {
            MessageBoxShowDelegate(mesg, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
