namespace MunicipalSystem
{
    partial class ServiceRequestStatusForm
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
            dgvRequests = new DataGridView();
            txtRequestId = new TextBox();
            btnTrackRequest = new Button();
            lblRequestDetails = new Label();
            btnBack = new Button();
            label1 = new Label();
            btnViewPriorityRequest = new Button();
            grpNetworkAnalysis = new GroupBox();
            cmbStartLocation = new ComboBox();
            btnBFS = new Button();
            btnDFS = new Button();
            btnMST = new Button();
            lstNetworkResults = new ListBox();
            btnProcessPriority = new Button();
            btnResolveRequest = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequests.Location = new Point(403, 31);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(695, 324);
            dgvRequests.TabIndex = 0;
            dgvRequests.CellContentClick += dgvRequests_CellContentClick;
            // 
            // txtRequestId
            // 
            txtRequestId.Location = new Point(29, 41);
            txtRequestId.Name = "txtRequestId";
            txtRequestId.Size = new Size(340, 27);
            txtRequestId.TabIndex = 1;
            txtRequestId.TextChanged += txtRequestId_TextChanged;
            // 
            // btnTrackRequest
            // 
            btnTrackRequest.Location = new Point(210, 94);
            btnTrackRequest.Name = "btnTrackRequest";
            btnTrackRequest.Size = new Size(159, 29);
            btnTrackRequest.TabIndex = 2;
            btnTrackRequest.Text = "Track Request";
            btnTrackRequest.UseVisualStyleBackColor = true;
            btnTrackRequest.Click += btnTrackRequest_Click_1;
            // 
            // lblRequestDetails
            // 
            lblRequestDetails.AutoSize = true;
            lblRequestDetails.Location = new Point(29, 188);
            lblRequestDetails.MaximumSize = new Size(350, 250);
            lblRequestDetails.MinimumSize = new Size(340, 230);
            lblRequestDetails.Name = "lblRequestDetails";
            lblRequestDetails.Size = new Size(340, 230);
            lblRequestDetails.TabIndex = 3;
            lblRequestDetails.Text = "Details";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(787, 607);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(311, 29);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 17);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 5;
            label1.Text = "Enter tracking ID";
            // 
            // btnViewPriorityRequest
            // 
            btnViewPriorityRequest.Location = new Point(29, 94);
            btnViewPriorityRequest.Name = "btnViewPriorityRequest";
            btnViewPriorityRequest.Size = new Size(161, 29);
            btnViewPriorityRequest.TabIndex = 6;
            btnViewPriorityRequest.Text = "View Priority Request";
            btnViewPriorityRequest.UseVisualStyleBackColor = true;
            btnViewPriorityRequest.Click += btnViewPriorityRequest_Click;
            // 
            // grpNetworkAnalysis
            // 
            grpNetworkAnalysis.Location = new Point(787, 392);
            grpNetworkAnalysis.Name = "grpNetworkAnalysis";
            grpNetworkAnalysis.Size = new Size(311, 183);
            grpNetworkAnalysis.TabIndex = 7;
            grpNetworkAnalysis.TabStop = false;
            grpNetworkAnalysis.Text = "Municipal Network Analysis";
            // 
            // cmbStartLocation
            // 
            cmbStartLocation.FormattingEnabled = true;
            cmbStartLocation.Location = new Point(29, 462);
            cmbStartLocation.Name = "cmbStartLocation";
            cmbStartLocation.Size = new Size(354, 28);
            cmbStartLocation.TabIndex = 8;
            cmbStartLocation.Text = "Select starting location";
            // 
            // btnBFS
            // 
            btnBFS.Location = new Point(29, 510);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(354, 29);
            btnBFS.TabIndex = 9;
            btnBFS.Text = "Breadth-First Search";
            btnBFS.UseVisualStyleBackColor = true;
            btnBFS.Click += btnBFS_Click;
            // 
            // btnDFS
            // 
            btnDFS.Location = new Point(29, 552);
            btnDFS.Name = "btnDFS";
            btnDFS.Size = new Size(354, 29);
            btnDFS.TabIndex = 10;
            btnDFS.Text = "Depth-First Search";
            btnDFS.UseVisualStyleBackColor = true;
            btnDFS.Click += btnDFS_Click;
            // 
            // btnMST
            // 
            btnMST.Location = new Point(29, 597);
            btnMST.Name = "btnMST";
            btnMST.Size = new Size(354, 29);
            btnMST.TabIndex = 11;
            btnMST.Text = "Minimum Spanning Tree";
            btnMST.UseVisualStyleBackColor = true;
            btnMST.Click += btnMST_Click;
            // 
            // lstNetworkResults
            // 
            lstNetworkResults.FormattingEnabled = true;
            lstNetworkResults.Location = new Point(403, 392);
            lstNetworkResults.Name = "lstNetworkResults";
            lstNetworkResults.Size = new Size(357, 244);
            lstNetworkResults.TabIndex = 12;
            // 
            // btnProcessPriority
            // 
            btnProcessPriority.Location = new Point(210, 144);
            btnProcessPriority.Name = "btnProcessPriority";
            btnProcessPriority.Size = new Size(161, 29);
            btnProcessPriority.TabIndex = 13;
            btnProcessPriority.Text = "Process Priority Request";
            btnProcessPriority.UseVisualStyleBackColor = true;
            btnProcessPriority.Click += btnProcessPriority_Click;
            // 
            // btnResolveRequest
            // 
            btnResolveRequest.Location = new Point(29, 144);
            btnResolveRequest.Name = "btnResolveRequest";
            btnResolveRequest.Size = new Size(161, 29);
            btnResolveRequest.TabIndex = 14;
            btnResolveRequest.Text = "Resolve Request";
            btnResolveRequest.UseVisualStyleBackColor = true;
            btnResolveRequest.Click += btnResolveRequest_Click;
            // 
            // ServiceRequestStatusForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(1124, 659);
            Controls.Add(btnResolveRequest);
            Controls.Add(btnProcessPriority);
            Controls.Add(lstNetworkResults);
            Controls.Add(btnMST);
            Controls.Add(btnDFS);
            Controls.Add(btnBFS);
            Controls.Add(cmbStartLocation);
            Controls.Add(grpNetworkAnalysis);
            Controls.Add(btnViewPriorityRequest);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(lblRequestDetails);
            Controls.Add(btnTrackRequest);
            Controls.Add(txtRequestId);
            Controls.Add(dgvRequests);
            Name = "ServiceRequestStatusForm";
            Text = "ServiceRequestStatusForm";
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRequests;
        private TextBox txtRequestId;
        private Button btnTrackRequest;
        private Label lblRequestDetails;
        private Button btnBack;
        private Label label1;
        private Button btnViewPriorityRequest;
        private GroupBox grpNetworkAnalysis;
        private ComboBox cmbStartLocation;
        private Button btnBFS;
        private Button btnDFS;
        private Button btnMST;
        private ListBox lstNetworkResults;
        private Button btnProcessPriority;
        private Button btnResolveRequest;
    }
}