using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS
{
    public partial class MemberForm : Form
    {
        public MemberForm()
        {
            InitializeComponent();
        }

        private void RosterForm_Load(object sender, EventArgs e)
        {

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

            dataGridView2.DataSource = table;
            connection.Close();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMOS();
        }
    }
}

