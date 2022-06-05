using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class AppointmentGradeService
    {
        public AppointmentGrade GetById(string idGrade)
        {
            return GradeRepository.Instance.GetById(idGrade);
        }

        public List<AppointmentGrade> GetAllToList()
        {
            return GradeRepository.Instance.GetAllToList();
        }

        public bool Create(AppointmentGrade grade)
        {
            return GradeRepository.Instance.Create(grade);
        }

        public bool Update(AppointmentGrade grade)
        {
            return GradeRepository.Instance.Update(grade);
        }

        public bool GradeExists(string idGrade)
        {
            if (GetAllToList().Count != 0)
            {
                foreach (var grade in GetAllToList())
                {
                    if (grade.Id == idGrade)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }


    }
}
