using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Events
{
    public class TextCopyEventArgs : EventArgs
    {
        public string text { get; }

        //constructor
        public TextCopyEventArgs(string mText)
        {
            this.text = mText;
        }
    }
}
