using System;
using System.Collections.Generic;
using System.Text;

namespace Remote_Keyboard
{
    public interface EventManager
    {
        void SendKeyPress(SDLK scanCode, bool isPressed);

        SDLK ScanCodeFromVirtualKey(uint virtualKeyCode);

        uint VirtualKeyFromScanCode(SDLK scanCode);
    }
}
