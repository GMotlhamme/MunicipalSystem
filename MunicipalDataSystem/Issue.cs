namespace MunicipalDataSystem
{
    public class Issue
    {
        public string RequestId { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime DateReported { get; set; }
        public IssueStatus Status { get; set; }
        public IssuePriority Priority { get; set; }

        public Issue(
            string location,
            string category,
            string description,
            string attachmentPath)
        {
            RequestId = $"MS-{Guid.NewGuid():N}";
            Location = location;
            Category = category;
            Description = description;
            AttachmentPath = attachmentPath;
            DateReported = DateTime.Now;
            Status = IssueStatus.Submitted;
            Priority = category switch
            {
                "Electricity" => IssuePriority.High,
                "Water" => IssuePriority.Medium,
                _ => IssuePriority.Low
            };
        }
    }
}
