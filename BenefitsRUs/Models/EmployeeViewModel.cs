using System.Collections.Generic;
using BenefitsRUs.Models.Mappers;

namespace BenefitsRUs.Models
{
    public class EmployeeViewModel : BeneficiaryViewModel
    {
        public List<BeneficiaryViewModel> Dependents { get; set; }
    }
}