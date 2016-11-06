using Microsoft.Practices.Unity;

namespace EmployeeDomain
{
    public static class UnityRegister
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IEmployeeRepository, IEmployeeRepository>();
        }
    }
}
