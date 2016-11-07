using System;
using System.Collections.Generic;
using EmployeeDomain.Models;

namespace EmployeeDomain.Repository
{
    public interface IDataStore
    {
        Dictionary<Guid, Employee> Employees { get; }
    }
}