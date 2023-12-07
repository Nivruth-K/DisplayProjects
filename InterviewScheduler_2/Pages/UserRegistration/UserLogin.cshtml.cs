using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InterviewScheduler_2.Data;
using InterviewScheduler_2.Models;

namespace InterviewScheduler_2.Pages.UserRegistration
{
    public class UserLoginModel : PageModel
    {
        private readonly InterviewScheduler_2.Data.InterviewScheduler_2Context _context;

        public UserLoginModel(InterviewScheduler_2.Data.InterviewScheduler_2Context context)
        {
            _context = context;
        }
        [BindProperty]
      public User User_obj { get; set; } = default!;

        public User User_temp { get; set; } = default!;

        public int result { get; set; }   


        public void onGet()
        {
            
        }

        public IActionResult  OnPost()
        {
           
            if (User_obj.User_Name != null && User_obj.User_Password != null)  
            {
                  var loginid = (_context.User.Where(user => user.User_Name==User_obj.User_Name && user.User_Password==User_obj.User_Password).Select(user => user.UserId));
                var loginidList=loginid.ToList();
                 result = loginidList.FirstOrDefault();
                HttpContext.Session.SetInt32("User_id", result);

                HttpContext.Session.SetString("User_name", User_obj.User_Name);
            }

           

            return RedirectToPage("/ScheduleContent/ScheduleHome");

        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/UserRegistration/UserLogin"); 
        }

    }
}
