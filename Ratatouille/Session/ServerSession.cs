using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ServerCore;
using System.ComponentModel;
using Ratatouille;

public class ServerSession : PacketSession
{
    int _sessionId = 0;
    public int SessionId
    {
        get
        {
            return _sessionId;
        }
        set
        {
            _sessionId = value;
        }
    }

    Task t;
    public void SetBackgroundWork()
    {
        t = new Task(SendScreen);
        t.Start();
    }
    void SendScreen()
    {
        while (_disconnected != 1)
        {
            ArraySegment<byte> pkt = MakePacket.C_ScreenImage();
            Send(pkt);
            Thread.Sleep(1);
        }
    }


    public override void OnConnected(EndPoint endPoint)
    {
        SetBackgroundWork();
        Console.WriteLine($"OnConnected :{endPoint}");
    }

    public override void OnDisconnected(EndPoint endPoint)
    {
        ServerSessionManager.Instance.Remove(this);
        Console.WriteLine($"OnDisconnected :{endPoint}");
    }

    public override void OnRecvPacket(ArraySegment<byte> buffer)
    {
        ClientPacketManager.Instance.OnRecvPacket(this, buffer);
    }

    public override void OnSend(int numOfBytes)
    {

    }
}