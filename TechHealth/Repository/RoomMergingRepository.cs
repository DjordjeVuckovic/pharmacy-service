using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository.IRepository;

namespace TechHealth.Repository
{
    public class RoomMergingRepository : GenericRepository<string, RoomMerging>, IRoomMergingRepository
    {
        private static readonly RoomMergingRepository instance = new RoomMergingRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RoomMergingRepository()
        {
        }

        private RoomMergingRepository()
        {
        }

        public static RoomMergingRepository Instance => instance;
        protected override string GetKey(RoomMerging entity)
        {
            return entity.MergeID;
        }

        protected override string GetPath()
        {
            return @"../../Json/roomMerging.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(RoomMerging entity)
        {
            entity.ShouldSerialize = true;
        }
    }
}
