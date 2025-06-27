using NUnit.Framework;
using System.Linq;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        private EmployeeManager _manager;

        [SetUp]
        public void SetUp()
        {
            _manager = new EmployeeManager();
        }

        [Test]
        public void GetEmployees_Collection_ShouldNotContainNullValues()
        {
            var employees = _manager.GetEmployees();
            Assert.That(employees, Is.All.Not.Null);
        }

        [Test]
        public void GetEmployees_EmployeeWithId100_ShouldExist()
        {
            var employees = _manager.GetEmployees();
            Assert.That(employees.Any(e => e.EmpId == 100), Is.True);
        }

        [Test]
        public void GetEmployees_ShouldContainOnlyUniqueEmployees()
        {
            var employees = _manager.GetEmployees();
            var uniqueEmployees = employees.Distinct().ToList();

            // Classic Model
            Assert.That(employees.Count, Is.EqualTo(uniqueEmployees.Count));

            // Constraint Model
            Assert.That(employees, Is.Unique);
        }

        [Test]
        public void GetEmployeesAndPreviousYearEmployees_ShouldBeEqual()
        {
            var empList1 = _manager.GetEmployees();
            var empList2 = _manager.GetEmployeesWhoJoinedInPreviousYears();

            // Classic Assertion
            Assert.That(empList1.Count, Is.EqualTo(empList2.Count));

            // Constraint Model
            Assert.That(empList1, Is.EquivalentTo(empList2));
        }
    }
}
