using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class SubstanceController
    {
        private SubstanceService substanceService = new SubstanceService();

        public List<Substance> GetAllToList()
        {
            return substanceService.GetAllToList();
        }

        public List<string> GetSubstanceNames()
        {
            return substanceService.GetSubstanceNames();
        }

        public List<Substance> GetSubstanceListFromNames(List<string> names)
        {
            return substanceService.GetSubstanceListFromNames(names);
        }
    }
}
