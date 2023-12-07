using InterviewScheduler_2.Data;
using InterviewScheduler_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewScheduler_2.Services
{
    public class CompanyCreateService
    {
        private readonly InterviewScheduler_2Context _context;

        public CompanyCreateService(InterviewScheduler_2Context context)
        {
            _context = context;
        }

        public async Task CreateCompanyAsync(Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
        
        }
    }
}
