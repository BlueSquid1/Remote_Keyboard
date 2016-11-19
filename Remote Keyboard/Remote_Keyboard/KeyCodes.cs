using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

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




    public enum SDLK : ushort
    {
        UNKNOWN = 0,
        RETURN = '\r',
        ESCAPE = '\033',
        BACKSPACE = '\b',
        TAB = '\t',
        SPACE = ' ',
        EXCLAIM = '!',
        QUOTEDBL = '"',
        HASH = '#',
        PERCENT = '%',
        DOLLAR = '$',
        AMPERSAND = '&',
        QUOTE = '\'',
        LEFTPAREN = '(',
        RIGHTPAREN = ')',
        ASTERISK = '*',
        PLUS = '+',
        COMMA = ',',
        MINUS = '-',
        PERIOD = '.',
        SLASH = '/',
        key_0 = '0',
        key_1 = '1',
        key_2 = '2',
        key_3 = '3',
        key_4 = '4',
        key_5 = '5',
        key_6 = '6',
        key_7 = '7',
        key_8 = '8',
        key_9 = '9',
        COLON = ':',
        SEMICOLON = ';',
        LESS = '<',
        EQUALS = '=',
        GREATER = '>',
        QUESTION = '?',
        AT = '@',
        //Skip uppercase letters
        LEFTBRACKET = '[',
        BACKSLASH = '\\',
        RIGHTBRACKET = ']',
        CARET = '^',
        UNDERSCORE = '_',
        BACKQUOTE = '`',
        a = 'a',
        b = 'b',
        c = 'c',
        d = 'd',
        e = 'e',
        f = 'f',
        g = 'g',
        h = 'h',
        i = 'i',
        j = 'j',
        k = 'k',
        l = 'l',
        m = 'm',
        n = 'n',
        o = 'o',
        p = 'p',
        q = 'q',
        r = 'r',
        s = 's',
        t = 't',
        u = 'u',
        v = 'v',
        w = 'w',
        x = 'x',
        y = 'y',
        z = 'z',

        /*
        CAPSLOCK = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CAPSLOCK),

        F1 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F1),
        F2 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F2),
        F3 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F3),
        F4 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F4),
        F5 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F5),
        F6 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F6),
        F7 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F7),
        F8 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F8),
        F9 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F9),
        F10 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F10),
        F11 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F11),
        F12 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F12),

        PRINTSCREEN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PRINTSCREEN),
        SCROLLLOCK = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SCROLLLOCK),
        PAUSE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PAUSE),
        INSERT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_INSERT),
        HOME = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_HOME),
        PAGEUP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PAGEUP),
        DELETE = '\177',
        END = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_END),
        PAGEDOWN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PAGEDOWN),
        RIGHT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RIGHT),
        LEFT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LEFT),
        DOWN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_DOWN),
        UP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_UP),

        NUMLOCKCLEAR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_NUMLOCKCLEAR),
        KP_DIVIDE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_DIVIDE),
        KP_MULTIPLY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MULTIPLY),
        KP_MINUS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MINUS),
        KP_PLUS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_PLUS),
        KP_ENTER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_ENTER),
        KP_1 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_1),
        KP_2 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_2),
        KP_3 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_3),
        KP_4 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_4),
        KP_5 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_5),
        KP_6 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_6),
        KP_7 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_7),
        KP_8 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_8),
        KP_9 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_9),
        KP_0 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_0),
        KP_PERIOD = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_PERIOD),

        APPLICATION = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_APPLICATION),
        POWER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_POWER),
        KP_EQUALS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_EQUALS),
        F13 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F13),
        F14 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F14),
        F15 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F15),
        F16 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F16),
        F17 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F17),
        F18 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F18),
        F19 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F19),
        F20 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F20),
        F21 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F21),
        F22 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F22),
        F23 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F23),
        F24 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F24),
        EXECUTE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_EXECUTE),
        HELP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_HELP),
        MENU = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MENU),
        SELECT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SELECT),
        STOP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_STOP),
        AGAIN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AGAIN),
        UNDO = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_UNDO),
        CUT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CUT),
        COPY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_COPY),
        PASTE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PASTE),
        FIND = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_FIND),
        MUTE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MUTE),
        VOLUMEUP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_VOLUMEUP),
        VOLUMEDOWN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_VOLUMEDOWN),
        KP_COMMA = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_COMMA),
        KP_EQUALSAS400 =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_EQUALSAS400),

        ALTERASE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_ALTERASE),
        SYSREQ = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SYSREQ),
        CANCEL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CANCEL),
        CLEAR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CLEAR),
        PRIOR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PRIOR),
        RETURN2 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RETURN2),
        SEPARATOR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SEPARATOR),
        OUT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_OUT),
        OPER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_OPER),
        CLEARAGAIN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CLEARAGAIN),
        CRSEL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CRSEL),
        EXSEL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_EXSEL),

        KP_00 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_00),
        KP_000 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_000),
        THOUSANDSSEPARATOR =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_THOUSANDSSEPARATOR),
        DECIMALSEPARATOR =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_DECIMALSEPARATOR),
        CURRENCYUNIT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CURRENCYUNIT),
        CURRENCYSUBUNIT =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CURRENCYSUBUNIT),
        KP_LEFTPAREN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_LEFTPAREN),
        KP_RIGHTPAREN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_RIGHTPAREN),
        KP_LEFTBRACE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_LEFTBRACE),
        KP_RIGHTBRACE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_RIGHTBRACE),
        KP_TAB = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_TAB),
        KP_BACKSPACE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_BACKSPACE),
        KP_A = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_A),
        KP_B = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_B),
        KP_C = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_C),
        KP_D = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_D),
        KP_E = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_E),
        KP_F = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_F),
        KP_XOR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_XOR),
        KP_POWER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_POWER),
        KP_PERCENT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_PERCENT),
        KP_LESS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_LESS),
        KP_GREATER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_GREATER),
        KP_AMPERSAND = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_AMPERSAND),
        KP_DBLAMPERSAND =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_DBLAMPERSAND),
        KP_VERTICALBAR =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_VERTICALBAR),
        KP_DBLVERTICALBAR =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_DBLVERTICALBAR),
        KP_COLON = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_COLON),
        KP_HASH = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_HASH),
        KP_SPACE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_SPACE),
        KP_AT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_AT),
        KP_EXCLAM = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_EXCLAM),
        KP_MEMSTORE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMSTORE),
        KP_MEMRECALL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMRECALL),
        KP_MEMCLEAR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMCLEAR),
        KP_MEMADD = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMADD),
        KP_MEMSUBTRACT =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMSUBTRACT),
        KP_MEMMULTIPLY =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMMULTIPLY),
        KP_MEMDIVIDE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMDIVIDE),
        KP_PLUSMINUS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_PLUSMINUS),
        KP_CLEAR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_CLEAR),
        KP_CLEARENTRY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_CLEARENTRY),
        KP_BINARY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_BINARY),
        KP_OCTAL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_OCTAL),
        KP_DECIMAL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_DECIMAL),
        KP_HEXADECIMAL =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_HEXADECIMAL),

        LCTRL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LCTRL),
        LSHIFT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LSHIFT),
        LALT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LALT),
        LGUI = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LGUI),
        RCTRL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RCTRL),
        RSHIFT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RSHIFT),
        RALT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RALT),
        RGUI = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RGUI),

        MODE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MODE),

        AUDIONEXT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIONEXT),
        AUDIOPREV = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIOPREV),
        AUDIOSTOP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIOSTOP),
        AUDIOPLAY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIOPLAY),
        AUDIOMUTE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIOMUTE),
        MEDIASELECT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MEDIASELECT),
        WWW = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_WWW),
        MAIL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MAIL),
        CALCULATOR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CALCULATOR),
        COMPUTER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_COMPUTER),
        AC_SEARCH = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_SEARCH),
        AC_HOME = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_HOME),
        AC_BACK = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_BACK),
        AC_FORWARD = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_FORWARD),
        AC_STOP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_STOP),
        AC_REFRESH = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_REFRESH),
        AC_BOOKMARKS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_BOOKMARKS),

        BRIGHTNESSDOWN =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_BRIGHTNESSDOWN),
        BRIGHTNESSUP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_BRIGHTNESSUP),
        DISPLAYSWITCH = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_DISPLAYSWITCH),
        KBDILLUMTOGGLE =
            SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KBDILLUMTOGGLE),
        KBDILLUMDOWN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KBDILLUMDOWN),
        KBDILLUMUP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KBDILLUMUP),
        EJECT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_EJECT),
        SLEEP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SLEEP)
    }
    /*     
    SDLK_UNKNOWN = 0,
    SDLK_RETURN = '\r',
    SDLK_ESCAPE = '\033',
    SDLK_BACKSPACE = '\b',
    SDLK_TAB = '\t',
    SDLK_SPACE = ' ',
    SDLK_EXCLAIM = '!',
    SDLK_QUOTEDBL = '"',
    SDLK_HASH = '#',
    SDLK_PERCENT = '%',
    SDLK_DOLLAR = '$',
    SDLK_AMPERSAND = '&',
    SDLK_QUOTE = '\'',
    SDLK_LEFTPAREN = '(',
    SDLK_RIGHTPAREN = ')',
    SDLK_ASTERISK = '*',
    SDLK_PLUS = '+',
    SDLK_COMMA = ',',
    SDLK_MINUS = '-',
    SDLK_PERIOD = '.',
    SDLK_SLASH = '/',
    SDLK_0 = '0',
    SDLK_1 = '1',
    SDLK_2 = '2',
    SDLK_3 = '3',
    SDLK_4 = '4',
    SDLK_5 = '5',
    SDLK_6 = '6',
    SDLK_7 = '7',
    SDLK_8 = '8',
    SDLK_9 = '9',
    SDLK_COLON = ':',
    SDLK_SEMICOLON = ';',
    SDLK_LESS = '<',
    SDLK_EQUALS = '=',
    SDLK_GREATER = '>',
    SDLK_QUESTION = '?',
    SDLK_AT = '@',
    //Skip uppercase letters
    SDLK_LEFTBRACKET = '[',
    SDLK_BACKSLASH = '\\',
    SDLK_RIGHTBRACKET = ']',
    SDLK_CARET = '^',
    SDLK_UNDERSCORE = '_',
    SDLK_BACKQUOTE = '`',
    SDLK_a = 'a',
    SDLK_b = 'b',
    SDLK_c = 'c',
    SDLK_d = 'd',
    SDLK_e = 'e',
    SDLK_f = 'f',
    SDLK_g = 'g',
    SDLK_h = 'h',
    SDLK_i = 'i',
    SDLK_j = 'j',
    SDLK_k = 'k',
    SDLK_l = 'l',
    SDLK_m = 'm',
    SDLK_n = 'n',
    SDLK_o = 'o',
    SDLK_p = 'p',
    SDLK_q = 'q',
    SDLK_r = 'r',
    SDLK_s = 's',
    SDLK_t = 't',
    SDLK_u = 'u',
    SDLK_v = 'v',
    SDLK_w = 'w',
    SDLK_x = 'x',
    SDLK_y = 'y',
    SDLK_z = 'z',

    SDLK_CAPSLOCK = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CAPSLOCK),

    SDLK_F1 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F1),
    SDLK_F2 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F2),
    SDLK_F3 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F3),
    SDLK_F4 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F4),
    SDLK_F5 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F5),
    SDLK_F6 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F6),
    SDLK_F7 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F7),
    SDLK_F8 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F8),
    SDLK_F9 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F9),
    SDLK_F10 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F10),
    SDLK_F11 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F11),
    SDLK_F12 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F12),

    SDLK_PRINTSCREEN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PRINTSCREEN),
    SDLK_SCROLLLOCK = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SCROLLLOCK),
    SDLK_PAUSE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PAUSE),
    SDLK_INSERT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_INSERT),
    SDLK_HOME = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_HOME),
    SDLK_PAGEUP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PAGEUP),
    SDLK_DELETE = '\177',
    SDLK_END = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_END),
    SDLK_PAGEDOWN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PAGEDOWN),
    SDLK_RIGHT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RIGHT),
    SDLK_LEFT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LEFT),
    SDLK_DOWN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_DOWN),
    SDLK_UP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_UP),

    SDLK_NUMLOCKCLEAR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_NUMLOCKCLEAR),
    SDLK_KP_DIVIDE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_DIVIDE),
    SDLK_KP_MULTIPLY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MULTIPLY),
    SDLK_KP_MINUS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MINUS),
    SDLK_KP_PLUS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_PLUS),
    SDLK_KP_ENTER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_ENTER),
    SDLK_KP_1 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_1),
    SDLK_KP_2 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_2),
    SDLK_KP_3 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_3),
    SDLK_KP_4 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_4),
    SDLK_KP_5 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_5),
    SDLK_KP_6 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_6),
    SDLK_KP_7 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_7),
    SDLK_KP_8 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_8),
    SDLK_KP_9 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_9),
    SDLK_KP_0 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_0),
    SDLK_KP_PERIOD = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_PERIOD),

    SDLK_APPLICATION = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_APPLICATION),
    SDLK_POWER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_POWER),
    SDLK_KP_EQUALS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_EQUALS),
    SDLK_F13 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F13),
    SDLK_F14 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F14),
    SDLK_F15 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F15),
    SDLK_F16 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F16),
    SDLK_F17 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F17),
    SDLK_F18 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F18),
    SDLK_F19 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F19),
    SDLK_F20 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F20),
    SDLK_F21 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F21),
    SDLK_F22 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F22),
    SDLK_F23 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F23),
    SDLK_F24 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_F24),
    SDLK_EXECUTE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_EXECUTE),
    SDLK_HELP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_HELP),
    SDLK_MENU = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MENU),
    SDLK_SELECT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SELECT),
    SDLK_STOP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_STOP),
    SDLK_AGAIN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AGAIN),
    SDLK_UNDO = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_UNDO),
    SDLK_CUT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CUT),
    SDLK_COPY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_COPY),
    SDLK_PASTE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PASTE),
    SDLK_FIND = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_FIND),
    SDLK_MUTE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MUTE),
    SDLK_VOLUMEUP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_VOLUMEUP),
    SDLK_VOLUMEDOWN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_VOLUMEDOWN),
    SDLK_KP_COMMA = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_COMMA),
    SDLK_KP_EQUALSAS400 =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_EQUALSAS400),

    SDLK_ALTERASE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_ALTERASE),
    SDLK_SYSREQ = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SYSREQ),
    SDLK_CANCEL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CANCEL),
    SDLK_CLEAR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CLEAR),
    SDLK_PRIOR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_PRIOR),
    SDLK_RETURN2 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RETURN2),
    SDLK_SEPARATOR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SEPARATOR),
    SDLK_OUT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_OUT),
    SDLK_OPER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_OPER),
    SDLK_CLEARAGAIN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CLEARAGAIN),
    SDLK_CRSEL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CRSEL),
    SDLK_EXSEL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_EXSEL),

    SDLK_KP_00 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_00),
    SDLK_KP_000 = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_000),
    SDLK_THOUSANDSSEPARATOR =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_THOUSANDSSEPARATOR),
    SDLK_DECIMALSEPARATOR =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_DECIMALSEPARATOR),
    SDLK_CURRENCYUNIT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CURRENCYUNIT),
    SDLK_CURRENCYSUBUNIT =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CURRENCYSUBUNIT),
    SDLK_KP_LEFTPAREN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_LEFTPAREN),
    SDLK_KP_RIGHTPAREN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_RIGHTPAREN),
    SDLK_KP_LEFTBRACE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_LEFTBRACE),
    SDLK_KP_RIGHTBRACE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_RIGHTBRACE),
    SDLK_KP_TAB = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_TAB),
    SDLK_KP_BACKSPACE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_BACKSPACE),
    SDLK_KP_A = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_A),
    SDLK_KP_B = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_B),
    SDLK_KP_C = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_C),
    SDLK_KP_D = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_D),
    SDLK_KP_E = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_E),
    SDLK_KP_F = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_F),
    SDLK_KP_XOR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_XOR),
    SDLK_KP_POWER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_POWER),
    SDLK_KP_PERCENT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_PERCENT),
    SDLK_KP_LESS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_LESS),
    SDLK_KP_GREATER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_GREATER),
    SDLK_KP_AMPERSAND = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_AMPERSAND),
    SDLK_KP_DBLAMPERSAND =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_DBLAMPERSAND),
    SDLK_KP_VERTICALBAR =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_VERTICALBAR),
    SDLK_KP_DBLVERTICALBAR =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_DBLVERTICALBAR),
    SDLK_KP_COLON = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_COLON),
    SDLK_KP_HASH = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_HASH),
    SDLK_KP_SPACE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_SPACE),
    SDLK_KP_AT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_AT),
    SDLK_KP_EXCLAM = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_EXCLAM),
    SDLK_KP_MEMSTORE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMSTORE),
    SDLK_KP_MEMRECALL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMRECALL),
    SDLK_KP_MEMCLEAR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMCLEAR),
    SDLK_KP_MEMADD = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMADD),
    SDLK_KP_MEMSUBTRACT =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMSUBTRACT),
    SDLK_KP_MEMMULTIPLY =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMMULTIPLY),
    SDLK_KP_MEMDIVIDE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_MEMDIVIDE),
    SDLK_KP_PLUSMINUS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_PLUSMINUS),
    SDLK_KP_CLEAR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_CLEAR),
    SDLK_KP_CLEARENTRY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_CLEARENTRY),
    SDLK_KP_BINARY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_BINARY),
    SDLK_KP_OCTAL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_OCTAL),
    SDLK_KP_DECIMAL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_DECIMAL),
    SDLK_KP_HEXADECIMAL =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KP_HEXADECIMAL),

    SDLK_LCTRL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LCTRL),
    SDLK_LSHIFT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LSHIFT),
    SDLK_LALT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LALT),
    SDLK_LGUI = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_LGUI),
    SDLK_RCTRL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RCTRL),
    SDLK_RSHIFT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RSHIFT),
    SDLK_RALT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RALT),
    SDLK_RGUI = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_RGUI),

    SDLK_MODE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MODE),

    SDLK_AUDIONEXT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIONEXT),
    SDLK_AUDIOPREV = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIOPREV),
    SDLK_AUDIOSTOP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIOSTOP),
    SDLK_AUDIOPLAY = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIOPLAY),
    SDLK_AUDIOMUTE = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AUDIOMUTE),
    SDLK_MEDIASELECT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MEDIASELECT),
    SDLK_WWW = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_WWW),
    SDLK_MAIL = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_MAIL),
    SDLK_CALCULATOR = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_CALCULATOR),
    SDLK_COMPUTER = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_COMPUTER),
    SDLK_AC_SEARCH = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_SEARCH),
    SDLK_AC_HOME = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_HOME),
    SDLK_AC_BACK = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_BACK),
    SDLK_AC_FORWARD = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_FORWARD),
    SDLK_AC_STOP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_STOP),
    SDLK_AC_REFRESH = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_REFRESH),
    SDLK_AC_BOOKMARKS = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_AC_BOOKMARKS),

    SDLK_BRIGHTNESSDOWN =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_BRIGHTNESSDOWN),
    SDLK_BRIGHTNESSUP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_BRIGHTNESSUP),
    SDLK_DISPLAYSWITCH = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_DISPLAYSWITCH),
    SDLK_KBDILLUMTOGGLE =
        SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KBDILLUMTOGGLE),
    SDLK_KBDILLUMDOWN = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KBDILLUMDOWN),
    SDLK_KBDILLUMUP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_KBDILLUMUP),
    SDLK_EJECT = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_EJECT),
    SDLK_SLEEP = SDL_SCANCODE_TO_KEYCODE(SDL_SCANCODE_SLEEP)

     */

}
