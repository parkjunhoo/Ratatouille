using ServerCore;
using System;
using System.Collections.Generic;

class ClientPacketManager
{
	#region Singleton
	static ClientPacketManager _instance = new ClientPacketManager();
	public static ClientPacketManager Instance
	{
		get { return _instance; }
	}
    #endregion

    ClientPacketManager()
    {
        Register();
    }

	Dictionary<ushort, Action<PacketSession, ArraySegment<byte>>> _onRecv = new Dictionary<ushort, Action<PacketSession, ArraySegment<byte>>>();
	Dictionary<ushort, Action<PacketSession, IPacket>> _handler = new Dictionary<ushort, Action<PacketSession, IPacket>>();
		
	public void Register()
	{
		_onRecv.Add((ushort)PacketID.S_ConnectRes, MakePacket<S_ConnectRes>);
		_handler.Add((ushort)PacketID.S_ConnectRes, PacketHandler.S_ConnectResHandler);
		_onRecv.Add((ushort)PacketID.S_MouseClick, MakePacket<S_MouseClick>);
		_handler.Add((ushort)PacketID.S_MouseClick, PacketHandler.S_MouseClickHandler);

	}

	public void OnRecvPacket(PacketSession session, ArraySegment<byte> buffer)
	{
		int count = 0;

		int size = BitConverter.ToInt32(buffer.Array, buffer.Offset);
		count += 4;
		ushort id = BitConverter.ToUInt16(buffer.Array, buffer.Offset + count);
		count += 2;

		Action<PacketSession, ArraySegment<byte>> action = null;
		if (_onRecv.TryGetValue(id, out action))
			action.Invoke(session, buffer);
	}

	void MakePacket<T>(PacketSession session, ArraySegment<byte> buffer) where T : IPacket, new()
	{
		T pkt = new T();
		pkt.Read(buffer);
		Action<PacketSession, IPacket> action = null;
		if (_handler.TryGetValue(pkt.Protocol, out action))
			action.Invoke(session, pkt);
	}
}