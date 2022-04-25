using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Conversions
{
    public class ManagerConversions
    {
        public static EquipmentType StringToEquipmentType(string str)
        {
            switch (str)
            {
                case "Static":
                    return EquipmentType.statical;
                case "Dynamic":
                    return EquipmentType.dynamical;
                default:
                    return EquipmentType.statical;
            }
        }
        public static string EquipmentTypeToString(EquipmentType type)
        {
            switch (type)
            {
                case EquipmentType.statical:
                    return "Static";
                case EquipmentType.dynamical:
                    return "Dynamic";
                default:
                    return "";
            }
        }

        public static string RoomTypesToString(RoomTypes type)
        {
            switch (type)
            {
                case RoomTypes.operation:
                    return "Operation";
                case RoomTypes.examination:
                    return "Examination";
                case RoomTypes.rest:
                    return "Rest";
                case RoomTypes.office:
                    return "Office";
                default:
                    return "";
            }
        }

        public static string FloorToString(int floor)
        {
            switch (floor)
            {
                case 1:
                    return "1";
                case 2:
                    return "2";
                case 3:
                    return "3";
                default:
                    return "0";
            }
        }

        public static string AvailabilityToString(bool availability)
        {
            if (availability)
                return "In function";
            else
                return "Not in function";

        }

        public static RoomTypes StringToRoomType(string str)
        {
            switch (str)
            {
                case "Operation":
                    return RoomTypes.operation;
                case "Examination":
                    return RoomTypes.examination;
                case "Rest":
                    return RoomTypes.rest;
                case "Office":
                    return RoomTypes.office;
                default:
                    return RoomTypes.rest;
            }
        }

        public static int StringToFloor(string str)
        {
            switch (str)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                default:
                    return 0;
            }
        }

        public static bool StringToAvailability(string str)
        {
            //return str.Equals("In function");
            if (str.Equals("In function"))
            {
                return true;
            }
            else return false;
        }
    }
}
