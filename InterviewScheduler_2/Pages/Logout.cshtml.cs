using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InterviewScheduler_2.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
    
           
                HttpContext.Session.Clear(); // Clear all session variables
          
           
        }
    }
}
