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

namespace WebApplication1.Address_Book.AdminPanel.City
{
    public partial class City: System.Web.UI.Page
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


        #region FillGrid View
        private void FillGridView()
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            try
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objConn;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "PR_City_SelectAll";

                SqlDataReader objSDR = objcmd.ExecuteReader();
                if (objSDR.HasRows)
                {
                    gvCity.DataSource = objSDR;
                    gvCity.DataBind();
                }


               

                objConn.Close();
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
        #endregion FillGrid View


        #region Row Command
        protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "DeleteRecord")
            {


                if (e.CommandArgument.ToString() != "")
                {
                    DeleteCity(Convert.ToInt32(e.CommandArgument));

                }
            }
        }
        #endregion Row Command


        #region Delete Record
        private void DeleteCity(SqlInt32 CityID)
        {
            #region Set Connection

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

            #endregion Set Connection

            #region Set Command

            try
            {
                if(ConnectionState.Open != objConn.State)
                objConn.Open();

                SqlCommand objcmd = objConn.CreateCommand();
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "[dbo].[PR_City_DeleteByPK]";
                objcmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

                objcmd.ExecuteNonQuery();

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
                if(objConn.State != ConnectionState.Closed)
                objConn.Close();
            }

            #endregion Set Command

        }
        #endregion Delete Record
    }
}
    