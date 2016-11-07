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
                Cost = beneficiaryViewModel.Cost
            };
        }

        public static Employee ToEmployee(this EmployeeViewModel employeeViewModel)
        {
            Employee employee = (Employee) employeeViewModel.ToBeneficiary();
            employee.Dependents = employeeViewModel.Dependents.Select(d => d.ToBeneficiary()).ToList();
            return employee;
        }

        public static BeneficiaryViewModel ToBeneficiarViewModel(this Beneficiary beneficiary)
        {
            return new BeneficiaryViewModel()
            {
                FirstName = beneficiary.FirstName,
                MiddleName = beneficiary.MiddleName,
                LastName = beneficiary.LastName,
                Cost = beneficiary.Cost
            };
        }

        public static EmployeeViewModel ToEmployeeViewModel(this Employee employee)
        {
            EmployeeViewModel employeeViewModel = (EmployeeViewModel)employee.ToBeneficiarViewModel();
            employee.Dependents = employeeViewModel.Dependents.Select(d => d.ToBeneficiary()).ToList();
            return employeeViewModel;
        }

    }
}