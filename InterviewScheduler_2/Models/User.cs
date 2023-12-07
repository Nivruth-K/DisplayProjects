using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InterviewScheduler_2.Models
{
    public class User
    {
       public int UserId { get; set; }
        public string User_Name { get; set; }
        public string? User_Password { get; set;}
        public string User_Email { get; set;}
        public double  User_PhoneNumber { get; set;}
        public ICollection<Scheduler> schedulers { get; set; }

    }
}
