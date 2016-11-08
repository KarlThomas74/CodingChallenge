using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDomain.Models
{
    public class Employee : Beneficiary
    {
        private readonly List<Beneficiary> _dependents;

        //This is an enumerable so that calling code can only get the list without being
        //able to add to it without going through the method
        public IEnumerable<Beneficiary> Dependents => _dependents;

        public decimal WeeklySalary { get; private set; }


        public Employee()
        {
            _dependents = new List<Beneficiary>();
            BaseBenefitCost = 1000;
            WeeklySalary = 2000;

        }

        public void AddDependent(Beneficiary dependent)
        {
            dependent.BaseBenefitCost = 500;
            _dependents.Add(dependent);
        }

        public void RemoveDependent(Guid id)
        {
            var index =  _dependents.FindIndex(d => d.Id == id);
            _dependents.RemoveAt(index);

        }

        //Makes unit tests easier
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
