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
    public partial class ProductListControl : UserControl
       
    {
        private DataAccess Da { get; set; }
        public ProductListControl()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.Product_ID.DataPropertyName = "Product_ID";
            this.Product_Name.DataPropertyName = "Product_Name";
            this.Brand.DataPropertyName = "Brand";
            this.Quantity.DataPropertyName = "Quantity";
            this.Unit_Price.DataPropertyName = "Unit_Price";

            this.dgvProduct.DataBindingComplete += DgvProduct_DataBindingComplete;
            

            this.PopulateGridView();
            
        }

        private void DgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvProduct.ClearSelection(); 
            this.dgvProduct.CurrentCell = null; 
        }


        

        internal void PopulateGridView(string sql = "select * from Product;")
        {
            var ds = this.Da.ExecuteQuery(sql);
            

            this.dgvProduct.AutoGenerateColumns = false;
            this.dgvProduct.DataSource = ds.Tables[0];
            
          
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProduct.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = this.dgvProduct.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvProduct.CurrentRow.Cells[1].Value.ToString();
                //MessageBox.Show(id);

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + name + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                var sql = "delete from Product where Product_ID = '" + id + "';";
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

        private void btnProductUpdate_Click(object sender, EventArgs e)
        {
            try { 
             if (dgvProduct.SelectedRows.Count > 0)
            {
               
                var selectedRow = dgvProduct.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells[0].Value); 
                string productName = selectedRow.Cells[1].Value.ToString();
                string productBrand = selectedRow.Cells[2].Value.ToString();
                int productQuantity = Convert.ToInt32(selectedRow.Cells[3].Value);
                float productPrice = Convert.ToSingle(selectedRow.Cells[4].Value);



                   
                    FormProductUpdate updateForm = new FormProductUpdate();
                updateForm.FillProductData(productId, productName, productBrand, productQuantity, productPrice);
                updateForm.ShowDialog();
            }
            else
            {
               
                FormProductUpdate updateForm = new FormProductUpdate();
                    updateForm.FillProductData(null, string.Empty, string.Empty, 0, 0f);



                    updateForm.ShowDialog();
            }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
