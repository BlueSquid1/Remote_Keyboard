#if __IOS__ || __ANDROID__ || WINDOWS_UWP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using Xamarin.Forms;

namespace Remote_Keyboard
{
	public class App : Application
	{
        public App ()
		{
            MainPage = new SplashScreen();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

#endif
