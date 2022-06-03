using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class MeetingRepository : GenericRepository<string, Meeting>
    {
        private static readonly MeetingRepository instance = new MeetingRepository();
        static MeetingRepository()
        {
        }
        private MeetingRepository()
        {
        }
        public static MeetingRepository Instance => instance;
        protected override string GetKey(Meeting entity)
        {
            return entity.Id;
        }

        protected override string GetPath()
        {
            return @"../../Json/meeting.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(Meeting entity)
        {
            foreach (var a in entity.Attendants)
            {
                a.ShouldSerialize = false;
            }
            entity.Room.ShouldSerialize = false;
        }
    }
}
