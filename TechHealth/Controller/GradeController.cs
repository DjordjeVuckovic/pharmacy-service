using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class GradeController
    {
        private GradeService gradeService = new GradeService();
        public AppointmentGrade GetById(string id)
        {
            return gradeService.GetById(id);
        }

        public List<AppointmentGrade> GetAll()
        {
            return gradeService.GetAll();
        }

        public bool Create(AppointmentGrade grade)
        {
            return gradeService.Create(grade);
        }

        public bool Update(AppointmentGrade grade)
        {
            return gradeService.Update(grade);
        }

        public bool Delete(string id)
        {
            return gradeService.Delete(id);
        }

        public List<int> GetStaffGrades()
        {
            return gradeService.GetStaffGrades();
        }

        public double GetGradesSum(List<int> grades)
        {
            return gradeService.GetGradesSum(grades);
        }

        public int GetGradesNum(int gradeValue)
        {
            return gradeService.GetGradesNum(gradeValue);
        }
    }
}
