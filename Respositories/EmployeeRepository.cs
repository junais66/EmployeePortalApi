using System;
using EmloyeePortal.Data;
using EmloyeePortal.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace EmloyeePortal.Respositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDbContex _dbContext;

        public EmployeeRepository(EmpDbContex empDbContex)
        {
            _dbContext = empDbContex;
        }

        public async Task<int> GetEmployeeCount()
        {
            return await _dbContext.Employee.CountAsync();
        }
        public async Task<int> GetActiveEmployeeCount()
        {
            return await _dbContext.Employee.CountAsync(p => p.Status == true);
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var result = await (from p in _dbContext.Employee

                                select new EmployeeDto
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Email = p.Email,
                                    DateOfBirth = p.DateOfBirth,
                                    Designation = p.Designation,
                                    Salary = p.Salary,
                                    Status = p.Status
                                }).ToListAsync();

            return result;
        }
        public async Task<EmployeeDto> GetEmployeeById(string id)
        {
            return await (from p in _dbContext.Employee
                          where p.Id == id
                          select new EmployeeDto
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Email = p.Email,
                              // Map other properties as needed
                          }).FirstAsync();
        }
    }
}

