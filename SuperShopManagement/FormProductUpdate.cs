using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace SuperShopManagement
{
    public partial class FormProductUpdate : MetroForm
    {
        private DataAccess Da { get; set; }
        
        public FormProductUpdate()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            
        }
        public int? ProductId { get; set; }

        
        public void FillProductData(int? productId, string productName,string productBrand,int productQuantity,float productPrice)
        {
            
            txtPID.Text = productId.HasValue ? productId.ToString() : string.Empty;
            txtPName.Text = productName;
            txtPBrand.Text = productBrand;
            txtPQuantity.Text = productQuantity.ToString();
            txtPPrice.Text = productPrice.ToString("0.##");


        }
        private bool IsValidToSave()
        {
            if ( string.IsNullOrEmpty(this.txtPBrand.Text) ||
                string.IsNullOrEmpty(this.txtPName.Text)
                )
                return false;
            else
                return true;
        }




        private void btnPUpSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the fields");
                    return;
                }

                
                var query = "SELECT * FROM Product WHERE Product_ID = @ProductID";
                var parameters = new Dictionary<string, object>
        {
            { "@ProductID", this.txtPID.Text }
        };

                var ds = this.Da.ExecuteQuery(query, parameters);
                string sql;
                int count;

                if (ds.Tables[0].Rows.Count == 1)
                {
                    
                    sql = @"UPDATE Product
                    SET 
                        Product_Name = @ProductName,
                        Brand = @Brand,
                        Quantity = @Quantity,
                        Unit_Price = @UnitPrice
                    WHERE Product_ID = @ProductID";

                    parameters = new Dictionary<string, object>
            {
                { "@ProductName", this.txtPName.Text },
                { "@Brand", this.txtPBrand.Text },
                { "@Quantity", Convert.ToInt32(this.txtPQuantity.Text) },
                { "@UnitPrice", Convert.ToSingle(this.txtPPrice.Text) },
                { "@ProductID", this.txtPID.Text }
            };

                    count = this.Da.ExecuteDMLQuery(sql, parameters);

                    MessageBox.Show(count == 1 ? "Data has been updated properly" : "Data hasn't been updated properly");
                }
                else
                {
                    
                    sql = @"INSERT INTO Product (Product_Name, Brand, Quantity, Unit_Price)
                    VALUES (@ProductName, @Brand, @Quantity, @UnitPrice)";

                    parameters = new Dictionary<string, object>
            {
                { "@ProductName", this.txtPName.Text },
                { "@Brand", this.txtPBrand.Text },
                { "@Quantity", Convert.ToInt32(this.txtPQuantity.Text) },
                { "@UnitPrice", Convert.ToSingle(this.txtPPrice.Text) }
            };

                    count = this.Da.ExecuteDMLQuery(sql, parameters);

                    MessageBox.Show(count == 1 ? "Data has been added properly" : "Data hasn't been added properly");
                }

                
                this.Close();

                


            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred. Please check: " + exc.Message);
            }
        }

    }
}
