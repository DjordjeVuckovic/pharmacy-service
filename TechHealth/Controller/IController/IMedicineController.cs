using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Controller.IController
{
    public interface IMedicineController:IController<Medicine,string>
    {
        List<Medicine> GetAllApproved();

    }
}