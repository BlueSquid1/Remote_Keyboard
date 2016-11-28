using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;
using System.Collections;

namespace Remote_Keyboard
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms646270(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct INPUT
    {
        internal uint type;
        internal InputUnion U;
        internal static int Size
        {
            get { return Marshal.SizeOf(typeof(INPUT)); }
        }
    }


    // Declare the InputUnion struct
    [StructLayout(LayoutKind.Explicit)]
    internal struct InputUnion
    {
        [FieldOffset(0)]
        internal MOUSEINPUT mi;
        [FieldOffset(0)]
        internal KEYBDINPUT ki;
        [FieldOffset(0)]
        internal HARDWAREINPUT hi;
    }

    /// <summary>
    /// http://social.msdn.microsoft.com/forums/en-US/netfxbcl/thread/2abc6be8-c593-4686-93d2-89785232dacd
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        internal int dx;
        internal int dy;
        internal MouseEventDataXButtons mouseData;
        internal MOUSEEVENTF dwFlags;
        internal uint time;
        internal UIntPtr dwExtraInfo;
    }

    [Flags]
    internal enum MouseEventDataXButtons : uint
    {
        Nothing = 0x00000000,
        XBUTTON1 = 0x00000001,
        XBUTTON2 = 0x00000002
    }

    [Flags]
    internal enum MOUSEEVENTF : uint
    {
        ABSOLUTE = 0x8000,
        HWHEEL = 0x01000,
        MOVE = 0x0001,
        MOVE_NOCOALESCE = 0x2000,
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010,
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        VIRTUALDESK = 0x4000,
        WHEEL = 0x0800,
        XDOWN = 0x0080,
        XUP = 0x0100
    }

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms646310(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        internal VirtualKeyShort wVk;
        internal uint wScan;
        internal KEYEVENTF dwFlags;
        internal uint time;
        internal UIntPtr ExtraInfo;
    }

    [Flags]
    internal enum KEYEVENTF : uint
    {
        EXTENDEDKEY = 0x0001,
        KEYUP = 0x0002,
        SCANCODE = 0x0008,
        UNICODE = 0x0004
    }


    public enum VirtualKeyShort : ushort
    {
        #region COMPUTER
        LBUTTON = 0x01,
        RBUTTON = 0x02,
        CANCEL = 0x03,
        MBUTTON = 0x04,
        XBUTTON1 = 0x05,    /* NOT contiguous with L & RBUTTON */
        XBUTTON2 = 0x06,    /* NOT contiguous with L & RBUTTON */
        BACK = 0x08,
        TAB = 0x09,
        CLEAR = 0x0C,
        RETURN = 0x0D,
        SHIFT = 0x10,
        CONTROL = 0x11,
        MENU = 0x12,
        PAUSE = 0x13,
        CAPITAL = 0x14,
        KANA = 0x15,
        HANGEUL = 0x15,  /* old name - should be here for compatibility */
        HANGUL = 0x15,
        JUNJA = 0x17,
        FINAL = 0x18,
        HANJA = 0x19,
        KANJI = 0x19,
        ESCAPE = 0x1B,
        CONVERT = 0x1C,
        NONCONVERT = 0x1D,
        ACCEPT = 0x1E,
        MODECHANGE = 0x1F,
        SPACE = 0x20,
        PRIOR = 0x21,
        NEXT = 0x22,
        END = 0x23,
        HOME = 0x24,
        LEFT = 0x25,
        UP = 0x26,
        RIGHT = 0x27,
        DOWN = 0x28,
        SELECT = 0x29,
        PRINT = 0x2A,
        EXECUTE = 0x2B,
        SNAPSHOT = 0x2C,
        INSERT = 0x2D,
        DELETE = 0x2E,
        HELP = 0x2F,
        #endregion

        #region KEYS
        KEY_0 = 0x30,
        KEY_1 = 0x31,
        KEY_2 = 50,
        KEY_3 = 0x33,
        KEY_4 = 0x34,
        KEY_5 = 0x35,
        KEY_6 = 0x36,
        KEY_7 = 0x37,
        KEY_8 = 0x38,
        KEY_9 = 0x39,
        KEY_A = 0x41,
        KEY_B = 0x42,
        KEY_C = 0x43,
        KEY_D = 0x44,
        KEY_E = 0x45,
        KEY_F = 70,
        KEY_G = 0x47,
        KEY_H = 0x48,
        KEY_I = 0x49,
        KEY_J = 0x4a,
        KEY_K = 0x4b,
        KEY_L = 0x4c,
        KEY_M = 0x4d,
        KEY_N = 0x4e,
        KEY_O = 0x4f,
        KEY_P = 80,
        KEY_Q = 0x51,
        KEY_R = 0x52,
        KEY_S = 0x53,
        KEY_T = 0x54,
        KEY_U = 0x55,
        KEY_V = 0x56,
        KEY_W = 0x57,
        KEY_X = 0x58,
        KEY_Y = 0x59,
        KEY_Z = 90,
        #endregion

        #region FUNCTION_KEYS
        LWIN = 0x5B,
        RWIN = 0x5C,
        APPS = 0x5D,
        SLEEP = 0x5F,
        NUMPAD0 = 0x60,
        NUMPAD1 = 0x61,
        NUMPAD2 = 0x62,
        NUMPAD3 = 0x63,
        NUMPAD4 = 0x64,
        NUMPAD5 = 0x65,
        NUMPAD6 = 0x66,
        NUMPAD7 = 0x67,
        NUMPAD8 = 0x68,
        NUMPAD9 = 0x69,
        MULTIPLY = 0x6A,
        ADD = 0x6B,
        SEPARATOR = 0x6C,
        SUBTRACT = 0x6D,
        DECIMAL = 0x6E,
        DIVIDE = 0x6F,
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,
        F13 = 0x7C,
        F14 = 0x7D,
        F15 = 0x7E,
        F16 = 0x7F,
        F17 = 0x80,
        F18 = 0x81,
        F19 = 0x82,
        F20 = 0x83,
        F21 = 0x84,
        F22 = 0x85,
        F23 = 0x86,
        F24 = 0x87,
        NUMLOCK = 0x90,
        SCROLL = 0x91,
        OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
OEM_FJ_JISHO = 0x92,   // 'Dictionary' key
OEM_FJ_MASSHOU = 0x93,   // 'Unregister word' key
OEM_FJ_TOUROKU = 0x94,   // 'Register word' key
OEM_FJ_LOYA = 0x95,   // 'Left OYAYUBI' key
OEM_FJ_ROYA = 0x96,   // 'Right OYAYUBI' key


/*
 * L* & R* - left and right Alt, Ctrl and Shift virtual keys.
 * Used only as parameters to GetAsyncKeyState() and GetKeyState().
 * No other API or message will distinguish left and right keys in this way.
 */
LSHIFT = 0xA0,
        RSHIFT = 0xA1,
        LCONTROL = 0xA2,
        RCONTROL = 0xA3,
        LMENU = 0xA4,
        RMENU = 0xA5,

        BROWSER_BACK = 0xA6,
        BROWSER_FORWARD = 0xA7,
        BROWSER_REFRESH = 0xA8,
        BROWSER_STOP = 0xA9,
        BROWSER_SEARCH = 0xAA,
        BROWSER_FAVORITES = 0xAB,
        BROWSER_HOME = 0xAC,
        VOLUME_MUTE = 0xAD,
        VOLUME_DOWN = 0xAE,
        VOLUME_UP = 0xAF,
        MEDIA_NEXT_TRACK = 0xB0,
        MEDIA_PREV_TRACK = 0xB1,
        MEDIA_STOP = 0xB2,
        MEDIA_PLAY_PAUSE = 0xB3,
        LAUNCH_MAIL = 0xB4,
        LAUNCH_MEDIA_SELECT = 0xB5,
        LAUNCH_APP1 = 0xB6,
        LAUNCH_APP2 = 0xB7,

        OEM_1 = 0xBA,   // ';:' for US
        OEM_PLUS = 0xBB,   // '+' any country
        OEM_COMMA = 0xBC,   // ',' any country
        OEM_MINUS = 0xBD,   // '-' any country
        OEM_PERIOD = 0xBE,   // '.' any country
        OEM_2 = 0xBF,   // '/?' for US
        OEM_3 = 0xC0,   // '`~' for US
        OEM_4 = 0xDB,  //  '[{' for US
        OEM_5 = 0xDC,  //  '\|' for US
        OEM_6 = 0xDD,  //  ']}' for US
        OEM_7 = 0xDE,  //  ''"' for US
        OEM_8 = 0xDF,
        #endregion

        #region ENHANCEMENTS
        OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
        OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
        ICO_HELP = 0xE3,  //  Help key on ICO
        ICO_00 = 0xE4,  //  00 key on ICO
        PROCESSKEY = 0xE5,
        ICO_CLEAR = 0xE6,
        PACKET = 0xE7,
        #endregion

        #region NOKIA
        OEM_RESET = 0xE9,
        OEM_JUMP = 0xEA,
        OEM_PA1 = 0xEB,
        OEM_PA2 = 0xEC,
        OEM_PA3 = 0xED,
        OEM_WSCTRL = 0xEE,
        OEM_CUSEL = 0xEF,
        OEM_ATTN = 0xF0,
        OEM_FINISH = 0xF1,
        OEM_COPY = 0xF2,
        OEM_AUTO = 0xF3,
        OEM_ENLW = 0xF4,
        OEM_BACKTAB = 0xF5,
        ATTN = 0xF6,
        CRSEL = 0xF7,
        EXSEL = 0xF8,
        EREOF = 0xF9,
        PLAY = 0xFA,
        ZOOM = 0xFB,
        NONAME = 0xFC,
        PA1 = 0xFD,
        OEM_CLEAR = 0xFE
        #endregion
    }

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms646310(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
        public uint Msg;
        public ushort ParamL;
        public ushort ParamH;
    }

    /*
        qtKeyToVirtualKey[Qt::Key_Cancel] = VK_CANCEL;
        qtKeyToVirtualKey[Qt::Key_Backspace] = VK_BACK;
        qtKeyToVirtualKey[Qt::Key_Tab] = VK_TAB;
        qtKeyToVirtualKey[Qt::Key_Clear] = VK_CLEAR;
        qtKeyToVirtualKey[Qt::Key_Return] = VK_RETURN;
        qtKeyToVirtualKey[Qt::Key_Enter] = VK_RETURN;
        //qtKeyToWinVirtualKey[Qt::Key_Shift] = VK_SHIFT;
        //qtKeyToWinVirtualKey[Qt::Key_Control] = VK_CONTROL;
        //qtKeyToWinVirtualKey[Qt::Key_Alt] = VK_MENU;
        qtKeyToVirtualKey[Qt::Key_Pause] = VK_PAUSE;
        qtKeyToVirtualKey[Qt::Key_CapsLock] = VK_CAPITAL;
        qtKeyToVirtualKey[Qt::Key_Escape] = VK_ESCAPE;
        qtKeyToVirtualKey[Qt::Key_Mode_switch] = VK_MODECHANGE;
        qtKeyToVirtualKey[Qt::Key_Space] = VK_SPACE;
        qtKeyToVirtualKey[Qt::Key_PageUp] = VK_PRIOR;
        qtKeyToVirtualKey[Qt::Key_PageDown] = VK_NEXT;
        qtKeyToVirtualKey[Qt::Key_End] = VK_END;
        qtKeyToVirtualKey[Qt::Key_Home] = VK_HOME;
        qtKeyToVirtualKey[Qt::Key_Left] = VK_LEFT;
        qtKeyToVirtualKey[Qt::Key_Up] = VK_UP;
        qtKeyToVirtualKey[Qt::Key_Right] = VK_RIGHT;
        qtKeyToVirtualKey[Qt::Key_Down] = VK_DOWN;
        qtKeyToVirtualKey[Qt::Key_Select] = VK_SELECT;
        qtKeyToVirtualKey[Qt::Key_Printer] = VK_PRINT;
        qtKeyToVirtualKey[Qt::Key_Execute] = VK_EXECUTE;
        qtKeyToVirtualKey[Qt::Key_Print] = VK_SNAPSHOT;
        qtKeyToVirtualKey[Qt::Key_Insert] = VK_INSERT;
        qtKeyToVirtualKey[Qt::Key_Delete] = VK_DELETE;
        qtKeyToVirtualKey[Qt::Key_Help] = VK_HELP;
        qtKeyToVirtualKey[Qt::Key_Meta] = VK_LWIN;
        //qtKeyToWinVirtualKey[Qt::Key_Meta] = VK_RWIN;
        qtKeyToVirtualKey[Qt::Key_Menu] = VK_APPS;
        qtKeyToVirtualKey[Qt::Key_Sleep] = VK_SLEEP;

        qtKeyToVirtualKey[AntKey_KP_Multiply] = VK_MULTIPLY;
        //qtKeyToVirtualKey[Qt::Key_Asterisk] = VK_MULTIPLY;
        qtKeyToVirtualKey[AntKey_KP_Add] = VK_ADD;
        //qtKeyToVirtualKey[Qt::Key_Comma] = VK_SEPARATOR;
        qtKeyToVirtualKey[AntKey_KP_Subtract] = VK_SUBTRACT;
        qtKeyToVirtualKey[AntKey_KP_Decimal] = VK_DECIMAL;
        qtKeyToVirtualKey[AntKey_KP_Divide] = VK_DIVIDE;

        qtKeyToVirtualKey[Qt::Key_NumLock] = VK_NUMLOCK;
        qtKeyToVirtualKey[Qt::Key_ScrollLock] = VK_SCROLL;
        qtKeyToVirtualKey[Qt::Key_Massyo] = VK_OEM_FJ_MASSHOU;
        qtKeyToVirtualKey[Qt::Key_Touroku] = VK_OEM_FJ_TOUROKU;

        qtKeyToVirtualKey[Qt::Key_Shift] = VK_LSHIFT;
        //qtKeyToWinVirtualKey[Qt::Key_Shift] = VK_RSHIFT;
        qtKeyToVirtualKey[Qt::Key_Control] = VK_LCONTROL;
        //qtKeyToWinVirtualKey[Qt::Key_Control] = VK_RCONTROL;
        qtKeyToVirtualKey[Qt::Key_Alt] = VK_LMENU;
        //qtKeyToWinVirtualKey[Qt::Key_Alt] = VK_RMENU;
        qtKeyToVirtualKey[Qt::Key_Back] = VK_BROWSER_BACK;
        qtKeyToVirtualKey[Qt::Key_Forward] = VK_BROWSER_FORWARD;
        qtKeyToVirtualKey[Qt::Key_Refresh] = VK_BROWSER_REFRESH;
        qtKeyToVirtualKey[Qt::Key_Stop] = VK_BROWSER_STOP;
        qtKeyToVirtualKey[Qt::Key_Search] = VK_BROWSER_SEARCH;
        qtKeyToVirtualKey[Qt::Key_Favorites] = VK_BROWSER_FAVORITES;
        qtKeyToVirtualKey[Qt::Key_HomePage] = VK_BROWSER_HOME;
        qtKeyToVirtualKey[Qt::Key_VolumeMute] = VK_VOLUME_MUTE;
        qtKeyToVirtualKey[Qt::Key_VolumeDown] = VK_VOLUME_DOWN;
        qtKeyToVirtualKey[Qt::Key_VolumeUp] = VK_VOLUME_UP;
        qtKeyToVirtualKey[Qt::Key_MediaNext] = VK_MEDIA_NEXT_TRACK;
        qtKeyToVirtualKey[Qt::Key_MediaPrevious] = VK_MEDIA_PREV_TRACK;
        qtKeyToVirtualKey[Qt::Key_MediaStop] = VK_MEDIA_STOP;
        qtKeyToVirtualKey[Qt::Key_MediaPlay] = VK_MEDIA_PLAY_PAUSE;
        qtKeyToVirtualKey[Qt::Key_LaunchMail] = VK_LAUNCH_MAIL;
        qtKeyToVirtualKey[Qt::Key_LaunchMedia] = VK_LAUNCH_MEDIA_SELECT;
        qtKeyToVirtualKey[Qt::Key_Launch0] = VK_LAUNCH_APP1;
        qtKeyToVirtualKey[Qt::Key_Launch1] = VK_LAUNCH_APP2;
        qtKeyToVirtualKey[Qt::Key_Kanji] = VK_KANJI;

        // The following VK_OEM_* keys are consistent across all
        // keyboard layouts.
        qtKeyToVirtualKey[Qt::Key_Equal] = VK_OEM_PLUS;
        qtKeyToVirtualKey[Qt::Key_Minus] = VK_OEM_MINUS;
        qtKeyToVirtualKey[Qt::Key_Period]  = VK_OEM_PERIOD;
        qtKeyToVirtualKey[Qt::Key_Comma] = VK_OEM_COMMA;
        //qtKeyToVirtualKey[Qt::Key_Semicolon] = VK_OEM_1;
        //qtKeyToVirtualKey[Qt::Key_Slash] = VK_OEM_2;
        //qtKeyToVirtualKey[Qt::Key_Equal] = VK_OEM_PLUS;
        //qtKeyToVirtualKey[Qt::Key_Minus] = VK_OEM_MINUS;
        //qtKeyToVirtualKey[Qt::Key_Period]  = VK_OEM_PERIOD;
        //qtKeyToVirtualKey[Qt::Key_QuoteLeft] = VK_OEM_3;
        //qtKeyToVirtualKey[Qt::Key_BracketLeft] = VK_OEM_4;
        //qtKeyToVirtualKey[Qt::Key_Backslash] = VK_OEM_5;
        //qtKeyToVirtualKey[Qt::Key_BracketRight] = VK_OEM_6;
        //qtKeyToVirtualKey[Qt::Key_Apostrophe] = VK_OEM_7;

    qtKeyToVirtualKey[Qt::Key_Play] = VK_PLAY;
        qtKeyToVirtualKey[Qt::Key_Zoom] = VK_ZOOM;
        //qtKeyToWinVirtualKey[Qt::Key_Clear] = VK_OEM_CLEAR;

        // Map 0-9 ASCII codes
        for (int i = 0; i <= (0x39 - 0x30); i++)
        {
            qtKeyToVirtualKey[Qt::Key_0 + i] = 0x30 + i;
        }

        // Map A-Z ASCII codes
        for (int i = 0; i <= (0x5a - 0x41); i++)
        {
            qtKeyToVirtualKey[Qt::Key_A + i] = 0x41 + i;
        }

        // Map function keys
        for (int i = 0; i <= (VK_F24 - VK_F1); i++)
        {
            qtKeyToVirtualKey[Qt::Key_F1 + i] = VK_F1 + i;
        }

        // Map numpad keys
        for (int i = 0; i <= (VK_NUMPAD9 - VK_NUMPAD0); i++)
        {
            qtKeyToVirtualKey[AntKey_KP_0 + i] = VK_NUMPAD0 + i;
        }

        // Map custom keys
        qtKeyToVirtualKey[AntKey_Alt_R] = VK_RMENU;
        qtKeyToVirtualKey[AntKey_Meta_R] = VK_RWIN;
        qtKeyToVirtualKey[AntKey_Shift_R] = VK_RSHIFT;
        qtKeyToVirtualKey[AntKey_Control_R] = VK_RCONTROL;

        // Go through VK_OEM_* values and find the appropriate association
        // with a key defined in Qt. Association is decided based on char
        // returned from Windows for the VK_OEM_* key.
        QHashIterator<unsigned int, unsigned int> iterDynamic(dynamicOEMToQtKeyHash);
        while (iterDynamic.hasNext())
        {
            iterDynamic.next();

            byte ks[256];
char cbuf[2] = { '\0', '\0' };
            GetKeyboardState(ks);
unsigned int oemkey = iterDynamic.key();
unsigned int scancode = MapVirtualKey(oemkey, 0);
int charlength = ToAscii(oemkey, scancode, ks, (WORD*)cbuf, 0);
            if (charlength< 0)
            {
                charlength = ToAscii(VK_SPACE, scancode, ks, (WORD*)cbuf, 0);
                QString temp = QString::fromUtf8(cbuf);
                if (temp.length() > 0)
                {
                    QHashIterator<QString, unsigned int> tempiter(charToQtKeyHash);
                    while (tempiter.hasNext())
                    {
                        tempiter.next();
                        QString currentChar = tempiter.key();
                        if (currentChar == temp)
                        {
                            dynamicOEMToQtKeyHash[oemkey] = tempiter.value();
                            tempiter.toBack();
                        }
                    }
                }
            }
            else if (charlength == 1)
            {
                QString temp = QString::fromUtf8(cbuf);
QHashIterator<QString, unsigned int> tempiter(charToQtKeyHash);
                while (tempiter.hasNext())
                {
                    tempiter.next();
                    QString currentChar = tempiter.key();
                    if (currentChar == temp)
                    {
                        dynamicOEMToQtKeyHash[oemkey] = tempiter.value();
                        tempiter.toBack();
                    }
                }
            }
        }
    */
}
