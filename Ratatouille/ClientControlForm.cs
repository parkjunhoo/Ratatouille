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
using System.Reflection;
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
        //Middle mouse button down: 0x0020
        //Middle mouse button up: 0x0040

        Dictionary<MouseButtons, uint> MouseDownButtonDict = new Dictionary<MouseButtons, uint>();
        Dictionary<MouseButtons, uint> MouseUpButtonDict = new Dictionary<MouseButtons, uint>();
        bool _sizeSet = false;
        public float ImageWidth = 0f;
        public float ImageHeight = 0f;
        bool _moveReady = true;
        bool _isTBoxTyping = false;
        public ClientSession MySession;
        bool _isFocus = false;



        #region UI
        bool _topBarPanelMouseDown;
        Point Pos;

        int Mx;
        int My;
        int Sw;
        int Sh;
        bool mov;
        #endregion
        public void SetImageSize(float w, float h)
        {
            ImageWidth = w;
            ImageHeight = h;
            _sizeSet = true;
        }

        public ClientControlForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            //this.KeyDown += clientScreenPbox_event_KeyDown;
            //this.KeyUp += clientScreenPbox_event_KeyUp;
            clientScreenPbox.MouseWheel += new MouseEventHandler(clientScreenPbox_MouseWheel);

            MouseDownButtonDict.Add(MouseButtons.Left, 0x0002);
            MouseDownButtonDict.Add(MouseButtons.Right, 0x0008);

            MouseUpButtonDict.Add(MouseButtons.Left, 0x0004);
            MouseUpButtonDict.Add(MouseButtons.Right, 0x00010);

            MouseDownButtonDict.Add(MouseButtons.Middle, 0x0020);
            MouseUpButtonDict.Add(MouseButtons.Middle, 0x0040);

            Timer mouseMovetimer = new System.Timers.Timer();
            mouseMovetimer.Interval = 50;
            mouseMovetimer.Elapsed += new ElapsedEventHandler(mouseMovetimer_Elapsed);
            mouseMovetimer.Start();

        }

        private void ClientControlForm_Load(object sender, EventArgs e)
        {
            clientScreenPbox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void FormFocus()
        {
            //foreach(var session in ClientSessionManager.Instance._sessions)
            //{
            //    if (session.Key == MySession.SessionId) continue;
            //    session.Value.MyClientControlForm.ClientControlForm_Deactivate(null, null);
            //}
            if (Program.OnNewFocus != null) Program.OnNewFocus.Invoke(null, null);

            _isFocus = true;
            if (titleLabel.InvokeRequired)
            {
                titleLabel.Invoke(new MethodInvoker(delegate ()
                {
                    titleLabel.Text = "FOCUS";
                }));
            }
            else
            {
                titleLabel.Text = "FOCUS";
            }
            BackColor = Color.Crimson;

            MySession.Send(MakePacket.S_SendScreenSleep(Convert.ToUInt32(sendSleepTbox.Text)));

            Program.OnKey -= OnK;
            Program.OnKey += OnK;
            Program.OnNewFocus -= ClientControlForm_Deactivate;
            Program.OnNewFocus += ClientControlForm_Deactivate;
        }

        public void ClientControlForm_Deactivate(object sender, EventArgs e)
        {
            MySession.Send(MakePacket.S_SendScreenSleep(300));
            _isFocus = false;
            if (titleLabel.InvokeRequired)
            {
                titleLabel.Invoke(new MethodInvoker(delegate ()
                {
                    titleLabel.Text = "UNFOCUS";
                }));
            }
            else
            {
                titleLabel.Text = "UNFOCUS";
            }
            BackColor = Color.CornflowerBlue;
            Program.OnKey -= OnK;
            Program.OnNewFocus -= ClientControlForm_Deactivate;
        }

        void mouseMovetimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _moveReady = true;
        }



        private void clientScreenPbox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (clientScreenPbox.Image == null || !_isFocus || !_sizeSet) return;
            short line = e.Delta > 0 ? (short)120 : (short)-120;
            MySession.Send(MakePacket.S_MouseClick((uint)0x0800 , line));
        }
        private void clientScreenPbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_moveReady == false || !_isFocus || !_sizeSet) return;
            float posX = e.X * ((float)clientScreenPbox.Image.Size.Width / (float)clientScreenPbox.Size.Width);
            float posY = e.Y * ((float)clientScreenPbox.Image.Size.Height / (float)clientScreenPbox.Size.Height);
            MySession.Send(MakePacket.S_MouseMove((short)posX, (short)posY));
            _moveReady = false;
        }
        private void clientScreenPbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (clientScreenPbox.Image == null || !_isFocus || !_sizeSet) return;
            MySession.Send(MakePacket.S_MouseClick(MouseDownButtonDict[e.Button]));
        }
        private void clientScreenPbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (clientScreenPbox.Image == null || !_isFocus || !_sizeSet) return;
            MySession.Send(MakePacket.S_MouseClick(MouseUpButtonDict[e.Button]));
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!_isTBoxTyping) clientScreenPbox.Focus();

            return false;
        }

        void OnK(Keys e, int p)
        {
            if (_isTBoxTyping || e == Keys.Pause || !_isFocus) return;
            MySession.Send(MakePacket.S_Keyboard((byte)p, (byte)e));
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


        private void topBarPanel_Click(object sender, EventArgs e)
        {
            FormFocus();
        }
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

        

        private void sendSleepBtn_Click(object sender, EventArgs e)
        {
            MySession.Send(MakePacket.S_SendScreenSleep(Convert.ToUInt32(sendSleepTbox.Text)));
        }

        private void sendSleepTbox_Enter(object sender, EventArgs e)
        {
            _isTBoxTyping = true;
        }

        private void sendSleepTbox_Leave(object sender, EventArgs e)
        {
            _isTBoxTyping = false;
        }

        private void clientScreenPbox_Click(object sender, EventArgs e)
        {
            FormFocus();
        }
    }
}
