using SignalR.UserNotification.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.UserNotification.Services
{
    public class UserConnectionManager : IUserConnectionManager
    {
        private static Dictionary<string, List<string>> userConnectionMap = new Dictionary<string, List<string>>();

        private static string userConnectionMapLocker = string.Empty;

        public void KeepUserConnection(string userId, string connectionId)
        {
            lock (userConnectionMapLocker)
            {
                if (!userConnectionMap.ContainsKey(userId))
                {
                    userConnectionMap[userId] = new List<string>();
                }
                userConnectionMap[userId].Add(connectionId);
            }
        }

        public void RemoveUserConnection(string connectionId)
        {
            lock (userConnectionMapLocker)
            {
                foreach (var item in userConnectionMap.Keys)
                {
                    if (userConnectionMap.ContainsKey(item))
                    {
                        if (userConnectionMap[item].Contains(connectionId))
                        {
                            userConnectionMap[item].Remove(connectionId);
                            break;
                        }
                    }
                }

            }
        }

        public List<string> GetUserConnections(string userId)
        {
            var conn = new List<string>();
            lock (userConnectionMapLocker)
            {
                conn = userConnectionMap[userId];
            }
            return conn;
        }
    }
}
