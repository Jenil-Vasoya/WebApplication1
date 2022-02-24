using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;

namespace WebApplication1.Address_Book.AdminPanel.Country
{
    public partial class AddCountry : System.Web.UI.Page
    {
        #region Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CountryID"] != null)
                {
                    lblMessage.Text = "Edit Mode | CountryID = " + Request.QueryString["CountryID"].ToString();
                    FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
                }
                else
                {
                    lblMessage.Text = "Add Mode";
                }
            }

        }

        #endregion Load Event

        #region Button : Save

        protected void btnSave_Click(object sender, EventArgs e)
        {

        
        
            /* if(txtCountryCode.Text=="" && txtCountryName.Text=="")
             {
                 lblMessage.Text = "Please enter the Country Name and Code";
             }
             if(txtCountryName.Text=="" && txtCountryCode.Text!="")
             {
                 lblMessage.Text = "Please enter the Country Name";
             }
             if(txtCountryCode.Text=="" && txtCountryName.Text!="")
             {
                 lblMessage.Text = "Please enter the Country Code";
             }
             if(txtCountryName.Text!="" && txtCountryCode.Text!="")
             {
                 SqlString strCountryName = SqlString.Null;
                 SqlString strCountryCode = SqlString.Null;
                 SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
                 objConn.Open();

                 SqlCommand objCmd = objConn.CreateCommand();
                 objCmd.CommandType = CommandType.StoredProcedure;
                 objCmd.CommandText = "[dbo].[PR_Country_Insert]";


                 strCountryName = txtCountryName.Text.Trim();
                 strCountryCode = txtCountryCode.Text.Trim();
                 objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
                 objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
                 objCmd.ExecuteNonQuery();

                 objConn.Close();
                 lblMessage.Text = " Data is added successfully";
                 txtCountryName.Text = "";
                 txtCountryCode.Text = "";
                 txtCountryName.Focus();
             }
            */

            #region Connection String 
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Connection String 

            try
            {
                #region Local variable
                //Declare Local variables to insert the data
                SqlString strCountryName = SqlString.Null;
                SqlString strCountryCode = SqlString.Null;
                #endregion Local variable

                #region server side Validation
                //Validation | Server side validation
                string strErrorMessage = "";


                if (txtCountryName.Text.Trim() == "")
                    strErrorMessage += " - Enter Country Name ";
                if (txtCountryCode.Text.Trim() == "")
                    strErrorMessage += " - Enter Country Code ";

                if (strErrorMessage != "")
                {
                    lblMessage.Text = strErrorMessage;
                    return;
                }

                if (txtCountryName.Text.Trim() != "")
                {
                    strCountryName = txtCountryName.Text.Trim();
                }
                if (txtCountryCode.Text.Trim() != "")
                {
                    strCountryCode = txtCountryCode.Text.Trim();
                }

                #endregion server side Validation

                //save the country data
                //Establish the connection

                #region Set Connection & Command Object

                if (ConnectionState.Open != objConn.State)
                    objConn.Open();

                //prepare the command

                //SqlCommand objCmd = new SqlCommand();
                //objCmd.Connection = objConn;
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;


                //Pass the parameter in the SP
                objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
                objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
                #endregion Set Connection & Command Object

                if (Request.QueryString["CountryID"] != null)
                {
                    #region Edit Mode
                    objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
                    objCmd.CommandText = "[PR_Country_UpdateByPK]";
                    objCmd.ExecuteNonQuery();


                    Response.Redirect("~/Address Book/AdminPanel/Country/Country.aspx", true);
                    #endregion Edit Mode

                }
                else
                {
                    #region Add Mode

                    objCmd.CommandText = "PR_Country_Insert";
                    objCmd.ExecuteNonQuery();

                    lblMessage.Text = txtCountryName.Text.Trim() + " : " + txtCountryCode.Text.Trim() + " - " + "Insert Successfully";
                    txtCountryName.Text = txtCountryCode.Text = "";
                    txtCountryName.Focus();
                    #endregion Add Mode

                }
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();

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

        #endregion Button : Save

    #region Fill Edit Control

        private void FillControls(SqlInt32 CountryID)
        {
            #region Connection String

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString);
            #endregion Connection String


            try
            {
                #region Set Connection & Command Object


                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectByPK";
                objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString());

                #endregion Set Connection & Command Object


                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryName"].Equals(DBNull.Value))
                        {
                            txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                        }
                        if (!objSDR["CountryCode"].Equals(DBNull.Value))
                        {
                            txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                        }
                        break;

                    }
                }
                else
                {
                    lblMessage.Text = "No data avilable for the country id" + CountryID.ToString();
                }
                if (objConn.State == ConnectionState.Open)
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
        #endregion Fill Edit Control

       
    }








}