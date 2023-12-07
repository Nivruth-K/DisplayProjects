using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InterviewScheduler_2.Data;
using InterviewScheduler_2.Models;
using Microsoft.AspNetCore.CookiePolicy;

namespace InterviewScheduler_2.Pages.UserRegistration
{
    public class UserRegistrationModel : PageModel
    {
        private readonly InterviewScheduler_2.Data.InterviewScheduler_2Context _context;

        public UserRegistrationModel(InterviewScheduler_2.Data.InterviewScheduler_2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public User User_obj { get; set; } = default!;

        public IActionResult OnPost()
        {
            _context.User.Add(User_obj);
            _context.SaveChanges();
            return RedirectToAction("UserRegistration/UserRegistration");
        }
    }
}
