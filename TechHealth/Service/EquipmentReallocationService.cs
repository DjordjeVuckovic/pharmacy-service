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
        public bool Create(EquipmentReallocationDTO dto)
        {
            return EquipmentReallocationRepository.Instance.Create(dto);
        }

        public void SubmitReallocation(EquipmentReallocationDTO dto)
        {
            RoomEquipment reDst = new RoomEquipment();
            RoomEquipment reSrc = new RoomEquipment();
            reDst = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.DestinationRoomID);
            reSrc = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.SourceRoomID);
            if (RoomEquipmentRepository.Instance.ReEqExists(dto.EquipmentName, dto.DestinationRoomID))
            {
                if (reSrc.Quantity >= dto.AmountMoving)
                { 
                    reDst.Quantity += dto.AmountMoving;
                    RoomEquipmentRepository.Instance.Update(reDst);

                    reSrc.Quantity -= dto.AmountMoving;
                    if (reSrc.Quantity == 0)
                    {
                        RoomEquipmentRepository.Instance.Delete(reSrc.RoomID + "-" + reSrc.EquipmentName);
                    }
                    else
                    {
                        RoomEquipmentRepository.Instance.Update(reSrc);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Can't transfer that much!");
                    return;
                }
            }
            else
            {
                if (reSrc.Quantity >= dto.AmountMoving)
                {
                    reDst.EquipmentName = dto.EquipmentName;
                    reDst.RoomID = dto.DestinationRoomID;
                    reDst.Quantity = dto.AmountMoving;
                    RoomEquipmentRepository.Instance.Create(reDst);

                    reSrc = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.SourceRoomID);

                    reSrc.EquipmentName = dto.EquipmentName;
                    reSrc.RoomID = dto.SourceRoomID;
                    reSrc.Quantity -= dto.AmountMoving;
                    if (reSrc.Quantity == 0)
                    {
                        RoomEquipmentRepository.Instance.Delete(reSrc.RoomID + "-" + reSrc.EquipmentName);
                    }
                    else
                    {
                        RoomEquipmentRepository.Instance.Update(reSrc);
                    }
                    return;
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
            reallocations = EquipmentReallocationRepository.Instance.GetAllToList();
            foreach (var r in reallocations)
            {
                if (DateTime.Compare(DateTime.Now, r.ReallocationTime) == 0 || DateTime.Compare(r.ReallocationTime, DateTime.Now) < 0)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        SubmitReallocation(r);
                        EquipmentReallocationRepository.Instance.Delete(r.ReallocationID);
                    });
                }
            }
        }
    }
}
