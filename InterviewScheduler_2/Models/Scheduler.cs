using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewScheduler_2.Models
{
    public class Scheduler
    {
        public int SchedulerId { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime RegisteredDate { get; set; }


      
        public Company Company { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }

        public string AppliedPost { get; set;}
        public DateTime Scheduled_Date { get; set; }

        public Round Round { get; set; }

        [ForeignKey("Round")]
        public int RoundId { get; set; }
        public Boolean Active { get; set; }
    }
}
