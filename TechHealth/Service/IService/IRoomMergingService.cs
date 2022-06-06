using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IRoomMergingService:IService<RoomMerging,string>
    {
        void MergeRooms(RoomMerging rm);
        void MergeOnDate(object state);
    }
}