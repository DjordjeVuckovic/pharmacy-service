using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Controller.IController;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class NoteController : INoteController
    {
        private readonly INoteService noteService = new NoteService();

        public void Create(Note entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetAll()
        {
            return noteService.GetAll();
        }

        public Note GetById(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
        {
            throw new NotImplementedException();
        }

        public Note GetByNoteId(string id)
        {
            return noteService.GetById(id);
        }
    }
}
