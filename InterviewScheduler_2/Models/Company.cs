namespace InterviewScheduler_2.Models
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public ICollection<Scheduler> schedulers { get; set; }  
    }
}
