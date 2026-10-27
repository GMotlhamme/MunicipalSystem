namespace MunicipalSystem
{
    partial class LocalEventsAndAnnouncementsForm
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
            lblPageTitle = new Label();
            cmbCategory = new ComboBox();
            dtpEventDate = new DateTimePicker();
            label1 = new Label();
            btnSearch = new Button();
            btnClearFilters = new Button();
            lstEvents = new ListBox();
            lblEventDetails = new Label();
            btnBack = new Button();
            lstRecommendations = new ListBox();
            label2 = new Label();
            chkFilterByDate = new CheckBox();
            btnPriorityEvent = new Button();
            btnProcessNextEvent = new Button();
            btnRecentSearch = new Button();
            SuspendLayout();
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.BackColor = Color.Cornsilk;
            lblPageTitle.Font = new Font("Segoe UI", 29F);
            lblPageTitle.Location = new Point(56, 22);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(757, 66);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Local Events and Announcements";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(56, 144);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(351, 28);
            cmbCategory.TabIndex = 1;
            // 
            // dtpEventDate
            // 
            dtpEventDate.Location = new Point(443, 144);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(236, 27);
            dtpEventDate.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 110);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 3;
            label1.Text = "Find an event";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(56, 199);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Location = new Point(687, 199);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(126, 29);
            btnClearFilters.TabIndex = 5;
            btnClearFilters.Text = "Clear ";
            btnClearFilters.UseVisualStyleBackColor = true;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // lstEvents
            // 
            lstEvents.FormattingEnabled = true;
            lstEvents.Location = new Point(56, 250);
            lstEvents.Name = "lstEvents";
            lstEvents.Size = new Size(351, 144);
            lstEvents.TabIndex = 6;
            lstEvents.SelectedIndexChanged += lstEvents_SelectedIndexChanged;
            // 
            // lblEventDetails
            // 
            lblEventDetails.AutoSize = true;
            lblEventDetails.Location = new Point(443, 250);
            lblEventDetails.Name = "lblEventDetails";
            lblEventDetails.Size = new Size(95, 20);
            lblEventDetails.TabIndex = 7;
            lblEventDetails.Text = "Event Details";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(443, 504);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(370, 29);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lstRecommendations
            // 
            lstRecommendations.FormattingEnabled = true;
            lstRecommendations.Location = new Point(56, 429);
            lstRecommendations.Name = "lstRecommendations";
            lstRecommendations.Size = new Size(351, 104);
            lstRecommendations.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 406);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 10;
            label2.Text = "Recomendations";
            // 
            // chkFilterByDate
            // 
            chkFilterByDate.AutoSize = true;
            chkFilterByDate.Location = new Point(695, 144);
            chkFilterByDate.Name = "chkFilterByDate";
            chkFilterByDate.Size = new Size(118, 24);
            chkFilterByDate.TabIndex = 11;
            chkFilterByDate.Text = "Filter by date";
            chkFilterByDate.UseVisualStyleBackColor = true;
            // 
            // btnPriorityEvent
            // 
            btnPriorityEvent.Location = new Point(182, 199);
            btnPriorityEvent.Name = "btnPriorityEvent";
            btnPriorityEvent.Size = new Size(183, 29);
            btnPriorityEvent.TabIndex = 12;
            btnPriorityEvent.Text = "View Next Priority Event";
            btnPriorityEvent.UseVisualStyleBackColor = true;
            btnPriorityEvent.Click += btnPriorityEvent_Click;
            // 
            // btnProcessNextEvent
            // 
            btnProcessNextEvent.Location = new Point(381, 199);
            btnProcessNextEvent.Name = "btnProcessNextEvent";
            btnProcessNextEvent.Size = new Size(141, 29);
            btnProcessNextEvent.TabIndex = 13;
            btnProcessNextEvent.Text = "Process Next Event";
            btnProcessNextEvent.UseVisualStyleBackColor = true;
            btnProcessNextEvent.Click += btnProcessNextEvent_Click;
            // 
            // btnRecentSearch
            // 
            btnRecentSearch.Location = new Point(528, 199);
            btnRecentSearch.Name = "btnRecentSearch";
            btnRecentSearch.Size = new Size(151, 29);
            btnRecentSearch.TabIndex = 14;
            btnRecentSearch.Text = "View Recent Search";
            btnRecentSearch.UseVisualStyleBackColor = true;
            btnRecentSearch.Click += btnRecentSearch_Click;
            // 
            // LocalEventsAndAnnouncementsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Yellow;
            ClientSize = new Size(863, 560);
            Controls.Add(btnRecentSearch);
            Controls.Add(btnProcessNextEvent);
            Controls.Add(btnPriorityEvent);
            Controls.Add(chkFilterByDate);
            Controls.Add(label2);
            Controls.Add(lstRecommendations);
            Controls.Add(btnBack);
            Controls.Add(lblEventDetails);
            Controls.Add(lstEvents);
            Controls.Add(btnClearFilters);
            Controls.Add(btnSearch);
            Controls.Add(label1);
            Controls.Add(dtpEventDate);
            Controls.Add(cmbCategory);
            Controls.Add(lblPageTitle);
            Name = "LocalEventsAndAnnouncementsForm";
            Text = "LocalEventsAndAnnouncementsForm";
            Load += LocalEventsAndAnnouncementsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPageTitle;
        private ComboBox cmbCategory;
        private DateTimePicker dtpEventDate;
        private Label label1;
        private Button btnSearch;
        private Button btnClearFilters;
        private ListBox lstEvents;
        private Label lblEventDetails;
        private Button btnBack;
        private ListBox lstRecommendations;
        private Label label2;
        private CheckBox chkFilterByDate;
        private Button btnPriorityEvent;
        private Button btnProcessNextEvent;
        private Button btnRecentSearch;
    }
}