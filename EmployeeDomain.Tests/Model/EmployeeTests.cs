using System.Linq;
using EmployeeDomain.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace EmployeeDomain.Tests.Model
{
    [TestFixture()]
    public class EmployeeTests
    {
        [Test]
        public void EmployeeShouldHaveCorrectSalary()
        {
            var employee = new Employee();

            Assert.AreEqual(2000,employee.WeeklySalary);
        }
        [Test]
        public void GivenAnEmployeesNameDoesNotStartWithA_Employee_ShouldHaveCorrectBenefitCost()
        {
            var employee = new Employee()
            {
                FirstName = "Betty",
                LastName = "Ross"
            };

            Assert.AreEqual(1000,employee.BenefitCost);
        }

        [Test]
        public void GivenAnEmployeesNameStartWithA_Employee_ShouldHaveCorrectBenefitCost()
        {
            var employee = new Employee()
            {
                FirstName = "Adam",
                LastName = "Ross"
            };

            Assert.AreEqual(employee.BaseBenefitCost*.90M, employee.BenefitCost);
        }

        [Test]
        public void GivenADependentWhoseNameDoesNotStartWithA_Dependent_ShouldHaveCorrectBenefitCost()
        {
            var employee = new Employee()
            {
                FirstName = "Betty",
                LastName = "Ross"
            };
            employee.AddDependent(new Beneficiary()
            {
                FirstName = "Wilma",
                LastName = "Flinstone"
            });

            Assert.AreEqual(employee.Dependents.First().BaseBenefitCost, employee.Dependents.First().BenefitCost);
        }

        [Test]
        public void GivenADependentNameStartWithA_Dependent_ShouldHaveCorrectBenefitCost()
        {
            var employee = new Employee()
            {
                FirstName = "Betsy",
                LastName = "Ross"
            };

            employee.AddDependent(new Beneficiary()
            {
                FirstName = "Adam",
                LastName = "Sandler"
            });

            Assert.AreEqual(employee.Dependents.First().BaseBenefitCost * .90M, employee.Dependents.First().BenefitCost);
        }
    }
}
