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
    public partial class LocalEventsAndAnnouncementsForm : Form
    {
        public LocalEventsAndAnnouncementsForm(HomeForm homeForm)
        {
            InitializeComponent();
            LoadSampleEvents();
            LoadCategories();
            LoadRecommendations();
            this.homeForm = homeForm;
        }

        // Handles event storage, searching and recommendations.
        private readonly EventService eventService = new EventService();
        private readonly HomeForm homeForm;
        private void LoadSampleEvents()
        {
            // Sample municipal events for testing the search and recommendation features.
            eventService.AddEvent(new MunicipalDataSystem.Event
            {
                EventId = 1,
                Title = "Community Cleanup",
                Description = "Join residents in cleaning public spaces.",
                Category = "Community",
                Date = new DateTime(2026, 10, 20),
                Location = "Community Hall",
                IsAnnouncement = false
            });

            eventService.AddEvent(new MunicipalDataSystem.Event
            {
                EventId = 2,
                Title = "Youth Coding Workshop",
                Description = "An introduction to programming for young people.",
                Category = "Education",
                Date = new DateTime(2026, 10, 24),
                Location = "Public Library",
                IsAnnouncement = false
            });

            eventService.AddEvent(new MunicipalDataSystem.Event
            {
                EventId = 3,
                Title = "Water Interruption Notice",
                Description = "Scheduled maintenance may temporarily interrupt water supply.",
                Category = "Announcements",
                Date = new DateTime(2026, 10, 18),
                Location = "Ward 4",
                IsAnnouncement = true
            });

            eventService.AddEvent(new MunicipalDataSystem.Event
            {
                EventId = 4,
                Title = "Community Sports Day",
                Description = "A day of sporting activities for local residents.",
                Category = "Sports",
                Date = new DateTime(2026, 10, 28),
                Location = "Municipal Sports Ground",
                IsAnnouncement = false
            });

            eventService.AddEvent(new MunicipalDataSystem.Event
            {
                EventId = 5,
                Title = "Local Health Awareness Day",
                Description = "Learn about local health services and wellness programmes.",
                Category = "Health",
                Date = new DateTime(2026, 11, 5),
                Location = "Civic Centre",
                IsAnnouncement = false
            });
        }

        private void LoadCategories()
        {
            // Populate the dropdown with unique categories from the service.
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            foreach (string category in eventService.GetCategories().OrderBy(c => c))
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;
        }
        private void LocalEventsAndAnnouncementsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Start with all events stored in the service.
            List<MunicipalDataSystem.Event> matchingEvents =
                eventService.GetAllEvents();

            // Filter by category unless the user selected "All Categories".
            if (cmbCategory.SelectedItem.ToString() != "All Categories")
            {
                string selectedCategory = cmbCategory.SelectedItem.ToString();

                matchingEvents = matchingEvents
                    .Where(ev => ev.Category == selectedCategory)
                    .ToList();
            }

            // Filter by date if the user enabled the date filter.
            if (chkFilterByDate.Checked)
            {
                DateTime selectedDate = dtpEventDate.Value.Date;

                matchingEvents = matchingEvents
                    .Where(ev => ev.Date.Date == selectedDate)
                    .ToList();
            }

            // Display the matching events.

            // Bind the matching events to the ListBox.
            lstEvents.DataSource = null;
            lstEvents.DisplayMember = "Title";
            lstEvents.DataSource = matchingEvents;

            if (matchingEvents.Count == 0)
            {
                lblEventDetails.Text = "No event selected.";

                MessageBox.Show(
                    "No events match your selected filters.",
                    "No Events Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                lblEventDetails.Text = "Select an event to view its details.";
            }

            // Record a specific category search as a user preference.
            if (cmbCategory.SelectedItem != null &&
                cmbCategory.SelectedItem.ToString() != "All Categories")
            {
                eventService.RecordCategorySearch(
                    cmbCategory.SelectedItem.ToString());
            }

            // Refresh the recommendations after recording the search.
            LoadRecommendations();
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItem is MunicipalDataSystem.Event selectedEvent)
            {
                lblEventDetails.Text =
                    $"Title: {selectedEvent.Title}\n\n" +
                    $"Category: {selectedEvent.Category}\n\n" +
                    $"Date: {selectedEvent.Date:dd MMMM yyyy}\n\n" +
                    $"Location: {selectedEvent.Location}\n\n" +
                    $"Description: {selectedEvent.Description}\n\n" +
                    $"Type: {(selectedEvent.IsAnnouncement ? "Announcement" : "Event")}";
            }
        }


        private void LoadRecommendations()
        {
            // Retrieve recommendations based on the user's search history.
            List<MunicipalDataSystem.Event> recommendations =
                eventService.GetRecommendedEvents();

            lstRecommendations.DataSource = null;
            lstRecommendations.DisplayMember = "Title";
            lstRecommendations.DataSource = recommendations;

        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            // Reset the category and date filters.
            cmbCategory.SelectedIndex = 0;
            chkFilterByDate.Checked = false;
            dtpEventDate.Value = DateTime.Today;

            // Clear the selected event details.
            lblEventDetails.Text = "Select an event to view its details.";

            // Refresh the list to show all events.
            List<MunicipalDataSystem.Event> allEvents =
                eventService.GetAllEvents();

            lstEvents.DataSource = null;
            lstEvents.DisplayMember = "Title";
            lstEvents.DataSource = allEvents;

            // Keep recommendations based on previous searches.
            LoadRecommendations();
        }

        private void btnPriorityEvent_Click(object sender, EventArgs e)
        {
            // Prepare the priority queue using the available events.
            eventService.LoadPriorityEvents();

            MunicipalDataSystem.Event nextEvent =
                eventService.GetNextPriorityEvent();

            if (nextEvent == null)
            {
                MessageBox.Show("There are no events available.");
                return;
            }

            MessageBox.Show(
                $"Next priority item:\n\n" +
                $"Title: {nextEvent.Title}\n" +
                $"Category: {nextEvent.Category}\n" +
                $"Date: {nextEvent.Date:dd MMMM yyyy}\n" +
                $"Type: {(nextEvent.IsAnnouncement ? "Announcement" : "Event")}",
                "Priority Queue",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnProcessNextEvent_Click(object sender, EventArgs e)
        {
            // Process events in the order they were added.
            MunicipalDataSystem.Event nextEvent =
                eventService.ProcessNextEvent();

            if (nextEvent == null)
            {
                MessageBox.Show(
                    "There are no more events in the queue.",
                    "Queue Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            MessageBox.Show(
                $"Processed event: {nextEvent.Title}\n" +
                $"Date: {nextEvent.Date:dd MMMM yyyy}",
                "Queue Processing",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnRecentSearch_Click(object sender, EventArgs e)
        {
            // Peek at the latest search without removing it from the stack.
            string recentSearch = eventService.GetMostRecentSearch();

            if (string.IsNullOrEmpty(recentSearch))
            {
                MessageBox.Show(
                    "No searches have been recorded yet.",
                    "Search History",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            MessageBox.Show(
                $"Your most recent category search was: {recentSearch}",
                "Search History",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            homeForm.Show();
            this.Close();
        }
    }
}
