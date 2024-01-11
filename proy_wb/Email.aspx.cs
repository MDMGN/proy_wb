using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proy_wb
{
    public partial class Email : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        public bool emailIsvalid = false;

  

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"]?.ToString() ?? "";
            string token = Request.QueryString["token"]?.ToString() ?? "";

            conn = new SqlConnection("Data Source=SEGUNDO150\\SEGUNDO;Initial Catalog=DAM2_DarrenVargas;Integrated Security=True");
            cmd = new SqlCommand("UPDATE dv.Users SET state=1 WHERE Email=@email AND token_access=@token", conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@token", token);
            try
            {
                cmd.Connection.Open();
               int rows= cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    emailIsvalid = true;
                    Literal1.Text = "¡Tu cuenta ha sido verificada con exito!";
                }
                else
                {
                    emailIsvalid = false;
                    Literal2.Text = "¡No se ha podido verificar el correo electrónico; token o correo electrónico inválido!";
                }
            }catch (Exception ex)
            {
                Literal2.Text += ex.Message;
            }finally { cmd.Connection.Close(); }

        }
    }
}