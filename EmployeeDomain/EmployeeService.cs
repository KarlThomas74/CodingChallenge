using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeDomain.Models;

namespace EmployeeDomain
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }


        public List<Employee> Get()
        {
            return _repository.Get();
        }

        public Employee GetBy(Guid id)
        {

            if (id == Guid.Empty)
            {
                throw new Exception("Id cannot be empty");
            }
            return _repository.GetBy(id);
        }

        public void Update(Employee employee)
        {
            if (employee.Id == null)
            {
                throw new Exception("Employee ID cannot be null for updates.");
            }
            if (employee.Dependents.Any(d => d.Id == null))
            {
                throw new Exception("Employees dependents cannot have null id");
            }
            _repository.Update(employee);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void Insert(Employee employee)
        {
            if (employee.Id != null)
            {
                throw new Exception("Employee ID must be null for inserts.");
            }
            if (employee.Dependents.Any(d => d.Id != null))
            {
                throw new Exception("Employees dependents must have null id");
            }

            _repository.Insert(employee);
        }
    }
}
