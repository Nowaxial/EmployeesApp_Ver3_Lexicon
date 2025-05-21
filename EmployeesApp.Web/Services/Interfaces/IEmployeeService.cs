using EmployeesApp.Web.Models;

namespace EmployeesApp.Web.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void Add(Employee employee);

        public Employee[] GetAll();

        public Employee GetById(int id);

        public bool CheckIsVIP(Employee employee);

        //public void Add();

        //public Employee[] GetAll();

        //public Employee GetById();

        //public bool CheckIsVIP();
    }
}
