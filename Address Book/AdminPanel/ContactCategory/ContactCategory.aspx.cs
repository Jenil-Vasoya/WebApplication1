using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Address_Book.AdminPanel.ContactCategory
{
    public partial class ContactCategory : System.Web.UI.Page
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

        protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRecord")

                if (e.CommandArgument.ToString() != "")
                {
                    DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString()));
                }

        }

#endregion gvContact : RowCommand


        #region FillGridView

        private void FillGridView()
        {
            #region connection string

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());


            #endregion connection string


            try
            {

                #region Set Connection & Command Object

                objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactCategory_SelectAll";

                #endregion Set Connection & Command Object

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    gvContactCategory.DataSource = objSDR;
                    gvContactCategory.DataBind();
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
        private void DeleteContactCategory(SqlInt32 ContactCategoryID)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactCategory_DeleteByPK";
                objCmd.Parameters.AddWithValue("ContactCategoryID", ContactCategoryID.ToString());

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

        