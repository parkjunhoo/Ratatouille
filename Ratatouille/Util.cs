using Ratatouille;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public static class Util
{

    #region IP 관련 유틸함수 IsTcpPortAvailable , GetExterbalIPAddress
    public static bool IsTcpPortAvailable(int tcpPort) // 포트가 사용가능하면 true
    {
        var ipgp = IPGlobalProperties.GetIPGlobalProperties();

        // Check ActiveConnection ports
        TcpConnectionInformation[] conns = ipgp.GetActiveTcpConnections();
        foreach (var cn in conns)
        {
            if (cn.LocalEndPoint.Port == tcpPort)
            {
                return false;
            }
        }

        // Check LISTENING ports
        IPEndPoint[] endpoints = ipgp.GetActiveTcpListeners();
        foreach (var ep in endpoints)
        {
            if (ep.Port == tcpPort)
            {
                return false;
            }
        }

        return true;
    }
    public static string GetExternalIPAddress()
    {
        string externalip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim(); //http://icanhazip.com

        if (String.IsNullOrWhiteSpace(externalip))
        {
            Console.WriteLine("External IP was null");
        }

        return externalip;
    } //외부아이피
    #endregion

    public static requestControl CreateClientRequestUI(string labelText, PacketSession session)
    {
        requestControl rc = new requestControl();

        //OK BTN
        rc.acceptReqBtn.Click += (sender, e) =>
        {
            System.Console.WriteLine($"Client Request Accept :{labelText}");
            rc.Parent.Controls.Remove(rc); // 버튼 폼 지우기

            ClientSession cs = ClientSessionManager.Instance.Generate(); //새 클라이언트 세션 만들기

            string host = Dns.GetHostName(); // ip,port 설정
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[1];
            int port = 7778; 
            while (Util.IsTcpPortAvailable(port) == false) // 포트가 사용불가능하면 포트 ++
            {
                port++;
            }
            IPEndPoint endPoint = new IPEndPoint(ipAddr, port);


            Listener listener = new Listener();
            listener.Init(endPoint, () =>
            {
                return cs;
            });

            session.Send(MakePacket.L_ClientRes(true , port)); // 상대방에게 수락 소켓 전송

        };

        //CANCLE BTN
        rc.closeReqBtn.Click += (sender, e) =>
        {
            System.Console.WriteLine($"Client Request Cancel :{labelText}");
            rc.Parent.Controls.Remove(rc);
            session.Send(MakePacket.L_ClientRes(false, 0));
            session.Disconnect();
        };

        rc.Dock = DockStyle.Top;
        rc.requestAlarmLabel.Text = labelText;

        return rc;
    }

    public static requestControl CreateServerRequestUI(string labelText, PacketSession session)
    {
        requestControl rc = new requestControl();
        //OK BTN
        rc.acceptReqBtn.Click += (sender, e) =>
        {
            System.Console.WriteLine($" Server Request Accept :{labelText}");
            rc.Parent.Controls.Remove(rc); // 버튼 폼 지우기

            ServerSession ss = ServerSessionManager.Instance.Generate(); //새 서버 세션 만들기

            string host = Dns.GetHostName(); // ip,port 설정
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[1];
            int port = 7778;
            while (Util.IsTcpPortAvailable(port) == false) // 포트가 사용불가능하면 포트 ++
            {
                port++;
            }
            IPEndPoint endPoint = new IPEndPoint(ipAddr, port);


            Listener listener = new Listener();
            listener.Init(endPoint, () =>
            {
                return ss;
            });

            session.Send(MakePacket.L_ServerRes(true, port)); // 상대방에게 수락 소켓 전송
        };

        //CANCLE BTN
        rc.closeReqBtn.Click += (sender, e) =>
        {
            System.Console.WriteLine($"Server Request Cancel :{labelText}");
            rc.Parent.Controls.Remove(rc);
            session.Send(MakePacket.L_ClientRes(false, 0));
            session.Disconnect();
        };

        rc.Dock = DockStyle.Top;
        rc.requestAlarmLabel.Text = labelText;

        return rc;
    }

    public static connectionControl CreateConnectionUI(string labelText, ClientSession session)
    {
        connectionControl control = new connectionControl();

        //SHOW BTN
        control.showControlFormBtn.Click += (sender, e) =>
        {
            control.dummyBtn.Focus();
            if (session.MyClientControlForm.InvokeRequired)
            {
                session.MyClientControlForm.Invoke(new MethodInvoker(delegate ()
                {
                    session.MyClientControlForm.Visible = !session.MyClientControlForm.Visible;
                }));
            }
            else
            {
                session.MyClientControlForm.Visible = !session.MyClientControlForm.Visible;
            }
        };
        

        //CANCLE BTN
        control.closeConnectBtn.Click += (sender, e) =>
        {
            session.Disconnect();
            control.Parent.Controls.Remove(control);
        };

        control.Dock = DockStyle.Top;
        control.NameLabel.Text = labelText;

        return control;
    }
    public static connectionControl CreateConnectionUI(string labelText, ServerSession session)
    {
        connectionControl control = new connectionControl();

        //SHOW BTN
        control.showControlFormBtn.Visible = false;

        //CANCLE BTN
        control.closeConnectBtn.Click += (sender, e) =>
        {
            session.Disconnect();
            control.Parent.Controls.Remove(control);
        };

        control.Dock = DockStyle.Top;
        control.NameLabel.Text = labelText;

        return control;
    }



    public static byte[] Compress(byte[] data)
    {
        using (MemoryStream output = new MemoryStream())
        {
            using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress))
            {
                gzip.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
    }

    public static byte[] Decompress(byte[] compressedData)
    {
        using (MemoryStream input = new MemoryStream(compressedData))
        {
            using (GZipStream gzip = new GZipStream(input, CompressionMode.Decompress))
            {
                using (MemoryStream output = new MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = gzip.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                    }
                    return output.ToArray();
                }
            }
        }
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
            return Compress(ms.ToArray());
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