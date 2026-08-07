namespace SuperShopManagement
{
    partial class FormAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeft = new MetroFramework.Controls.MetroPanel();
            this.btnEmployee = new MetroFramework.Controls.MetroButton();
            this.btnSales = new MetroFramework.Controls.MetroButton();
            this.btnProduct = new MetroFramework.Controls.MetroButton();
            this.panelRight = new MetroFramework.Controls.MetroPanel();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.btnEmployee);
            this.panelLeft.Controls.Add(this.btnSales);
            this.panelLeft.Controls.Add(this.btnProduct);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.HorizontalScrollbarBarColor = true;
            this.panelLeft.HorizontalScrollbarHighlightOnWheel = false;
            this.panelLeft.HorizontalScrollbarSize = 10;
            this.panelLeft.Location = new System.Drawing.Point(20, 111);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(115, 347);
            this.panelLeft.TabIndex = 1;
            this.panelLeft.VerticalScrollbarBarColor = true;
            this.panelLeft.VerticalScrollbarHighlightOnWheel = false;
            this.panelLeft.VerticalScrollbarSize = 10;
            // 
            // btnEmployee
            // 
            this.btnEmployee.Location = new System.Drawing.Point(4, 61);
            this.btnEmployee.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(98, 22);
            this.btnEmployee.TabIndex = 8;
            this.btnEmployee.Text = "Employee List";
            this.btnEmployee.UseSelectable = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnSales
            // 
            this.btnSales.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSales.Location = new System.Drawing.Point(2, 4);
            this.btnSales.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(98, 22);
            this.btnSales.TabIndex = 6;
            this.btnSales.Text = "Sales";
            this.btnSales.UseSelectable = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(4, 32);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(98, 22);
            this.btnProduct.TabIndex = 7;
            this.btnProduct.Text = "Product List";
            this.btnProduct.UseSelectable = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.HorizontalScrollbarBarColor = true;
            this.panelRight.HorizontalScrollbarHighlightOnWheel = false;
            this.panelRight.HorizontalScrollbarSize = 10;
            this.panelRight.Location = new System.Drawing.Point(139, 111);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(617, 347);
            this.panelRight.TabIndex = 2;
            this.panelRight.VerticalScrollbarBarColor = true;
            this.panelRight.VerticalScrollbarHighlightOnWheel = false;
            this.panelRight.VerticalScrollbarSize = 10;
            // 
            // FormAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(776, 478);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdmin";
            this.Padding = new System.Windows.Forms.Padding(20, 111, 20, 20);
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dashboard";
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelLeft;
        private MetroFramework.Controls.MetroButton btnEmployee;
        private MetroFramework.Controls.MetroButton btnSales;
        private MetroFramework.Controls.MetroButton btnProduct;
        private MetroFramework.Controls.MetroPanel panelRight;
    }
}

