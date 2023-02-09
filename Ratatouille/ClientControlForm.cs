using ServerCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ratatouille
{
    public partial class ClientControlForm : Form
    {
        public ClientSession MySession;
        public ClientControlForm()
        {
            InitializeComponent();
        }

        private void ClientControlForm_Load(object sender, EventArgs e)
        {
            clientScreenPbox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void clientScreenPbox_MouseDown(object sender, MouseEventArgs e)
        {
            float posX = e.X * ((float)clientScreenPbox.Image.Size.Width / (float)clientScreenPbox.Size.Width);
            float posY = e.Y * ((float)clientScreenPbox.Image.Size.Height / (float)clientScreenPbox.Size.Height);
            MySession.Send(MakePacket.MakeS_MouseClick(posX, posY));
        }
    }
}
