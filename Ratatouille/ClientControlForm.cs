using ALYacServer;
using ServerCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Ratatouille
{
    public partial class ClientControlForm : Form
    {
        //const uint MOUSEMOVE = 0x0001;      // 마우스 이동
        //const uint ABSOLUTEMOVE = 0x8000;   // 전역 위치
        //const uint LBUTTONDOWN = 0x0002;    // 왼쪽 마우스 버튼 눌림
        //const uint LBUTTONUP = 0x0004;      // 왼쪽 마우스 버튼 떼어짐
        //const uint RBUTTONDOWN = 0x0008;    // 오른쪽 마우스 버튼 눌림
        //const uint RBUTTONUP = 0x00010;      // 오른쪽 마우스 버튼 떼어짐

        Dictionary<MouseButtons, uint> MouseDownButtonDict = new Dictionary<MouseButtons, uint>();
        Dictionary<MouseButtons, uint> MouseUpButtonDict = new Dictionary<MouseButtons, uint>();
        bool _moveReady = true;
        public ClientSession MySession;

        Low lh = new Low();


        #region UI
        bool _topBarPanelMouseDown;
        Point Pos;

        int Mx;
        int My;
        int Sw;
        int Sh;
        bool mov;
        #endregion

        public ClientControlForm()
        {
            InitializeComponent();

            //this.KeyDown += clientScreenPbox_event_KeyDown;
            //this.KeyUp += clientScreenPbox_event_KeyUp;

            MouseDownButtonDict.Add(MouseButtons.Left, 0x0002);
            MouseDownButtonDict.Add(MouseButtons.Right, 0x0008);

            MouseUpButtonDict.Add(MouseButtons.Left, 0x0004);
            MouseUpButtonDict.Add(MouseButtons.Right, 0x00010);

            Timer mouseMovetimer = new System.Timers.Timer();
            mouseMovetimer.Interval = 125;
            mouseMovetimer.Elapsed += new ElapsedEventHandler(mouseMovetimer_Elapsed);
            mouseMovetimer.Start();

        }
        void mouseMovetimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _moveReady = true;
        }

        private void ClientControlForm_Load(object sender, EventArgs e)
        {
            clientScreenPbox.SizeMode = PictureBoxSizeMode.StretchImage;
            lh.KP += (sd, ev) => OnK(ev, 0);
            lh.KC += (sd, ev) => OnK(ev, 2);
        }
        void OnK(Keys e, int p)
        {
            MySession.Send(MakePacket.S_Keyboard((byte)p, (byte)e));
        }

        private void clientScreenPbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (clientScreenPbox.Image == null || _moveReady == false) return;
            float posX = e.X * ((float)clientScreenPbox.Image.Size.Width / (float)clientScreenPbox.Size.Width);
            float posY = e.Y * ((float)clientScreenPbox.Image.Size.Height / (float)clientScreenPbox.Size.Height);
            MySession.Send(MakePacket.S_MouseMove((short)posX, (short)posY));
            _moveReady = false;
        }
        private void clientScreenPbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (clientScreenPbox.Image == null) return;
            MySession.Send(MakePacket.S_MouseClick(MouseDownButtonDict[e.Button]));
        }
        private void clientScreenPbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (clientScreenPbox.Image == null) return;
            MySession.Send(MakePacket.S_MouseClick(MouseUpButtonDict[e.Button]));
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //MySession.Send(MakePacket.S_Keyboard(0x00, (byte)keyData));
            return false;
        }
        private void clientScreenPbox_event_KeyDown(object sender , KeyEventArgs e)
        {
            MySession.Send(MakePacket.S_Keyboard(0x00, (byte)e.KeyCode));
        }
        private void clientScreenPbox_event_KeyUp(object sender, KeyEventArgs e)
        {
            MySession.Send(MakePacket.S_Keyboard(0x02, (byte)e.KeyCode));
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
        private void HideBtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private void miniBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //TopBarEventHandler
        #endregion



        private void topBarPanel_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
            else this.WindowState = FormWindowState.Maximized;
        }

        private void sizer_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }

        private void sizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == true && this.WindowState == FormWindowState.Normal)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        private void sizer_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }

        private void ClientControlForm_Activated(object sender, EventArgs e)
        {
            lh.HookKeyboard();
        }

        private void ClientControlForm_Deactivate(object sender, EventArgs e)
        {
            lh.UnHookKeyboard();
        }
    }
}
