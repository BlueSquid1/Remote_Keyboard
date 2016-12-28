using Remote_Keyboard.Events;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_Keyboard.WindowsForms
{
    class ClipboardEventsWin : ClipboardEvents
    {
        //below three functions are for getting clipboard notifications
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


        private Form winForm;

        //in windows you are reponsible for notifying the next process of a
        //clipboard update.
        private IntPtr nextClipboardViewer;

        //constructor
        public ClipboardEventsWin(Form mWinForm)
        {
            this.winForm = mWinForm;
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)winForm.Handle);
        }

        public void DisposeClipboard()
        {
            ChangeClipboardChain(winForm.Handle, nextClipboardViewer);
        }

        public bool HandleWndProc(Message m)
        {
            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    {
                        this.GetAndSendClipBoard();
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                                    m.LParam);
                        break;
                    }

                case WM_CHANGECBCHAIN:
                    {
                        if (m.WParam == nextClipboardViewer)
                            nextClipboardViewer = m.LParam;
                        else
                            SendMessage(nextClipboardViewer, m.Msg, m.WParam,
                                        m.LParam);
                        break;
                    }

                default:
                    return false;
            }


            return true;
        }

        //called automatically when the clipboard has been changed
        private void GetAndSendClipBoard()
        {

            if (Clipboard.ContainsFileDropList())
            {
                //Clipboard.Get
                StringCollection filePaths = Clipboard.GetFileDropList();

                //convert from stringcollection to list<string>
                List<string> filePathList = new List<string>();
                foreach(string filePath in filePaths)
                {
                    filePathList.Add(filePath);
                }
                OnFilesCopiedEvent(this, new FilesCopyEventArgs(filePathList));
            }
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                OnTextCopiedEvent(this, new TextCopyEventArgs(clipboardText));
            }

            //Plaintext includes text, Unicode text, OEM (Object Exchange Model) text, and CSV (Comma-separated values)
            if (Clipboard.ContainsData(DataFormats.UnicodeText.ToString()))
            {
                Console.WriteLine("unicode Text");
            }

            if (Clipboard.ContainsData(DataFormats.UnicodeText.ToString()))
            {
                Console.WriteLine("unicode Text");
            }
        }
    }
}
