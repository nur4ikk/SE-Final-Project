using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for AnalyticsDashboard.xaml
    /// </summary>
    public partial class AnalyticsDashboard : Window
    {
        public AnalyticsDashboard()
        {
            InitializeComponent();
            LoadAnalyticsData();
        }

        private void LoadAnalyticsData()
        {
            // Load Most Popular Events
            var events = GetMostPopularEvents();
            EventsListView.ItemsSource = events;

            // Load Sales Trends
            var salesTrends = GetSalesTrends();
            // Binding sales trend data to the LineSeries
            SalesTrendChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Sales",
                    Values = new ChartValues<double>(salesTrends.ConvertAll(s => s.Amount)),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 15
                }
            };

            // Load Member Engagement
            var engagement = GetMemberEngagement();
            EngagementListView.ItemsSource = engagement;
        }

        private List<Event> GetMostPopularEvents()
        {
            var events = new List<Event>();
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "SELECT EventName, AttendanceCount FROM Events ORDER BY AttendanceCount DESC LIMIT 5";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            events.Add(new Event
                            {
                                EventName = reader.GetString(0),
                                AttendanceCount = reader.GetInt32(1)
                            });
                        }
                    }
                }
            }
            return events;
        }

        private List<SalesTrend> GetSalesTrends()
        {
            var trends = new List<SalesTrend>();
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "SELECT strftime('%Y-%m', SaleDate) AS Period, SUM(Amount) AS TotalSales FROM Sales GROUP BY Period ORDER BY Period DESC";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            trends.Add(new SalesTrend
                            {
                                Date = reader.GetString(0),
                                Amount = reader.GetDouble(1)
                            });
                        }
                    }
                }
            }
            return trends;
        }

        private List<MemberEngagement> GetMemberEngagement()
        {
            var engagement = new List<MemberEngagement>();
            using (var connection = new SQLiteConnection(Helper.connectionString))
            {
                connection.Open();
                string query = "SELECT m.Name, e.EventName, el.EngagementType FROM Members m " +
                               "JOIN EngagementLog el ON m.MemberID = el.MemberID " +
                               "JOIN Events e ON el.EventID = e.EventID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            engagement.Add(new MemberEngagement
                            {
                                Name = reader.GetString(0),
                                EventName = reader.GetString(1),
                                EngagementType = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return engagement;
        }
    }

    public class SalesTrend
    {
        public string Date { get; set; }
        public double Amount { get; set; }
    }

    public class MemberEngagement
    {
        public string Name { get; set; }
        public string EventName { get; set; }
        public string EngagementType { get; set; }
        public string EngagementDate { get; set; }
    }
}
