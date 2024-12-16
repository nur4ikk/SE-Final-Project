using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM_System_Development_Plan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Helper.IsAdmin==Convert.ToBoolean(1))
            {
                _AdminForm.Visibility = Visibility.Visible; ;
            }
            else
            {
                _AdminForm.Visibility = Visibility.Collapsed; // If not Admin, hide the form
            }
        }
        private void OpenAnalyticsButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Analytics Dashboard form
            var analyticsDashboard = new AnalyticsDashboard();
            analyticsDashboard.Show();
        } 
        private void OpenMemberButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Member Management form
            var analyticsDashboard = new MemberManagementForm();
            analyticsDashboard.Show();
        } 
        private void OpenEventButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Event Management Form
            var analyticsDashboard = new EventManagementForm();
            analyticsDashboard.Show();
        }
        
        private void OpenSalesButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Event Management Form
            var analyticsDashboard = new SalesForm();
            analyticsDashboard.Show();
        } 
        private void OpenEngagementLogButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Event Management Form
            var analyticsDashboard = new EngagementLogForm();
            analyticsDashboard.Show();
        } 
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the Event Admin Form
            var analyticsDashboard = new AdminForm();
            analyticsDashboard.Show();
        }
    }
}
