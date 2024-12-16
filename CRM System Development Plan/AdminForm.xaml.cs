using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminForm.xaml
    /// </summary>
    public partial class AdminForm : Window
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        // Filter Members by Membership Type
        private void MembershipTypeFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string membershipType = (MembershipTypeFilter.SelectedItem as System.Windows.Controls.ComboBoxItem).Content.ToString();
            LoadFilteredMembers(membershipType);
        }

        private void LoadFilteredMembers(string membershipType)
        {
            var members = new List<Member>();
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = membershipType == "All"
                    ? "SELECT Name, MembershipType FROM Members"
                    : "SELECT Name, MembershipType FROM Members WHERE MembershipType = @MembershipType";

                using (var command = new SQLiteCommand(query, connection))
                {
                    if (membershipType != "All")
                        command.Parameters.AddWithValue("@MembershipType", membershipType);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            members.Add(new Member
                            {
                                Name = reader.GetString(0),
                                MembershipType = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            MembersListView.ItemsSource = members;
        }

        // Search for Members or Guests
        private void SearchMember_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = MemberSearchBox.Text;
            var results = new List<MemberEngagement>();

            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "SELECT m.Name, e.EventName, el.EngagementDate " +
                               "FROM Members m " +
                               "JOIN EngagementLog el ON m.MemberID = el.MemberID " +
                               "JOIN Events e ON el.EventID = e.EventID " +
                               "WHERE m.Name LIKE @SearchTerm";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new MemberEngagement
                            {
                                Name = reader.GetString(0),
                                EventName = reader.GetString(1),
                                EngagementDate = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            EngagementsListView.ItemsSource = results;
        }

        // Search Events or Time Period
        private void SearchEvent_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = EventSearchBox.Text;
            var results = new List<Event>();

            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "SELECT EventName, Date, AttendanceCount " +
                               "FROM Events " +
                               "WHERE EventName LIKE @SearchTerm OR Date LIKE @SearchTerm";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new Event
                            {
                                EventName = reader.GetString(0),
                                Date = reader.GetString(1),
                                AttendanceCount = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            EventsListView.ItemsSource = results;
        }
    }

    

  

}
