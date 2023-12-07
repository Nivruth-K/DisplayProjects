using Microsoft.AspNetCore.Mvc;
using InterviewScheduler_2.Models;

namespace InterviewScheduler_2.ViewComponents
{
    public class RoundViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var model= new Round();
            return View("Round",model);
        }
    }
}
