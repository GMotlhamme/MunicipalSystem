namespace MunicipalSystem
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssuesForm reportIssues = new ReportIssuesForm();
            reportIssues.Show();
            this.Hide();
        }

        private void btnLocalEventsAndAnnouncements_Click(object sender, EventArgs e)
        {
            LocalEventsAndAnnouncementsForm localEvents = new LocalEventsAndAnnouncementsForm();
            localEvents.Show();
            this.Hide();
        }
    }
}
