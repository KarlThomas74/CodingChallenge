using System;
using System.Collections.Generic;
using EmployeeDomain.Models;

namespace EmployeeDomain.Repository
{
    public class DataStore : IDataStore
    {
        private static Dictionary<Guid, Employee> _employees; 
        public Dictionary<Guid,Employee> Employees => _employees;
    }
}
