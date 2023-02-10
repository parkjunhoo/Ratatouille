using Ratatouille;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ServerSessionManager
{
    static ServerSessionManager _session = new ServerSessionManager();
    public static ServerSessionManager Instance { get { return _session; } }

    int _sessionId = 0;
    public Dictionary<int, ServerSession> _sessions = new Dictionary<int, ServerSession>();

    object _lock = new object();

    public ServerSession Generate()
    {
        lock (_lock)
        {
            int sessionId = ++_sessionId;

            ServerSession session = new ServerSession();
            session.SessionId = sessionId;
            _sessions.Add(sessionId, session);

            Program.MainForm.RefreshConnectList();

            Console.WriteLine($"Connected : {sessionId}");

            return session;
        }
    }


    public ServerSession Find(int id)
    {
        lock (_lock)
        {
            ServerSession session = null;
            _sessions.TryGetValue(id, out session);
            return session;
        }
    }

    public void Remove(ServerSession session)
    {
        lock (_lock)
        {
            _sessions.Remove(session.SessionId);
            Program.MainForm.RefreshConnectList();
        }
    }
}
