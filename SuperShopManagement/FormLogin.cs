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
    public partial class FormLogin : MetroForm
    {
        private DataAccess Da { get; set; }

        public FormLogin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtUsername.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    MessageBox.Show("Please fill the empty fields");
                    return;
                }


                string sql = "SELECT * FROM Login WHERE UserName = @userId AND Password = @password";


                var parameters = new Dictionary<string, object>
            {
                { "@userId", this.txtUsername.Text },
                { "@password", this.txtPassword.Text }
            };


                DataSet ds = this.Da.ExecuteQuery(sql, parameters);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    var name = ds.Tables[0].Rows[0][1].ToString();
                    MessageBox.Show("Valid User");

                    string userRole = ds.Tables[0].Rows[0][2].ToString();
                    if (userRole.Equals("admin"))
                    {
                        this.Visible = false;
                        new FormAdmin().Show();
                    }
                    /*else if (userRole.Equals("member"))
                    {
                        this.Visible = false;
                        new FormMember(name, this).Show();
                    }*/
                }
                else
                {
                    MessageBox.Show("Invalid User");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred, please check: " + exc.Message);
            }
        }
    }
}