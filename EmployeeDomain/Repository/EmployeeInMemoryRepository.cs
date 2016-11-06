using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeDomain.Models;

namespace EmployeeDomain.Repository
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
    {

        private static Dictionary<Guid, Employee> Employees = new Dictionary<Guid, Employee>();


        public void Insert(Employee employee)
        {
            employee.Id = new Guid();
            Employees.Add(employee.Id,employee);
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
            return Employees.Values.Where(e => e.Id == id).SingleOrDefault();
        }

        public void Update(Employee employee)
        {
            Employees[employee.Id] = employee;
        }
    }
}
