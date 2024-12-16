using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
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
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace CRM_System_Development_Plan
{
    /// <summary>
    /// Interaction logic for MemberManagementForm.xaml
    /// </summary>
    public partial class MemberManagementForm : Window
    {
        private ObservableCollection<Member> members;
        private ObservableCollection<Member> allMembers;  // To store the full list of members

        public MemberManagementForm()
        {
            InitializeComponent();
           
            LoadMembers();
        }

        // Load members from SQLite database
        private void LoadMembers()
        {
            members = new ObservableCollection<Member>();
            allMembers = new ObservableCollection<Member>();  // Store the full member list
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Members";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var member = new Member
                        {
                            MemberID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Interests = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Demographics = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            MembershipStatus = reader.GetString(4),
                            JoinDate = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Email = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            MembershipType = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        };
                        members.Add(member);
                        allMembers.Add(member);  // Keep the full list for future filtering
                    }
                }
            }

            dgMembers.ItemsSource = members;
            
        }

        // Search button click handler
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            string selectedMembershipType = (cmbSearchMembershipType.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (searchText!="" )
            {
               
                var filteredList = allMembers.Where(m =>
               (string.IsNullOrEmpty(searchText) || m.Name.ToLower().Contains(searchText) || m.Email.ToLower().Contains(searchText))
           ).ToList();

                // Update the DataGrid with the filtered list
                members.Clear();
                foreach (var member in filteredList)
                {
                    members.Add(member);
                }
            }
            else if (selectedMembershipType!=null)
            {
                var filteredList = allMembers.Where(m => selectedMembershipType == "All" || m.MembershipType == selectedMembershipType
                          ).ToList();

                // Update the DataGrid with the filtered list
                members.Clear();
                foreach (var member in filteredList)
                {
                    members.Add(member);
                }
            }
            else
            {
                members.Clear();
                foreach (var member in allMembers)
                {
                    members.Add(member);
                }
                
            }
      
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || cmbMembershipStatus.SelectedItem == null || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newMember = new Member
            {
                Name = txtName.Text,
                Interests = txtInterests.Text,
                Demographics = txtDemographics.Text,
                MembershipStatus = (cmbMembershipStatus.SelectedItem as ComboBoxItem)?.Content.ToString(),
                JoinDate = dpJoinDate.SelectedDate?.ToString("yyyy-MM-dd"),
                Email = txtEmail.Text,
                MembershipType= (cmbMembershipType.SelectedItem as ComboBoxItem)?.Content.ToString(),
              
            };

            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Members (Name, Interests, Demographics, MembershipStatus, JoinDate, Email,MembershipType) VALUES (@Name, @Interests, @Demographics, @MembershipStatus, @JoinDate, @Email,@MembershipType)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", newMember.Name);
                    command.Parameters.AddWithValue("@Interests", newMember.Interests);
                    command.Parameters.AddWithValue("@Demographics", newMember.Demographics);
                    command.Parameters.AddWithValue("@MembershipStatus", newMember.MembershipStatus);
                    command.Parameters.AddWithValue("@JoinDate", newMember.JoinDate);
                    command.Parameters.AddWithValue("@Email", newMember.Email);
                    command.Parameters.AddWithValue("@MembershipType", newMember.MembershipType);
                    command.ExecuteNonQuery();

                    // Get the last inserted ID
                    newMember.MemberID = (int)connection.LastInsertRowId;
                }
            }

            members.Add(newMember);
            ClearFields();
        }
        private void dgMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if any row is selected
            if (dgMembers.SelectedItem != null)
            {
                // Cast the selected item to the appropriate data model
                var selectedEvent = (Member)dgMembers.SelectedItem;

                txtName.Text = selectedEvent.Name;
                txtInterests.Text = selectedEvent.Interests;
                txtDemographics.Text = selectedEvent.Demographics;
             
                // Find the ComboBoxItem that matches the MembershipStatus
                foreach (ComboBoxItem item in cmbMembershipStatus.Items)
                {
                    if (item.Content.ToString() == selectedEvent.MembershipStatus)
                    {
                        cmbMembershipStatus.SelectedItem = item;
                        break;
                    }
                }
                dpJoinDate.SelectedDate = selectedEvent.JoinDate==""? DateTime.Now: Convert.ToDateTime( selectedEvent.JoinDate);
                txtEmail.Text = selectedEvent.Email;
                foreach (ComboBoxItem item in cmbMembershipType.Items)
                {
                    if (item.Content.ToString() == selectedEvent.MembershipType)
                    {
                        cmbMembershipType.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgMembers.SelectedItem is Member selectedMember)
            {
                using (var connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Members SET Name = @Name, Interests = @Interests, Demographics = @Demographics, MembershipStatus = @MembershipStatus, JoinDate = @JoinDate, Email = @Email,MembershipType=@MembershipType WHERE MemberID = @MemberID";
                    using (var command = new SQLiteCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@Interests", txtInterests.Text);
                        command.Parameters.AddWithValue("@Demographics", txtDemographics.Text);
                        command.Parameters.AddWithValue("@MembershipStatus", (cmbMembershipStatus.SelectedItem as ComboBoxItem)?.Content.ToString());
                        command.Parameters.AddWithValue("@JoinDate", dpJoinDate.SelectedDate?.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@MemberID", selectedMember.MemberID);
                        command.Parameters.AddWithValue("@MembershipType", (cmbMembershipType.SelectedItem as ComboBoxItem)?.Content.ToString());
                        command.ExecuteNonQuery();
                    }
                }

                selectedMember.Name = txtName.Text;
                selectedMember.Interests = txtInterests.Text;
                selectedMember.Demographics = txtDemographics.Text;
                selectedMember.MembershipStatus = (cmbMembershipStatus.SelectedItem as ComboBoxItem)?.Content.ToString();
                selectedMember.JoinDate = dpJoinDate.SelectedDate?.ToString("yyyy-MM-dd");
                selectedMember.Email = txtEmail.Text;
                selectedMember.MembershipType = (cmbMembershipType.SelectedItem as ComboBoxItem)?.Content.ToString();
                dgMembers.Items.Refresh();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Select a member to edit.", "Edit Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgMembers.SelectedItem is Member selectedMember)
            {
                using (var connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Members WHERE MemberID = @MemberID";
                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MemberID", selectedMember.MemberID);
                        command.ExecuteNonQuery();
                    }
                }

                members.Remove(selectedMember);
            }
            else
            {
                MessageBox.Show("Select a member to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtInterests.Clear();
            txtDemographics.Clear();
            txtEmail.Clear();
            dpJoinDate.SelectedDate = null;
            cmbMembershipStatus.SelectedIndex = -1;
            cmbMembershipType.SelectedIndex = 0;
        }
    }

    // Member model
    public class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Interests { get; set; }
        public string Demographics { get; set; }
        public string MembershipStatus { get; set; }
        public string JoinDate { get; set; }
        public string Email { get; set; }
        public string MembershipType { get; set; }
    }
}
