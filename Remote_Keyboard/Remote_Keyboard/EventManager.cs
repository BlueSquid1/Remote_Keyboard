using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard
{
    public interface EventManager
    {
        void SendKeyPress(ushort scanCode, bool isPressed);

        ushort ScanCodeFromVirtualKey(ushort virtualKeyCode);

        ushort VirtualKeyFromScanCode(ushort scanCode);
    }
}
