using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ChooseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbtnDU_CheckedChanged(object sender, EventArgs e)
        {
            lblrShow.Text = "";
            lblrMessage.Text = "Select Your Degree Branch";
            rbtnCED.Visible = false;
            rbtnMED.Visible = false;
            rbtnEED.Visible = false;
            rbtnCID.Visible = false;
            rbtnCE.Visible = true;
            rbtnME.Visible = true;
            rbtnEE.Visible = true;
            rbtnCI.Visible = true;
            btnrShow.Visible = true;
        }
    
        protected void rbtnDUD_CheckedChanged(object sender, EventArgs e)
        {
            lblrShow.Text = "";
            lblrMessage.Text = "Select Your Diploma Branch";
            rbtnCED.Visible = true;
            rbtnMED.Visible = true;
            rbtnEED.Visible = true;
            rbtnCID.Visible = true;
            rbtnCE.Visible = false;
            rbtnME.Visible = false;
            rbtnEE.Visible = false;
            rbtnCI.Visible = false;
            btnrShow.Visible=true;
                
            

        }

        protected void btnrShow_Click(object sender, EventArgs e)
        {
            if(rbtnDU.Checked == true)
            {
                lblrShow.Text = "";
                if (rbtnCE.Checked)
                {
                    lblrShow.Text = "Your Degree CE Branch is Selected";
                }
                else if (rbtnME.Checked)
                {
                    lblrShow.Text = "Your Degree ME Branch is Selected";
                }
                else if (rbtnEE.Checked)
                {
                    lblrShow.Text = "Your Degree EE Branch is Selected";
                }
                else if (rbtnCI.Checked)
                {
                    lblrShow.Text = "Your Degree CI Branch is Selected";
                }
                else
                {
                    lblrShow.Text = "Please select your branch";
                }
            }
            if (rbtnDU.Checked == false)
            {
                rbtnCE.Checked = false;
                rbtnME.Checked = false;
                rbtnEE.Checked = false;
                rbtnCI.Checked = false;
            }
            if(rbtnDUD.Checked == true)
            {
                lblrShow.Text = "";
                if (rbtnCED.Checked)
                {
                    lblrShow.Text = "Your Diploma CE Branch is Selected";
                }
                else if (rbtnMED.Checked)
                {
                    lblrShow.Text = "Your Diploma ME Branch is Selected";
                }
                else if (rbtnEED.Checked)
                {
                    lblrShow.Text = "Your Diploma EE Branch is Selected";
                }
                else if (rbtnCID.Checked)
                {
                    lblrShow.Text = "Your Diploma CI Branch is Selected";
                }
                else
                {
                    lblrShow.Text = "Please select your branch";
                }
            }
            if (rbtnDUD.Checked == false)
            {
                rbtnCED.Checked = false;
                rbtnMED.Checked = false;
                rbtnEED.Checked = false;
                rbtnCID.Checked = false;
            }
           

        }

        /*                Checkbox              */

        protected void chkbDU_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbDU.Checked == true || chkbDUD.Checked == true)
            {
                if (chkbDU.Checked == true && chkbDUD.Checked == true)
                {
                    lblcMessage.Text = "Select Your Degree & Diploma Branch :</br>";
                    chkbCE.Visible = true;
                    chkbME.Visible = true;
                    chkbEE.Visible = true;
                    chkbCI.Visible = true;
                    chkbCED.Visible = true;
                    chkbMED.Visible = true;
                    chkbEED.Visible = true;
                    chkbCID.Visible = true;
                    btncShow.Visible = true;

                }
                else if (chkbDU.Checked == true && chkbDUD.Checked == false)
                {
                    lblcMessage.Text = "Select Your Degree Branch";
                    chkbCED.Visible = false;
                    chkbMED.Visible = false;
                    chkbEED.Visible = false;
                    chkbCID.Visible = false;
                    chkbCE.Visible = true;
                    chkbME.Visible = true;
                    chkbEE.Visible = true;
                    chkbCI.Visible = true;
                    btncShow.Visible = true;
                }
                else if (chkbDUD.Checked == true && chkbDU.Checked == false)
                {

                    lblcMessage.Text = "Select Your Diploma Branch";
                    chkbCE.Visible = false;
                    chkbME.Visible = false;
                    chkbEE.Visible = false;
                    chkbCI.Visible = false;
                    chkbCED.Visible = true;
                    chkbMED.Visible = true;
                    chkbEED.Visible = true;
                    chkbCID.Visible = true;
                    btncShow.Visible = true;
                }
            }
            else
            {
                lblcMessage.Text = "";
                chkbCED.Visible = false;
                chkbMED.Visible = false;
                chkbEED.Visible = false;
                chkbCID.Visible = false;
                chkbCE.Visible = false;
                chkbME.Visible = false;
                chkbEE.Visible = false;
                chkbCI.Visible = false;
                btncShow.Visible = false;
            }
        }
           
        

        protected void chkbDUD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbDUD.Checked == true || chkbDU.Checked == true)
            {
                if (chkbDUD.Checked == true && chkbDU.Checked == true)
                {
                    lblcMessage.Text = "Select Your Degree & Diploma Branch :</br>";
                    chkbCE.Visible = true;
                    chkbME.Visible = true;
                    chkbEE.Visible = true;
                    chkbCI.Visible = true;
                    chkbCED.Visible = true;
                    chkbMED.Visible = true;
                    chkbEED.Visible = true;
                    chkbCID.Visible = true;
                    btncShow.Visible = true;

                }
                else if (chkbDUD.Checked == true && chkbDU.Checked == false)
                {
                    lblcMessage.Text = "Select Your Diploma Branch";
                    chkbCED.Visible = true;
                    chkbMED.Visible = true;
                    chkbEED.Visible = true;
                    chkbCID.Visible = true;
                    chkbCE.Visible = false;
                    chkbME.Visible = false;
                    chkbEE.Visible = false;
                    chkbCI.Visible = false;
                    btncShow.Visible = true;
                }
                else if (chkbDU.Checked == true && chkbDUD.Checked == false)
                {

                    lblcMessage.Text = "Select Your Degree Branch";
                    chkbCED.Visible = false;
                    chkbMED.Visible = false;
                    chkbEED.Visible = false;
                    chkbCID.Visible = false;
                    chkbCE.Visible = true;
                    chkbME.Visible = true;
                    chkbEE.Visible = true;
                    chkbCI.Visible = true;
                    btncShow.Visible = true;
                }
            }
            else
            {
                lblcMessage.Text = "";
                chkbCED.Visible = false;
                chkbMED.Visible = false;
                chkbEED.Visible = false;
                chkbCID.Visible = false;
                chkbCE.Visible = false;
                chkbME.Visible = false;
                chkbEE.Visible = false;
                chkbCI.Visible = false;
                btncShow.Visible = false;
            }
            
           
        }

        protected void chkbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbSelectAll.Checked==true)
            {
                chkbDU.Checked = true;
                chkbCE.Checked = true;
                chkbME.Checked = true;
                chkbEE.Checked = true;
                chkbCI.Checked = true;
                chkbDUD.Checked = true;
                chkbCED.Checked = true;
                chkbMED.Checked = true;
                chkbEED.Checked = true;
                chkbCID.Checked = true;
                
                    lblcMessage.Text = "Select Your Degree & Diploma Branch :</br>";
                    chkbCE.Visible = true;
                    chkbME.Visible = true;
                    chkbEE.Visible = true;
                    chkbCI.Visible = true;
                    chkbCED.Visible = true;
                    chkbMED.Visible = true;
                    chkbEED.Visible = true;
                    chkbCID.Visible = true;
                    btncShow.Visible = true;
                
            }
            if(chkbSelectAll.Checked==false)
            {
                chkbDU.Checked = false;
                chkbCE.Checked = false;
                chkbME.Checked = false;
                chkbEE.Checked = false;
                chkbCI.Checked = false;
                chkbDUD.Checked = false;
                chkbCED.Checked = false;
                chkbMED.Checked = false;
                chkbEED.Checked = false;
                chkbCID.Checked = false;

                lblcMessage.Text = "";
                chkbCED.Visible = false;
                chkbMED.Visible = false;
                chkbEED.Visible = false;
                chkbCID.Visible = false;
                chkbCE.Visible = false;
                chkbME.Visible = false;
                chkbEE.Visible = false;
                chkbCI.Visible = false;
                btncShow.Visible = false;

            }
            if (chkbCE.Checked==true && chkbME.Checked==true && chkbEE.Checked==true && chkbCI.Checked==true && chkbCED.Checked==true && chkbMED.Checked==true && chkbEED.Checked==true && chkbCID.Checked==true)
            {
                chkbSelectAll.Checked = true;
            }
            else
            {
                chkbSelectAll.Checked = false;
            }
            
        }

        protected void btncShow_Click(object sender, EventArgs e)
        {
            lblcShow.Text = "";

            if(chkbDU.Checked || chkbDUD.Checked || chkbSelectAll.Checked)
            {
                var chkb = new List<CheckBox>() {chkbCE,chkbME,chkbEE,chkbCI,chkbCED,chkbMED,chkbEED,chkbCID};
                var onchkb = new List<CheckBox>() {};
                foreach(CheckBox chk in chkb)
                {
                    if(chk.Checked)
                    {
                        onchkb.Add(chk);
                    }
                }
                if(onchkb.Count==0)
                {
                    lblcShow.Text = "Please Select at least one branch";
                }
                else
                {
                    lblcShow.Text = "Selected by you :</br>";
                    foreach(CheckBox chk in onchkb)

                    {
                        lblcShow.Text +=chk.Text+"</br>";
                    }       
                }
            }
          
            
           

        }
  
    }
}