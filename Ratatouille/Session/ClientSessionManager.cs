using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratatouille
{
    class ClientSessionManager
    {
        static ClientSessionManager _session = new ClientSessionManager();
        public static ClientSessionManager Instance { get { return _session; } }

        int _sessionId = 0;
        public Dictionary<int, ClientSession> _sessions = new Dictionary<int, ClientSession>();

        object _lock = new object();

        public ClientSession Generate()
        {
            lock (_lock)
            {
                int sessionId = ++_sessionId;

                ClientSession session = new ClientSession();
                session.SessionId = sessionId;
                _sessions.Add(sessionId, session);

                Program.MainForm.RefreshConnectList();

                Console.WriteLine($"Connected : {sessionId}");

                return session;
            }
        }

        //public void Add(ClientSession session)
        //{
        //    lock (_lock)
        //    {
        //        int sessionId = ++_sessionId;

        //        session.SessionId = sessionId;
        //        _sessions.Add(sessionId, session);

        //        Console.WriteLine($"Connected : {sessionId}");
        //    }
        //}

        public ClientSession Find(int id)
        {
            lock(_lock)
            {
                ClientSession session = null;
                _sessions.TryGetValue(id, out session);
                return session;
            }
        }

        public void Remove(ClientSession session)
        {
            lock (_lock)
            {
                _sessions.Remove(session.SessionId);
                Program.MainForm.RefreshConnectList();
            }
        }
    }
}
