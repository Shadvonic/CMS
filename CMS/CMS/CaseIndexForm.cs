using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class CaseIndexForm : Form
    {
        public CaseIndexForm()
        {
            InitializeComponent();
            

        }
        private void LoadCases() 

        {
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //  filter strings based on the selected values 

            string crimeTypeFilter = cmbCrimeType.SelectedItem.ToString() != "All" ? " AND crimeType = @crimeType" : "";
            string statusFilter = cmbStatus.SelectedItem.ToString() != "All" ? " AND status = @status" : "";
            string dateFilter = " AND assignDt >= @startDate AND assignDt <= @endDate";
            string sortOrder = cmbSortingOrder.SelectedItem.ToString() == "Ascending" ? "ASC" : "DESC";

            //  SQL query for the  filters

            string sql = "SELECT caseID, occurFrom, status, assignMOS, crimeType FROM cases WHERE 1 = 1" + crimeTypeFilter + statusFilter + dateFilter + " ORDER BY assignDt " + sortOrder;
            SqlCommand command = new SqlCommand(sql, connection);

            // add parameters to the query 

            if (cmbCrimeType.SelectedItem.ToString() != "All")
            {
                string crimeTypeCode = GetCodeFromDisplayValue(cmbCrimeType.SelectedItem.ToString(), true);
                command.Parameters.AddWithValue("@crimeType", crimeTypeCode);
            }

            if (cmbStatus.SelectedItem.ToString() != "All")
            {
                string statusCode = GetCodeFromDisplayValue(cmbStatus.SelectedItem.ToString(), false);
                command.Parameters.AddWithValue("@status", statusCode);
            }

            command.Parameters.AddWithValue("@startDate", dtpStartDate.Value.Date);
            command.Parameters.AddWithValue("@endDate", dtpEndDate.Value.Date);

            // retrieve the data and fill a table 

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridViewCases.DataSource = table;
            connection.Close();
        }
        private string GetCodeFromDisplayValue(string displayValue, bool isCrimeType)
        {
            if (displayValue == "All")
            {
                return "All";
            }

            if (isCrimeType)
            {
                if (displayValue == "Felony") return "F";
                if (displayValue == "Misdemeanor") return "M";
            }
            else
            {
                if (displayValue == "Open") return "O";
                if (displayValue == "Close") return "C";
            }

            return "Other";
        }

        private void CaseIndexForm_Load(object sender, EventArgs e)
        {
            //options to the combo boxes
            cmbCrimeType.Items.Add("All");
            cmbCrimeType.Items.Add("Felony");
            cmbCrimeType.Items.Add("Misdemeanor");
            cmbCrimeType.Items.Add("Other");

            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Open");
            cmbStatus.Items.Add("Close");

            cmbSortingOrder.Items.Add("Ascending");
            cmbSortingOrder.Items.Add("Descending");

            cmbCrimeType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbSortingOrder.SelectedIndex = 0;

            LoadCases();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadCases();

        }

        private void dataGridViewCases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
