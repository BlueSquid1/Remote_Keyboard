#if __IOS__ || __ANDROID__ || WINDOWS_UWP
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

#if __ANDROID__
using Android.Views;
using Android.OS;
using Android.Runtime;
#endif

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
#if __ANDROID__
    /*
    [Android.Runtime.Register("android/view/KeyEvent", DoNotGenerateAcw = true)]
    public class KeyEvent : InputEvent, IDisposable
    {
        public KeyEvent(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        [Android.Runtime.Register(".ctor", "(II)V", "")]
        public void KeyEvent([Android.Runtime.GeneratedEnum] KeyEventActions action, [Android.Runtime.GeneratedEnum] Keycode code)
        {

        }

        public override long EventTime
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override InputSourceType Source
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            throw new NotImplementedException();
        }
    }
    */

    public class CustomEditor : Editor
    {
    }

#endif
    public class SplashScreen : ContentPage
    {
        private string welcomeMessage = "Welcome Developer";

        private StackLayout stackLayout;

        //Constructor
        public SplashScreen()
        {
            this.stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15,
            };

            this.CreateMenu();

            base.Content = this.stackLayout;
        }

        private void CreateMenu()
        {
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

            KeyboardInput();

            Button test = new Button
            {
                Text = "test"
            };
            test.Clicked += TestEvent;
            stackLayout.Children.Add(test);
        }

        private void KeyboardInput()
        {
#if __ANDROID__
            //editTxt = KeyEvent.Callback.FindViewById(Resource.Id.editTxt);

            [Register("myapplication.droid.CustomButton")]
            Editor entryArea = new Editor();
            //entryArea.Keyboard = Keyboard.Numeric;
            //stackLayout.Children.Add(entryArea);
#endif
        }


        private void SendEvent(object sender, EventArgs e)
        {
#if !WINDOWS_UWP
            BaseStation baseStation = BaseStation.GetInstance(10000);
            baseStation.BroadcastSendAsync("from mobile");
#endif
        }

        private void TestEvent(object sender, EventArgs e)
        {
            ((Button)sender).Text = "Test Button pressed";
        }
    }
}
#endif