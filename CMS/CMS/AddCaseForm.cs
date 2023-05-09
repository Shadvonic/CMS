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
    public partial class AddCaseForm : Form
    {
        public AddCaseForm()
        {
            InitializeComponent();
        }

        private void AddCaseForm_Load(object sender, EventArgs e)
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
        private void LoadMOS()            // loads data into grideview
        {
        
             string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "SELECT PersNum, LName, FName, MI, active, cmd, rank FROM MOS";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            DataTable table = new DataTable();
            adapter.Fill(table);

            connection.Close();
        }
        private void btnAddCase_Click(object sender, EventArgs e)            // adds a new  entry to the database by using 

        {
            try
            {
                 string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\moxey\\Desktop\\Cs234\\CMS\\UtopiaPD.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                // Look up the rank number based on the selected rank full literal value
                string rankSql = "SELECT rank FROM rank WHERE rankfullLit = @rankfullLit";
                SqlCommand rankCommand = new SqlCommand(rankSql, connection);
                rankCommand.Parameters.AddWithValue("@rankfullLit", cmbRank.SelectedItem.ToString());
                int rankNumber = Convert.ToInt32(rankCommand.ExecuteScalar());

                // Insert the MOS entry with the rank number
                string mosSql = "INSERT INTO MOS (PersNum, LName, FName, MI, active, cmd, rank) VALUES (@PersNum, @LName, @FName, @MI, @active, @cmd, @rank)";
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
                    MessageBox.Show("MOS entry added successfully.");
                }
                else
                {
                    MessageBox.Show("Error adding MOS entry.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMOS();
        }
    


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}