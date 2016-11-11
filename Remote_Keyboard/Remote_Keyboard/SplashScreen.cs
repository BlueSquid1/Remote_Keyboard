using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Remote_Keyboard
{
    public class SplashScreen : ContentPage
    {
        private string welcomeMessage = "Welcome Developer";


        public SplashScreen()
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
}
    }
}
