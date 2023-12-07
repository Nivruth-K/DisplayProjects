namespace InterviewScheduler_2.Models
{
    public class Round
    {
        public int RoundId { get; set; }
        public string Round_Type { get; set; }
        public ICollection<Scheduler> schedulers { get; set; }

    }
}
