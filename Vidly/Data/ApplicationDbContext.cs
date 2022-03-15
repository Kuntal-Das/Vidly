using System;
using System.Collections.Generic;
using System.Text;
using Vidly.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Vidly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genere> Generes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
