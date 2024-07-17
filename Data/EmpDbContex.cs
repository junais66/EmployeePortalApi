using System;
using EmloyeePortal.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmloyeePortal.Data
{
    public class EmpDbContex: DbContext
    {
        public EmpDbContex(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; } = null!;
    }
}

