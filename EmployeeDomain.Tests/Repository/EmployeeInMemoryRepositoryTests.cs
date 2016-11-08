using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EmployeeDomain.Models;
using EmployeeDomain.Repository;
using NUnit.Framework;

namespace EmployeeDomain.Tests.Repository
{
    [TestFixture]
    public class EmployeeInMemoryRepositoryTests
    {
        [Test]
        public void Get_ShouldGetAllRecords()
        {
            var mockDataStore = new MockDataStore();
            var expected = mockDataStore.Employees.Values.ToList();
            var repository = new EmployeeInMemoryRepository(mockDataStore);

            var actual = repository.Get();

            CollectionAssert.AreEqual(expected,actual);
        }

        [Test]
        public void GivenAValidEmployeeId_GetById_ShouldReturnCorrectEmployee()
        {
            var mockDataStore = new MockDataStore();
            var expected = mockDataStore.Employees.Values.ToList();
            var repository = new EmployeeInMemoryRepository(mockDataStore);

            var actual = repository.GetBy(expected[0].Id.Value);

            Assert.AreEqual(expected[0],actual);
        }

        [Test]
        public void GivenAnInvalidEmployeeId_GetById_ShouldReturnNull()
        {
            var mockDataStore = new MockDataStore();
            var repository = new EmployeeInMemoryRepository(mockDataStore);

            var actual = repository.GetBy(Guid.NewGuid());

            Assert.IsNull(actual);
        }

        public void GivenAValidEmployee_Insert_ShouldAddRecord()
        {
            var mockDataStore = new MockDataStore();
            var repository = new EmployeeInMemoryRepository(mockDataStore);

            var expected = new Employee()
            {
                FirstName = "Test",
                LastName = "Employee"
            };

            expected.AddDependent(new Beneficiary()
            {
                FirstName = "Jane",
                LastName = "Jungle"
            });

            expected.AddDependent(new Beneficiary()
            {
                FirstName = "Tarzan",
                LastName = "Jungle"
            });

            repository.Insert(expected);
            var actual = mockDataStore.Employees.Values.SingleOrDefault(e => e.FirstName == "Test");

            Assert.IsNotNull(actual);
        }

        [Test]
        public void GivenAValidEmployee_Insert_ShouldAddGuidsToInsertedRecord()
        {
            var mockDataStore = new MockDataStore();
            var repository = new EmployeeInMemoryRepository(mockDataStore);

            var expected = new Employee()
            {
                FirstName = "Test",
                LastName = "Employee"
            };

            expected.AddDependent(new Beneficiary()
            {
                FirstName = "Jane",
                LastName = "Jungle"
            });

            expected.AddDependent(new Beneficiary()
            {
                FirstName = "Tarzan",
                LastName = "Jungle"
            }); repository.Insert(expected);
            var actual = mockDataStore.Employees.Values.SingleOrDefault(e => e.FirstName == "Test");

            Assert.IsNotNull(actual);

            Assert.IsNotNull(actual.Id);
            Assert.IsTrue(expected.Dependents.All(e => e.Id != null));
        }

        [Test]
        public void GivenAValidEmployeeId_Delete_ShouldDeleteRecord()
        {
            var mockDataStore = new MockDataStore();
            var repository = new EmployeeInMemoryRepository(mockDataStore);

            var idToDelete = mockDataStore.Employees.Values.First().Id;

            repository.Delete(idToDelete.Value);
            var actual = mockDataStore.Employees.Values.SingleOrDefault(e => e.Id == idToDelete);

            Assert.IsNull(actual);
        }


        [Test]
        public void GivenAnInValidEmployeeId_Delete_ShouldNotThrowAnError()
        {
            var mockDataStore = new MockDataStore();
            var repository = new EmployeeInMemoryRepository(mockDataStore);


            repository.Delete(Guid.NewGuid());

            Assert.Pass();
        }

        [Test]
        public void GivenAValidEmployee_Update_ShouldUpdateRecord()
        {
            var mockDataStore = new MockDataStore();
            var repository = new EmployeeInMemoryRepository(mockDataStore);

            var expected = mockDataStore.Employees.Values.First();
            var expectedId = expected.Id;
            expected.FirstName = "Changed";
            expected.LastName = "RealSecret";
            expected.Dependents.First().FirstName = "Mary";
            expected.Dependents.First().LastName = "Poppins";

            repository.Update(expected);

            var actual = mockDataStore.Employees.Values.FirstOrDefault(e => e.Id == expectedId);

            Assert.AreEqual(expected,actual);

        }
    }

    public class MockDataStore : IDataStore
    {
        public Dictionary<Guid, Employee> Employees { get; private set; }

        public MockDataStore()
        {

            var dependents1 = new List<Beneficiary>()
            {
                new Beneficiary()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Lennon"
                },
                new Beneficiary()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Paul",
                    LastName = "McCartney"
                },
            };

            var dependents2 = new List<Beneficiary>()
            {
                new Beneficiary()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "George",
                    LastName = "Harrison"
                },
                new Beneficiary()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ringo",
                    LastName = "Starr"
                },
            };
               
        var employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    MiddleName = "D",
                    LastName = "Doe",
                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    MiddleName = "D",
                    LastName = "Doe",
                }
            };

            dependents1.ForEach(d => employees[0].AddDependent(d));
            dependents2.ForEach(d => employees[1].AddDependent(d));
            Employees = employees.ToDictionary(k => k.Id.Value, v => v);
        }
    }

}
