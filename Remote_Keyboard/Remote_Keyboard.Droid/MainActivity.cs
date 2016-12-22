using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Android.Runtime;
using System.ComponentModel;
using Remote_Keyboard.Common;
using Remote_Keyboard.Events;
using System.IO;

namespace Remote_Keyboard.Droid
{
    [Activity(Label = "Remote_Keyboard.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //private AlertDialog dialog;

        private TextView textView;
        private EditText editText;
        AirKeyboard airKeyboard;


        //entry point
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Stream fileStream = Assets.Open("KeyMapping.xml");
            EventManager eventManager = new EventManagerDroid(fileStream);
            airKeyboard = new AirKeyboard(eventManager);

            //LinearLayout background = FindViewById<LinearLayout>(Resource.Id.background);

            editText = FindViewById<EditText>(Resource.Id.editText);

            textView = FindViewById<TextView>(Resource.Id.textView); 

            editText.TextChanged += TextChanged;

        }

        //detects hard keyboard inputs
        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            ushort androidValue = (ushort)e.KeyCode;
            textView.Text = (e.KeyCode).ToString();
            return base.OnKeyDown(keyCode, e);
        }

        //detects hard keyboard inputs
        public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            ushort androidValue = (ushort)e.KeyCode;
            textView.Text = (e.KeyCode).ToString();

            return base.OnKeyDown(keyCode, e);
        }

        private void TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (e.Text.ToString().Length == 0)
            {
                //do nothing
                return;
            }

            string text = e.Text.ToString();

            textView.Text = text;

            //clear value
            editText.Text = "";
        }
    }
}


