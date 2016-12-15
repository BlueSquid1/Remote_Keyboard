using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard.Common
{
    [Serializable]
    public enum OSValue
    {
        Windows10 = 0,
        OSX = 1,
        Linux = 2,
        Android = 3,
        iOS = 4
    }

    public class Settings
    {
        //put setting variables here
        public bool acceptKeyStrokes { get; set; }
        public bool acceptCopySync { get; set; }
        public OSValue platform { get; set; }

        //constructor
        public Settings()
        {
            Reset();
        }

        //resets settings variables to their origional state
        public void Reset()
        {
            acceptKeyStrokes = true;
            acceptCopySync = true;
            platform = OSValue.Windows10;
        }
    }
}
