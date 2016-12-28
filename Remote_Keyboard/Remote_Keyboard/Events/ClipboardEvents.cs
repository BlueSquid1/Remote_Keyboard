using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Events
{
    public abstract class ClipboardEvents
    {
        public event EventHandler<TextCopyEventArgs> TextCopiedEvent;
        public event EventHandler<FilesCopyEventArgs> FilesCopiedEvent;

        //methods that are used to invoke the events in child classes
        protected void OnTextCopiedEvent(object sender, TextCopyEventArgs e)
        {
            TextCopiedEvent?.Invoke(sender, e);
        }

        protected void OnFilesCopiedEvent(object sender, FilesCopyEventArgs e)
        {
            FilesCopiedEvent?.Invoke(sender, e);
        }
    }
}
