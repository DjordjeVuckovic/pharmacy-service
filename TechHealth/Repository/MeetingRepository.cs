using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public bool CheckAttendants(Meeting meeting)
        {
            foreach (var p in meeting.Attendants)
            {
                foreach (var m in MeetingRepository.Instance.GetAll().Values)
                {
                    foreach (var a in m.Attendants)
                    {
                        if (p.Jmbg.Equals(a.Jmbg))
                        {
                            if (meeting.Date.Equals(m.Date))
                            {
                                if (DateTime.Compare(DateTime.Parse(meeting.StartTime.ToString("HH:mm")), DateTime.Parse(m.StartTime.ToString("HH:mm"))) >= 0)
                                {
                                    if (DateTime.Compare(DateTime.Parse(meeting.StartTime.ToString("HH:mm")), DateTime.Parse(m.FinishTime.ToString("HH:mm"))) <= 0)
                                    {
                                        MessageBox.Show(p.FullName + " already has a meeting.");
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
