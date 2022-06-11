using System;
using System.Collections.Generic;
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
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Controller;
using TechHealth.DTO;
using System.Collections.ObjectModel;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Page = ceTe.DynamicPDF.Page;
using Label = ceTe.DynamicPDF.PageElements.Label;
using ListItem = ceTe.DynamicPDF.PageElements.ListItem;

namespace TechHealth.View.SecretaryView
{
    public partial class Report : Window
    {
        private DoctorController doctorController = new DoctorController();
        private PatientController patientController = new PatientController(); 
        public Report()
        {
            InitializeComponent();
        }
        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            new SecretaryMainWindow().Show();
            Close();
        }
        private void Button_Guests(object sender, RoutedEventArgs e)
        {
            new GuestsView().Show();
            Close();
        }
        private void Button_Accounts(object sender, RoutedEventArgs e)
        {
            new AccountsView().Show();
            Close();
        }
        private void Button_Appointments(object sender, RoutedEventArgs e)
        {
            new AppointmentsPickDate().Show();
            Close();
        }
        private void Button_Equipment(object sender, RoutedEventArgs e)
        {
            new EquipmentRequestsView().Show();
            Close();
        }
        private void Button_EmergencyExamination(object sender, RoutedEventArgs e)
        {
            new EmergencyExamination().Show();
            Close();
        }
        private void Button_Meetings(object sender, RoutedEventArgs e)
        {
            new MeetingsPickDate().Show();
            Close();
        }
        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
        private void Button_Click_Report(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateFrom = DateTime.Parse(datePickerFrom.Text);
                DateTime dateTo = DateTime.Parse(datePickerTo.Text);
            }
            catch
            {
                MessageBox.Show("You didn't select a date.");
                return;
            }

            List<Appointment> lista = new List<Appointment>();
            foreach (var a in AppointmentRepository.Instance.GetAllToList())
            {
                if (DateTime.Compare(a.Date, DateTime.Parse(datePickerFrom.Text)) >= 0)
                {
                    if (DateTime.Compare(a.Date, DateTime.Parse(datePickerTo.Text)) <= 0)
                    {
                        lista.Add(a);
                    }
                }
            }
            lista.Sort((x, y) => DateTime.Compare(x.Date, y.Date));

            Document document = new Document();
            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);

            Table2 table = new Table2(0, 0, 600, 600);

            Column2 column1 = table.Columns.Add(80);
            column1.CellDefault.Align = TextAlign.Center;
            table.Columns.Add(50);
            table.Columns.Add(50);
            table.Columns.Add(100);
            table.Columns.Add(100);
            table.Columns.Add(80);

            Row2 row1 = table.Rows.Add(20, Font.HelveticaBold, 16, Grayscale.Black, Grayscale.Gray);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Date");
            row1.Cells.Add("Start");
            row1.Cells.Add("End");
            row1.Cells.Add("Doctor");
            row1.Cells.Add("Patient");
            row1.Cells.Add("Type");

            table.CellDefault.Padding.Value = 5.0f;
            table.CellSpacing = 5.0f;
            table.Border.Top.Color = RgbColor.Black;
            table.Border.Bottom.Color = RgbColor.Black;
            table.Border.Top.Width = 2;
            table.Border.Bottom.Width = 2;
            table.Border.Left.LineStyle = LineStyle.None;
            table.Border.Right.LineStyle = LineStyle.None;

            foreach (var a in lista)
            {
                string spec = doctorController.GetById(a.Doctor.Jmbg).FullSpecialization;
                string name = patientController.GetByPatientId(a.Patient.Jmbg).FullName;
                Row2 row2 = table.Rows.Add(20, Font.HelveticaBold, 11, Grayscale.Black, null);
                row2.CellDefault.Align = TextAlign.Center;
                row2.CellDefault.VAlign = VAlign.Center;
                row2.Cells.Add(a.Date.ToShortDateString());
                row2.Cells.Add(a.StartTime.ToShortTimeString());
                row2.Cells.Add(a.FinishTime.ToShortTimeString());
                row2.Cells.Add(spec);
                row2.Cells.Add(name);
                row2.Cells.Add(a.AppointmentType.ToString());
            }
            page.Elements.Add(table);
            document.Pages.Add(page);
            document.Draw("../Report.pdf");
            MessageBox.Show("Pdf is located in 'bin' folder.");
        }
    }
}
