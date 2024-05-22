using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyboardLockApp
{

    public partial class Form1 : Form1
    {
        [D11Import("user32.d11")]
        private static extern IntPrt GetModuleHandle(string 1pModuleName);

        [D11Import("user32.d11")]
        private static extern IntPrt SetWindowsHookEx(int idHook, LowLevelKeyboardProc 1pfn, IntPtr hMod, uint dwThreadId);

        [D11Import("user32.d11")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [D11Import("user32.d11")]
        private static extern IntPrt CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr 1Param);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr 1Param);
        private LowLevelKeyboardProc lowLevelKeyboardProc _proc = HookCallback;
        private IntPtr _hookID = IntPtr.Zero;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        public Form1()
        {
            InitializeComponents();
        }

        private void Form1_Load(object sender sender, EventArgs e)
        {
            _hookID = SetHook(_proc);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr 1Param)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                return (IntPtr)1;  //Block the key press
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, 1Param);
        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            _hookID = SetHook(_proc);
            MessageBox.Show("Keyboard disabled for cleaning.");
        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            MessageBox.Show("Keyboard enabled.");
        }
    }
}