using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SuperShopManagement
{
    public partial class SalesControl : UserControl
    {
        private DataAccess Da { get; set; }
        public SalesControl()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.Order_ID.DataPropertyName = "Order_ID";
            this.Order_Date.DataPropertyName = "Order_Date";
            this.Amount.DataPropertyName = "Amount";
            this.Employee_Name.DataPropertyName = "Employee_Name";
            

            this.dgvSales.DataBindingComplete += DgvProduct_DataBindingComplete;
            this.PopulateGridView();

        }

        private void DgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvSales.ClearSelection(); 
            this.dgvSales.CurrentCell = null; 
        }

        private void PopulateGridView(string sql = "select * from Sales;")
        {
            var ds = this.Da.ExecuteQuery(sql);


            this.dgvSales.AutoGenerateColumns = false;
            this.dgvSales.DataSource = ds.Tables[0];


        }

        private void btnSearchSales_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            

            
            string sql = "SELECT * FROM Sales WHERE Order_Date BETWEEN @startDate AND @endDate";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\Swopnil;Initial Catalog=SuperShop;Integrated Security=True"))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                   
                    adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSales.DataSource = dt;

                   
                    if (dgvSales.Rows.Count > 0)
                    {
                        dgvSales.ClearSelection();
                        dgvSales.CurrentCell = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}