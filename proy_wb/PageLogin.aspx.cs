using CryptSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proy_wb
{
    public partial class PageLogin : System.Web.UI.Page
    {
        private SqlConnection conn=new SqlConnection("Data Source=SEGUNDO150\\SEGUNDO;Initial Catalog=DAM2_DarrenVargas;Integrated Security=True");
        private SqlCommand cmd=new SqlCommand("SELECT UserName,Password,state FROM dv.Users WHERE UserName=@user");

        public PageLogin()
        {
            cmd.Parameters.Add(new SqlParameter { ParameterName = "@user", DbType =System.Data.DbType.String});
            cmd.Connection = conn;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/Default");
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            LiteralErrorMsg.Text = "";

            string password = TextPassword.Text;

            // Verificar si una contraseña coincide con un hash
            bool isValidPass, isValidUser;
            isValidPass=isValidUser = false;

            cmd.Parameters["@user"].Value= TextUserName.Text;
            cmd.Connection.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            if(reader.Read())
            {
               isValidPass =Crypter.CheckPassword(password, reader["Password"].ToString());
               isValidUser = bool.Parse(reader["state"].ToString());
            }


            if(isValidUser && isValidPass)
            {
                Session["user"] = reader["UserName"].ToString();
                Response.Redirect("~/Default");
            }
            else
            {
                 LiteralErrorMsg.Text = "¡Usuario o email incorrecto!";
            }

            cmd.Connection.Close();
        }

    }
}