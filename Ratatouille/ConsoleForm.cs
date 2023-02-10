
namespace Ratatouille
{
    public partial class ConsoleForm : Form
    {
        bool _topBarPanelMouseDown = false;
        Point Pos;

        string _commandText = "";

        public ConsoleForm()
        {
            InitializeComponent();
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            Program.OnConsoleWriteLine += OnConsoleWriteLine;
        }


        #region UI EventHandler
        //TopBarEventHandler
        private void topBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _topBarPanelMouseDown = true;
                Pos = e.Location;
            }
        }
        private void topBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_topBarPanelMouseDown)
            {
                Location = new Point(Location.X + (e.X - Pos.X), Location.Y + (e.Y - Pos.Y));
            }
        }

        private void topBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _topBarPanelMouseDown = false;
                Pos = e.Location;
            }
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //TopBarEventHandler
        #endregion

        void OnConsoleWriteLine(string value)
        {
            if (consoleLogTbox.InvokeRequired)
            {
                consoleLogTbox.Invoke(new MethodInvoker(delegate ()
                {
                    consoleLogTbox.Text += $"{value}";
                }));
            }
            else
            {
                consoleLogTbox.Text += $"{value}";
            }
        }

        private void commandTbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _commandText = commandTbox.Text;
                string res = "";

                if (_commandText.Trim(' ') == "")
                {
                    commandTbox.Text = "";
                    consoleLogTbox.Text += "\r\n";
                    return;
                }


                switch (_commandText)
                {
                    case "sessionCount":
                        {
                            res = $"ServerSession:{ServerSessionManager.Instance._sessions.Count} \r\n ClientSession: {ClientSessionManager.Instance._sessions.Count}";
                            break;
                        }

                    default:
                        {
                            res = $"{_commandText} : 알수없는 명령어입니다.";
                            break;
                        }
                }
                commandTbox.Text = "";
                consoleLogTbox.Text += res + "\r\n";
            }
            if (e.KeyCode == Keys.Up)
            {
                if (_commandText == null) return;
                commandTbox.Text = _commandText;
            }
        }





        //Tbox 소리방지
        private void commandTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
            }
        }



        //스크롤바 내리기
        private void consoleLogTbox_TextChanged(object sender, EventArgs e)
        {
            consoleLogTbox.Select(consoleLogTbox.Text.Length, 0);
            consoleLogTbox.ScrollToCaret();
        }
    }
}
