using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}