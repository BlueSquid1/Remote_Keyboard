#if __IOS__ || __ANDROID__
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

/*
#if __IOS__
using UIKit;
#elif __ANDROID__
using Android.OS;
#elif WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_UWP
using Windows.Security.ExchangeActiveSyncProvisioning;
#endif
*/


namespace Remote_Keyboard
{
    public class SplashScreen : ContentPage
    {
        private string welcomeMessage = "Welcome Developer";

        //Constructor
        public SplashScreen()
        {
            Initalize();

            StackLayout stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15,
            };
            Label title = new Label
            {
                Text = welcomeMessage
            };
            stackLayout.Children.Add(title);

            Button send = new Button
            {
                Text = "send message"
            };
            send.Clicked += SendEvent;
            stackLayout.Children.Add(send);


            base.Content = stackLayout;
        }


        private void SendEvent(object sender, EventArgs e)
        {
            BaseStation baseStation = BaseStation.GetInstance(10000);
            baseStation.BroadcastSendAsync("from mobile");
        }

        private void Initalize()
{
}
    }
}
#endif