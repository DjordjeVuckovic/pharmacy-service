using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechHealth.Annotations;
using TechHealth.Controller;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for RoomInventoryView.xaml
    /// </summary>
    public partial class RoomInventoryView : UserControl
    {
        private ObservableCollection<RoomEquipment> reList;
        public event PropertyChangedEventHandler PropertyChanged;
        public static Timer timer;
        private EquipmentReallocationController eqReallocationController = new EquipmentReallocationController();
        private RoomEquipmentController roomEquipmentController = new RoomEquipmentController();

        public ObservableCollection<RoomEquipment> ReList
        {
            get
            {
                return reList;
            }

            set
            {
                reList = value;
                OnPropertyChanged(nameof(ReList));
            }
        }
        public RoomInventoryView()
        {
            timer = new Timer(new TimerCallback(eqReallocationController.ReallocateOnDate), null, 1000, 60000);
            InitializeComponent();
            DataContext = this;
            var room = RoomInventoryViewModel.Instance().getSelectedRoom();
            reList = new ObservableCollection<RoomEquipment>(roomEquipmentController.GetRoomEqListByRoomID(room.roomId));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var RoomVm = new RoomViewModel();
            MainViewModel.Instance().CurrentView = RoomVm;
        }
    }
}
