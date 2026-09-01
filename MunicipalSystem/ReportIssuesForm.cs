using MunicipalDataSystem;
using MunicipalDataSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalSystem
{
    public partial class ReportIssuesForm : Form
    {
        private string selectedFilePath = "";
        private readonly IssueService issueService;
        public ReportIssuesForm()
        {
            InitializeComponent();
            issueService = new IssueService();

        }

        private void ReportIssuesForm_Load(object sender, EventArgs e)
        {
            lstCategory.Items.Add("Sanitation");
            lstCategory.Items.Add("Roads");
            lstCategory.Items.Add("Water");
            lstCategory.Items.Add("Electricity");
            lstCategory.Items.Add("Waste Management");
            lstCategory.Items.Add("Utilities");
            lstCategory.Items.Add("Other");
        }
        private void UpdateProgress()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                progress += 25;
            }

            if (lstCategory.SelectedIndex != -1)
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                progress += 25;
            }

            if (!string.IsNullOrWhiteSpace(lblDocumentUpload.Text) &&
                lblDocumentUpload.Text != "No Document Selected")
            {
                progress += 25;
            }

            progressReport.Value = progress;

            if (progress == 0)
            {
                lblEngagement.Text = "Let's get your report started.";
            }
            else if (progress == 25)
            {
                lblEngagement.Text = "Great start. Keep going.";
            }
            else if (progress == 50)
            {
                lblEngagement.Text = "Halfway there. Tell us what happened.";
            }
            else if (progress == 75)
            {
                lblEngagement.Text = "Almost done. You can attach supporting evidence.";
            }
            else
            {
                lblEngagement.Text = "Your report is ready to submit!";
            }
        }

        private void progressReport_Click(object sender, EventArgs e)
        {

        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();

        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();

        }

        private void btnDocumentUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select a document or image";
            openFileDialog.Filter = "Images and Documents|*.jpg;*.jpeg;*.png;*.pdf;*.doc;*.docx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblDocumentUpload.Text = Path.GetFileName(openFileDialog.FileName);

                UpdateProgress();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show(
                    "Please enter the location of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (lstCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a category.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show(
                    "Please provide a description of the issue.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            Issue newIssue = new Issue(
                txtLocation.Text.Trim(),
                lstCategory.SelectedItem.ToString(),
                txtDescription.Text.Trim(),
                selectedFilePath
            );

            issueService.AddIssue(newIssue);

            MessageBox.Show("Your issue has been successfully reported.", "Report Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
        }

        private void ClearForm()
        {
            txtLocation.Clear();
            lstCategory.SelectedIndex = -1;
            txtDescription.Clear();

            selectedFilePath = "";
            lblDocumentUpload.Text = "No Document Selected";

            progressReport.Value = 0;
            lblEngagement.Text = "Let's get your report started!";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Close();
        }
    }
}
