using System;
using System.Collections.Generic;
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
            return _repository.GetBy(id);
        }

        public void Update(Employee employee)
        {
            _repository.Update(employee);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void Insert(Employee employee)
        {
            _repository.Insert(employee);
        }
    }
}
