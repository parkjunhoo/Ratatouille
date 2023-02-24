using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ServerCore;
using System.ComponentModel;
using Ratatouille;

public class ServerSession : PacketSession
{
    uint _sendScreenSleep = 100;
    public uint SendScreenSleep
    {
        get
        {
            return _sendScreenSleep;
        }
        set
        {
            _sendScreenSleep = value;
        }
    }

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
            uint s = _sendScreenSleep;
            ArraySegment<byte> pkt = MakePacket.C_ScreenImage();
            Send(pkt);
            Thread.Sleep((int)s);
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