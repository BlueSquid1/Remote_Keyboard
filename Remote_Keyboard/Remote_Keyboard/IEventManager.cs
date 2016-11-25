using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard
{
    public interface IEventManager
    {
        void TriggerKeyPress(ushort scanCode, bool isPressed);

        ushort ScanCodeFromVirtualKey(ushort virtualKeyCode);

        ushort VirtualKeyFromScanCode(ushort scanCode);
    }
}
