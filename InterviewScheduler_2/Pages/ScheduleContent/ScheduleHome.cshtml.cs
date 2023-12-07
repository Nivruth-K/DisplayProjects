using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InterviewScheduler_2.Data;
using InterviewScheduler_2.Models;
using InterviewScheduler_2.ViewModels;
using InterviewScheduler_2.Services;

namespace InterviewScheduler_2.Pages.ScheduleContent
{
    public class ScheduleHomeModel : PageModel
    {
        #region Properties
        private readonly InterviewScheduler_2.Data.InterviewScheduler_2Context _context;


        [BindProperty]
        public String Greet_User_name { get; set; }

        [BindProperty]
        public List<ScheduleViewModel> schedule_v_obj { get; set; }

        [BindProperty]
        public Company company { get; set; } = default!;

        #endregion

        public ScheduleHomeModel(InterviewScheduler_2.Data.InterviewScheduler_2Context context)
        {
            _context = context;
          
        }


        public IActionResult OnGet()
        {
            var id= HttpContext.Session.GetInt32("User_id");
         var name=  HttpContext.Session.GetString("User_name");

            if (id.HasValue && id > 0)
            {
                Greet_User_name = name;
                schedule_v_obj = _context.Schedule.
                          Where(s => s.UserId==id)
                          .Include(s => s.Company)
                          .Include(s => s.Round).
                          Select(s => new ScheduleViewModel
                          {
                              SchedulerId = s.SchedulerId,
                              Round_Type = s.Round.Round_Type,
                              CompanyName = s.Company.CompanyName,
                              Scheduled_Date = s.Scheduled_Date,
                          }
                  ).ToList();
                return Page();
            }
         
                 else
                {
                    return RedirectToPage("/Logout");
                }
         

        }

    }
}
