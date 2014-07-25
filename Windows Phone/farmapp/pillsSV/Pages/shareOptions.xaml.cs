using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace pillsSV.Pages
{
    public partial class shareOptions : PhoneApplicationPage
    {
        string message = "El precio máximo de: ";
        private void ListBoxItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SmsComposeTask smsComposeTask = new SmsComposeTask();

            smsComposeTask.Body = message;

            smsComposeTask.Show();
        }

        private void ListBoxItem_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask();

            task.Subject = "Precio máximo medicina";

            task.Body = message;

            task.Show();
        }

        private void ListBoxItem_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShareStatusTask shareStatusTask = new ShareStatusTask();

            shareStatusTask.Status = message;

            shareStatusTask.Show();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            message += NavigationContext.QueryString["name"] + " es de: $" + NavigationContext.QueryString["price"];
        }
    }
}