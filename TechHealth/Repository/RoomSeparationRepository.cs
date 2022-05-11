using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class RoomSeparationRepository : GenericRepository<string, RoomSeparation>
    {
        private static readonly RoomSeparationRepository instance = new RoomSeparationRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RoomSeparationRepository()
        {
        }

        private RoomSeparationRepository()
        {
        }

        public static RoomSeparationRepository Instance => instance;
        protected override string GetKey(RoomSeparation entity)
        {
            return entity.SeparationID;
        }

        protected override string GetPath()
        {
            return @"../../Json/roomSeparation.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(RoomSeparation entity)
        {
            entity.ShouldSerialize = true;
            entity.RoomOne.ShouldSerialize = false;
            entity.RoomTwo.ShouldSerialize = false;
        }
    }
}
