using EmloyeePortal.Model.Dto;

namespace EmloyeePortal.Services
{
    public interface IEmployeeService
    {
        Task<DashboardDataDto> GetDashboardData();
        bool SaveEmployee(EmployeeDto input);
        bool UpdateEmployee(EmployeeDto input, string id);
        bool DeleteEmployee(string id);
        Task<List<EmployeeDto>> GetAllEmployees();
    }
}