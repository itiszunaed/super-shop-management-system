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
    public partial class FormAdmin : MetroForm
    {
        public FormAdmin()
        {
            InitializeComponent();
            this.Load += MainForm_Load;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnSales.PerformClick(); // Trigger the Sales button click
        }


        private void LoadControl(UserControl control)
        {
            panelRight.Controls.Clear(); // Clear previous controls
            control.Dock = DockStyle.Fill; // Make it fill the panel
            panelRight.Controls.Add(control); // Add the new control
        }

       



        private void btnSales_Click(object sender, EventArgs e)
        {
            LoadControl(new SalesControl());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadControl(new ProductListControl());
        }

        
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            LoadControl(new EmployeeListControl());
        }
    }
}
