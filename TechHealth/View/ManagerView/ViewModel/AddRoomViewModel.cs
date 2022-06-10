using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Core;
using TechHealth.Model;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class AddRoomViewModel:ViewModelBase
    {
        //public RelayCommand CloseCommand { get; set; }
        //public RelayCommand ConfirmCommand { get; set; }
        //private Room room;
        //private RoomController roomController = new RoomController();
        //private string textBox;
        //private string cbFloor;
        //private string cbAvailability;
        //private string cbType;

        //public string CbType
        //{
        //    get { return cbType; }
        //    set
        //    { 
        //        cbType = value;
        //        OnPropertyChanged(nameof(CbType));
        //    }
        //}


        //public string CbAvailability
        //{
        //    get { return cbAvailability; }
        //    set
        //    {
        //        cbAvailability = value;
        //        OnPropertyChanged(nameof(CbAvailability));
        //    }
        //}

        //public string CbFloor
        //{
        //    get { return cbFloor; }
        //    set
        //    {
        //        cbFloor = value;
        //        OnPropertyChanged(nameof(CbFloor));
        //    }
        //}

        //public string TextBox
        //{
        //    get { return textBox; }
        //    set 
        //    {
        //        textBox = value;
        //        OnPropertyChanged(nameof(TextBox));
        //    }
        //}
        //public AddRoomViewModel()
        //{
        //    CloseCommand = new RelayCommand(param => ExecuteClose());
        //    ConfirmCommand = new RelayCommand(param => ExecuteConfirm(), param => CanExecuteConfirm());
        //}

        //private bool CanExecuteConfirm()
        //{
        //    if (TextBox == null || CbFloor == null || CbAvailability == null || CbType == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private void ExecuteConfirm()
        //{
        //    room = new Room();
        //    var RoomVm = new RoomViewModel();

        //    room.RoomId = TextBox;
        //    room.Floor = ManagerConversions.StringToFloor(CbFloor);
        //    room.RoomTypes = ManagerConversions.StringToRoomType(CbType);
        //    room.Availability = ManagerConversions.StringToAvailability(CbAvailability);

        //    foreach (var r in roomController.GetAll())
        //    {
        //        if (room.RoomId == r.RoomId)
        //        {
        //            MessageBox.Show("Room with this id already exists!");
        //            return;
        //        }
        //    }

        //    if (roomController.WarehouseExists() && room.RoomTypes == RoomTypes.warehouse)
        //    {
        //        MessageBox.Show("There can only be one warehouse!");
        //        MainViewModel.Instance().CurrentView = RoomVm;
        //        return;
        //    }
        //    roomController.Create(room);
        //    MainViewModel.Instance().CurrentView = RoomVm;
        //}

        //private void ExecuteClose()
        //{
        //    var RoomVm = new RoomViewModel();
        //    MainViewModel.Instance().CurrentView = RoomVm;
        //}     
    }
}
