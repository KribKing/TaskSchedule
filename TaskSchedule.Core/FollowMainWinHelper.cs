using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace TaskSchedule.Core
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
        private Dictionary<string, IntPtr> WinHanles = new Dictionary<string, IntPtr>();
        private IntPtr _ConsoleHandle = IntPtr.Zero;

        public IntPtr ConsoleHandle
        {
            get { return _ConsoleHandle; }
            set { _ConsoleHandle = value; }
        }


        public void AddWinHandle(string key, IntPtr handle)
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
        public bool IsExistsKey(string key)
        {
            return WinHanles.Keys.Contains(key);

        }
        public void RemoveWinHandle(string key)
        {
            WinHanles.Remove(key);
        }
        public void CloseWin(string key)
        {
            if (!WinHanles.ContainsKey(key))
                return;
            CloseWin(WinHanles[key]);
        }
        public void CloseWin(IntPtr handle)
        {
            WinApiHelper.SendMessage(handle, WinApiHelper.WM_SYSCOMMAND, WinApiHelper.SC_CLOSE, 0);
        }
        public void MoveWin()
        {
            foreach (var item in WinHanles.Keys)
            {
                MoveWinByHandle(WinHanles[item]);
            }
        }
        public void MoveWinByKey(string key)
        {
            MoveWinByHandle(WinHanles[key]);
        }

        public void MoveWinByHandle(IntPtr handle)
        {
            if (FollowMainWin == null)
                return;
            int x = 0;
            int y = FollowMainWin.Location.Y;
            if (FollowMainWin.Location.X > Screen.PrimaryScreen.Bounds.Width / 2 + 100)
            {
                x = FollowMainWin.Location.X - 900;
            }
            else
            {
                x = FollowMainWin.Location.X + FollowMainWin.Size.Width;
            }
            int nWidth = 900;
            int nHeight = FollowMainWin.Size.Height;
            WinApiHelper.MoveWindow(handle, x, y, nWidth, nHeight, true);
        }

        public void SetTopMost(string key)
        {
            WinApiHelper.SetForegroundWindow(WinHanles[key]);
        }
        /// <summary>
        /// 设置窗口显示状态
        /// </summary>
        /// <param name="cmdShow">
        ///SW_FORCEMINIMIZE	11	无论拥有窗口的线程是否被挂起，均使窗口最小化。在从其他线程最小化窗口时才使用这个参数。有点类似强制最小化窗口
        ///SW_HIDE	0	隐藏窗口并且激活其它窗口
        ///SW_MAXIMIZE	3	最大化标识的窗口
        ///SW_MINIMIZE	6	最小化窗口，并且按Z序激活下一个窗口
        ///SW_RESTORE	9	激活并显示窗口，如果窗口最小化或最大化，系统恢复其原来的大小和位置。当恢复最小化窗口时，程序应该使用这个标志
        ///SW_SHOW	5	在当前位置及大小情况下，激活并显示窗口
        ///SW_SHOWDEFAULT	10	父进程通过 CreateProcess 创建当前进程时，使用此标志来按 STARTUPINFO 结构体中的标志显示窗口
        ///SW_SHOWMAXIMIZED	3	激活，并按最大化方式显示窗口
        ///SW_SHOWMINIMIZED	2	激活，并按最小化方式显示窗口
        ///SW_SHOWMINNOACTIVE	7	最小化窗口。除了窗口不被激活，其它的类似SW_SHOWMINIMIZED
        ///SW_SHOWNA	8	以当前的大小和位置显示窗口。除了窗口不被激活，其它的类似SW_SHOW
        ///SW_SHOWNOACTIVATE	4	以最近的大小和位置显示窗口，除了窗口不被激活，其它的类似SW_SHOWNORMAL
        ///SW_SHOWNORMAL	1	激活和显示窗口。如果窗口是最大化或最小化，恢复其大小和位置。程序不应该在第一次调用ShowWindow时设置此标志
        ///   </param>
        public void SetShow(int cmdShow)
        {
            foreach (IntPtr hanlde in WinHanles.Values)
            {
                SetSingleShow(cmdShow, hanlde);
            }
        }
        /// <summary>
        /// 设置单个窗口显示状态
        /// </summary>
        /// <param name="isshow">
        ///SW_FORCEMINIMIZE	11	无论拥有窗口的线程是否被挂起，均使窗口最小化。在从其他线程最小化窗口时才使用这个参数。有点类似强制最小化窗口
        ///SW_HIDE	0	隐藏窗口并且激活其它窗口
        ///SW_MAXIMIZE	3	最大化标识的窗口
        ///SW_MINIMIZE	6	最小化窗口，并且按Z序激活下一个窗口
        ///SW_RESTORE	9	激活并显示窗口，如果窗口最小化或最大化，系统恢复其原来的大小和位置。当恢复最小化窗口时，程序应该使用这个标志
        ///SW_SHOW	5	在当前位置及大小情况下，激活并显示窗口
        ///SW_SHOWDEFAULT	10	父进程通过 CreateProcess 创建当前进程时，使用此标志来按 STARTUPINFO 结构体中的标志显示窗口
        ///SW_SHOWMAXIMIZED	3	激活，并按最大化方式显示窗口
        ///SW_SHOWMINIMIZED	2	激活，并按最小化方式显示窗口
        ///SW_SHOWMINNOACTIVE	7	最小化窗口。除了窗口不被激活，其它的类似SW_SHOWMINIMIZED
        ///SW_SHOWNA	8	以当前的大小和位置显示窗口。除了窗口不被激活，其它的类似SW_SHOW
        ///SW_SHOWNOACTIVATE	4	以最近的大小和位置显示窗口，除了窗口不被激活，其它的类似SW_SHOWNORMAL
        ///SW_SHOWNORMAL	1	激活和显示窗口。如果窗口是最大化或最小化，恢复其大小和位置。程序不应该在第一次调用ShowWindow时设置此标志
        /// </param>
        /// <param name="handle">窗口句柄</param>
        public void SetSingleShow(int cmdShow, IntPtr handle)
        {
            WinApiHelper.ShowWindow(handle, cmdShow);
        }

        public void LoadConsole(object wrapper)
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
        public void FreeConsole(object wrapper)
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
        public void MoveConsole()
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
