using Dapper;
using EmployeeTest.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeTest.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Fields
        private readonly string _connectionString;
        #endregion

        #region Ctor
        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EmployeeTest");
        }
        #endregion

        #region Methods
        public List<Employee> GetAllEmployees()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Employee>("GetAllEmployees", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Employee>("GetEmployeeById", new { Id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void InsertEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("InsertEmployee", new
                {
                    employee.Name,
                    employee.Email,
                    employee.Phone,
                    employee.Address,
                    employee.State,
                    employee.City
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("UpdateEmployee", new
                {
                    employee.Id,
                    employee.Name,
                    employee.Email,
                    employee.Phone,
                    employee.Address,
                    employee.State,
                    employee.City
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("DeleteEmployee", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
    }
}