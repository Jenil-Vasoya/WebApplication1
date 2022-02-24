using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;

namespace WebApplication1.Address_Book.AdminPanel.Contact
{
    public partial class ContactAddEdit : System.Web.UI.Page
    {

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDownContactCategoryList();
                FillDropDownCountryList();

                if (Request.QueryString["ContactID"] != null)
                {
                    lblMessage.Text = "Edit Mode  |  CityID " + Request.QueryString["ContactID"].Trim();
                    FillControls(Convert.ToInt32(Request.QueryString["ContactID"].Trim()));
                    FillDropDownStateList();
                    FillDropDownCityList();
                }
            }

        }



        #endregion page load


        #region Button : save
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Local Variable

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            SqlInt32 strCountryID = new SqlInt32();
            SqlInt32 strStateID = new SqlInt32();
            SqlInt32 strCityID = new SqlInt32();
            SqlInt32 strContactCategoryID = new SqlInt32();
            SqlString strContactName = new SqlString();
            SqlString strContactNo = new SqlString();
            SqlString strWhatsappNo = new SqlString();
            SqlString strBirthDate = new SqlString();
            SqlString strEmail = new SqlString();
            SqlInt32 strAge = new SqlInt32();
            SqlString strAddress = new SqlString();
            SqlString strBloodGroup = new SqlString();
            SqlString strFacebook = new SqlString();
            SqlString strLinkedIn = new SqlString();

            #endregion Local Variable

            lblCountry.Text = "";
            lblState.Text = "";
            lblCity.Text = "";
            lblContactCategory.Text = "";
            lblContactName.Text = "";
            lblContactNo.Text = "";
            lblEmail.Text = "";
            lblAddress.Text = "";
            try
            {
                #region Server Side Validation


                if (ddlCountry.SelectedIndex == 0)
                {
                    lblCountry.Text = "Select the Country";
                }
                if (ddlState.SelectedIndex == 0)
                {
                    lblState.Text = "Select the State";
                }
                if (ddlCity.SelectedIndex == 0)
                {
                    lblCity.Text = "Select the City";
                }
                if (ddlContactCategory.SelectedIndex == 0)
                {
                    lblContactCategory.Text = "Select the ContactCategory";
                }
                if (txtContactName.Text == "")
                {
                    lblContactName.Text = "Please fill the ContactName";
                }
                if (txtContactNo.Text == "")
                {
                    lblContactNo.Text = "Please fill the ContactNo";
                }
                if (txtEmail.Text == "")
                {
                    lblEmail.Text = "Please fill the Email";
                }
                if (txtAddress.Text == "")
                {
                    lblAddress.Text = "Please fill the Address";
                }

                #endregion Server Side Validation

                #region Gather Information

                if (ddlCountry.SelectedIndex > 0)
                {
                    strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                }
                if (ddlState.SelectedIndex > 0)
                {
                    strStateID = Convert.ToInt32(ddlState.SelectedValue);
                }
                if (ddlCity.SelectedIndex > 0)
                {
                    strCityID = Convert.ToInt32(ddlCity.SelectedValue);
                }
                if (ddlContactCategory.SelectedIndex > 0)
                {
                    strContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue);
                }
                if (txtContactName.Text.Trim() != "")
                {
                    strContactName = txtContactName.Text.Trim();
                }
                if (txtContactNo.Text.Trim() != "")
                {
                    strContactNo = txtContactNo.Text.Trim();
                }
                if (txtWhatsappNo.Text.Trim() != "")
                {
                    strWhatsappNo = txtWhatsappNo.Text.Trim();
                }
                if (txtBirthDate.Text.Trim() != "")
                {
                    strBirthDate = txtBirthDate.Text.Trim();
                }
                if (txtEmail.Text.Trim() != "")
                {
                    strEmail = txtEmail.Text.Trim();
                }
                if (txtAge.Text.Trim() != "")
                {
                    strAge = Convert.ToInt32(txtAge.Text.Trim());
                }
                if (txtAddress.Text.Trim() != "")
                {
                    strAddress = txtAddress.Text.Trim();
                }
                if (txtBloodGroup.Text.Trim() != "")
                {
                    strBloodGroup = txtBloodGroup.Text.Trim();
                }
                if (txtFacebook.Text.Trim() != "")
                {
                    strFacebook = txtFacebook.Text.Trim();
                }
                if (txtLinkedIn.Text.Trim() != "")
                {
                    strLinkedIn = txtLinkedIn.Text.Trim();
                }

                #endregion Gather Information

                #region Set Connection & Command Object

                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(ddlCountry.SelectedValue));
                objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddlState.SelectedValue));
                objCmd.Parameters.AddWithValue("@CityID", Convert.ToInt32(ddlCity.SelectedValue));
                objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(ddlContactCategory.SelectedValue));
                objCmd.Parameters.AddWithValue("@ContactName", strContactName);
                objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
                objCmd.Parameters.AddWithValue("@WhatsappNo", strWhatsappNo);
                objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
                objCmd.Parameters.AddWithValue("@Email", strEmail);
                objCmd.Parameters.AddWithValue("@Age", strAge);
                objCmd.Parameters.AddWithValue("@Address", strAddress);
                objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
                objCmd.Parameters.AddWithValue("@FacebookID", strFacebook);
                objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedIn);

                #endregion Set Connection & Command Object

                if (Request.QueryString["ContactID"] != null)
                {
                    #region Edit Mode
                    //Edit Mode

                    objCmd.CommandText = "PR_Contact_UpdateByPK";
                    objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/Address Book/AdminPanel/Contact/Contact.aspx", true);
                    
                    lblMessage.Text = "Data Updated Successfully";
                    ddlCountry.Focus();

                    #endregion Edit Mode
                }
                else
                {
                    #region Add Mode
                    //Add Mode
                    objCmd.CommandText = "PR_Contact_Insert";
                    objCmd.ExecuteNonQuery();



                   
                    ddlCountry.SelectedIndex = 0;
                    ddlState.SelectedIndex = 0;
                    ddlCity.SelectedIndex = 0;
                    ddlContactCategory.SelectedIndex = 0;
                    txtContactName.Text = "";
                    txtContactNo.Text = "";
                    txtWhatsappNo.Text = "";
                    txtBirthDate.Text = "";
                    txtEmail.Text = "";
                    txtAge.Text = "";
                    txtAddress.Text = "";
                    txtBloodGroup.Text = "";
                    txtFacebook.Text = "";
                    txtLinkedIn.Text = "";
                    txtContactName.Focus();
                    txtContactNo.Focus();
                    txtWhatsappNo.Focus();
                    txtBirthDate.Focus();
                    txtEmail.Focus();
                    txtAge.Focus();
                    txtAddress.Focus();
                    txtBloodGroup.Focus();
                    txtFacebook.Focus();
                    txtLinkedIn.Focus();

                    lblMessage.Text = " Data Inserted successfully";

                    #endregion Add Mode
                }

                if (objConn.State == ConnectionState.Open)
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
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
        }
        #endregion Button : save

        #region Fill Drop Down Country
        protected void FillDropDownCountryList()
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectCountryDropDownList";

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCountry.DataSource = objSDR;
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataBind();
            }

            ddlCountry.Items.Insert(0, new ListItem("- Select Country -", "-1"));

            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
        #endregion Fill Drop Down Country

        #region Fill Drop Down State
        protected void FillDropDownStateList()
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_CountryStateDropDownList";
            objCmd.Parameters.AddWithValue("CountryID", Convert.ToInt32(ddlCountry.SelectedValue));

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlState.DataSource = objSDR;
                ddlState.DataValueField = "StateID";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
            }

            ddlState.Items.Insert(0, new ListItem("- Select State -", "-1"));
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }

        }
        #endregion Fill Drop Down State

        #region Fill Drop Down City
        protected void FillDropDownCityList()
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_StateCityDropDownList";
            objCmd.Parameters.AddWithValue("StateID",Convert.ToInt32(ddlState.SelectedValue));

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCity.DataSource = objSDR;
                ddlCity.DataValueField = "CityID";
                ddlCity.DataTextField = "CityName";
                ddlCity.DataBind();
            }

            ddlCity.Items.Insert(0, new ListItem("- Select City -", "-1"));

            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
        #endregion Fill Drop Down City

        #region Fill Drop Down Contact Category
        protected void FillDropDownContactCategoryList()
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectContactCategoryDropDownList";

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlContactCategory.DataSource = objSDR;
                ddlContactCategory.DataValueField = "ContactCategoryID";
                ddlContactCategory.DataTextField = "ContactCategoryName";
                ddlContactCategory.DataBind();
            }

            ddlContactCategory.Items.Insert(0, new ListItem("- Select Contact Category -", "-1"));

            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
        #endregion Fill Drop Down Contact Category

        #region FillControl
        private void FillControls(SqlInt32 ContactID)
        {
            #region Local variable

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);

            #endregion Local variable

            try
            {
                #region Connection Open And Command Object

                if (ConnectionState.Open != objConn.State)
                {
                    objConn.Open();
                }

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Contact_SelectByPK";

                objCmd.Parameters.AddWithValue("ContactID", ContactID.ToString());

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();
                        }
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                        }
                        if (!objSDR["CityID"].Equals(DBNull.Value))
                        {
                            ddlCity.SelectedValue = objSDR["CityID"].ToString().Trim();
                        }
                        if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                        {
                            ddlContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                        }
                        if (!objSDR["ContactName"].Equals(DBNull.Value))
                        {
                            txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                        }
                        if (!objSDR["ContactNo"].Equals(DBNull.Value))
                        {
                            txtContactNo.Text = objSDR["ContactNo"].ToString().Trim();
                        }
                        if (!objSDR["WhatsappNo"].Equals(DBNull.Value))
                        {
                            txtWhatsappNo.Text = objSDR["WhatsappNo"].ToString().Trim();
                        }
                        if (!objSDR["BirthDate"].Equals(DBNull.Value))
                        {
                            txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                        }
                        if (!objSDR["Email"].Equals(DBNull.Value))
                        {
                            txtEmail.Text = objSDR["Email"].ToString().Trim();
                        }
                        if (!objSDR["Age"].Equals(DBNull.Value))
                        {
                            txtAge.Text = objSDR["Age"].ToString().Trim();
                        }
                        if (!objSDR["Address"].Equals(DBNull.Value))
                        {
                            txtAddress.Text = objSDR["Address"].ToString().Trim();
                        }
                        if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                        {
                            txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                        }
                        if (!objSDR["FacebookID"].Equals(DBNull.Value))
                        {
                            txtFacebook.Text = objSDR["FacebookID"].ToString().Trim();
                        }
                        if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                        {
                            txtFacebook.Text = objSDR["LinkedINID"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    lblMessage.Text = "No Data Available for the CityID =" + ContactID.ToString();
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

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlState.Items.Clear();
            ddlCity.Items.Clear();

            FillDropDownStateList();
            
            

        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Items.Clear();
            FillDropDownCityList();
        }
    }



}



 #region old

        /*

            string strErrorMessage = "";

        if (ddlCountry.SelectedIndex == 0)
        {
            strErrorMessage += "Select Country <br />";
        }
        if (ddlState.SelectedIndex == 0)
        {
            strErrorMessage += "Select State <br />";
        }
        if (ddlCity.SelectedIndex == 0)
        {
            strErrorMessage += "Select City <br />";
        }
        if (ddlContactCategory.SelectedIndex == 0)
        {
            strErrorMessage += "Select Contact Category <br />";
        }
        if (txtContactName.Text == "")
        {
            strErrorMessage += "Please Enter Contact Name <br />";
        }
        if(txtContactNo.Text=="")
        {
            strErrorMessage += "Please Enter ContactNo";
        }
        if (txtAddress.Text == "")
        {
            strErrorMessage += "Please Enter Email  <br />";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }

        if (ddlCountry.SelectedValue != "-1")
        {
            if (ddlState.SelectedValue != "-1")
            {
                if (ddlCity.SelectedValue != "-1")
                {
                    if (ddlContactCategory.SelectedValue != "-1")
                    {
                        if (txtContactName.Text != "")
                        {
                            if (txtContactNo.Text != "")
                            {
                                if (txtEmail.Text != "")
                                {
                                    if (txtAddress.Text != "")
                                    {
                                        SqlString strContactName = SqlString.Null;
                                        SqlString strContactNo = SqlString.Null;
                                        SqlString strWhatsappNo = SqlString.Null;
                                        SqlString strBirthDate = SqlString.Null;
                                        SqlString strEmail = SqlString.Null;
                                        SqlString strAge = SqlString.Null;
                                        SqlString strAddress = SqlString.Null;
                                        SqlString strBloodGroup = SqlString.Null;
                                        SqlString strFacebookID = SqlString.Null;
                                        SqlString strLinkedInID = SqlString.Null;

                                        SqlConnection objConn = new SqlConnection("data source=(local); initial catalog=Address Book; Integrated Security=true;");
                                        objConn.Open();

                                        SqlCommand objCmd = objConn.CreateCommand();
                                        objCmd.CommandType = CommandType.StoredProcedure;
                                        objCmd.CommandText = "PR_Contact_Insert";

                                        strContactName = txtContactName.Text.Trim();
                                        strContactNo = txtContactNo.Text.Trim();
                                        strWhatsappNo = txtWhatsappNo.Text.Trim();
                                        strBirthDate = txtBirthDate.Text.Trim();
                                        strEmail = txtEmail.Text.Trim();
                                        strAge = txtAge.Text.Trim();
                                        strAddress = txtAddress.Text.Trim();
                                        strBloodGroup = txtBloodGroup.Text.Trim();
                                        strFacebookID = txtFacebook.Text.Trim();
                                        strLinkedInID = txtLinkedIn.Text.Trim();

                                        objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(ddlCountry.SelectedValue));
                                        objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddlState.SelectedValue));
                                        objCmd.Parameters.AddWithValue("@CityID", Convert.ToInt32(ddlCity.SelectedValue));
                                        objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(ddlContactCategory.SelectedValue));
                                        objCmd.Parameters.AddWithValue("@ContactName", strContactName);
                                        objCmd.Parameters.AddWithValue("@ContactNo", strContactNo);
                                        objCmd.Parameters.AddWithValue("@WhatsappNo", strWhatsappNo);
                                        objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
                                        objCmd.Parameters.AddWithValue("@Email", strEmail);
                                        objCmd.Parameters.AddWithValue("@Age", strAge);
                                        objCmd.Parameters.AddWithValue("@Address", strAddress);
                                        objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
                                        objCmd.Parameters.AddWithValue("@FacebookID", strFacebookID);
                                        objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedInID);

                                        if (Request.QueryString["ContactID"] != null)
                                        {
                                            #region Edit Mode
                                            //Edit Mode
                                            objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
                                            objCmd.CommandText = "PR_Contact_UpdateByPK";
                                            objCmd.ExecuteNonQuery();
                                            Response.Redirect("~/Address Book/AdminPanel/City/City.aspx", true);
                                            lblMessage.Text = "Data Updated Successfully";
                                            #endregion Edit Mode
                                        }
                                        else
                                        {
                                            #region Add Mode
                                            //Add Mode
                                            objCmd.CommandText = "PR_Contact_Insert";
                                            objCmd.ExecuteNonQuery();



                                            lblMessage.Text = " Data is added successfully";
                                            ddlCountry.SelectedIndex = 0;
                                            ddlState.SelectedIndex = 0;
                                            ddlCity.SelectedIndex = 0;
                                            ddlContactCategory.SelectedIndex = 0;
                                            txtContactName.Text = "";
                                            txtContactNo.Text = "";
                                            txtWhatsappNo.Text = "";
                                            txtBirthDate.Text = "";
                                            txtEmail.Text = "";
                                            txtAge.Text = "";
                                            txtAddress.Text = "";
                                            txtBloodGroup.Text = "";
                                            txtFacebook.Text = "";
                                            txtLinkedIn.Text = "";
                                            txtContactName.Focus();
                                            txtContactNo.Focus();
                                            txtWhatsappNo.Focus();
                                            txtBirthDate.Focus();
                                            txtEmail.Focus();
                                            txtAge.Focus();
                                            txtAddress.Focus();
                                            txtBloodGroup.Focus();
                                            txtFacebook.Focus();
                                            txtLinkedIn.Focus();

                                            #endregion Add Mode
                                        }
                                        objConn.Close();
                                    }
                                    }   



                                }
                            }
                        }
                    }
                }
            }

       if (!Page.IsPostBack) private void FillDropDownList()
    {
        /Country/
        if (!Page.IsPostBack)
        {
            SqlConnection objConn = new SqlConnection("data source=(local); initial catalog=Address Book; Integrated Security=true;");
    objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
    objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectCountryDropDownList";

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlCountry.DataSource = objSDR;
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataBind();
            }

ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
            objConn.Close();
        }

/*State/
if (!Page.IsPostBack)
{
SqlConnection objConn = new SqlConnection("data source=(local); initial catalog=Address Book; Integrated Security=true;");
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

ddlState.Items.Insert(0, new ListItem("Select State", "-1"));

objConn.Close();
}

/* City/

if (!Page.IsPostBack)
{
SqlConnection objConn = new SqlConnection("data source=(local); initial catalog=Address Book; Integrated Security=true");
objConn.Open();

SqlCommand objCmd = objConn.CreateCommand();
objCmd.CommandType = CommandType.StoredProcedure;
objCmd.CommandText = "PR_City_SelectCityDropDownList";
SqlDataReader objSDR = objCmd.ExecuteReader();

if (objSDR.HasRows == true)
{
    ddlCity.DataSource = objSDR;
    ddlCity.DataValueField = "CityID";
    ddlCity.DataTextField = "CityName";
    ddlCity.DataBind();
}

ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));

objConn.Close();
}

/*Contact Category/
if (!Page.IsPostBack)
{
SqlConnection objConn = new SqlConnection("data source=(local); initial catalog=Address Book; Integrated Security=true");
objConn.Open();

SqlCommand objCmd = objConn.CreateCommand();
objCmd.CommandType = CommandType.StoredProcedure;
objCmd.CommandText = "PR_ContactCategory_SelectContactCategoryDropDownList";

SqlDataReader objSDR = objCmd.ExecuteReader();

if (objSDR.HasRows == true)
{
    ddlContactCategory.DataSource = objSDR;
    ddlContactCategory.DataValueField = "ContactCategoryID";
    ddlContactCategory.DataTextField = "ContactCategoryName";
    ddlContactCategory.DataBind();
}

ddlContactCategory.Items.Insert(0, new ListItem("Select Contact Category", "-1"));

objConn.Close();
}

    }*/

        #endregion old