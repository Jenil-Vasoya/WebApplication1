using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Address_Book.AdminPanel.City
{
    public partial class CityAddEdit : System.Web.UI.Page
    {

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                FillDropDownList();

                if (Request.QueryString["CityID"] != null)
                {
                    lblMessage.Text = "Edit Mode | CityID " + Request.QueryString["CityID"].Trim();
                    FillControls(Convert.ToInt32(Request.QueryString["CityID"].Trim()));
                }
                else
                {
                    lblMessage.Text = "Add Mode";
                }

            }
        }
        #endregion page load


        #region Button : save
        protected void btnSave_Click(object sender, EventArgs e)
        {

            #region Local Variable

            SqlInt32 strStateID = new SqlInt32();
            SqlString strCityName = new SqlString();
            SqlString strPINCode = new SqlString();
            SqlString strSTDCode = new SqlString();


            string strErrorMessage = "";

            #endregion Local Variable

            #region Server Side Validation

            if (ddlState.SelectedIndex == 0)
            {
                strErrorMessage += "- Select State <br/>";

            }
            if (txtCityName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter City Name <br/> ";
            }


            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }

            if (ddlState.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlState.SelectedValue);
            }

            if (txtCityName.Text.Trim() != "")
            {
                strCityName = txtCityName.Text.Trim();
            }

            #endregion Server Side Validation

            #region Set Connection

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

            #endregion Set Connection

            objConn.Open();

            #region Set Command

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_City_Insert]";

            strCityName = txtCityName.Text.Trim();
            strPINCode = txtPINCode.Text.Trim();
            strSTDCode = txtSTDCode.Text.Trim();

            objCmd.Parameters.AddWithValue("@StateID", strStateID);
            objCmd.Parameters.AddWithValue("@CityName", strCityName);
            objCmd.Parameters.AddWithValue("@PINCode", strPINCode);
            objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);

            #endregion Set Command

            if (Request.QueryString["CityID"] != null)
            {

                #region Edit Mode
                //Edit Mode
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                objCmd.CommandText = "[PR_City_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/Address Book/AdminPanel/City/City.aspx", true);
                lblMessage.Text = "Data Updated Successfully";
                #endregion Edit Mode
            }
            else
            {
                #region Add Mode
                //Add Mode
                objCmd.CommandText = "[dbo].[PR_City_Insert]";
                objCmd.ExecuteNonQuery();
                txtCityName.Text = "";
                txtPINCode.Text = "";
                txtSTDCode.Text = "";
                ddlState.SelectedIndex = 0;
                ddlState.Focus();
                lblMessage.Text = "Data Inserted Successfully";
                #endregion Add Mode
            }
            objConn.Close();
        }
        #endregion Button : save


        #region FillDropDown
        private void FillDropDownList()
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

            try
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }

                SqlCommand objCmd = objConn.CreateCommand();

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_State_SelectStateDropDownList";

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows == true)
                {
                    ddlState.DataSource = objSDR;
                    ddlState.DataValueField = "StateID";
                    ddlState.DataTextField = "StateName";
                    ddlState.DataBind();

                }
                ddlState.Items.Insert(0, new ListItem("Select State", "-1"));

                if (objConn.State != ConnectionState.Closed)
                {
                    objConn.Close();
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;

            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                {
                    objConn.Close();
                }
            }

        }
        #endregion FillDropDown


        #region FillControl
        private void FillControls(SqlInt32 CityID)
        {
            #region Local variable
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
            #endregion Local variable
            try
            {
                #region Connection Open And Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectByPK";
                objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                        }
                        if (!objSDR["CityName"].Equals(DBNull.Value))
                        {
                            txtCityName.Text = objSDR["CityName"].ToString().Trim();
                        }
                        if (!objSDR["PINCode"].Equals(DBNull.Value))
                        {
                            txtPINCode.Text = objSDR["PINCode"].ToString().Trim();
                        }
                        if (!objSDR["STDCode"].Equals(DBNull.Value))
                        {
                            txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                        }

                        break;
                    }
                }
                else
                {
                    lblMessage.Text = "No Data Available for the CityID =" + CityID.ToString();
                }




                #endregion Connection Open And Command Object

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                {
                    objConn.Close();
                }
            }

        }
        #endregion FillControl
    }
}




















/*
if (!Page.IsPostBack)
{
    SqlConnection objConn = new SqlConnection("data source = (local); initial catalog=Address Book; Integrated Security = true;");
    objConn.Open();

    SqlCommand objCmd = objConn.CreateCommand();
    objCmd.CommandType = CommandType.StoredProcedure;
    objCmd.CommandText = "PR_State_SelectStateDropDownList";
    SqlDataReader objSDR = objCmd.ExecuteReader();

    if (objSDR.HasRows == true)
    {
        ddlState.DataSource = objSDR;
        ddlState.DataValueField = "StateID";
        ddlState.DataTextField = "StateName";
        ddlState.DataBind();
    }

    ddlState.Items.Insert(0, new ListItem("Select Country", "-1"));

    objConn.Close();
}
}

protected void btnSave_Click(object sender, EventArgs e)
{
if (ddlState.SelectedValue == "-1")
{
    if (txtCityName.Text == "")
    {
        lblMessage.Text = "Please select the State name and enter the City name";
    }
    else
    {
        lblMessage.Text = "Please select the State";
    }

}
if (txtCityName.Text == "" && ddlState.SelectedValue != "-1")
{
    lblMessage.Text = "Please enter the City Name";
}
if (ddlState.SelectedValue == "-1" && txtCityName.Text != "")
{
    lblMessage.Text = "Please select the State";
}
if (txtCityName.Text != "" && ddlState.SelectedValue != "-1")
{

    SqlString strCityName = SqlString.Null;
    SqlString strSTDCode = SqlString.Null;
    SqlString strPINCode = SqlString.Null;

    SqlConnection objConn = new SqlConnection("data source=(local); initial catalog=Address Book; Integrated Security=true;");
    objConn.Open();

    SqlCommand objCmd = objConn.CreateCommand();
    objCmd.CommandType = CommandType.StoredProcedure;
    objCmd.CommandText = "PR_City_Insert";

    strCityName = txtCityName.Text.Trim();
    strSTDCode = txtSTDCode.Text.Trim();
    strPINCode = txtPINCode.Text.Trim();

    objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddlState.SelectedValue));
    objCmd.Parameters.AddWithValue("@CityName", strCityName);
    objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
    objCmd.Parameters.AddWithValue("@PINCode", strPINCode);
    objCmd.ExecuteNonQuery();


    objConn.Close();
    lblMessage.Text = " Data is added successfully";
    txtCityName.Text = "";
    txtSTDCode.Text = "";
    txtPINCode.Text = "";
    txtCityName.Focus();

}
}
}
}*/




