using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace DownLoad.Core
{
    public class FollowMainWinHelper
    {
        private Control FollowMainWin;
        public FollowMainWinHelper()
        {
        }
        public FollowMainWinHelper(Control ctrl)
        {
            FollowMainWin = ctrl;
        }
        private  Dictionary<string, IntPtr> WinHanles = new Dictionary<string, IntPtr>();
        private  IntPtr _ConsoleHandle = IntPtr.Zero;

        public  IntPtr ConsoleHandle
        {
            get { return _ConsoleHandle; }
            set { _ConsoleHandle = value; }
        }


        public  void AddWinHandle(string key, IntPtr handle)
        {
            if (WinHanles.Keys.Contains(key))
            {
                WinHanles[key] = handle;
            }
            else
            {
                WinHanles.Add(key, handle);
            }
        }
        public  bool IsExistsKey(string key)
        {
            return WinHanles.Keys.Contains(key);

        }
        public  void RemoveWinHandle(string key)
        {
            WinHanles.Remove(key);
        }
        public  void MoveWin()
        {
            foreach (var item in WinHanles.Keys)
            {
                MoveWinByHandle(WinHanles[item]);
            }
        }
        public  void MoveWinByKey(string key)
        {
            MoveWinByHandle(WinHanles[key]);
        }

        public  void MoveWinByHandle(IntPtr handle)
        {
            if (FollowMainWin == null)
                return;
            int x = 0;
            int y = FollowMainWin.Location.Y;
            if (FollowMainWin.Location.X > Screen.PrimaryScreen.Bounds.Width / 2 + 100)
            {
                x = FollowMainWin.Location.X - 850;
            }
            else
            {
                x = FollowMainWin.Location.X + FollowMainWin.Size.Width;
            }
            int nWidth = 850;
            int nHeight = FollowMainWin.Size.Height;
            WinApiHelper.MoveWindow(handle, x, y, nWidth, nHeight, true);

        }

        public  void SetTopMost(string key)
        {
            WinApiHelper.SetForegroundWindow(WinHanles[key]);
        }

        public  void LoadConsole(object wrapper)
        {

            WinApiHelper.AllocConsole();
            ConsoleHandle = WinApiHelper.FindWindow(null, Process.GetCurrentProcess().MainModule.FileName);
            IntPtr closeMenu = WinApiHelper.GetSystemMenu(ConsoleHandle, IntPtr.Zero);
            uint SC_CLOSE = 0xF060;
            WinApiHelper.RemoveMenu(closeMenu, SC_CLOSE, 0x0);
            HandleRef ParentHandle = new HandleRef(wrapper, ConsoleHandle);
            // 初始化窗口风格
            IntPtr Style = WinApiHelper.GetWindowLongPtr(ConsoleHandle, WinApiHelper.GWL_STYLE);
            uint tempStyle = (uint)Style.ToInt32() & ~WinApiHelper.WS_CAPTION & ~WinApiHelper.WS_SYSMENU & ~WinApiHelper.WS_SIZEBOX;
            WinApiHelper.SetWindowLongPtr(ParentHandle, WinApiHelper.GWL_STYLE, new IntPtr(tempStyle));
            

            WinApiHelper.SetParent(ConsoleHandle, ((Control)wrapper).Handle); //panel1.Handle为要显示外部程序的容器
            WinApiHelper.ShowWindow(ConsoleHandle, 3);       
        }
        public  void FreeConsole(object wrapper)
        {

            WinApiHelper.FreeConsole();
            ConsoleHandle = IntPtr.Zero;
            //ConsoleHandle = WinApiHelper.FindWindow(null, Process.GetCurrentProcess().MainModule.FileName);
            //IntPtr closeMenu = WinApiHelper.GetSystemMenu(ConsoleHandle, IntPtr.Zero);
            //uint SC_CLOSE = 0xF060;
            //WinApiHelper.RemoveMenu(closeMenu, SC_CLOSE, 0x0);
            //HandleRef ParentHandle = new HandleRef(wrapper, ConsoleHandle);
            //// 初始化窗口风格
            //IntPtr Style = WinApiHelper.GetWindowLongPtr(ConsoleHandle, WinApiHelper.GWL_STYLE);
            //uint tempStyle = (uint)Style.ToInt32() & ~WinApiHelper.WS_CAPTION & ~WinApiHelper.WS_SYSMENU & ~WinApiHelper.WS_SIZEBOX;
            //WinApiHelper.SetWindowLongPtr(ParentHandle, WinApiHelper.GWL_STYLE, new IntPtr(tempStyle));

            //WinApiHelper.SetParent(windowHandle, this.pconsole.Handle); //panel1.Handle为要显示外部程序的容器
            //WinApiHelper.ShowWindow(windowHandle, 3);       
        }
        public  void MoveConsole()
        {
            if (ConsoleHandle == IntPtr.Zero)
                return;
            MoveWinByHandle(ConsoleHandle);
        }


        #region Win32 Methods

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetConsoleOutputCP();

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool SetConsoleTextAttribute(
            IntPtr consoleHandle,
            ushort attributes);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetConsoleScreenBufferInfo(
            IntPtr consoleHandle,
            out CONSOLE_SCREEN_BUFFER_INFO bufferInfo);

        //		[DllImport("Kernel32.dll", SetLastError=true, CharSet=CharSet.Unicode)]
        //		private static extern bool WriteConsoleW(
        //			IntPtr hConsoleHandle,
        //			[MarshalAs(UnmanagedType.LPWStr)] string strBuffer,
        //			UInt32 bufferLen,
        //			out UInt32 written,
        //			IntPtr reserved);

        //private const UInt32 STD_INPUT_HANDLE = unchecked((UInt32)(-10));
        private const UInt32 STD_OUTPUT_HANDLE = unchecked((UInt32)(-11));
        private const UInt32 STD_ERROR_HANDLE = unchecked((UInt32)(-12));

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetStdHandle(
            UInt32 type);

        [StructLayout(LayoutKind.Sequential)]
        private struct COORD
        {
            public UInt16 x;
            public UInt16 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SMALL_RECT
        {
            public UInt16 Left;
            public UInt16 Top;
            public UInt16 Right;
            public UInt16 Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CONSOLE_SCREEN_BUFFER_INFO
        {
            public COORD dwSize;
            public COORD dwCursorPosition;
            public ushort wAttributes;
            public SMALL_RECT srWindow;
            public COORD dwMaximumWindowSize;
        }

        #endregion // Win32 Methods

    }
}
