using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Events
{
    public class FilesCopyEventArgs : EventArgs
    {
        public List<string> filePaths { get; }

        //constructor
        public FilesCopyEventArgs(List<string> mFilePaths)
        {
            this.filePaths = mFilePaths;
        }
    }
}
