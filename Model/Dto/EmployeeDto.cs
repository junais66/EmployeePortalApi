using System;
namespace EmloyeePortal.Model.Dto
{
	public class EmployeeDto
	{
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Designation { get; set; }
        public decimal? Salary { get; set; }
        public bool Status { get; set; }
    }
}

