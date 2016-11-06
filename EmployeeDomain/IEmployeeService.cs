using System;
using System.Collections.Generic;
using EmployeeDomain.Models;

namespace EmployeeDomain
{
    public interface IEmployeeService
    {
        List<Employee> Get();
        Employee GetBy(Guid id);
        void Update(Employee employee);
        void Delete(Guid employee);
        void Insert(Employee toEmployee);
    }
}