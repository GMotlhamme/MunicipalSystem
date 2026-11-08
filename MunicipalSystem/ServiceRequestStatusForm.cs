using MunicipalDataSystem;
using MunicipalDataSystem.DataStructures;
using MunicipalDataSystem.Services;

namespace MunicipalSystem
{
    public partial class ServiceRequestStatusForm : Form
    {
        private readonly IssueService issueService;
        private readonly HomeForm homeForm;

        public ServiceRequestStatusForm(
            IssueService service,
            HomeForm home)
        {
            InitializeComponent();

            issueService = service;
            homeForm = home;

            LoadRequests();
            LoadServiceLocations();
        }
        private void LoadServiceLocations()
        {
            cmbStartLocation.DataSource = issueService.GetServiceLocations();
            cmbStartLocation.SelectedIndex = -1;
        }

        // Display all submitted requests in the DataGridView
        private void LoadRequests()
        {
            dgvRequests.DataSource = null;

            dgvRequests.DataSource = issueService.GetIssuesSortedById()
                .Select(issue => new
                {
                    issue.RequestId,
                    issue.Category,
                    issue.Location,
                    issue.DateReported,
                    Status = issue.Status.ToString()
                })
                .ToList();
        }

        // Search for a request using its unique tracking ID
        private void btnTrackRequest_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e) { }

        // Return to the existing main menu
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            homeForm.Show();
            this.Close();
        }

        private void dgvRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtRequestId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTrackRequest_Click_1(object sender, EventArgs e)
        {
            string requestId = txtRequestId.Text.Trim();

            if (string.IsNullOrWhiteSpace(requestId))
            {
                MessageBox.Show("Please enter a tracking ID.");
                return;
            }

            Issue issue = issueService.GetIssueById(requestId);

            if (issue == null)
            {
                lblRequestDetails.Text = "No request found with that tracking ID.";
                return;
            }

            lblRequestDetails.Text =
                $"Tracking ID: {issue.RequestId}\n" +
                $"Category: {issue.Category}\n" +
                $"Location: {issue.Location}\n" +
                $"Description: {issue.Description}\n" +
                $"Date Reported: {issue.DateReported:g}\n" +
                $"Status: {issue.Status}";
        }

        private void btnViewPriorityRequest_Click(object sender, EventArgs e)
        {
            Issue? issue = issueService.GetHighestPriorityRequest();

            if (issue == null)
            {
                MessageBox.Show(
                    "There are no priority requests available.",
                    "Priority Queue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            MessageBox.Show(
                $"Tracking ID: {issue.RequestId}\n" +
                $"Category: {issue.Category}\n" +
                $"Location: {issue.Location}\n" +
                $"Priority: {issue.Priority}\n" +
                $"Status: {issue.Status}",
                "Highest Priority Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Display Breadth-First Search traversal
        private void btnBFS_Click(object sender, EventArgs e)
        {
            if (cmbStartLocation.SelectedItem == null)
            {
                MessageBox.Show("Please select a starting location.");
                return;
            }

            string start = cmbStartLocation.SelectedItem.ToString()!;

            List<string> results =
                issueService.GetConnectedLocationsBFS(start);

            lstNetworkResults.Items.Clear();
            lstNetworkResults.Items.Add("Breadth-First Search:");

            foreach (string location in results)
                lstNetworkResults.Items.Add(location);
        }

        // Display Depth-First Search traversal
        private void btnDFS_Click(object sender, EventArgs e)
        {
            if (cmbStartLocation.SelectedItem == null)
            {
                MessageBox.Show("Please select a starting location.");
                return;
            }

            string start = cmbStartLocation.SelectedItem.ToString()!;

            List<string> results =
                issueService.GetConnectedLocationsDFS(start);

            lstNetworkResults.Items.Clear();
            lstNetworkResults.Items.Add("Depth-First Search:");

            foreach (string location in results)
                lstNetworkResults.Items.Add(location);
        }

        // Display the Minimum Spanning Tree
        private void btnMST_Click(object sender, EventArgs e)
        {
            List<WeightedConnection> connections =
                issueService.GetMinimumSpanningTree();

            lstNetworkResults.Items.Clear();
            lstNetworkResults.Items.Add("Minimum Spanning Tree:");

            int totalWeight = 0;

            foreach (WeightedConnection connection in connections)
            {
                lstNetworkResults.Items.Add(
                    $"{connection.LocationA} - {connection.LocationB} " +
                    $"(Weight: {connection.Weight})");

                totalWeight += connection.Weight;
            }

            lstNetworkResults.Items.Add("------------------------");
            lstNetworkResults.Items.Add($"Total Weight: {totalWeight}");
        }

        private void btnProcessPriority_Click(object sender, EventArgs e)
        {
            Issue? issue = issueService.ProcessHighestPriorityRequest();

            if (issue == null)
            {
                MessageBox.Show(
                    "There are no more requests waiting to be processed.",
                    "Priority Queue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            MessageBox.Show(
                $"Request: {issue.RequestId}\n" +
                $"Category: {issue.Category}\n" +
                $"Priority: {issue.Priority}\n" +
                $"New Status: {issue.Status}",
                "Request Processing Started",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Refresh the displayed requests
            LoadRequests();
        }

        private void btnResolveRequest_Click(object sender, EventArgs e)
        {
            string requestId = txtRequestId.Text.Trim();

            if (string.IsNullOrWhiteSpace(requestId))
            {
                MessageBox.Show(
                    "Please enter a tracking ID.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            bool resolved = issueService.ResolveRequest(requestId);

            if (!resolved)
            {
                MessageBox.Show(
                    "Request not found or it has not been marked as In Progress.",
                    "Unable to Resolve",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "The service request has been marked as Resolved.",
                "Request Resolved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadRequests();

            // Refresh the details if the request is currently displayed
            btnTrackRequest_Click(sender, e);
        }
    }
}