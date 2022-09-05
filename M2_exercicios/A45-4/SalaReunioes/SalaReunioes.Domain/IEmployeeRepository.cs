using System.Collections.Generic;

namespace SalaReunioes.Domain
{
    public interface IEmployeeRepository
    {
        public void AddEmployee(Employee employee);
        public List<Employee> SearchAllEmployees();
        public Employee SearchEmployeeById(int id);
        public int GetLastId();
    }
}