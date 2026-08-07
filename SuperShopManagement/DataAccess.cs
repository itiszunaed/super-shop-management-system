using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SuperShopManagement
{
    class DataAccess
    {
        private SqlConnection sqlcon;
        public SqlConnection Sqlcon
        {
            get { return this.sqlcon; }
            set { this.sqlcon = value; }
        }

        private SqlCommand sqlcom;
        public SqlCommand Sqlcom
        {
            get { return this.sqlcom; }
            set { this.sqlcom = value; }
        }

        private SqlDataAdapter sda;
        public SqlDataAdapter Sda
        {
            get { return this.sda; }
            set { this.sda = value; }
        }

        private DataSet ds;
        public DataSet Ds
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        //internal DataTable dt;

        public DataAccess()
        {
            this.Sqlcon = new SqlConnection(@"Data Source=(localdb)\Swopnil;Initial Catalog=SuperShop;Integrated Security=True");
            Sqlcon.Open();
        }

        private void QueryText(string query)
        {
            this.Sqlcom = new SqlCommand(query, this.Sqlcon);
        }

        public DataSet ExecuteQuery(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon);//this.QueryText(sql);
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return Ds;
        }

        public DataSet ExecuteQuery(string sql, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (this.Sqlcom = new SqlCommand(sql, this.Sqlcon))
                {
                    // Add parameters to the SqlCommand
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            this.Sqlcom.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (this.Sda = new SqlDataAdapter(this.Sqlcom))
                    {
                        this.Ds = new DataSet();
                        this.Sda.Fill(this.Ds);
                        return this.Ds;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query: " + ex.Message);
            }
        }




        public DataTable ExecuteQueryTable(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon);//this.QueryText(sql);
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return Ds.Tables[0];
        }

        public int ExecuteDMLQuery(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon);//this.QueryText(sql);
            int u = this.Sqlcom.ExecuteNonQuery();
            return u;
        }


        public int ExecuteDMLQuery(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                using (this.Sqlcom = new SqlCommand(sql, this.Sqlcon))
                {
                    // Add parameters to the SqlCommand
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            this.Sqlcom.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    // Execute the query
                    int rowsAffected = this.Sqlcom.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing DML query: " + ex.Message);
            }
        }

    }
}
  

