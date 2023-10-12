using EmployeeSampleAPI.Model;

namespace EmployeeSampleAPI
{
    public interface IEmployeeAPI
    {
        ResponseVM GetEmployees();
        ResponseVM GetManagers();
        ResponseVM AddEmployee(List<Employee> employee);
    }
}
