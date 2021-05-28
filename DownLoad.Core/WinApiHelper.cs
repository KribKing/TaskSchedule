using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DownLoad.Core
{
    public class WinApiHelper
    {
        [DllImport("Kernel32.dll")]
        public static extern bool AllocConsole(); //启动窗口   
        [DllImport("kernel32.dll", EntryPoint = "FreeConsole")]
        public static extern bool FreeConsole();      //释放窗口，即关闭   
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);//找出运行的窗口   

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        public extern static IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert); //取出窗口运行的菜单   

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        public extern static IntPtr RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags); //灰掉按钮

        [DllImport("Kernel32.dll")]
        public static extern bool SetConsoleTitle(string strMessage); //更改Console标题

        [DllImport("User32.dll ", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll ", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        /// <summary>
        /// 这种静态方法是必需的，因为早期操作系统不支持
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        public static IntPtr SetWindowLongPtr(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }


        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong32(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

        /// <summary>
        /// 获取置顶窗口
        /// </summary>
        /// <returns></returns>

        [DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();


        /// <summary>
        /// 检索有关指定窗口的信息。该函数还将以指定的偏移量将值检索到额外的窗口内存中。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return GetWindowLongPtr32(hWnd, nIndex);
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        public static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);
        /// <summary>
        /// 设置一个新的窗口样式
        /// </summary>
        public static readonly int GWL_STYLE = -16;

        /// <summary>
        /// 标题
        /// </summary>
        public static readonly uint WS_CAPTION = 0x00C00000;     /* WS_BORDER | WS_DLGFRAME  */

        /// <summary>
        /// 系统菜单
        /// </summary>
        public static readonly uint WS_SYSMENU = 0x00080000;


        /// <summary>
        /// 设置调整窗口大小的厚的结构的窗口。
        /// </summary>
        public static readonly uint WS_THICKFRAME = 0x00040000;

        /// <summary>
        /// 创建一个可调边框的窗口，与 WS_THICKFRAME 风格相同
        /// </summary>
        public static readonly uint WS_SIZEBOX = WS_THICKFRAME;

        // <summary>
        /// 设置目标窗体大小，位置
        /// </summary>
        /// <param name="hWnd">目标句柄</param>
        /// <param name="x">目标窗体新位置X轴坐标</param>
        /// <param name="y">目标窗体新位置Y轴坐标</param>
        /// <param name="nWidth">目标窗体新宽度</param>
        /// <param name="nHeight">目标窗体新高度</param>
        /// <param name="BRePaint">是否刷新窗体</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//设置此窗体为活动窗体

    }
}
