﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Employee.Core.Data;
using Employee.Core.DomainObjects;
using Employee.Domain.Entities;

namespace Employee.Data.Contexts
{
    public class OracleContext : DbContext, IUnitOfWork
    {
        public OracleContext(DbContextOptions<OracleContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();
            modelBuilder.Ignore<Validation>();
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
