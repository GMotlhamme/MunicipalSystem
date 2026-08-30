namespace MunicipalSystem
{
    partial class ReportIssuesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLocation = new TextBox();
            label1 = new Label();
            lstCategory = new ListBox();
            label2 = new Label();
            txtDescription = new RichTextBox();
            label3 = new Label();
            lblDocumentUpload = new Label();
            btnDocumentUpload = new Button();
            btnSubmit = new Button();
            btnBack = new Button();
            lblEngagement = new Label();
            progressReport = new ProgressBar();
            SuspendLayout();
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(34, 93);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(313, 27);
            txtLocation.TabIndex = 0;
            txtLocation.TextChanged += txtLocation_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 70);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 1;
            label1.Text = "Location";
            // 
            // lstCategory
            // 
            lstCategory.FormattingEnabled = true;
            lstCategory.Location = new Point(34, 156);
            lstCategory.Name = "lstCategory";
            lstCategory.Size = new Size(313, 144);
            lstCategory.TabIndex = 2;
            lstCategory.SelectedIndexChanged += lstCategory_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 133);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 3;
            label2.Text = "Category Selection";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(412, 93);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(321, 208);
            txtDescription.TabIndex = 4;
            txtDescription.Text = "";
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(412, 70);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 5;
            label3.Text = "Description";
            // 
            // lblDocumentUpload
            // 
            lblDocumentUpload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDocumentUpload.AutoSize = true;
            lblDocumentUpload.Location = new Point(202, 398);
            lblDocumentUpload.Name = "lblDocumentUpload";
            lblDocumentUpload.Size = new Size(163, 20);
            lblDocumentUpload.TabIndex = 6;
            lblDocumentUpload.Text = "No Document Selected";
            // 
            // btnDocumentUpload
            // 
            btnDocumentUpload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDocumentUpload.Location = new Point(34, 388);
            btnDocumentUpload.Name = "btnDocumentUpload";
            btnDocumentUpload.Size = new Size(162, 42);
            btnDocumentUpload.TabIndex = 7;
            btnDocumentUpload.Text = "Upload Document";
            btnDocumentUpload.UseVisualStyleBackColor = true;
            btnDocumentUpload.Click += btnDocumentUpload_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSubmit.Location = new Point(394, 388);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(162, 41);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.Location = new Point(571, 388);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(162, 41);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back to main menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblEngagement
            // 
            lblEngagement.AutoSize = true;
            lblEngagement.Font = new Font("Segoe UI", 14F);
            lblEngagement.Location = new Point(235, 18);
            lblEngagement.Name = "lblEngagement";
            lblEngagement.Size = new Size(318, 32);
            lblEngagement.TabIndex = 10;
            lblEngagement.Text = "Let's get your report started!";
            // 
            // progressReport
            // 
            progressReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressReport.Location = new Point(34, 327);
            progressReport.Name = "progressReport";
            progressReport.Size = new Size(313, 29);
            progressReport.TabIndex = 11;
            progressReport.Click += progressReport_Click;
            // 
            // ReportIssuesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(782, 471);
            Controls.Add(progressReport);
            Controls.Add(lblEngagement);
            Controls.Add(btnBack);
            Controls.Add(btnSubmit);
            Controls.Add(btnDocumentUpload);
            Controls.Add(lblDocumentUpload);
            Controls.Add(label3);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(lstCategory);
            Controls.Add(label1);
            Controls.Add(txtLocation);
            MinimumSize = new Size(800, 450);
            Name = "ReportIssuesForm";
            Text = "ReportIssuesForm";
            Load += ReportIssuesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLocation;
        private Label label1;
        private ListBox lstCategory;
        private Label label2;
        private RichTextBox txtDescription;
        private Label label3;
        private Label lblDocumentUpload;
        private Button btnDocumentUpload;
        private Button btnSubmit;
        private Button btnBack;
        private Label lblEngagement;
        private ProgressBar progressReport;
    }
}