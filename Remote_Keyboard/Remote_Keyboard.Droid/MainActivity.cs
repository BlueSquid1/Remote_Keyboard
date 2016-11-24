using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using Android.Runtime;

namespace Remote_Keyboard.Droid
{
    [Activity(Label = "Remote_Keyboard.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //private AlertDialog dialog;

        public static TextView textView;


        //entry point
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            RelativeLayout layout = (RelativeLayout)FindViewById(Resource.Id.background);


            EditText editText = FindViewById<EditText>(Resource.Id.editText);
            //TextView textView = FindViewById<TextView>(Resource.Id.textView);
            //Button ButtonView = FindViewById<Button>(Resource.Id.button1);

            //KeypadHandler keypadHandler = new KeypadHandler();


            //editText.KeyListener = temp;
            //editText.SetOnKeyListener();

            /*
            var dialog = new AlertDialog.Builder(this)
                                    .SetTitle("Delete entry")
                                    .SetMessage("Are you sure you want to delete this entry?")
                                     .Show();
            */
            View.IOnKeyListener x = (View.IOnKeyListener)new KeyListener();
            layout.SetOnKeyListener(x);

        }
    }

    public class KeyListener : Activity, View.IOnKeyListener
    {
        public bool OnKey(View v, [GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            //throw new NotImplementedException();
            return false;
        }

        public bool OnKey(IDialogInterface dialog, [GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            //throw new NotImplementedException();
            return false;
        }
    }
}


