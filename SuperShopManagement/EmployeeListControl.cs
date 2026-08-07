using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopManagement
{
    public partial class EmployeeListControl : UserControl
    {
        private DataAccess Da { get; set; }
        public EmployeeListControl()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.Employee_ID.DataPropertyName = "Employee_ID";
            this.Employee_Name.DataPropertyName = "Employee_Name";
            this.NID.DataPropertyName = "NID";
            this.Mobile.DataPropertyName = "Mobile";
            

            this.dgvEmployee.DataBindingComplete += DgvProduct_DataBindingComplete;
            this.PopulateGridView();

        }

        private void DgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvEmployee.ClearSelection(); 
            this.dgvEmployee.CurrentCell = null;
        }

        private void PopulateGridView(string sql = "select * from Employee;")
        {
            var ds = this.Da.ExecuteQuery(sql);


            this.dgvEmployee.AutoGenerateColumns = false;
            this.dgvEmployee.DataSource = ds.Tables[0];


        }

        private void btnEmployeeDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.dgvEmployee.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = this.dgvEmployee.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvEmployee.CurrentRow.Cells[1].Value.ToString();
                

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + name + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                var sql = "delete from Employee where Employee_ID = '" + id + "';";
                var count = this.Da.ExecuteDMLQuery(sql);
                if (count == 1)
                    MessageBox.Show(name.ToUpper() + " has been removed properly from the list.");
                else
                    MessageBox.Show("Data hasn't been removed properly");

                this.PopulateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred. Please check: " + exc.Message);
            }
        }
    }
}
