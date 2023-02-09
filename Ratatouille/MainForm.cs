using System.Net;
using System.Net.Sockets;
using System.Text;
using ServerCore;

namespace Ratatouille
{
    public partial class MainForm : Form
    {
        static Listener _listener = new Listener();

        bool _topBarPanelMouseDown;
        Point Pos;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Program.ConsoleForm.Show();
            Program.ConsoleForm.Visible = false;

            // DNS (Domain Name System)
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            //소켓 생성
            Socket listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            _listener.Init(endPoint, () =>
            {
                return C_SessionManager.Instance.Generate();
            });

            System.Console.WriteLine($"Listening... On {Util.GetExternalIPAddress()}");
        }



        private void serverConnectStartBtn_Click(object sender, EventArgs e) // 원격제어 요청하기
        {
            ServerSession session = new ServerSession();
            try
            {
                IPAddress ipAddr = IPAddress.Parse(ServerAddrTBox.Text);
                
                IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

                Connecter connecter = new Connecter();
                connecter.Connect(endPoint, () =>
                {
                    return session;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            session.Send(MakePacket.MakeC_ConnectReq(Util.GetExternalIPAddress()));
        }

        private void cllientConnectStartBtn_Click(object sender, EventArgs e) //원격제어 시작하기
        {
            ClientSession session = new ClientSession();
            try
            {
                IPAddress ipAddr = IPAddress.Parse(ServerAddrTBox.Text);

                IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

                Connecter connecter = new Connecter();
                connecter.Connect(endPoint, () =>
                {
                    return session;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            session.Send(MakePacket.MakeC_ConnectReq(Util.GetExternalIPAddress()));
        }

        private void showConsoleBtn_Click(object sender, EventArgs e)
        {
            Program.ConsoleForm.Visible = !Program.ConsoleForm.Visible;
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

        private void acceptReqBtn_Click(object sender, EventArgs e)
        {

        }

        private void closeReqBtn_Click(object sender, EventArgs e)
        {

        }
    }
}