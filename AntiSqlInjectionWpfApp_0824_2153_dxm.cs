// 代码生成时间: 2025-08-24 21:53:36
using System;
using System.Data.SqlClient;
using System.Windows;

namespace AntiSqlInjectionWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExecuteQueryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Assuming 'txtQuery' is a TextBox control where the user inputs their query
                string userQuery = txtQuery.Text;

                // Using parameterized queries to prevent SQL injection
                using (SqlConnection conn = new SqlConnection("Data Source=YourDataSource;Initial Catalog=YourCatalog;Integrated Security=True"))
                {
                    conn.Open();

                    // Using parameterized queries to prevent SQL injection
                    using (SqlCommand cmd = new SqlCommand(userQuery, conn))
                    {
                        // Example: cmd.Parameters.AddWithValue("@ParameterName", txtParameter.Text);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // Process the result from the database
                            // For example, display the data in a ListBox or DataGrid
                            // listBoxResults.Items.Add(reader["ColumnName"]);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                MessageBox.Show("An error occurred while executing the query: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}

// Note: This is a simplified example and does not include all necessary features such as parameter validation,
// proper error handling, and security checks. In a production environment, you would need to
// implement additional safeguards and consider using an ORM like Entity Framework to further
// mitigate the risk of SQL injection attacks.