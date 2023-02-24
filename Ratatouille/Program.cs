using ServerCore;
using System.Text;

namespace Ratatouille
{
    internal static class Program
    {
        public static MainForm MainForm = new MainForm();
        public static ConsoleForm ConsoleForm = new ConsoleForm();

        public static Low Low = new Low();
        public static byte LeftFlag = 0;
        public static byte RightFlag = 0;
        public static Action<Keys, int> OnKey = null;

        public static Action<object, EventArgs> OnNewFocus = null;


        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Console.SetOut(new CWriter());

            Low.KP += (sd, ev) => OnKP(ev, 0);
            Low.KC += (sd, ev) => OnKP(ev, 2);
            Low.HookKeyboard();
            Low.HookMouse();

            
            Application.Run(MainForm);
            Application.ApplicationExit += OnApplicationExit;
        }
        static void OnApplicationExit(object sender, EventArgs e)
        {
            Low.UnHookKeyboard();
            Low.UnHookMouse();
        }
        static void OnKP(Keys e, int p)
        {
            if (OnKey != null) OnKey.Invoke(e, p);
        }

        #region override ConsoleWriteLine
        public static Action<string> OnConsoleWriteLine = null;
        public class CWriter : System.IO.TextWriter
        {
            public override void Write(string value)
            {
                if (OnConsoleWriteLine != null) OnConsoleWriteLine.Invoke(value);
            }

            public override Encoding Encoding
            {
                get
                {
                    return Encoding.ASCII;
                }
            }
        }
        #endregion
    }
}