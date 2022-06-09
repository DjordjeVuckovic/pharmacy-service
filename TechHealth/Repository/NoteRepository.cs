using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository.IRepository;

namespace TechHealth.Repository
{
    public class NoteRepository : GenericRepository<string, Note>, INoteRepository
    {
        private static readonly NoteRepository instance = new NoteRepository();

        static NoteRepository() { }

        private NoteRepository() { }

        public static NoteRepository Instance => instance;

        protected override string GetKey(Note entity)
        {
            return entity.NoteId;
        }

        protected override string GetPath()
        {
            return @"../../Json/note.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(Note entity)
        {
            entity.SelectedAppointment.ShouldSerialize = false;
            entity.Patient.ShouldSerialize = false;
        }

        public Note GetNotebyId(string id)
        {
            foreach (var n in GetAllToList())
            {
                if (n.NoteId.Equals(id))
                {
                    return n;
                }
            }
            return null;
        }
    }
}
