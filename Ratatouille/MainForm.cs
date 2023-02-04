using System.Net;
using System.Net.Sockets;

namespace Ratatouille
{
    public partial class MainForm : Form
    {
        bool _topBarPanelMouseDown;
        Point Pos;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
        private void serverConnectStartBtn_Click(object sender, EventArgs e) // 원격제어 요청하기
        {

        }

        private void cllientConnectStartBtn_Click(object sender, EventArgs e) //원격제어 시작하기
        {
        }

        #region UI EventHandler

        // TextBox EventHandler
        private void ServerAddrTBox_Enter(object sender, EventArgs e)
        {
            serverAddrLine.BackColor = Color.Black;
            ServerAddrTBox.BackColor = Color.White;
        }

        private void ServerAddrTBox_Leave(object sender, EventArgs e)
        {
            serverAddrLine.BackColor = Color.Gray;
            ServerAddrTBox.BackColor = Color.Gainsboro;
        }

        private void ClientAddrTBox_Enter(object sender, EventArgs e)
        {
            clientAddrLine.BackColor = Color.Black;
            clientAddrTBox.BackColor = Color.White;
        }
        private void ClientAddrTBox_Leave(object sender, EventArgs e)
        {
            clientAddrLine.BackColor = Color.Gray;
            clientAddrTBox.BackColor = Color.Gainsboro;
        }
        // TextBox EventHandler



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
            Application.Exit();
        }
        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //TopBarEventHandler
        #endregion

        
    }
}