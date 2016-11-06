using System;

namespace EmployeeDomain.Models
{
    public class Beneficiary
    { 

        public Guid Id { get; internal set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal Cost { get; set; }
    }
}
