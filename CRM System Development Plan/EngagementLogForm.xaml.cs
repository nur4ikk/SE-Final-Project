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
    /// Interaction logic for EngagementLogForm.xaml
    /// </summary>
    public partial class EngagementLogForm : Window
    {
        public EngagementLogForm()
        {
            InitializeComponent();
            LoadMembers();
            LoadEvents();
            LoadEngagementLogs();
        }

        // Load Members into ComboBox
        private void LoadMembers()
        {
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "SELECT MemberID, Name FROM Members";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var members = new ObservableCollection<dynamic>();
                    while (reader.Read())
                    {
                        members.Add(new
                        {
                            MemberID = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                    cbMember.ItemsSource = members;
                    cbMember.DisplayMemberPath = "Name";
                    cbMember.SelectedValuePath = "MemberID";
                }
            }
        }

        // Load Events into ComboBox
        private void LoadEvents()
        {
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "SELECT EventID, EventName FROM Events";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var events = new ObservableCollection<dynamic>();
                    while (reader.Read())
                    {
                        events.Add(new
                        {
                            EventID = reader.GetInt32(0),
                            EventName = reader.GetString(1)
                        });
                    }
                    cbEvent.ItemsSource = events;
                    cbEvent.DisplayMemberPath = "EventName";
                    cbEvent.SelectedValuePath = "EventID";
                }
            }
        }

        // Load Engagement Logs into DataGrid
        private void LoadEngagementLogs()
        {
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = @"SELECT LogID, m.MemberID,m.Name as MemberName, e.EventID,e.EventName, EngagementType, EngagementDate FROM EngagementLog el
                                    join Members m ON m.MemberID = el.MemberID
                                    JOIN Events e ON  e.EventID = el.EventID";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    var engagementLogs = new ObservableCollection<EngagementLog>();
                    while (reader.Read())
                    {
                        engagementLogs.Add(new EngagementLog
                        {
                            LogID = reader.GetInt32(0),
                            MemberID = reader.GetInt32(1),
                            MemberName= reader.GetString(2),
                            EventID = reader.GetInt32(3),
                            EventName = reader.GetString(4),
                            EngagementType = reader.GetString(5),
                            EngagementDate = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        });
                    }
                    dgEngagementLogs.ItemsSource = engagementLogs;
                }
            }
        }

        // Add Engagement Button Click Event
        private void btnAddEngagement_Click(object sender, RoutedEventArgs e)
        {
            if (cbMember.SelectedValue == null || cbEvent.SelectedValue == null || dpEngagementDate.SelectedDate == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newEngagement = new EngagementLog
            {
                MemberID = (int)cbMember.SelectedValue,
                EventID = (int)cbEvent.SelectedValue,
                EngagementType = ((ComboBoxItem)cbEngagementType.SelectedItem).Content.ToString(),
                EngagementDate = dpEngagementDate.SelectedDate.Value.ToString("yyyy-MM-dd")
            };

            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO EngagementLog (MemberID, EventID, EngagementType, EngagementDate) " +
                               "VALUES (@MemberID, @EventID, @EngagementType, @EngagementDate)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", newEngagement.MemberID);
                    command.Parameters.AddWithValue("@EventID", newEngagement.EventID);
                    command.Parameters.AddWithValue("@EngagementType", newEngagement.EngagementType);
                    command.Parameters.AddWithValue("@EngagementDate", newEngagement.EngagementDate);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Engagement logged successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadEngagementLogs();
            ClearFields();
        }


        // Assuming the EngagementLog class has the properties LogID, MemberID, MemberName, EventID, EventName, EngagementType, EngagementDate
        private void dgEngagementLogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if any row is selected
            if (dgEngagementLogs.SelectedItem != null)
            {
                // Cast the selected item to the appropriate data model
                var selectedLog = (EngagementLog)dgEngagementLogs.SelectedItem;

                // Populate the form fields with the selected row's data
                cbMember.SelectedValue = selectedLog.MemberID; // Assuming MemberID is the value you want to use
                cbEvent.SelectedValue = selectedLog.EventID; // Assuming EventID is the value you want to use
               // cbEngagementType.SelectedValue = selectedLog.EngagementType; // Assuming EngagementType is a string

                foreach (ComboBoxItem item in cbEngagementType.Items)
                {
                    if (item.Content.ToString() == selectedLog.EngagementType)
                    {
                        cbEngagementType.SelectedItem = item;
                        break;
                    }
                }
                dpEngagementDate.SelectedDate = selectedLog.EngagementDate == "" ? DateTime.Now : Convert.ToDateTime(selectedLog.EngagementDate); // Assuming EngagementDate is a DateTime
            }
        }
        private void ClearFields()
        {
            cbMember.SelectedIndex = -1;
            cbEvent.SelectedIndex = -1;
            cbEngagementType.SelectedIndex = -1;
            dpEngagementDate.SelectedDate = null;
        }
        // Edit Engagement Button Click Event
        private void btnEditEngagement_Click(object sender, RoutedEventArgs e)
        {
            if (dgEngagementLogs.SelectedItem == null)
            {
                MessageBox.Show("Please select an engagement log to edit.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedEngagement = (EngagementLog)dgEngagementLogs.SelectedItem;

            // Update the selected engagement with the new values
            selectedEngagement.MemberID = (int)cbMember.SelectedValue;
            selectedEngagement.EventID = (int)cbEvent.SelectedValue;
            selectedEngagement.EngagementType = ((ComboBoxItem)cbEngagementType.SelectedItem).Content.ToString();
            selectedEngagement.EngagementDate = dpEngagementDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            UpdateEngagementLogInDatabase(selectedEngagement);
            LoadEngagementLogs();
            ClearFields();
        }
        private void UpdateEngagementLogInDatabase(EngagementLog updatedEngagement)
        {
            

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();

                    // Prepare the SQL UPDATE statement
                    string sql = "UPDATE EngagementLog SET " +
                                 "MemberID = @MemberID, " +
                                 "EventID = @EventID, " +
                                 "EngagementType = @EngagementType, " +
                                 "EngagementDate = @EngagementDate " +
                                 "WHERE LogID = @LogID;";

                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@MemberID", updatedEngagement.MemberID);
                        command.Parameters.AddWithValue("@EventID", updatedEngagement.EventID);
                        command.Parameters.AddWithValue("@EngagementType", updatedEngagement.EngagementType);
                        command.Parameters.AddWithValue("@EngagementDate", updatedEngagement.EngagementDate);
                        command.Parameters.AddWithValue("@LogID", updatedEngagement.LogID);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Failed to update the engagement log.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating the engagement log: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Delete Engagement Button Click Event
        private void btnDeleteEngagement_Click(object sender, RoutedEventArgs e)
        {
            if (dgEngagementLogs.SelectedItem == null)
            {
                MessageBox.Show("Please select an engagement log to delete.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedEngagement = (EngagementLog)dgEngagementLogs.SelectedItem;

            var result = MessageBox.Show("Are you sure you want to delete this engagement log?", "Confirm Deletion",
                                         MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using (var connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM EngagementLog WHERE LogID = @LogID";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LogID", selectedEngagement.LogID);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Engagement log deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadEngagementLogs();
                ClearFields();
            }
        }
    }

    public class EngagementLog
    {
        public int LogID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string EngagementType { get; set; }
        public string EngagementDate { get; set; }
    }
}
