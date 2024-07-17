using AutoMapper;
using System;
using EmloyeePortal.Data;
using EmloyeePortal.Model.Domain;
using EmloyeePortal.Model.Dto;
using EmloyeePortal.Respositories;
using Microsoft.EntityFrameworkCore;
using EmloyeePortal.Model.Dto.Validators;

namespace EmloyeePortal.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly EmpDbContex _dbContext;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(EmpDbContex dbContext, IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DashboardDataDto> GetDashboardData()
        {

            try
            {
                var totalEmployeeCount = await _employeeRepository.GetEmployeeCount();
                var activeEmployeeCount = await _employeeRepository.GetActiveEmployeeCount();

                return new DashboardDataDto
                {
                    TotalEmployeeCount = totalEmployeeCount,
                    ActiveEmployeeCount = activeEmployeeCount
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all employees.");
                throw new ApplicationException("An error occurred while retrieving all employees. Please try again later.");
            }
        }

        public bool SaveEmployee(EmployeeDto input)
        {
            try
            {
                EmployeeDtoValidator validator = new EmployeeDtoValidator();
                var validationResult = validator.Validate(input);
                if (!validationResult.IsValid)
                {
                    throw new ApplicationException(validationResult.Errors.Select(e => e.ErrorMessage).Aggregate((i, j) => i + "; " + j));
                }
                var data = _mapper.Map<Employee>(input);
                _dbContext.Employee.Add(data);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all employees.");
                throw new ApplicationException("An error occurred while retrieving all employees. Please try again later.");
            }
        }
        public bool UpdateEmployee(EmployeeDto input, string id)
        {
            try
            {
                EmployeeDtoValidator validator = new EmployeeDtoValidator();
                var validationResult = validator.Validate(input);
                if (!validationResult.IsValid)
                {
                    throw new ApplicationException(validationResult.Errors.Select(e => e.ErrorMessage).Aggregate((i, j) => i + "; " + j));
                }
                var employee = _dbContext.Employee.FirstOrDefault(s => s.Id == id);
                if (employee != null)
                {
                    employee.Name = input.Name;
                    employee.Email = input.Email;
                    employee.Designation = input.Designation;
                    employee.DateOfBirth = input.DateOfBirth;
                    employee.Salary = input.Salary;
                    employee.Status = input.Status;
                    _dbContext.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all employees.");
                throw new ApplicationException("An error occurred while retrieving all employees. Please try again later.");
            }
        }

        public bool DeleteEmployee(string id)
        {
            var employee = _dbContext.Employee.FirstOrDefault(s => s.Id == id);
            if (employee != null)
            {
                _dbContext.Employee.Remove(employee);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            try
            {
                return await _employeeRepository.GetAllEmployees();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all employees.");
                throw new ApplicationException("An error occurred while retrieving all employees. Please try again later.");
            }
        }



        public class ServiceResult<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
        }

    }
}

