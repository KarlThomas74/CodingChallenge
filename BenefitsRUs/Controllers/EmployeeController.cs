using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BenefitsRUs.Models;
using BenefitsRUs.Models.Mappers;
using EmployeeDomain;
using EmployeeDomain.Repository;

namespace BenefitsRUs.Controllers
{
    public class EmployeeController : ApiController
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public List<EmployeeViewModel> Get()
        {
            return _employeeService.Get().Select(e => e.ToEmployeeViewModel()).ToList();
        }

        public EmployeeViewModel Get(Guid id)
        {
            return _employeeService.GetBy(id).ToEmployeeViewModel();
        }

        public void Post(EmployeeViewModel employeeViewModel)
        {
            _employeeService.Insert(employeeViewModel.ToEmployee());
        }

        public void Put(EmployeeViewModel employeeViewModel)
        {
            _employeeService.Update(employeeViewModel.ToEmployee());
        }

        public void Delete(Guid id)
        {
            _employeeService.Delete(id);
        }
    }
}
