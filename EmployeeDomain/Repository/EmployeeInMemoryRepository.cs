using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeDomain.Models;
using Microsoft.Practices.ObjectBuilder2;

namespace EmployeeDomain.Repository
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
    {

        private  Dictionary<Guid, Employee> Employees = new Dictionary<Guid, Employee>();


        public EmployeeInMemoryRepository(IDataStore dataStore)
        {
            Employees = dataStore.Employees;
        }

        public void Insert(Employee employee)
        {
            employee.Id = new Guid();
            employee.Dependents.ForEach(d => d.Id = new Guid());
            Employees.Add(employee.Id.Value,employee);
        }

        public void Delete(Guid id)
        {
            Employees.Remove(id);
        }

        public List<Employee> Get()
        {
            return Employees.Values.ToList();
        }

        public Employee GetBy(Guid id)
        {
            return Employees.Values.SingleOrDefault(e => e.Id == id);
        }

        public void Update(Employee employee)
        {        
            Employees[employee.Id.Value] = employee;
        }
    }
}
