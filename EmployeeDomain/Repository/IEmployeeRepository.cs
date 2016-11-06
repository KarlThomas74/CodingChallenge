using System;
using System.Collections.Generic;
using EmployeeDomain.Models;

namespace EmployeeDomain
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
        Employee GetBy(Guid id);
        void Update(Employee employee);
        void Insert(Employee employee);
        void Delete(Employee employee);
    }
}