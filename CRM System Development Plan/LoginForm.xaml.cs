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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim(); // Use PasswordBox for secure input

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            bool isAdmin;
            if (ValidateLogin(username, password, out isAdmin))
            {
                Helper.IsAdmin = isAdmin;
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Open the main window (or dashboard)
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close(); // Close the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateLogin(string username, string password, out bool isAdmin)
        {
            isAdmin = false; // Default value if not found
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Helper.connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*), IsAdmin FROM Login WHERE Username = @Username AND Password = @Password";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the query and get the results
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read() && Convert.ToInt32(reader[0]) > 0)
                            {
                                // User is valid, now check if admin
                                isAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                                return true; // Valid login
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return false; // Invalid login if no rows are returned
        }

    }
}
