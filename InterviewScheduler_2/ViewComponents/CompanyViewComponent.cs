using Microsoft.AspNetCore.Mvc;
using InterviewScheduler_2.Data;
using System.Security.Policy;
using InterviewScheduler_2.Models;
using InterviewScheduler_2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace InterviewScheduler_2.ViewComponents
{
      public class CompanyViewComponent : ViewComponent
    {
        private readonly InterviewScheduler_2Context _context;
        private readonly CompanyCreateService _companyService;

        public CompanyViewComponent(CompanyCreateService companyService)
        {
          
            _companyService=companyService;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var model = new Company();
            return View("Company",model);
        }

      
    }
}
