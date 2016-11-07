using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomain.Models
{
    public class Employee : Beneficiary
    {
        public List<Beneficiary> Dependents { get; set; }

        public override bool Equals(object obj)
        {
            var employee =  obj as Employee;
            if (employee == null)
            {
                return false;
            }
            return base.Equals(obj) && employee.Dependents.SequenceEqual(Dependents);
        }
    }

}
