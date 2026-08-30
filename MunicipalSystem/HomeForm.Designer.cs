namespace MunicipalSystem
{
    partial class HomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnReportIssues = new Button();
            btnLocalEventsAndAnnouncements = new Button();
            btnServiceRequestStatus = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(135, 58);
            label1.Name = "label1";
            label1.Size = new Size(559, 41);
            label1.TabIndex = 0;
            label1.Text = "Welcome to your local municality system";
            // 
            // btnReportIssues
            // 
            btnReportIssues.BackColor = Color.White;
            btnReportIssues.ImageAlign = ContentAlignment.MiddleRight;
            btnReportIssues.Location = new Point(8, 311);
            btnReportIssues.Name = "btnReportIssues";
            btnReportIssues.Size = new Size(256, 42);
            btnReportIssues.TabIndex = 1;
            btnReportIssues.Text = "Report Issues";
            btnReportIssues.UseVisualStyleBackColor = false;
            btnReportIssues.Click += btnReportIssues_Click;
            // 
            // btnLocalEventsAndAnnouncements
            // 
            btnLocalEventsAndAnnouncements.Enabled = false;
            btnLocalEventsAndAnnouncements.Location = new Point(270, 311);
            btnLocalEventsAndAnnouncements.Name = "btnLocalEventsAndAnnouncements";
            btnLocalEventsAndAnnouncements.Size = new Size(256, 42);
            btnLocalEventsAndAnnouncements.TabIndex = 2;
            btnLocalEventsAndAnnouncements.Text = "Local Events And Announcements";
            btnLocalEventsAndAnnouncements.UseVisualStyleBackColor = true;
            // 
            // btnServiceRequestStatus
            // 
            btnServiceRequestStatus.Enabled = false;
            btnServiceRequestStatus.Location = new Point(532, 311);
            btnServiceRequestStatus.Name = "btnServiceRequestStatus";
            btnServiceRequestStatus.Size = new Size(256, 42);
            btnServiceRequestStatus.TabIndex = 3;
            btnServiceRequestStatus.Text = "Service Request Status";
            btnServiceRequestStatus.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(190, 191);
            label2.Name = "label2";
            label2.Size = new Size(456, 32);
            label2.TabIndex = 4;
            label2.Text = "What services are you looking for today?!";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnServiceRequestStatus);
            Controls.Add(btnLocalEventsAndAnnouncements);
            Controls.Add(btnReportIssues);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            Name = "HomeForm";
            Text = "Municipal Services";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnReportIssues;
        private Button btnLocalEventsAndAnnouncements;
        private Button btnServiceRequestStatus;
        private Label label2;
    }
}
