
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmloyeePortal.Model.Domain
{
	public class Employee
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

