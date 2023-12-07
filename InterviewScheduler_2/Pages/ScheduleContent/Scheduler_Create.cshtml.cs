using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InterviewScheduler_2.Data;
using InterviewScheduler_2.Models;
using System.Collections;
using Newtonsoft.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel;
using InterviewScheduler_2.Services;

namespace InterviewScheduler_2.Pages.ScheduleContent
{
    [IgnoreAntiforgeryToken]
    public class Scheduler_CreateModel : PageModel
    {
        #region properties

        private readonly InterviewScheduler_2Context _context;
        private readonly InterviewScheduler_2Context _context2;
        private readonly InterviewScheduler_2Context _context3;

        public CompanyCreateService companySerivce { get; private set; }

        [BindProperty]
        public Scheduler Scheduler { get; set; } = new Scheduler();

        public Scheduler temp_obj { get; set; } = default!;

        [BindProperty]
        public Guid selectedCompany { get; set; }

        [BindProperty]
        public int selectedRound { get; set; }

        [BindProperty]
        public Company company { get; set; }

        [BindProperty]
        public Round round { get; set; }
        #endregion

        public Scheduler_CreateModel(InterviewScheduler_2.Data.InterviewScheduler_2Context context, InterviewScheduler_2Context context2, InterviewScheduler_2Context context3, CompanyCreateService ComService)
        {
            _context = context;
            temp_obj = new Scheduler();
            _context2=context2;
            _context3=context3;
            companySerivce=ComService;
        }

        public IActionResult OnGetCompanyDetails()
        {
            var company=_context.Company.Select(com => new { com.CompanyId, com.CompanyName });
            return new JsonResult(company);
        }

        public IActionResult OnGetRoundDetails()
        {
            var round_det = _context.Round.Select(round => new { round.RoundId,round.Round_Type});
            return new JsonResult(round_det);
        }



        public IActionResult OnGet()
        {
            var id = HttpContext.Session.GetInt32("User_id");
            if (id.HasValue && id > 0)
            {
                Scheduler.UserId = id.Value;
                return Page();
            }
            else
            {
                return RedirectToPage("/Logout");
            }
        }

        
        public async Task<IActionResult> OnPostAsync()
        {

            temp_obj = new Scheduler();
            temp_obj.UserId=Scheduler.UserId;
            temp_obj.AppliedPost=Scheduler.AppliedPost;
            temp_obj.RegisteredDate=System.DateTime.Now;
            temp_obj.Scheduled_Date=Scheduler.Scheduled_Date;
            temp_obj.CompanyId=selectedCompany;
            temp_obj.RoundId=selectedRound;
            temp_obj.Active=true;
 
            _context.Schedule.Add(temp_obj);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Schedule submitted successfully!";
            return Page();
        }

        #region Round,Company Create methods
        public async Task<IActionResult> OnPostCompanyCreateAsync(Company com)
        {
          await  companySerivce.CreateCompanyAsync(com);
        
            var comdetails = _context2.Company.Select(com => new { com.CompanyId, com.CompanyName });
            return new JsonResult(comdetails);
           

        }

        public async Task<IActionResult> OnPostRoundCreateAsync(Round round1)
        {
                _context3.Round.Add(round1);
            await _context3.SaveChangesAsync();
            var RoundDetails = _context3.Round.Select(r => new {r.RoundId,r.Round_Type});
            return new JsonResult(RoundDetails);
    
        }
        #endregion

        #region partial view methods
        public IActionResult OnGetCompanyComponent()
        {
            return Partial("~/Pages/Shared/Components/Company/Company.cshtml");
        }

        public IActionResult OnGetRoundComponent()
        {
            return Partial("~/Pages/Shared/Components/Round/Round.cshtml");
        }
        #endregion
    }
}
