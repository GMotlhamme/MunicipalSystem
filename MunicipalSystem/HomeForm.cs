using MunicipalDataSystem.Services;

namespace MunicipalSystem
{
    public partial class HomeForm : Form
    {
        private readonly IssueService issueService;

        public HomeForm()
        {
            InitializeComponent();

            issueService = new IssueService();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportIssues =
        new ReportIssuesForm(issueService, this);

            reportIssues.Show();
            this.Hide();
        }

        private void btnLocalEventsAndAnnouncements_Click(object sender, EventArgs e)
        {
            LocalEventsAndAnnouncementsForm localEvents = new LocalEventsAndAnnouncementsForm(this);

            localEvents.Show();
            this.Hide();
        }

        private void btnServiceRequestStatus_Click(object sender, EventArgs e)
        {
            ServiceRequestStatusForm requestStatus = new ServiceRequestStatusForm(issueService, this);

            requestStatus.Show();
            this.Hide();
        }
    }
}