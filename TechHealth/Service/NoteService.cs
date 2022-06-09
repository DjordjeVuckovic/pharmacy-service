using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Repository.IRepository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class NoteService : INoteService
    {
        public List<Note> GetAll()
        {
            return NoteRepository.Instance.GetAllToList();
        }

        public bool Create(Note entity)
        {
            return NoteRepository.Instance.Create(entity);
        }

        public bool Update(Note entity)
        {
            return NoteRepository.Instance.Update(entity);
        }

        public Note GetById(string key)
        {
            return NoteRepository.Instance.GetNotebyId(key);
        }

        public bool Delete(string key)
        {
            return NoteRepository.Instance.Delete(key);
        }

    }
}
