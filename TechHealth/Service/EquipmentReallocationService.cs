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
            if (dto.SourceRoomID != dto.DestinationRoomID)
            {
                if (AppointmentRepository.Instance.CanDoReallocation(dto.ReallocationTime, dto.SourceRoomID, dto.DestinationRoomID))
                {
                    if (RoomRenovationRepository.Instance.IsValidDate(dto.ReallocationTime, dto.SourceRoomID, dto.DestinationRoomID))
                    {
                        RoomEquipment reDst = new RoomEquipment();
                        RoomEquipment reSrc = new RoomEquipment();
                        reDst = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.DestinationRoomID);
                        reSrc = RoomEquipmentRepository.Instance.GetReByKey(dto.EquipmentName, dto.SourceRoomID);
                        if (RoomEquipmentRepository.Instance.ReEqExists(dto.EquipmentName, dto.DestinationRoomID))
                        {
                            if (reSrc.Quantity >= dto.AmountMoving)
                            {

                                EquipmentReallocationRepository.Instance.Create(dto);
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
                                EquipmentReallocationRepository.Instance.Create(dto);
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
                    else
                    {
                        MessageBox.Show("Invalid date!");
                    }
                }
                else
                {
                    MessageBox.Show("There is an appointment scheduled on that date!");
                }
            }
            else
            {
                MessageBox.Show("Invalid rooms for transfer selected!");
                return;
            }
        }
    }
}
