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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CMS
{
    public partial class EditCaseForm : Form
    {
        private int selectedRankID;

        public EditCaseForm()
        {
            InitializeComponent();
        }

        private void EditCaseForm_Load(object sender, EventArgs e)
        {

            LoadMOS();
            FillCmdComboBox();
            FillRankComboBox();
        }
        private void FillCmdComboBox()
        {
             string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "SELECT DISTINCT cmd FROM MOS";
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["cmd"]);
            }

            reader.Close();
            connection.Close();
        }
        private void LoadMOS()
        {
             string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "SELECT PersNum, LName, FName, MI, active, cmd, rank FROM MOS";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table;
            connection.Close();
        }
        private void FillRankComboBox()
        {
             string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "SELECT rankfullLit FROM rank";
            SqlCommand command = new SqlCommand(sql, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbRank.Items.Add(reader["rankfullLit"]);
            }

            reader.Close();
            connection.Close();
        }

        private void txtCaseNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadSelectedMOS(int persNum)
        {
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "SELECT * FROM MOS WHERE PersNum = @PersNum";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@PersNum", persNum);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtPersNum.Text = reader["PersNum"].ToString();
                txtLName.Text = reader["LName"].ToString();
                txtFName.Text = reader["FName"].ToString();
                txtMI.Text = reader["MI"].ToString();
                chkActive.Checked = Convert.ToBoolean(reader["active"]);
                comboBox1.SelectedItem = reader["cmd"].ToString();
                // Get rankfullLit based on rank number and set the combobox
                int rankNumber = Convert.ToInt32(reader["rank"]);
                string rankSql = "SELECT rankfullLit FROM rank WHERE rank = @rank";
                SqlCommand rankCommand = new SqlCommand(rankSql, connection);
                rankCommand.Parameters.AddWithValue("@rank", rankNumber);
                string rankfullLit = rankCommand.ExecuteScalar().ToString();
                cmbRank.SelectedItem = rankfullLit;
            }

            reader.Close();
            connection.Close();
        }

        private void btnUpdateRank_Click_Click(object sender, EventArgs e) //  updates the new entry in the database
        {


            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "UPDATE rank SET rankLit = @rankLit, rankFullLit = @rankFullLit, uni = @unit WHERE rank = @rankID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@rankLit", txtLName.Text);
            command.Parameters.AddWithValue("@rankFullLit", txtFName.Text);
            command.Parameters.AddWithValue("@unit", txtMI.Text);
            command.Parameters.AddWithValue("@rankID", selectedRankID);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Rank updated successfully.");
            }
            else
            {
                MessageBox.Show("Error updating rank.");
            }
            connection.Close();
        }



        // runs a SQL DELETE statement to delete

        private void btnDeleteRank_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this MOS record?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string persNum = txtPersNum.Text.Trim();
                if (!string.IsNullOrEmpty(persNum))
                {
                    string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();

                    string sql = "DELETE FROM MOS WHERE PersNum = @PersNum";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@PersNum", persNum);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("MOS record deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error deleting MOS record.");
                    }
                    connection.Close();

                    // Refresh the data grid
                    LoadMOS();
                }
                else
                {
                    MessageBox.Show("Please enter a PersNum value.");
                }
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                // Look up the rank number based on the selected rank full literal value
                string rankLookupSql = "SELECT rank FROM rank WHERE rankfullLit = @rankfullLit";
                SqlCommand rankLookupCommand = new SqlCommand(rankLookupSql, connection);
                rankLookupCommand.Parameters.AddWithValue("@rankfullLit", cmbRank.SelectedItem.ToString());
                int rankNumber = (int)rankLookupCommand.ExecuteScalar(); // This line is added to execute the command and get the rank number

                string mosSql = "UPDATE MOS SET LName = @LName, FName = @FName, MI = @MI, active = @active, cmd = @cmd, rank = @rank WHERE PersNum = @PersNum";
                SqlCommand mosCommand = new SqlCommand(mosSql, connection);
                mosCommand.Parameters.AddWithValue("@PersNum", txtPersNum.Text);
                mosCommand.Parameters.AddWithValue("@LName", txtLName.Text);
                mosCommand.Parameters.AddWithValue("@FName", txtFName.Text);
                mosCommand.Parameters.AddWithValue("@MI", txtMI.Text);
                mosCommand.Parameters.AddWithValue("@active", chkActive.Checked);
                mosCommand.Parameters.AddWithValue("@cmd", comboBox1.SelectedItem.ToString());
                mosCommand.Parameters.AddWithValue("@rank", rankNumber);

                int result = mosCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("MOS entry updated successfully.");
                }
                else
                {
                    MessageBox.Show("Error updating MOS entry.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadMOS();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
