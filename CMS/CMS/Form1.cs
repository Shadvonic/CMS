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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        // bring up the  forms
        private void btnCaseIndexForm_Click(object sender, EventArgs e)
        {
            
            CaseIndexForm caseIndexForm = new CaseIndexForm();
            caseIndexForm.ShowDialog();
        }

        private void btnAddCase_Click(object sender, EventArgs e)
        {
           
            AddCaseForm addCaseForm = new AddCaseForm();
            addCaseForm.ShowDialog();
        }

        private void btnEditCase_Click(object sender, EventArgs e)
        {
          
            EditCaseForm editCaseForm = new EditCaseForm();
            editCaseForm.ShowDialog();
        }

        private void btnRosterForm_Click(object sender, EventArgs e)
        {
            
            MemberForm rosterForm = new MemberForm();
            rosterForm.ShowDialog();
        }

       
        private void btnQuit_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void btnConfigurationSettings_Click(object sender, EventArgs e)
        {
            
            ConfigurationSettingsForm configurationSettingsForm = new ConfigurationSettingsForm();
            configurationSettingsForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
            AddCaseForm addCaseForm = new AddCaseForm();
            addCaseForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CaseIndexForm caseIndexForm = new CaseIndexForm();
            caseIndexForm.ShowDialog();
        }
    }
    }

