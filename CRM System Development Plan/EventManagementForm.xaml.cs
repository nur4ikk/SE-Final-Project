using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM_System_Development_Plan
{
    /// <summary>
    /// Interaction logic for EventManagementForm.xaml
    /// </summary>
    public partial class EventManagementForm : Window
    {
        private ObservableCollection<Event> events;
        private ObservableCollection<Event> allEvents;

        public EventManagementForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            events = new ObservableCollection<Event>();
            allEvents = new ObservableCollection<Event>();
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Events";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var _events = new Event
                        {
                            EventID = reader.GetInt32(0),
                            EventName = reader.GetString(1),
                            Category = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Date = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            AttendanceCount = reader.GetInt32(4),
                            Location = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Description = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        };
                        events.Add(_events);
                        allEvents.Add(_events);
                    }
                }
            }

            dgEvents.ItemsSource = events;
        }
        // Search button click handler
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
           

            // Filter based on search input and selected membership type
            var filteredList = allEvents.Where(m =>
                (string.IsNullOrEmpty(searchText) || m.EventName.ToLower().Contains(searchText))
            ).ToList();

            // Update the DataGrid with the filtered list
            events.Clear();
            foreach (var member in filteredList)
            {
                events.Add(member);
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text) || string.IsNullOrWhiteSpace(txtCategory.Text) || string.IsNullOrWhiteSpace(dpDate.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newEvent = new Event
            {
                EventName = txtEventName.Text,
                Category = txtCategory.Text,
                Date = dpDate.Text,
                AttendanceCount = int.TryParse(txtAttendance.Text, out var count) ? count : 0,
                Location = txtLocation.Text,
                Description = txtDescription.Text
            };

            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Events (EventName, Category, Date, AttendanceCount, Location, Description) VALUES (@EventName, @Category, @Date, @AttendanceCount, @Location, @Description)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventName", newEvent.EventName);
                    command.Parameters.AddWithValue("@Category", newEvent.Category);
                    command.Parameters.AddWithValue("@Date", newEvent.Date);
                    command.Parameters.AddWithValue("@AttendanceCount", newEvent.AttendanceCount);
                    command.Parameters.AddWithValue("@Location", newEvent.Location);
                    command.Parameters.AddWithValue("@Description", newEvent.Description);
                    command.ExecuteNonQuery();
                }
            }

            LoadEvents();
            ClearFields();
        }
        private void dgEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if any row is selected
            if (dgEvents.SelectedItem != null)
            {
                // Cast the selected item to the appropriate data model
                var selectedEvent = (Event)dgEvents.SelectedItem;

                txtEventName.Text = selectedEvent.EventName;
                txtCategory.Text= selectedEvent.Category;
                dpDate.Text = selectedEvent.Date;
                txtAttendance.Text = selectedEvent.AttendanceCount.ToString();
                txtLocation.Text= selectedEvent.Location;
                txtDescription.Text= selectedEvent.Description;

            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgEvents.SelectedItem is Event selectedEvent)
            {
                selectedEvent.EventName = txtEventName.Text;
                selectedEvent.Category = txtCategory.Text;
                selectedEvent.Date = dpDate.Text;
                selectedEvent.AttendanceCount = int.TryParse(txtAttendance.Text, out var count) ? count : 0;
                selectedEvent.Location = txtLocation.Text;
                selectedEvent.Description = txtDescription.Text;

                using (var connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Events SET EventName = @EventName, Category = @Category, Date = @Date, AttendanceCount = @AttendanceCount, Location = @Location, Description = @Description WHERE EventID = @EventID";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventName", selectedEvent.EventName);
                        command.Parameters.AddWithValue("@Category", selectedEvent.Category);
                        command.Parameters.AddWithValue("@Date", selectedEvent.Date);
                        command.Parameters.AddWithValue("@AttendanceCount", selectedEvent.AttendanceCount);
                        command.Parameters.AddWithValue("@Location", selectedEvent.Location);
                        command.Parameters.AddWithValue("@Description", selectedEvent.Description);
                        command.Parameters.AddWithValue("@EventID", selectedEvent.EventID);
                        command.ExecuteNonQuery();
                    }
                }

                LoadEvents();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Select an event to edit.", "Edit Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgEvents.SelectedItem is Event selectedEvent)
            {
                using (var connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Events WHERE EventID = @EventID";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventID", selectedEvent.EventID);
                        command.ExecuteNonQuery();
                    }
                }

                LoadEvents();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Select an event to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearFields()
        {
            txtEventName.Clear();
            txtCategory.Clear();
            dpDate.SelectedDate = null;
            txtAttendance.Clear();
            txtLocation.Clear();
            txtDescription.Clear();
        }
    }

    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public int AttendanceCount { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
