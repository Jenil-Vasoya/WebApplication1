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

namespace WebApplication1.Address_Book.AdminPanel.State
{
    public partial class State : System.Web.UI.Page
    {
        #region Load event
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                FillGridView();
            }
        }
        #endregion Load event

        #region gvState : RowCommand
        protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                }
            }

        }

        #endregion gvState : RowCommand

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
                objCmd.CommandText = "PR_State_SelectAll";

                #endregion Set Connection & Command Object


                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    gvState.DataSource = objSDR;
                    gvState.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if (ConnectionState.Closed != objConn.State)
                    objConn.Close();
            }
        }
        #endregion FillGridView

        #region Delete State
        private void DeleteState(SqlInt32 StateID)
        {
            #region connection string

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            #endregion connection string

            try
            {
                #region Set Connection & Command Object

                if (ConnectionState.Open != objConn.State)
                    objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_State_DeleteByPK";
                objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());
                objCmd.ExecuteNonQuery();

                #endregion Set Connection & Command Object

                objConn.Close();

                lblMessage.Text = "Data Deleted Successfully";

                FillGridView();
               
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if (ConnectionState.Closed != objConn.State)
                    objConn.Close();
            }
        }

        #endregion Delete State
    }

}