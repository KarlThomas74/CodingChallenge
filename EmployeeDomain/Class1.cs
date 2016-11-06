using EmployeeDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomain
{
    public class EmployeeDomain
    {
        private IEmployeeRepository _repository { get; set; }
        public EmployeeDomain(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public List<Employee> Get()
        {
            return _repository.Get();
        }

        public List<Employee> GetBy(Guid id)
        {
            return _repository.GetBy(id);
        }

        public void Update(Employee employee)
        {
            _repository.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _repository.Delete(employee);
        }
    }
}
