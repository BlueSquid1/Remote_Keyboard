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
        #region Media

        /// <summary>
        /// Next track if a song is playing
        /// </summary>
        MEDIA_NEXT_TRACK = 0xb0,

        /// <summary>
        /// Play pause
        /// </summary>
        MEDIA_PLAY_PAUSE = 0xb3,

        /// <summary>
        /// Previous track
        /// </summary>
        MEDIA_PREV_TRACK = 0xb1,

        /// <summary>
        /// Stop
        /// </summary>
        MEDIA_STOP = 0xb2,

        #endregion

        #region math

        /// <summary>Key "+"</summary>
        ADD = 0x6b,
        /// <summary>
        /// "*" key
        /// </summary>
        MULTIPLY = 0x6a,

        /// <summary>
        /// "/" key
        /// </summary>
        DIVIDE = 0x6f,

        /// <summary>
        /// Subtract key "-"
        /// </summary>
        SUBTRACT = 0x6d,

        #endregion

        #region Browser
        /// <summary>
        /// Go Back
        /// </summary>
        BROWSER_BACK = 0xa6,
        /// <summary>
        /// Favorites
        /// </summary>
        BROWSER_FAVORITES = 0xab,
        /// <summary>
        /// Forward
        /// </summary>
        BROWSER_FORWARD = 0xa7,
        /// <summary>
        /// Home
        /// </summary>
        BROWSER_HOME = 0xac,
        /// <summary>
        /// Refresh
        /// </summary>
        BROWSER_REFRESH = 0xa8,
        /// <summary>
        /// browser search
        /// </summary>
        BROWSER_SEARCH = 170,
        /// <summary>
        /// Stop
        /// </summary>
        BROWSER_STOP = 0xa9,
        #endregion

        #region Numpad numbers
        /// <summary>
        /// 
        /// </summary>
        NUMPAD0 = 0x60,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD1 = 0x61,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD2 = 0x62,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD3 = 0x63,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD4 = 100,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD5 = 0x65,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD6 = 0x66,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD7 = 0x67,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD8 = 0x68,
        /// <summary>
        /// 
        /// </summary>
        NUMPAD9 = 0x69,

        #endregion

        #region Fkeys
        /// <summary>
        /// F1
        /// </summary>
        F1 = 0x70,
        /// <summary>
        /// F10
        /// </summary>
        F10 = 0x79,
        /// <summary>
        /// 
        /// </summary>
        F11 = 0x7a,
        /// <summary>
        /// 
        /// </summary>
        F12 = 0x7b,
        /// <summary>
        /// 
        /// </summary>
        F13 = 0x7c,
        /// <summary>
        /// 
        /// </summary>
        F14 = 0x7d,
        /// <summary>
        /// 
        /// </summary>
        F15 = 0x7e,
        /// <summary>
        /// 
        /// </summary>
        F16 = 0x7f,
        /// <summary>
        /// 
        /// </summary>
        F17 = 0x80,
        /// <summary>
        /// 
        /// </summary>
        F18 = 0x81,
        /// <summary>
        /// 
        /// </summary>
        F19 = 130,
        /// <summary>
        /// 
        /// </summary>
        F2 = 0x71,
        /// <summary>
        /// 
        /// </summary>
        F20 = 0x83,
        /// <summary>
        /// 
        /// </summary>
        F21 = 0x84,
        /// <summary>
        /// 
        /// </summary>
        F22 = 0x85,
        /// <summary>
        /// 
        /// </summary>
        F23 = 0x86,
        /// <summary>
        /// 
        /// </summary>
        F24 = 0x87,
        /// <summary>
        /// 
        /// </summary>
        F3 = 0x72,
        /// <summary>
        /// 
        /// </summary>
        F4 = 0x73,
        /// <summary>
        /// 
        /// </summary>
        F5 = 0x74,
        /// <summary>
        /// 
        /// </summary>
        F6 = 0x75,
        /// <summary>
        /// 
        /// </summary>
        F7 = 0x76,
        /// <summary>
        /// 
        /// </summary>
        F8 = 0x77,
        /// <summary>
        /// 
        /// </summary>
        F9 = 120,

        #endregion

        #region Other
        /// <summary>
        /// 
        /// </summary>
        OEM_1 = 0xba,
        /// <summary>
        /// 
        /// </summary>
        OEM_102 = 0xe2,
        /// <summary>
        /// 
        /// </summary>
        OEM_2 = 0xbf,
        /// <summary>
        /// 
        /// </summary>
        OEM_3 = 0xc0,
        /// <summary>
        /// 
        /// </summary>
        OEM_4 = 0xdb,
        /// <summary>
        /// 
        /// </summary>
        OEM_5 = 220,
        /// <summary>
        /// 
        /// </summary>
        OEM_6 = 0xdd,
        /// <summary>
        /// 
        /// </summary>
        OEM_7 = 0xde,
        /// <summary>
        /// 
        /// </summary>
        OEM_8 = 0xdf,
        /// <summary>
        /// 
        /// </summary>
        OEM_CLEAR = 0xfe,
        /// <summary>
        /// 
        /// </summary>
        OEM_COMMA = 0xbc,
        /// <summary>
        /// 
        /// </summary>
        OEM_MINUS = 0xbd,
        /// <summary>
        /// 
        /// </summary>
        OEM_PERIOD = 190,
        /// <summary>
        /// 
        /// </summary>
        OEM_PLUS = 0xbb,

        #endregion

        #region KEYS

        /// <summary>
        /// 
        /// </summary>
        KEY_0 = 0x30,
        /// <summary>
        /// 
        /// </summary>
        KEY_1 = 0x31,
        /// <summary>
        /// 
        /// </summary>
        KEY_2 = 50,
        /// <summary>
        /// 
        /// </summary>
        KEY_3 = 0x33,
        /// <summary>
        /// 
        /// </summary>
        KEY_4 = 0x34,
        /// <summary>
        /// 
        /// </summary>
        KEY_5 = 0x35,
        /// <summary>
        /// 
        /// </summary>
        KEY_6 = 0x36,
        /// <summary>
        /// 
        /// </summary>
        KEY_7 = 0x37,
        /// <summary>
        /// 
        /// </summary>
        KEY_8 = 0x38,
        /// <summary>
        /// 
        /// </summary>
        KEY_9 = 0x39,
        /// <summary>
        /// 
        /// </summary>
        KEY_A = 0x41,
        /// <summary>
        /// 
        /// </summary>
        KEY_B = 0x42,
        /// <summary>
        /// 
        /// </summary>
        KEY_C = 0x43,
        /// <summary>
        /// 
        /// </summary>
        KEY_D = 0x44,
        /// <summary>
        /// 
        /// </summary>
        KEY_E = 0x45,
        /// <summary>
        /// 
        /// </summary>
        KEY_F = 70,
        /// <summary>
        /// 
        /// </summary>
        KEY_G = 0x47,
        /// <summary>
        /// 
        /// </summary>
        KEY_H = 0x48,
        /// <summary>
        /// 
        /// </summary>
        KEY_I = 0x49,
        /// <summary>
        /// 
        /// </summary>
        KEY_J = 0x4a,
        /// <summary>
        /// 
        /// </summary>
        KEY_K = 0x4b,
        /// <summary>
        /// 
        /// </summary>
        KEY_L = 0x4c,
        /// <summary>
        /// 
        /// </summary>
        KEY_M = 0x4d,
        /// <summary>
        /// 
        /// </summary>
        KEY_N = 0x4e,
        /// <summary>
        /// 
        /// </summary>
        KEY_O = 0x4f,
        /// <summary>
        /// 
        /// </summary>
        KEY_P = 80,
        /// <summary>
        /// 
        /// </summary>
        KEY_Q = 0x51,
        /// <summary>
        /// 
        /// </summary>
        KEY_R = 0x52,
        /// <summary>
        /// 
        /// </summary>
        KEY_S = 0x53,
        /// <summary>
        /// 
        /// </summary>
        KEY_T = 0x54,
        /// <summary>
        /// 
        /// </summary>
        KEY_U = 0x55,
        /// <summary>
        /// 
        /// </summary>
        KEY_V = 0x56,
        /// <summary>
        /// 
        /// </summary>
        KEY_W = 0x57,
        /// <summary>
        /// 
        /// </summary>
        KEY_X = 0x58,
        /// <summary>
        /// 
        /// </summary>
        KEY_Y = 0x59,
        /// <summary>
        /// 
        /// </summary>
        KEY_Z = 90,

        #endregion

        #region volume
        /// <summary>
        /// Decrese volume
        /// </summary>
        VOLUME_DOWN = 0xae,

        /// <summary>
        /// Mute volume
        /// </summary>
        VOLUME_MUTE = 0xad,

        /// <summary>
        /// Increase volue
        /// </summary>
        VOLUME_UP = 0xaf,

        #endregion

        #region Special

        /// <summary>
        /// Take snapshot of the screen and place it on the clipboard
        /// </summary>
        SNAPSHOT = 0x2c,

        /// <summary>Send right click from keyboard "key that is 2 keys to the right of space bar"</summary>
        RightClick = 0x5d,

        /// <summary>
        /// Go Back or delete
        /// </summary>
        BACKSPACE = 8,

        /// <summary>
        /// Control + Break "When debuging if you step into an infinite loop this will stop debug"
        /// </summary>
        CANCEL = 3,
        /// <summary>
        /// Caps lock key to send cappital letters
        /// </summary>
        CAPS_LOCK = 20,
        /// <summary>
        /// Ctlr key
        /// </summary>
        CONTROL = 0x11,

        /// <summary>
        /// Alt key
        /// </summary>
        ALT = 18,

        /// <summary>
        /// "." key
        /// </summary>
        DECIMAL = 110,

        /// <summary>
        /// Delete Key
        /// </summary>
        DELETE = 0x2e,


        /// <summary>
        /// Arrow down key
        /// </summary>
        DOWN = 40,

        /// <summary>
        /// End key
        /// </summary>
        END = 0x23,

        /// <summary>
        /// Escape key
        /// </summary>
        ESC = 0x1b,

        /// <summary>
        /// Home key
        /// </summary>
        HOME = 0x24,

        /// <summary>
        /// Insert key
        /// </summary>
        INSERT = 0x2d,

        /// <summary>
        /// Open my computer
        /// </summary>
        LAUNCH_APP1 = 0xb6,
        /// <summary>
        /// Open calculator
        /// </summary>
        LAUNCH_APP2 = 0xb7,

        /// <summary>
        /// Open default email in my case outlook
        /// </summary>
        LAUNCH_MAIL = 180,

        /// <summary>
        /// Opend default media player (itunes, winmediaplayer, etc)
        /// </summary>
        LAUNCH_MEDIA_SELECT = 0xb5,

        /// <summary>
        /// Left control
        /// </summary>
        LCONTROL = 0xa2,

        /// <summary>
        /// Left arrow
        /// </summary>
        LEFT = 0x25,

        /// <summary>
        /// Left shift
        /// </summary>
        LSHIFT = 160,

        /// <summary>
        /// left windows key
        /// </summary>
        LWIN = 0x5b,


        /// <summary>
        /// Next "page down"
        /// </summary>
        PAGEDOWN = 0x22,

        /// <summary>
        /// Num lock to enable typing numbers
        /// </summary>
        NUMLOCK = 0x90,

        /// <summary>
        /// Page up key
        /// </summary>
        PAGE_UP = 0x21,

        /// <summary>
        /// Right control
        /// </summary>
        RCONTROL = 0xa3,

        /// <summary>
        /// Return key
        /// </summary>
        ENTER = 13,

        /// <summary>
        /// Right arrow key
        /// </summary>
        RIGHT = 0x27,

        /// <summary>
        /// Right shift
        /// </summary>
        RSHIFT = 0xa1,

        /// <summary>
        /// Right windows key
        /// </summary>
        RWIN = 0x5c,

        /// <summary>
        /// Shift key
        /// </summary>
        SHIFT = 0x10,

        /// <summary>
        /// Space back key
        /// </summary>
        SPACE_BAR = 0x20,

        /// <summary>
        /// Tab key
        /// </summary>
        TAB = 9,

        /// <summary>
        /// Up arrow key
        /// </summary>
        UP = 0x26,
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
