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

namespace WebApplication1.Address_Book.AdminPanel
{
    public partial class LogIn : System.Web.UI.Page
    {
        public object SqlComand { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {

            #region Local Variable
            SqlString strUserName = new SqlString();
            SqlString strPassword = new SqlString();
            #endregion Local Variable

            #region Server Side Validation

            lblUserName.Text = "";
            lblPassword.Text = "";
            if(txtUserName.Text.Trim() == "")
            {
                lblUserName.Text = "*Envalid UserName";
            }
           if(txtPassword.Text.Trim() == "")
            {
                lblPassword.Text = "*Envalid Password";
            }

            #endregion Server Side Validation

            #region Assign the Values

           if(txtUserName.Text != "")
            {
                strUserName = txtUserName.Text.Trim();
            }
           if(txtPassword.Text != "")
            {
                strPassword = txtPassword.Text.Trim();
            }

            #endregion Assign the Values

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["UserAddressBookConnectionString"].ConnectionString);

            if (ConnectionState.Open != objConn.State)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUserIDPassword";

            objCmd.Parameters.AddWithValue("UserID", strUserName);
            objCmd.Parameters.AddWithValue("Password", strPassword);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                while(objSDR.Read())
                {
                    if(!objSDR["UserID"].Equals(DBNull.Value))
                    { 
                        Session["UserID"] = objSDR["UserID"].ToString();
                    }
                    if(!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString();
                    }
                }
            }


        }
    }
}