
namespace ResumeTracker.Core.Models
{
    public class TrackedApplication
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string? Location { get; set; }
        public bool IsRemote { get; set; }
        public string? ApplicationSource { get; set; }

        private DateTime _dateApplied = DateTime.UtcNow;
        public DateTime DateApplied
        {
            get => _dateApplied;
            set => _dateApplied = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public DateTime SuggestedFollowUpDate => DateApplied.AddDays(7);

        private DateTime? _followUpDate;
        public DateTime? FollowUpDate
        {
            get => _followUpDate;
            set => _followUpDate = value.HasValue
                ? DateTime.SpecifyKind(value.Value, DateTimeKind.Utc)
                : null;
        }

        public bool? FollowedUp => FollowUpDate.HasValue;

        public string? ResponseReceived { get; set; }
        public string? Notes { get; set; }
    }

}