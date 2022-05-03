using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class NotificationFileRepository : GenericRepository<string, Notification>
    {
        protected override string GetKey(Notification entity)
        {
            return entity.ID;
        }

        protected override string GetPath()
        {
            return @"../../Json/notifications.json";
        }

        protected override void RemoveAllReference(string key)
        {

        }

        public List<Notification> ReadByUser(string key)
        {
            List<Notification> retVal = GetAllToList();

            for (int i = 0; i < retVal.Count; i++)
            {
                if (!(retVal[i].ContainsTarget("All") || retVal[i].ContainsTarget(key)))
                {
                    retVal.RemoveAt(i);
                    i--;
                }

            }

            return retVal;

        }

        public List<Notification> ReadPastNotificationsByUser(string key)
        {
            List<Notification> retVal = GetAllToList();

            for (int i = 0; i < retVal.Count; i++)
            {
                if (!(retVal[i].ContainsTarget("All") || retVal[i].ContainsTarget(key)) || !retVal[i].GetIfPast())
                {
                    retVal.RemoveAt(i);
                    i--;
                }
            }

            return retVal;

        }

        protected override void ShouldSerialize(Notification entity)
        {

        }
    }
}
