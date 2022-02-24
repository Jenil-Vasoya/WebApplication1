using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblFirst.Text = "";
            lblSecond.Text = "";
            {
                double input;
                if (!double.TryParse(textFirst.Text.Trim(), out input) && !double.TryParse(textSecond.Text.Trim(), out input))
                {

                    lblFirst.Text = "Please enter a valid Number";
                    lblSecond.Text = "Please enter a valid Number";
                }
                else if (!double.TryParse(textFirst.Text.Trim(), out input))
                {
                    lblFirst.Text = "Please enter a valid Number";
                }
                else if (!double.TryParse(textSecond.Text.Trim(), out input))
                {
                    lblSecond.Text = "Please enter a valid Number";
                }

            }

            if (textFirst.Text.Trim() == "" && textSecond.Text.Trim() == "" && textOperation.Text.Trim() == "")
            {
                lblFirst.Text = "*Please Enter the first number";
                lblSecond.Text = "*Please Enter the second number";
                textAnswer.Text = "Invalid Operater";
            }
            else if (textFirst.Text.Trim() == "" && textOperation.Text.Trim() == "")
            {
                lblFirst.Text = "*Please Enter the first number";
                textAnswer.Text = "Invalid Operater";
            }
            else if (textOperation.Text.Trim() == "" && textSecond.Text.Trim() == "")
            {
                textAnswer.Text = "Invalid Operater";
                lblSecond.Text = "*Please Enter the second number";
            }
            else if (textFirst.Text.Trim() == "" && textSecond.Text.Trim() == "")
            {
                lblFirst.Text = "*Please Enter the first number";
                lblSecond.Text = "*Please Enter the second number";
            }
            else if (textFirst.Text.Trim() == "")
            {
                lblFirst.Text = "*Please Enter the first number";
            }
            else if (textSecond.Text == "")
            {
                lblSecond.Text = "*Please Enter the second number";
            }



            else if (textOperation.Text.Trim() == "+")
            {
                textAnswer.Text = Convert.ToString(Convert.ToDouble(textFirst.Text.Trim()) + Convert.ToDouble(textSecond.Text.Trim()));
            }
            else if (textOperation.Text.Trim() == "-")
            {
                textAnswer.Text = Convert.ToString(Convert.ToDouble(textFirst.Text.Trim()) - Convert.ToDouble(textSecond.Text.Trim()));
            }
            else if (textOperation.Text.Trim() == "*")
            {
                textAnswer.Text = Convert.ToString(Convert.ToDouble(textFirst.Text.Trim()) * Convert.ToDouble(textSecond.Text.Trim()));
            }
            else if (textOperation.Text.Trim() == "/")  
            {
                textAnswer.Text = Convert.ToString(Convert.ToDouble(textFirst.Text.Trim()) / Convert.ToDouble(textSecond.Text.Trim()));
            }
            else if (textOperation.Text.Trim() != string.Empty)
            {
                textAnswer.Text = "Invalid Operator";
            }
            else if (textOperation.Text.Trim() == "")
            {
                textAnswer.Text = "Invalid Operator";
            }


     }
               


            

          
        

        protected void btnReset_Click(object sender, EventArgs e)
        {
            textFirst.Text = "";
            textSecond.Text = "";
            textOperation.Text = "";
            textAnswer.Text = "";
            lblFirst.Text = "";
            lblSecond.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    } }
           
