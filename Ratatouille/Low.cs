
using Ratatouille;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ratatouille
{
    public class Low
    {
        private delegate IntPtr LKD(int code, IntPtr wordParameter, IntPtr longParameter);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookType, LKD callback, IntPtr moduleHandle, uint threadID);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookType, LMD callback, IntPtr moduleHandle, uint threadID);


        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hookID, int code, IntPtr wordParameter, IntPtr longParameter);


        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hookID);

        public event EventHandler<Keys> KP;
        public event EventHandler<Keys> KC;


        #region Field

        //keyboard
        private IntPtr kHookID = IntPtr.Zero;
        private LKD lowLevelKeyboardDelegate;
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYUP = 0x105;



        //mouse
        private IntPtr mHookID = IntPtr.Zero;
        private LMD lowLevelMouseDelegate;
        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_MBUTTONDOWN = 0x0207;
        private const int WM_MBUTTONUP = 0x0208;

        private delegate IntPtr LMD(int nCode, IntPtr wParam, IntPtr lParam);
        #endregion


        public Low()
        {
            this.lowLevelKeyboardDelegate = ProcessLowLevelKeyboard;
            this.lowLevelMouseDelegate = ProcessLowLevelMouse;
        }

        public void HookKeyboard()
        {
            this.kHookID = SetHook(this.lowLevelKeyboardDelegate);
        }

        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(this.kHookID);
        }

        public void HookMouse()
        {
            this.mHookID = SetHook(this.lowLevelMouseDelegate);
        }
        public void UnHookMouse()
        {
            UnhookWindowsHookEx(this.mHookID);
        }

        private IntPtr SetHook(LKD lowLevelKeyboardDelegate)
        {
            using (Process process = Process.GetCurrentProcess())
            {
                using (ProcessModule processModule = process.MainModule)
                {
                    return SetWindowsHookEx
                    (
                        WH_KEYBOARD_LL,
                        lowLevelKeyboardDelegate,
                        GetModuleHandle(processModule.ModuleName),
                        0
                    );
                }
            }
        }

        private IntPtr SetHook(LMD lowLevelMouseDelegate)
        {
            using (Process process = Process.GetCurrentProcess())
            {
                using (ProcessModule processModule = process.MainModule)
                {
                    return SetWindowsHookEx
                    (
                        WH_MOUSE_LL,
                        lowLevelMouseDelegate,
                        GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName),
                        0
                    );
                }
            }
        }

        private IntPtr ProcessLowLevelKeyboard(int code, IntPtr wordParameter, IntPtr longParameter)
        {
            if (code >= 0 && wordParameter == (IntPtr)WM_KEYDOWN || wordParameter == (IntPtr)WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(longParameter);

                KP?.Invoke(this, ((Keys)vkCode));
            }

            else if (code >= 0 && wordParameter == (IntPtr)WM_KEYUP || wordParameter == (IntPtr)WM_SYSKEYUP)
            {
                int vkCode = Marshal.ReadInt32(longParameter);

                KC?.Invoke(this, ((Keys)vkCode));
            }

            return CallNextHookEx(kHookID, code, wordParameter, longParameter);
        }

        private IntPtr ProcessLowLevelMouse(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
            {
                Program.LeftFlag = 1;
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONUP)
            {
                Program.LeftFlag = 0;
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_RBUTTONDOWN)
            {
                Program.RightFlag = 1;
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_RBUTTONUP)
            {
                Program.RightFlag = 0;
            }

            return CallNextHookEx(mHookID, nCode, wParam, lParam);
        }


    }
}