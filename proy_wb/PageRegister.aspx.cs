using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Data.SqlClient;
using CryptSharp;
using System.Data;
using System.Reflection;

namespace proy_wb
{
    public partial class PageRegister : System.Web.UI.Page
    {
        private static readonly Random random = new Random();
       private string applicationDir = (Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath) + "\\").Replace("%20","/");
        private SqlConnection conn;
        private SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
          conn = new SqlConnection("Data Source=SEGUNDO150\\SEGUNDO;Initial Catalog=DAM2_DarrenVargas;Integrated Security=True");
        cmd = new SqlCommand("INSERT INTO dv.Users(UserName,Password,Email,token_access) VALUES(@user,@pass,@email,@token)", conn);
        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@user", DbType = DbType.String });
        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@pass", DbType = DbType.String });
        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@email", DbType = DbType.String });
        cmd.Parameters.Add(new SqlParameter() { ParameterName = "@token", DbType = DbType.String });
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string token = generateToken(10);

            if (verifyUser(TextUserName.Text))
            {
                Literal1.Text = "El usuario ya existe";
                return;
            }

            bool isendEmail=sendEmailRegister(TextEmail.Text,token);

            if (!isendEmail)
            {
                Literal1.Text = "No hemos podido enviarte un email de verificación";
                return;
            }

            string password = TextPassword.Text;
            // Generar un hash de la contraseña
            string hashedPassword = Crypter.Blowfish.Crypt(password);
            cmd.Parameters["@user"].Value = TextUserName.Text;
            cmd.Parameters["@pass"].Value = hashedPassword;
            cmd.Parameters["@email"].Value = TextEmail.Text;
            cmd.Parameters["@token"].Value = token;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                Literal1.Text = "Te hemos enviado un correo de verificación.";
                   
            }catch(Exception ex)
            {
                Literal1.Text = ex.Message;
            }finally {
                cmd.Connection.Close();
            }


        }

        private bool verifyUser(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT 1 FROM dv.Users WHERE Username=@user",conn);
            cmd.Parameters.AddWithValue("@user", username);
            SqlDataReader reader;
            bool exists = false;
            try
            {
                cmd.Connection.Open();
                reader=cmd.ExecuteReader();
                exists=reader.Read();
                cmd.Connection.Close();
            }catch (Exception ex)
            {
                Literal1.Text = ex.Message;
            }
                return exists;
            
        }

        private bool sendEmailRegister(string email,string token)
        {
            string templateContent = File.ReadAllText(applicationDir + "..\\templates\\MailRegister.html");
            string encodedEmail = HttpUtility.UrlEncode(email);

            templateContent = templateContent.Replace("{{title}}", "Email de verificación");
            templateContent = templateContent.Replace("{{dominio}}", "localhost");
            templateContent = templateContent.Replace("{{puerto}}", "57408");
            templateContent = templateContent.Replace("{{token}}", token);
            templateContent = templateContent.Replace("{{email}}", encodedEmail);

            MailAddress mail = new MailAddress("michaelmdvrhack@gmail.com");  //Remitente

            MailMessage mailMessage = new MailMessage();
            //Dirección de correo electrónico del destinatario
            mailMessage.To.Add(email);
            // Dirección de correo electrónico del remitente
            mailMessage.From = new MailAddress("tucorreo@gmail.com");

            mailMessage.Subject = "Verificacíón del registro";
            // Cuerpo del correo electrónico (texto plano)
            mailMessage.Body = templateContent;
            mailMessage.IsBodyHtml = true;
            // Configurar el cliente SMTP para enviar el correo
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            // Cambia esto según tu proveedor de correo
            smtpClient.Port = 587; // Puerto del servidor SMTP (por ejemplo, 587 para Gmail)
            smtpClient.Credentials = new NetworkCredential("michaelmdvrhack@gmail.com", "znquwwahdbmqmmqw"); // Reemplaza con tu correo y contraseña
            smtpClient.EnableSsl = true; // Habilitar SSL/TLS

            // Envío del correo
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Correo enviado correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
                return false;
            }
        }

        public static string generateToken(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder tokenBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                tokenBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return tokenBuilder.ToString();
        }


    }
}