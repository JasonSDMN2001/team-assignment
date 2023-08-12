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
        Class1 myObj = new Class1(); //δημιουργώ ένα αντικείμενο της τάξης Class1 έξω από αυτήν ώστε να μπορώ παρακάτω να καλώ τις μεθόδους της
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = myObj.SelectCases();
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = true;
            Label4.Visible = true;
            Label4.Text = myObj.Andres().ToString();
            Label5.Visible = false;
            Label6.Visible = false;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = true;
            Label6.Visible = true;
            Label6.Text = myObj.Ginaikes().ToString();
        }
    }
}