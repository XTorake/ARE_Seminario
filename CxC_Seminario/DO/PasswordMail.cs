using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
namespace CxC_Seminario.DO
{
    public class PasswordMail
    {
        private void EnviarEmail(string usuario, string contrasena,string correo)
        {
            string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Content/PasswordReset.html"));

            Body = Body.Replace("#Usuario#", usuario);
            Body = Body.Replace("#Contrasena#", contrasena);
            
            using (SmtpClient smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential("nazarenotest@gmail.com", "T0rake159");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress("nazarenotest@gmail.com");

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = "Restablecimiento de Contraseña";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = Body;
                    message.To.Add(correo);

                    try
                    {
                        smtpClient.Send(message);
                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message
                       
                    }
                }
            }
        }
    }
}