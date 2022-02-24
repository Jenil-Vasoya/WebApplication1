using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Address_Book.AdminPanel.Contact
{
    public partial class Contact : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridView();
            }
        }

        #endregion Page Load

        #region gvContact : RowCommand

        protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRecord")
            {

                if (e.CommandArgument.ToString() != "")
                {
                    DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                }
            }

        }

        #endregion gvContact : RowCommand


        #region FillGridView
        private void FillGridView()
        {
            #region connection string

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            #endregion connection string

            try
            {
                #region Set Connection & Command Object
                objConn.Open();

                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Contact_SelectAll";

                #endregion Set Connection & Command Object

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    gvContact.DataSource = objSDR;
                    gvContact.DataBind();
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }

        }

        #endregion FillGridView


        #region Delete Contact

        private void DeleteContact(SqlInt32 ContactID)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

            try
            {
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Contact_DeleteByPK";
                objCmd.Parameters.AddWithValue("ContactID", ContactID.ToString());

                objCmd.ExecuteNonQuery();

                if (objConn.State != ConnectionState.Closed)
                {
                    objConn.Close();
                }

                lblMessage.Text = "Data Deleted Successfully";

                FillGridView();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }
        }
       
        #endregion Delete Contact

    }
}