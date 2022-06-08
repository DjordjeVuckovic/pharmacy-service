using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TechHealth.DTO;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class EquipmentReallocationService:IEquipmentReallocationService
    {
        private IRoomEquipmentService roomEquipmentService = new RoomEquipmentService();

        public List<EquipmentReallocationDTO> GetAll()
        {
            return EquipmentReallocationRepository.Instance.GetAllToList();
        }
        public bool Create(EquipmentReallocationDTO dto)
        {
            return EquipmentReallocationRepository.Instance.Create(dto);
        }

        public bool Update(EquipmentReallocationDTO dto)
        {
            return EquipmentReallocationRepository.Instance.Update(dto);
        }

        public EquipmentReallocationDTO GetById(string key)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string dtoID)
        {
            return EquipmentReallocationRepository.Instance.Delete(dtoID);
        }

        private void UpdateSrcRoomEquipmentDependingOnQuantity(RoomEquipment reSrc, EquipmentReallocationDTO dto)
        {
            reSrc.Quantity -= dto.AmountMoving;
            if (reSrc.Quantity == 0)
            {
                roomEquipmentService.Delete(reSrc.RoomID + "-" + reSrc.EquipmentName);
            }
            else
            {
                roomEquipmentService.Update(reSrc);
            }
        }

        private void MoveEquipmentToExistingDstRoom(RoomEquipment reSrc, RoomEquipment reDst, EquipmentReallocationDTO dto)
        {
            if (reSrc.Quantity >= dto.AmountMoving)
            {
                reDst.Quantity += dto.AmountMoving;
                roomEquipmentService.Update(reDst);

                UpdateSrcRoomEquipmentDependingOnQuantity(reSrc, dto);
            }
            else
            {
                MessageBox.Show("Can't transfer that much!");
            }
        }

        private void CreateDstRoomEquipment(RoomEquipment reDst, EquipmentReallocationDTO dto)
        {
            reDst.EquipmentName = dto.EquipmentName;
            reDst.RoomID = dto.DestinationRoomID;
            reDst.Quantity = dto.AmountMoving;
            roomEquipmentService.Create(reDst);
        }

        private void MoveEquipmentToNewDstRoom(RoomEquipment reSrc, RoomEquipment reDst, EquipmentReallocationDTO dto)
        {
            if (reSrc.Quantity >= dto.AmountMoving)
            {
                CreateDstRoomEquipment(reDst, dto);

                reSrc = roomEquipmentService.GetReByKey(dto.EquipmentName, dto.SourceRoomID);

                reSrc.EquipmentName = dto.EquipmentName;
                reSrc.RoomID = dto.SourceRoomID;

                UpdateSrcRoomEquipmentDependingOnQuantity(reSrc, dto);
            }
            else
            {
                MessageBox.Show("Can't transfer that much!");
            }
        }

        public void SubmitReallocation(EquipmentReallocationDTO dto)
        {
            RoomEquipment reDst = new RoomEquipment();
            RoomEquipment reSrc = new RoomEquipment();
            reDst = roomEquipmentService.GetReByKey(dto.EquipmentName, dto.DestinationRoomID);
            reSrc = roomEquipmentService.GetReByKey(dto.EquipmentName, dto.SourceRoomID);
            if (roomEquipmentService.ReEqExists(dto.EquipmentName, dto.DestinationRoomID))
            {
                MoveEquipmentToExistingDstRoom(reSrc, reDst, dto);
            }
            else
            {
                MoveEquipmentToNewDstRoom(reSrc, reDst, dto);
            }
        }

        public void ReallocateOnDate(object state)
        {
            List<EquipmentReallocationDTO> reallocations = new List<EquipmentReallocationDTO>();
            reallocations = GetAll();
            foreach (var r in reallocations)
            {
                if (DateTime.Compare(DateTime.Now, r.ReallocationTime) == 0 || DateTime.Compare(r.ReallocationTime, DateTime.Now) < 0)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        SubmitReallocation(r);
                        Delete(r.ReallocationID);
                    });
                }
            }
        }

        public bool IsReallocationHappening(DateTime start, DateTime end, string roomID)
        {
            bool isHappening = false;
            foreach (var er in GetAll())
            {
                if (er.ReallocationTime >= start && er.ReallocationTime <= end && (er.DestinationRoomID == roomID || er.SourceRoomID == roomID))
                {
                    isHappening = true;
                }
            }
            return isHappening;
        }
    }
}
