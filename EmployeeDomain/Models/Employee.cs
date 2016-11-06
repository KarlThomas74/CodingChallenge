using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomain.Models
{
    public class Employee : Beneficiary
    {
        public List<Beneficiary> Beneficiaries { get; set; }

    }
}
