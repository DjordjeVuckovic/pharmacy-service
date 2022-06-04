using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class SubstanceService
    {
        public List<Substance> GetAllToList()
        {
            return SubstanceRepository.Instance.GetAllToList();
        }

        public List<string> GetSubstanceNames()
        {
            List<string> names = new List<string>();
            foreach (var sub in GetAllToList())
            {
                names.Add(sub.SubstanceName);
            }
            return names;
        }

        public Substance GetSubstanceByName(string name)
        {
            Substance substance = new Substance();
            foreach (var sub in GetAllToList())
            {
                if (sub.SubstanceName == name)
                {
                    substance = sub;
                    break;
                }
            }
            return substance;
        }

        public void AddSubstancesToCompositionList(List<Substance> selectedSubstances, List<Substance> medSubstances)
        {
            foreach (var selected in selectedSubstances)
            {
                Substance sub = selected;
                medSubstances.Add(sub);
            }
        }

        public List<Substance> GetSubstanceListFromNames(List<string> names)
        {
            List<Substance> substances = new List<Substance>();
            foreach (var name in names)
            {
                Substance sub = GetSubstanceByName(name);
                substances.Add(sub);
            }
            return substances;
        }
    }
}
