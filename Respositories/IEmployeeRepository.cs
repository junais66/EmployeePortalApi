using EmloyeePortal.Model.Dto;

namespace EmloyeePortal.Respositories
{
    public interface IEmployeeRepository
    {
        Task<int> GetEmployeeCount();
        Task<int> GetActiveEmployeeCount();
        Task<EmployeeDto> GetEmployeeById(string id);
        Task<List<EmployeeDto>> GetAllEmployees();
    }
}