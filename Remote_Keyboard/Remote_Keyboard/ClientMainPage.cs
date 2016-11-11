using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

#if __IOS__
using UIKit;
#elif __ANDROID__
using Android.OS;
#elif WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_UWP
using Windows.Security.ExchangeActiveSyncProvisioning;
#endif


namespace Remote_Keyboard
{
    public class ClientMainPage : ContentPage
    {
        private string welcomeMessage = "Welcome Developer";

        //constructor
        public ClientMainPage()
        {
            Initalize();

            base.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = welcomeMessage
                        }
                    }
            };
        }

        private void Initalize()
        {
            #if WINDOWS_APP || WINDOWS_PHONE_APP || WINDOWS_UWP
                EasClientDeviceInformation devInfo = new EasClientDeviceInformation();
                welcomeMessage = String.Format("manufactor={0} product={1} operatingSystem={2}", devInfo.SystemManufacturer, devInfo.SystemProductName, devInfo.OperatingSystem);
            #endif
        }
    }
}
