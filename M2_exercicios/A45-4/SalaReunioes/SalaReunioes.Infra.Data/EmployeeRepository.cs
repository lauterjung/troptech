using System;
using System.Collections.Generic;
using SalaReunioes.Domain;
using SalaReunioes.Domain.Exceptions;
using SalaReunioes.Infra.Data.DAO;

namespace SalaReunioes.Infra.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDAO _employeeDAO = new EmployeeDAO();

        public void AddEmployee(Employee employee)
        {
            _employeeDAO.AddEmployee(employee);
        }

        public List<Employee> SearchAllEmployees()
        {
            List<Employee> employeeList = _employeeDAO.SearchAllEmployees();

            if (employeeList.Count == 0)
            {
                throw new ZeroEmployeesRegistered();
            }

            return employeeList;
        }

        public int GetLastId()
        {
            return _employeeDAO.GetLastId();
        }

        public Employee SearchEmployeeById(int id)
        {
            Employee employee = _employeeDAO.SearchEmployeeById(id);

            if (employee is null)
            {
                throw new EmployeeNotFound();
            }

            return employee;
        }
    }
}