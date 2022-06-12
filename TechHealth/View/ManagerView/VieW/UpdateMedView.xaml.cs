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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechHealth.Controller;
using TechHealth.Conversions;
using TechHealth.Model;
using TechHealth.View.ManagerView.ViewModel;

namespace TechHealth.View.ManagerView.VieW
{
    /// <summary>
    /// Interaction logic for UpdateMedView.xaml
    /// </summary>
    public partial class UpdateMedView : UserControl
    {
        private Medicine selected = new Medicine();
        private MedicineController medicineController = new MedicineController();
        private SubstanceController substanceController = new SubstanceController();
        private ObservableCollection<Substance> substances = new ObservableCollection<Substance>();
        private List<Substance> selectedSubstances;
        private List<string> substanceNames;
        public List<Substance> medSubstances { get; set; }

        public ObservableCollection<Substance> Substances
        {
            get { return substances; }
            set { substances = value; }
        }
        public UpdateMedView()
        {
            var med = UpdateMedViewModel.Instance().getSelectedMed();
            selected = med;
            InitializeComponent();
            substances = new ObservableCollection<Substance>(substanceController.GetAllToList());
            substanceNames = substanceController.GetSubstanceNames();
            substanceList.ItemsSource = substanceNames;
            TxtMedName.Text = selected.MedicineName;
            TxtMainSubstance.Text = selected.MainSubstance.SubstanceName.ToString();
            TxtQuantity.Text = selected.Quantity.ToString();
            TxtUnits.Text = selected.Units;
            TxtSideEffects.Text = selected.SideEffects;
            medSubstances = new List<Substance>();
            //substanceList.SelectedItems = selected.Composition;

        }

        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            Medicine medicine = new Medicine();
            medicine.MedicineId = selected.MedicineId;
            medicine.MedicineName = TxtMedName.Text;
            medicine.MainSubstance = ManagerConversions.StringToSubstance(TxtMainSubstance.Text);
            medicine.Quantity = Int32.Parse(TxtQuantity.Text);
            medicine.Units = TxtUnits.Text;
            medicine.SideEffects = TxtSideEffects.Text;
            medicine.MedicineStatus = MedicineStatus.Waiting;
            //medicine.Composition = selected.Composition;
            medicine.Price = selected.Price;

            var selectedItems = substanceList.SelectedItems;
            var collection = selectedItems.Cast<String>();
            var selectedCollection = collection.ToList();
            selectedSubstances = substanceController.GetSubstanceListFromNames(selectedCollection);
            substanceController.AddSubstancesToCompositionList(selectedSubstances, medSubstances);
            medicine.Composition = medSubstances;

            medicineController.Update(medicine);

            var MedVm = new MedViewModel();
            MainViewModel.Instance().CurrentView = MedVm;
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            var MedVm = new MedViewModel();
            MainViewModel.Instance().CurrentView = MedVm;
        }
    }
}
