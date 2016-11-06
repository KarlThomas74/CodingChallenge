using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BenefitsRUs.Models;
using BenefitsRUs.Models.Mappers;
using EmployeeDomain;

namespace BenefitsRUs.Controllers
{
    public class EmployeeController : ApiController
    {

        private IEmployeeService _employeeService;
        // GET api/values
        public List<EmployeeViewModel> Get()
        {
            return _employeeService.Get().Select(e => e.ToEmployeeViewModel()).ToList();
        }

        // GET api/values/5
        public EmployeeViewModel Get(Guid id)
        {
            return _employeeService.GetBy(id).ToEmployeeViewModel();
        }

        // POST api/values
        public void Post(EmployeeViewModel employeeViewModel)
        {
            _employeeService.Insert(employeeViewModel.ToEmployee());
        }

        // PUT api/values/5
        public void Put(EmployeeViewModel employee)
        {
        }

        // DELETE api/values/5
        public void Delete(Guid id)
        {
        }
    }
}
