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
    /// Interaction logic for SalesForm.xaml
    /// </summary>
    public partial class SalesForm : Window
    {
        private ObservableCollection<Sale> sales;
        

        public SalesForm()
        {
            InitializeComponent();
            LoadMembers();
            LoadEvents();
            LoadSales();
        }

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

        private void LoadSales()
        {
            sales = new ObservableCollection<Sale>();

            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = @"SELECT SaleID,m.MemberID,m.Name as MemberName, e.EventID,e.EventName,Amount,SaleDate FROM Sales s
join Members m ON m.MemberID = s.MemberID
JOIN Events e ON  e.EventID = s.EventID";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sales.Add(new Sale
                        {
                            SaleID = reader.GetInt32(0),
                            MemberID = reader.GetInt32(1),
                            MemberName = reader.GetString(2),
                            EventID = reader.GetInt32(3),
                            EventName = reader.GetString(4),
                            Amount = reader.GetFloat(5),
                            SaleDate = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        });
                    }
                }
            }

            dgSales.ItemsSource = sales;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbMember.SelectedValue == null || cbEvent.SelectedValue == null || dpSaleDate.SelectedDate == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newSale = new Sale
            {
                MemberID = (int)cbMember.SelectedValue,
                EventID = (int)cbEvent.SelectedValue,
                Amount = float.TryParse(txtAmount.Text, out var amount) ? amount : 0,
                SaleDate = dpSaleDate.SelectedDate.Value.ToString("yyyy-MM-dd")
            };

            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Sales (MemberID, EventID, Amount, SaleDate) VALUES (@MemberID, @EventID, @Amount, @SaleDate)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MemberID", newSale.MemberID);
                    command.Parameters.AddWithValue("@EventID", newSale.EventID);
                    command.Parameters.AddWithValue("@Amount", newSale.Amount);
                    command.Parameters.AddWithValue("@SaleDate", newSale.SaleDate);
                    command.ExecuteNonQuery();
                }
            }

            LoadSales();
            ClearFields();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cbMember.SelectedIndex = -1;
            cbEvent.SelectedIndex = -1;
            txtAmount.Clear();
            dpSaleDate.SelectedDate = null;
        }
        

        private void dgSales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if any row is selected
            if (dgSales.SelectedItem != null)
            {
                // Cast the selected item to the appropriate data model
                var selectedLog = (Sale)dgSales.SelectedItem;

                // Populate the form fields with the selected row's data
                cbMember.SelectedValue = selectedLog.MemberID; // Assuming MemberID is the value you want to use
                cbEvent.SelectedValue = selectedLog.EventID; // Assuming EventID is the value you want to use
                txtAmount.Text = selectedLog.Amount.ToString(); // Assuming EngagementType is a string
                dpSaleDate.SelectedDate = selectedLog.SaleDate==""?DateTime.Now: Convert.ToDateTime(selectedLog.SaleDate); // Assuming EngagementDate is a DateTime
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgSales.SelectedItem == null)
            {
                MessageBox.Show("Please select an Sales to edit.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedEngagement = (Sale)dgSales.SelectedItem;

            // Update the selected engagement with the new values
            selectedEngagement.MemberID = (int)cbMember.SelectedValue;
            selectedEngagement.EventID = (int)cbEvent.SelectedValue;
            selectedEngagement.Amount = float.TryParse(txtAmount.Text, out var amount) ? amount : 0;
            selectedEngagement.SaleDate = dpSaleDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            UpdateSalesInDatabase(selectedEngagement);
            LoadSales();
            ClearFields();
        }
        private void UpdateSalesInDatabase(Sale updatedEngagement)
        {


            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();

                    // Prepare the SQL UPDATE statement
                    string sql = "UPDATE Sales SET " +
                                 "MemberID = @MemberID, " +
                                 "EventID = @EventID, " +
                                 "Amount = @Amount, " +
                                 "SaleDate = @SaleDate " +
                                 "WHERE SaleID = @SaleID;";

                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@MemberID", updatedEngagement.MemberID);
                        command.Parameters.AddWithValue("@EventID", updatedEngagement.EventID);
                        command.Parameters.AddWithValue("@Amount", updatedEngagement.Amount);
                        command.Parameters.AddWithValue("@SaleDate", updatedEngagement.SaleDate);
                        command.Parameters.AddWithValue("@SaleID", updatedEngagement.SaleID);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Failed to update the sales.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating the sales: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgSales.SelectedItem == null)
            {
                MessageBox.Show("Please select an Sales to delete.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedEngagement = (Sale)dgSales.SelectedItem;

            var result = MessageBox.Show("Are you sure you want to delete this Sales?", "Confirm Deletion",
                                         MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using (var connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Sales WHERE SaleID = @SaleID";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SaleID", selectedEngagement.SaleID);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Engagement log deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadSales();
                ClearFields();
            }
        }
    }

    public class Sale
    {
        public int SaleID { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public float Amount { get; set; }
        public string SaleDate { get; set; }
    }
}
