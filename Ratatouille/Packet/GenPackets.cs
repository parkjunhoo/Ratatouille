using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ServerCore;

public enum PacketID
{
	L_ClientReq = 1,
	L_ClientRes = 2,
	L_ServerReq = 3,
	L_ServerRes = 4,
	C_ScreenImage = 5,
	S_MouseMove = 6,
	S_MouseClick = 7,
	S_Keyboard = 8,
	
}

interface IPacket
{
	ushort Protocol { get; }
	void Read(ArraySegment<byte> segment);
	ArraySegment<byte> Write();
}


class L_ClientReq : IPacket
{
	public string address;

	public ushort Protocol { get { return (ushort)PacketID.L_ClientReq; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		ushort addressLen = BitConverter.ToUInt16(s.Slice(count, s.Length - count));
		count += sizeof(ushort);
		this.address = Encoding.Unicode.GetString(s.Slice(count, addressLen));
		count += addressLen;
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.L_ClientReq);
		count += sizeof(ushort);
		ushort addressLen = (ushort)Encoding.Unicode.GetBytes(this.address, 0, this.address.Length, segment.Array, segment.Offset + count + sizeof(ushort));
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), addressLen);
		count += sizeof(ushort);
		count += addressLen;
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class L_ClientRes : IPacket
{
	public bool condition;
	public int port;

	public ushort Protocol { get { return (ushort)PacketID.L_ClientRes; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		this.condition = BitConverter.ToBoolean(s.Slice(count, s.Length - count));
		count += sizeof(bool);
		this.port = BitConverter.ToInt32(s.Slice(count, s.Length - count));
		count += sizeof(int);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.L_ClientRes);
		count += sizeof(ushort);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.condition);
		count += sizeof(bool);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.port);
		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class L_ServerReq : IPacket
{
	public string address;

	public ushort Protocol { get { return (ushort)PacketID.L_ServerReq; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		ushort addressLen = BitConverter.ToUInt16(s.Slice(count, s.Length - count));
		count += sizeof(ushort);
		this.address = Encoding.Unicode.GetString(s.Slice(count, addressLen));
		count += addressLen;
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.L_ServerReq);
		count += sizeof(ushort);
		ushort addressLen = (ushort)Encoding.Unicode.GetBytes(this.address, 0, this.address.Length, segment.Array, segment.Offset + count + sizeof(ushort));
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), addressLen);
		count += sizeof(ushort);
		count += addressLen;
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class L_ServerRes : IPacket
{
	public bool condition;
	public int port;

	public ushort Protocol { get { return (ushort)PacketID.L_ServerRes; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		this.condition = BitConverter.ToBoolean(s.Slice(count, s.Length - count));
		count += sizeof(bool);
		this.port = BitConverter.ToInt32(s.Slice(count, s.Length - count));
		count += sizeof(int);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.L_ServerRes);
		count += sizeof(ushort);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.condition);
		count += sizeof(bool);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.port);
		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class C_ScreenImage : IPacket
{
	public byte[] bmp;

	public ushort Protocol { get { return (ushort)PacketID.C_ScreenImage; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		int bmpLen = BitConverter.ToInt32(s.Slice(count, s.Length - count));
		count += sizeof(int);
		this.bmp = s.Slice(count, bmpLen).ToArray();
		count += bmpLen;
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(300000);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.C_ScreenImage);
		count += sizeof(ushort);
		int bmpLen = (int)this.bmp.Length;
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), bmpLen);
		count += sizeof(int);
		foreach(byte b in this.bmp)
		{
			segment.Array[segment.Offset + count] = b;
			count += sizeof(byte);
		}
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class S_MouseMove : IPacket
{
	public short posx;
	public short posy;

	public ushort Protocol { get { return (ushort)PacketID.S_MouseMove; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		this.posx = BitConverter.ToInt16(s.Slice(count, s.Length - count));
		count += sizeof(short);
		this.posy = BitConverter.ToInt16(s.Slice(count, s.Length - count));
		count += sizeof(short);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.S_MouseMove);
		count += sizeof(ushort);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.posx);
		count += sizeof(short);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.posy);
		count += sizeof(short);
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class S_MouseClick : IPacket
{
	public uint flag;

	public ushort Protocol { get { return (ushort)PacketID.S_MouseClick; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		this.flag = BitConverter.ToUInt32(s.Slice(count, s.Length - count));
		count += sizeof(uint);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.S_MouseClick);
		count += sizeof(ushort);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.flag);
		count += sizeof(uint);
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

class S_Keyboard : IPacket
{
	public uint flag;
	public byte keycode;

	public ushort Protocol { get { return (ushort)PacketID.S_Keyboard; } }

	public void Read(ArraySegment<byte> segment)
	{
		int count = 0;

		ReadOnlySpan<byte> s = new ReadOnlySpan<byte>(segment.Array, segment.Offset, segment.Count);
		count += sizeof(int);
		count += sizeof(ushort);
		this.flag = BitConverter.ToUInt32(s.Slice(count, s.Length - count));
		count += sizeof(uint);
		this.keycode = (byte)segment.Array[segment.Offset + count];
		count += sizeof(byte);
	}

	public ArraySegment<byte> Write()
	{
		ArraySegment<byte> segment = SendBufferHelper.Open(4096);
		int count = 0;
		bool success = true;

		Span<byte> s = new Span<byte>(segment.Array, segment.Offset, segment.Count);

		count += sizeof(int);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), (ushort)PacketID.S_Keyboard);
		count += sizeof(ushort);
		success &= BitConverter.TryWriteBytes(s.Slice(count, s.Length - count), this.flag);
		count += sizeof(uint);
		segment.Array[segment.Offset + count] = (byte)this.keycode;
		count += sizeof(byte);
		success &= BitConverter.TryWriteBytes(s, count);
		if (success == false)
			return null;
		return SendBufferHelper.Close(count);
	}
}

