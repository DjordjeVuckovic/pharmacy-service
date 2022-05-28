using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.View.ManagerView.CRUDRooms
{
    /// <summary>
    /// Interaction logic for AddMedWindow.xaml
    /// </summary>
    public partial class AddMedWindow : Window
    {
        private MedicineController medicineController = new MedicineController();
        private SubstanceController substanceController = new SubstanceController();
        private ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
        private ObservableCollection<Substance> substances = new ObservableCollection<Substance>();
        private List<string> substanceNames;
        private List<Substance> selectedSubstances;
        public List<Substance> medSubstances { get; set; }
        public ObservableCollection<Substance> Substances
        {
            get { return substances; }
            set { substances = value; }
        }

        public AddMedWindow(ObservableCollection<Medicine> meds)
        {
            medicines = meds;
            InitializeComponent();
            substances = new ObservableCollection<Substance>(substanceController.GetAllToList());
            substanceNames = substanceController.GetSubstanceNames();
            substanceList.ItemsSource = substanceNames;
            medSubstances = new List<Substance>();
        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            Medicine med = new Medicine();
            med.MedicineId = Guid.NewGuid().ToString("N");
            med.MedicineName = TxtMedName.Text;
            med.Quantity = Int32.Parse(TxtQuantity.Text);
            med.Units = TxtUnits.Text;
            med.SideEffects = TxtSideEffects.Text;
            med.MainSubstance = ManagerConversions.StringToSubstance(TxtMainSubstance.Text);
            med.Price = 0;
            med.MedicineStatus = MedicineStatus.Waiting;
            

            var selectedItems = substanceList.SelectedItems;
            var collection = selectedItems.Cast<String>();
            var selectedCollection = collection.ToList();
            selectedSubstances = substanceController.GetSubstanceListFromNames(selectedCollection);
            foreach (var selected in selectedSubstances)
            {
                Substance sub = selected;
                medSubstances.Add(sub);
            }
            med.Composition = medSubstances;

            medicineController.Create(med);
            medicines.Add(med);

            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
