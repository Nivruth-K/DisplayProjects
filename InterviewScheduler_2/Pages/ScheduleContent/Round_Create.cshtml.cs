using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InterviewScheduler_2.Data;
using InterviewScheduler_2.Models;

namespace InterviewScheduler_2.Pages.ScheduleContent
{
    public class Round_CreateModel : PageModel
    {
        private readonly InterviewScheduler_2.Data.InterviewScheduler_2Context _context;

        public Round_CreateModel(InterviewScheduler_2.Data.InterviewScheduler_2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Round Round { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
                     _context.Round.Add(Round);
            await _context.SaveChangesAsync();
            return RedirectToPage("/ScheduleContent/Round_Create");
        }
    }
}
