using Ratatouille;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public static class Util
{
    public static string GetExternalIPAddress()
    {
        string externalip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim(); //http://icanhazip.com

        if (String.IsNullOrWhiteSpace(externalip))
        {
            Console.WriteLine("External IP was null");
        }

        return externalip;
    }
    public static requestControl CreateRequestUI(string labelText, PacketSession session)
    {
        ClientSession cs = session as ClientSession;
        requestControl rc = new requestControl();
        rc.acceptReqBtn.Click += (sender, e) =>
        {
            System.Console.WriteLine($" Request Accept :{labelText}");
            cs.MyClientControlForm.Show();
            rc.Parent.Controls.Remove(rc);
            session.Send(MakePacket.MakeS_ConnectRes(true));
        };
        rc.closeReqBtn.Click += (sender, e) =>
        {
            System.Console.WriteLine($" Request Cancel :{labelText}");
            rc.Parent.Controls.Remove(rc);
            session.Send(MakePacket.MakeS_ConnectRes(false));
            session.Disconnect();
        };

        rc.Dock = DockStyle.Top;
        rc.requestAlarmLabel.Text = labelText;

        return rc;
    }



    #region 이미지 관련
    public static byte[] ScreenToByte()
    {
        Rectangle rect = Screen.PrimaryScreen.Bounds;
        Bitmap bmp = new Bitmap(rect.Width, rect.Height);
        using (Graphics gr = Graphics.FromImage(bmp))
        {
            gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
        }
        return ImageToByteArray(bmp);
    }

    public static byte[] ImageToByteArray(Image image) //이미지를 바이트배열 변환
    {
        using (var ms = new MemoryStream())
        {
            image.Save(ms, ImageFormat.Jpeg);
            image.Dispose();
            return ms.ToArray();
        }
    }

    public static Image ByteArrayToImage(byte[] imgbytes) //바이트를 이미지배열로 변환
    {
        using (var ms = new MemoryStream(imgbytes))
        {
            Image img = Image.FromStream(ms);
            imgbytes = null;
            return img;
        }
    }

    #endregion


}