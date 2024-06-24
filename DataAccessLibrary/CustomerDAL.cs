using BusinessLogicLibrary;
using Microsoft.Data.SqlClient;
using System.Data;
namespace DataAccessLibrary
{
    public class CustomerDAL
    {
        static string cnString = "Data Source=.\\sqlexpress;Initial Catalog=Shopping;User ID=sa;Password=123456;Trust Server Certificate=True";
        public List<CustomerBAL> GetCustomers()
        {
            DataSet ds = ConnectAndGetData();
            DataTable dt = ds.Tables["dt_customer"];
            List<CustomerBAL> custsList = new List<CustomerBAL>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerBAL cust = new CustomerBAL();
                cust.CustomerId = Convert.ToInt32(dt.Rows[i]["CustomerId"]);
                cust.CustomerName = dt.Rows[i]["CustomerName"].ToString();
                custsList.Add(cust);
            }
            return custsList;
        }
        public void InsertCustomer(CustomerBAL cust)
        {
            DataSet ds = ConnectAndGetData();
            DataRow drow = ds.Tables["dt_customer"].NewRow();
            drow["CustomerId"] = cust.CustomerId;
            drow["CustomerName"] = cust.CustomerName;
            ds.Tables["dt_customer"].Rows.Add(drow);
            //ds.Tables["dt_products"].Rows.Add((DataRow)drow);
            ConnectandUpdateServer(ds);
        }
        private static void ConnectandUpdateServer(DataSet ds)
        { 
            SqlConnection cn = new SqlConnection(cnString);
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Customer", cn);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            da.Update(ds.Tables["dt_customer"]);
        }
        private static DataSet ConnectAndGetData()
        {

            SqlConnection cn = new SqlConnection(cnString);
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_Customer", cn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
           // SqlDataAdapter da1 = new SqlDataAdapter("select * from tbl_Products", cn);
            DataSet ds = new DataSet();
            ds = new DataSet();
            da.Fill(ds, "dt_customer");
            //da1.Fill(ds, "dt_products");
            return ds;
        }
        public void UpdateCustomer(int id, CustomerBAL details)
        {
            DataSet ds = ConnectAndGetData();
            DataRow drow = ds.Tables["dt_customer"].Rows.Find(id);
            drow["CustomerId"] = details.CustomerId;
            drow["CustomerName"] = details.CustomerName;
            ConnectandUpdateServer(ds);
        }
        public void DeleteCustomer(CustomerBAL cust)
        {
            DataSet ds = ConnectAndGetData();
            DataRow drow = ds.Tables["dt_customer"].Rows.Find(cust.CustomerId);
            drow.Delete();
            ConnectandUpdateServer();
        }

        public CustomerBAL FindCustomer(int id)
        {
            DataSet ds = ConnectAndGetData();
            DataRow drow = ds.Tables["dt_customer"].Rows.Find(id);
            CustomerBAL bal = new CustomerBAL();
            bal.CustomerId = (int)drow["CustomerId"];
            bal.CustomerName = drow["CustomerName"].ToString();
            return bal;


        }

        private void ConnectandUpdateServer()
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}

