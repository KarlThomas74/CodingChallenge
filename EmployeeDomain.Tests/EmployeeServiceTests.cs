using System;
using System.Collections.Generic;
using EmployeeDomain.Models;
using Moq;
using NUnit.Framework;

namespace EmployeeDomain.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {

        [Test]
        public void Get_ShouldReturnAllItems()
        {
            var  mockRepo = new Mock<IEmployeeRepository>();
            var testData = GetTestData();
            mockRepo.Setup(m => m.Get()).Returns(testData);
            var service = new EmployeeService(mockRepo.Object);

            var actual = service.Get();

            Assert.AreEqual(actual.Count, testData.Count);
            CollectionAssert.AreEqual(testData,actual);
        }

        [Test]
        public void GivenAValidId_GetBy_ShouldReturnCorrectEmployee()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            var testData = GetTestData();
            mockRepo.Setup(m => m.GetBy(It.IsAny<Guid>())).Returns(testData[0]);
            var service = new EmployeeService(mockRepo.Object);

            var actual = service.GetBy(testData[0].Id.Value);

            Assert.IsTrue(testData[0].Equals(actual));
        }

        [Test]
        public void GivenAEmptyId_GetBy_ShouldThrowException()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            var testData = GetTestData();
            mockRepo.Setup(m => m.GetBy(It.IsAny<Guid>())).Returns(testData[0]);
            var service = new EmployeeService(mockRepo.Object);

            Assert.Throws<Exception>(() => service.GetBy(Guid.Empty));

        }

        [Test]
        public void GivenAValidEmployee_Update_ShouldUpdateRecord()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            Employee actualEmployee = null;
            mockRepo.Setup(m => m.Update(It.IsAny<Employee>()))
                .Callback<Employee>(u =>
                {
                    actualEmployee = u;
                });
            var service = new EmployeeService(mockRepo.Object);

            var expected = GetTestData()[0];
            expected.LastName = "Ono";

            service.Update(expected);

            Assert.IsTrue(expected.Equals(actualEmployee));

        }

        [Test]
        public void GivenAnEmployeeIdIsNull_Update_ShouldThrowException()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            Employee actualEmployee = null;
            mockRepo.Setup(m => m.Update(It.IsAny<Employee>()))
                .Callback<Employee>(u =>
                {
                    actualEmployee = u;
                });
            var service = new EmployeeService(mockRepo.Object);

            var expected = GetTestData()[0];
            expected.LastName = "Ono";
            expected.Id = null;

            Assert.Throws<Exception>(() => service.Update(expected), "Employee ID cannot be null for updates.");

        }


        [Test]
        public void GivenADependentIdIsNull_Update_ShouldThrowException()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            Employee actualEmployee = null;
            mockRepo.Setup(m => m.Update(It.IsAny<Employee>()))
                .Callback<Employee>(u =>
                {
                    actualEmployee = u;
                });
            var service = new EmployeeService(mockRepo.Object);

            var expected = GetTestData()[0];
            expected.LastName = "Ono";
            expected.Dependents[0].Id = null;

            Assert.Throws<Exception>(() => service.Update(expected), "Employees dependents cannot have null id");

        }

        [Test]
        public void GivenAValidId_Delete_ShouldDeleteRecord()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            Guid? actualId = null;
            mockRepo.Setup(m => m.Delete(It.IsAny<Guid>()))
                .Callback<Guid>(u =>
                {
                    actualId = u;
                });
            var service = new EmployeeService(mockRepo.Object);

            var expected = GetTestData()[0].Id;

            service.Delete(expected.Value);

            Assert.AreEqual(expected,actualId);
        }

        [Test]
        public void GivenAValidEmployee_Insert_ShouldInserRecord()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            Employee actualEmployee = null;
            mockRepo.Setup(m => m.Insert(It.IsAny<Employee>()))
                .Callback<Employee>(employee =>
                {
                    actualEmployee = employee;
                });
            var service = new EmployeeService(mockRepo.Object);

            var expected = GetTestData()[0];
            expected.Id = null;
            expected.Dependents.ForEach(d => d.Id = null);

            service.Insert(expected);

            Assert.AreEqual(expected, actualEmployee);
        }

        [Test]
        public void GivenANonNullEmployeeId_Insert_ShouldThrowException()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            Employee actualEmployee = null;
            mockRepo.Setup(m => m.Insert(It.IsAny<Employee>()))
                .Callback<Employee>(u =>
                {
                    actualEmployee = u;
                });
            var service = new EmployeeService(mockRepo.Object);

            var expected = GetTestData()[0];
         
            Assert.Throws<Exception>(() => service.Insert(expected), "Employee ID must be null for inserts.");

        }


        [Test]
        public void GivenNonNullDependentIds_Insert_ShouldThrowException()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            Employee actualEmployee = null;
            mockRepo.Setup(m => m.Update(It.IsAny<Employee>()))
                .Callback<Employee>(u =>
                {
                    actualEmployee = u;
                });
            var service = new EmployeeService(mockRepo.Object);

            var expected = GetTestData()[0];
         
            Assert.Throws<Exception>(() => service.Insert(expected), "Employees dependents must have null id");

        }




        private List<Employee> GetTestData()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    MiddleName = "D",
                    LastName = "Doe",
                    Cost = 2000,
                    Dependents = new List<Beneficiary>()
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
                    }
                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    MiddleName = "D",
                    LastName = "Doe",
                    Cost = 2000,
                    Dependents = new List<Beneficiary>()
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
                    }
                }
            };
        }
    }
}
