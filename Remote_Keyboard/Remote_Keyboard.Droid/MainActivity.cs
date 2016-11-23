using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Remote_Keyboard.Droid
{
	[Activity (Label = "Remote_Keyboard.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        //entry point
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            EditText editText = FindViewById<EditText>(Resource.Id.editText);
            TextView textView = FindViewById<TextView>(Resource.Id.textView);

            editText.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                //KeyPress();
                textView.Text += e.KeyCode.ToString(); // e.KeyCode.ToString();
            };

            editText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                textView.Text = e.Text.ToString(); // e.KeyCode.ToString();
            };
        }

        private void KeyPress()
        {

        }
	}
}


