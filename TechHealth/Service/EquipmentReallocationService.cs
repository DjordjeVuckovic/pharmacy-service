using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TechHealth.DTO;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class EquipmentReallocationService
    {
        private RoomEquipmentService roomEquipmentService = new RoomEquipmentService();

        public List<EquipmentReallocationDTO> GetAllToList()
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

        public bool Delete(string dtoID)
        {
            return EquipmentReallocationRepository.Instance.Delete(dtoID);
        }

        public void SubmitReallocation(EquipmentReallocationDTO dto)
        {
            RoomEquipment reDst = new RoomEquipment();
            RoomEquipment reSrc = new RoomEquipment();
            reDst = roomEquipmentService.GetReByKey(dto.EquipmentName, dto.DestinationRoomID);
            reSrc = roomEquipmentService.GetReByKey(dto.EquipmentName, dto.SourceRoomID);
            if (roomEquipmentService.ReEqExists(dto.EquipmentName, dto.DestinationRoomID))
            {
                if (reSrc.Quantity >= dto.AmountMoving)
                { 
                    reDst.Quantity += dto.AmountMoving;
                    roomEquipmentService.Update(reDst);

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
                else
                {
                    MessageBox.Show("Can't transfer that much!");
                }
            }
            else
            {
                if (reSrc.Quantity >= dto.AmountMoving)
                {
                    reDst.EquipmentName = dto.EquipmentName;
                    reDst.RoomID = dto.DestinationRoomID;
                    reDst.Quantity = dto.AmountMoving;
                    roomEquipmentService.Create(reDst);

                    reSrc = roomEquipmentService.GetReByKey(dto.EquipmentName, dto.SourceRoomID);

                    reSrc.EquipmentName = dto.EquipmentName;
                    reSrc.RoomID = dto.SourceRoomID;
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
                else
                {
                    MessageBox.Show("Can't transfer that much!");
                }
            }
        }

        public void ReallocateOnDate(object state)
        {
            List<EquipmentReallocationDTO> reallocations = new List<EquipmentReallocationDTO>();
            reallocations = GetAllToList();
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
            foreach (var er in GetAllToList())
            {
                if (er.ReallocationTime >= start && er.ReallocationTime <= end && (er.DestinationRoomID == roomID || er.SourceRoomID == roomID))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
