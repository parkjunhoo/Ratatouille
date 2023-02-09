using ServerCore;
using System.Text;

namespace Ratatouille
{
    internal static class Program
    {
        public static MainForm MainForm = new MainForm();
        public static ConsoleForm ConsoleForm = new ConsoleForm();

        [STAThread]
        static void Main()
        {
            // override ConsoleWriteLine
            Console.SetOut(new CWriter());


            ApplicationConfiguration.Initialize();
            Application.Run(MainForm);
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