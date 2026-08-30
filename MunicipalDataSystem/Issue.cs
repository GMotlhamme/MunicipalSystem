namespace MunicipalDataSystem
{
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime DateReported { get; set; }

        public Issue(
            string location,
            string category,
            string description,
            string attachmentPath)
        {
            Location = location;
            Category = category;
            Description = description;
            AttachmentPath = attachmentPath;
            DateReported = DateTime.Now;
        }
    }
}
