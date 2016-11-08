using System.Linq;
using EmployeeDomain.Models;

namespace BenefitsRUs.Models.Mappers
{
    public static class Mappers
    {
        public static Beneficiary ToBeneficiary(this BeneficiaryViewModel beneficiaryViewModel)
        {
            return new Beneficiary()
            {
                FirstName = beneficiaryViewModel.FirstName,
                MiddleName = beneficiaryViewModel.MiddleName,
                LastName = beneficiaryViewModel.LastName,
            };
        }

        public static Employee ToEmployee(this EmployeeViewModel employeeViewModel)
        {
            Employee employee = (Employee) employeeViewModel.ToBeneficiary();
            employeeViewModel.Dependents.ForEach(d => employee.AddDependent(d.ToBeneficiary()));
            return employee;
        }

        private static BeneficiaryViewModel ToBeneficiarViewModel(this Beneficiary beneficiary)
        {
            return new BeneficiaryViewModel()
            {
                FirstName = beneficiary.FirstName,
                MiddleName = beneficiary.MiddleName,
                LastName = beneficiary.LastName,
                Cost = beneficiary.BenefitCost
            };
        }

        public static EmployeeViewModel ToEmployeeViewModel(this Employee employee)
        {
            EmployeeViewModel employeeViewModel = (EmployeeViewModel)employee.ToBeneficiarViewModel();
            employeeViewModel.Dependents = employee.Dependents.Select(d => d.ToBeneficiarViewModel()).ToList();
            return employeeViewModel;
        }

    }
}