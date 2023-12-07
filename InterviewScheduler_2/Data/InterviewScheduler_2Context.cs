using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InterviewScheduler_2.Models;

namespace InterviewScheduler_2.Data
{
    public class InterviewScheduler_2Context : DbContext
    {
        public InterviewScheduler_2Context()
        {
        }

        public InterviewScheduler_2Context (DbContextOptions<InterviewScheduler_2Context> options)
            : base(options)
        {
        }

        public DbSet<InterviewScheduler_2.Models.User> User { get; set; } = default!;

        public DbSet<InterviewScheduler_2.Models.Scheduler>? Schedule { get; set; }
        public DbSet<InterviewScheduler_2.Models.Company>? Company { get; set; }
        public DbSet<InterviewScheduler_2.Models.Round>? Round { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Company>().HasData(
             new Company
             {
                 CompanyId = Guid.NewGuid(),
                 CompanyName = "TestCompany1",
                 CompanyAddress = "Test Address1",
                 CompanyCity = "TestCity1"
             },
             new Company
             {
                 CompanyId = Guid.NewGuid(),
                 CompanyName = "TestCompany1",
                 CompanyAddress = "Test Address2",
                 CompanyCity = "TestCity2"
             }
         
         );
        }
    }
}
