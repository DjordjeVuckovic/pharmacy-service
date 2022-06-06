using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IRoomSeparationService:IService<RoomSeparation,string>

    {
        void SeparateRooms(RoomSeparation rs);
        void SeparateOnDate(object state);

    }
}