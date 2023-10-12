using EmployeeSampleAPI.Model;

namespace EmployeeSampleAPI
{
    public class EmployeeAPI : IEmployeeAPI
    {
        List<Employee> employees = new List<Employee>
            {
                new Employee{ ID =  1, Name = "Employee1", IsManager = false},
                new Employee{ ID =  2, Name = "Employee2", IsManager = false},
                new Employee{ ID =  3, Name = "Employee3", IsManager = true},
                new Employee{ ID =  4, Name = "Employee4", IsManager = true}
            };
        public EmployeeAPI() { }
        public ResponseVM GetEmployees()
        {
            ResponseVM responseVM = new ResponseVM();
            var employeeList = employees.Where(x => x.IsManager == false).OrderBy(o => o.Name).ToList();

            responseVM.Status = "200";
            responseVM.data = employeeList;

            return responseVM;
        }

        public ResponseVM GetManagers()
        {
            ResponseVM responseVM = new ResponseVM();
            var employeeList = employees.Where(x => x.IsManager == true).OrderBy(o => o.Name).ToList();

            responseVM.Status = "200";
            responseVM.data = employeeList;

            return responseVM;
        }

        public ResponseVM AddEmployee(List<Employee> employee)
        {
            ResponseVM responseVM = new ResponseVM();

            employees.AddRange(employee);
            employees = employees.Where(x => x.IsManager == true).ToList();

            responseVM.Status = "200";
            responseVM.data = employees;

            return responseVM;
        }
    }
}
