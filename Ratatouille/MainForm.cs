using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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


            _listener.Init(endPoint, () =>
            {
                return new ListenSession();
            });

            System.Console.WriteLine($"ListenSession : Listening... On {Util.GetExternalIPAddress()}");
        }



        private void serverConnectStartBtn_Click(object sender, EventArgs e) // 원격제어 요청하기
        {
            ListenSession session = new ListenSession();
            try
            {
                if(serverAddrURLCBox.Checked)
                {
                    IPAddress[] ip_Addresses = Dns.GetHostAddresses(ServerAddrTBox.Text);
                    IPAddress ipAddr = ip_Addresses[0];
                    IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

                    Connecter connecter = new Connecter();
                    connecter.Connect(endPoint, () =>
                    {
                        return session;
                    });
                }
                else
                {
                    IPAddress ipAddr = IPAddress.Parse(ServerAddrTBox.Text);

                    IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

                    Connecter connecter = new Connecter();
                    connecter.Connect(endPoint, () =>
                    {
                        return session;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            session.Send(MakePacket.L_ClientReq(Util.GetExternalIPAddress()));
        }

        private void cllientConnectStartBtn_Click(object sender, EventArgs e) //원격제어 시작하기
        {
            ListenSession session = new ListenSession();
            try
            {
                if (clientAddrURLCBox.Checked)
                {
                    IPAddress[] ip_Addresses = Dns.GetHostAddresses(clientAddrTBox.Text);
                    IPAddress ipAddr = ip_Addresses[0];
                    IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

                    Connecter connecter = new Connecter();
                    connecter.Connect(endPoint, () =>
                    {
                        return session;
                    });
                }
                else
                {
                    IPAddress ipAddr = IPAddress.Parse(clientAddrTBox.Text);

                    IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

                    Connecter connecter = new Connecter();
                    connecter.Connect(endPoint, () =>
                    {
                        return session;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            session.Send(MakePacket.L_ServerReq(Util.GetExternalIPAddress()));
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

        public void RefreshConnectList()
        {
            for (int i = 0; i < this.connectionListPanel.Controls.Count; i++)
            {
                if (this.connectionListPanel.InvokeRequired)
                {
                    this.connectionListPanel.Invoke(new MethodInvoker(delegate ()
                    {
                        connectionListPanel.Controls.RemoveAt(i);
                    }));
                }
            }

            foreach (var session in ClientSessionManager.Instance._sessions)
            {
                if (this.connectionListPanel.InvokeRequired)
                {
                    this.connectionListPanel.Invoke(new MethodInvoker(delegate ()
                    {
                        this.connectionListPanel.Controls.Add(Util.CreateConnectionUI(session.Key.ToString(), session.Value));
                    }));
                }
                else
                {
                    this.connectionListPanel.Controls.Add(Util.CreateConnectionUI(session.Key.ToString(), session.Value));
                }
            }
            foreach (var session in ServerSessionManager.Instance._sessions)
            {
                if (this.connectionListPanel.InvokeRequired)
                {
                    this.connectionListPanel.Invoke(new MethodInvoker(delegate ()
                    {
                        this.connectionListPanel.Controls.Add(Util.CreateConnectionUI(session.Key.ToString(), session.Value));
                    }));
                }
                else
                {
                    this.connectionListPanel.Controls.Add(Util.CreateConnectionUI(session.Key.ToString(), session.Value));
                }
            }
        }
    }
}