using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Remote_Keyboard.Droid
{
	[Activity (Label = "Remote_Keyboard", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            /*
            this.SetContentView(Resource.Layout.Main);

            var editText = FindViewById<EditText>(Resource.Id.editText);
            TextView textView = FindViewById<TextView>(Resource.Id.textView);

            editText.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                textView.Text += '1'; // e.KeyCode.ToString();
            };

            editText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                textView.Text += '1'; // e.KeyCode.ToString();
            };
            */

            global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new Remote_Keyboard.App ());
		}
	}
}

