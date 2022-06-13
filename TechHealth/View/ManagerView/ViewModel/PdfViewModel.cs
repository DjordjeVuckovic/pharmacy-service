using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TechHealth.Core;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.View.ManagerView.VieW;

namespace TechHealth.View.ManagerView.ViewModel
{
    public class PdfViewModel:ViewModelBase
    {
        public RelayCommand DownloadCommand { get; set; }
        public RelayCommand GenerateGridCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        private BindingList<AppointmentGrade> surveys;
        private DateTime startDate;
        private DateTime endDate;
        private string startD { get; set; }
        private string endD { get; set; }

        public string StartD
        {
            get { return startD; }
            set
            {
                startD = value;
                OnPropertyChanged(nameof(StartD));
            }
        }

        public string EndD
        {
            get { return endD; }
            set
            {
                endD = value;
                OnPropertyChanged(nameof(EndD));
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public BindingList<AppointmentGrade> Surveys
        {
            get { return surveys; }
            set
            {
                surveys = value;
                OnPropertyChanged(nameof(Surveys));
            }
        }

        public PdfViewModel()
        {
            surveys = new BindingList<AppointmentGrade>(GradeRepository.Instance.GetAllToList());
            //surveys = CheckDate();
            DownloadCommand = new RelayCommand(param => ExecuteDownload());
            GenerateGridCommand = new RelayCommand(param => ExecuteGenerate());
            CloseCommand = new RelayCommand(param => ExecuteClose());
        }

        private void ExecuteClose()
        {
            var SurveyVm = new SurveyViewModel();
            MainViewModel.Instance().CurrentView = SurveyVm;
        }

        private void ExecuteGenerate()
        {
            surveys = CheckDate();
            StartD = StartDate.ToString();
            EndD = EndDate.ToString();
            new PdfToPrint(surveys, StartD, EndD);
        }

        private void ExecuteDownload()
        {
            //new PrintDialog().PrintVisual(new PdfView().Report, "PdfView");
            new PrintDialog().PrintVisual(new PdfToPrint(surveys, StartD, EndD).Report, "PdfToPrint");
        }

        private BindingList<AppointmentGrade> CheckDate()
        {
            surveys.Clear();
            foreach (var grade in GradeRepository.Instance.GetAllToList())
            {
                if (grade.SubmitDate >= StartDate && grade.SubmitDate <= EndDate)
                {

                    surveys.Add(grade);
                }
            }
            return surveys;
        }
    }
}
