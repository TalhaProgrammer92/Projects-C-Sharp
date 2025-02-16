using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
// Run this command in project directory on your terminal, if an error occur:
// dotnet add package Microsoft.Data.SqlClient

namespace CRUD_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Establishing SQL connection
        static string connectionString = @"Data Source=DESKTOP-UACK8EI;Initial Catalog=crud_app_data;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection connection = new SqlConnection(connectionString);

        // Clear data fields
        public void ClearData()
        {
            NameEntry.Clear();
            AgeEntry.Clear();
            GenderEntry.Clear();
            CityEntry.Clear();
            IdEntry.Clear();
        }

        // Load data to the data grid of app
        public void LoadData()
        {
            // Create a new SqlCommand object that represents the SQL query to be executed
            SqlCommand cmd = new SqlCommand("select * from Table_1", connection);

            // Create a new DataTable object to hold the retrieved data from the database
            DataTable table = new DataTable();

            // Open the database connection so we can execute the query
            connection.Open();

            // Execute the SQL query and retrieve the data in a SqlDataReader object
            SqlDataReader reader = cmd.ExecuteReader();

            // Load the data from the SqlDataReader into the DataTable object
            table.Load(reader);

            // Close the database connection after completing the data retrieval
            connection.Close();

            // Set the DataGrid's ItemsSource property to display the DataTable data in the UI
            DataGridTable.ItemsSource = table.DefaultView;
        }

        // On click "Clear" button
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearData();    // Calling the function to clear data from text boxes
        }

        // To prevent DataGrid_SelectionChanged error by compiler
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Check if an entry is valid
        public bool EmptyEntry(TextBox entry, string message)
        {
            if (entry.Text == string.Empty)
            {
                MessageBox.Show(
                        message,
                        "Failed",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }

        // Check all entries
        public bool ValidEntries()
        {
            bool validity;

            validity = EmptyEntry(NameEntry, "Name is require");
            validity = EmptyEntry(AgeEntry, "Age is require") && validity;
            validity = EmptyEntry(GenderEntry, "Gender is require") && validity;
            validity = EmptyEntry(CityEntry, "City is require") && validity;

            return validity;
        }

        // On click "Insert" Button
        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Main Action
                if (ValidEntries())
                {
                    // Run the SQL command to insert data
                    SqlCommand cmd = new SqlCommand("insert into Table_1 values (@Name, @Age, @Gender, @City)", connection);

                    // Set the command type to text
                    cmd.CommandType = CommandType.Text;

                    // Passing values to parameters
                    cmd.Parameters.AddWithValue("@Name", NameEntry.Text);
                    cmd.Parameters.AddWithValue("@Age", AgeEntry.Text);
                    cmd.Parameters.AddWithValue("@Gender", GenderEntry.Text);
                    cmd.Parameters.AddWithValue("@City", CityEntry.Text);

                    // Connection within query execution
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    // Load Data to the grid after changes
                    LoadData();

                    // Show a message box
                    MessageBox.Show(
                            "Successfully Registered",
                            "Saved",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                        );

                    // Clear data from entry fields
                    ClearData();
                }
            }
            // Exception Case
            catch (SqlException ex)
            {
                MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
            }
        }

        // On click "Delete" button
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the connection
            connection.Open();

            // SQL Command
            SqlCommand cmd = new SqlCommand($"delete from Table_1 where ID = {IdEntry.Text}", connection);

            try
            {
                // Execute query
                cmd.ExecuteNonQuery();

                // Display message box
                MessageBox.Show(
                        "Successfully Removed!",
                        "Remove",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
            }
            finally
            {
                // Close the connection
                connection.Close();

                // Clear field entries
                ClearData();

                // Load data grid
                LoadData();
            }
        }

        // On click "Update" button
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the connection
            connection.Open();

            // SQL Command
            SqlCommand cmd = new SqlCommand($"update Table_1 set Name = '{NameEntry.Text}', Age = '{AgeEntry.Text}', Gender = '{GenderEntry.Text}', City = '{CityEntry.Text}' where ID = '{IdEntry.Text}'", connection);

            try
            {
                // Execute query
                cmd.ExecuteNonQuery();

                // Display message box
                MessageBox.Show(
                        "Successfully Updated!",
                        "Update",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );
            }
            catch (SqlException ex)
            {
                // Display error message
                MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
            }
            finally
            {
                // Close the connection
                connection.Close();

                // Clear field entries
                ClearData();

                // Load data grid
                LoadData();
            }
        }
    }
}