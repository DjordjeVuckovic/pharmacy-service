using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository.IRepository
{
    public interface IRoomRepository:IRepository<Room, string>
    {
        Room GetRoombyId(string idr);
    }
}
