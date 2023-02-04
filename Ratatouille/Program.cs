namespace Ratatouille
{
    internal static class Program
    {
        static MainForm _mainForm = new MainForm();
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(_mainForm);
        }
    }
}