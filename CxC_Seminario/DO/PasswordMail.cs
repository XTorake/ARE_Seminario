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
        public static void RestablecerContraseña(string usuario, string contrasena,string correo)
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
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = "Restablecimiento de Contraseña";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = Body;
                    message.To.Add(correo);
                    smtpClient.Send(message);
                    try
                    {
                        
                        
                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message
                       
                    }
                }
            }
        }
        public static void UsuarioBloqueado(string usuario, string correo)
        {
            string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Content/UserBlocked.html"));

            Body = Body.Replace("#Usuario#", usuario);
        

            using (SmtpClient smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential("nazarenotest@gmail.com", "T0rake159");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress("nazarenotest@gmail.com");

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = "Usuario Bloqueado.";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = Body;
                    message.To.Add(correo);
                    smtpClient.Send(message);
                    try
                    {


                    }
                    catch (Exception ex)
                    {
                        //Error, could not send the message

                    }
                }
            }
        }
        public static void UsuarioCreado(string usuario, string contrasena, string correo)
        {
            string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Content/UserCreated.html"));

            Body = Body.Replace("#Usuario#", usuario);
            Body = Body.Replace("#Contrasena#", contrasena);

            using (SmtpClient smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential("nazarenotest@gmail.com", "T0rake159");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress("nazarenotest@gmail.com");

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = "Bienvenido! Nuevo usuario";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = Body;
                    message.To.Add(correo);
                    smtpClient.Send(message);
                    try
                    {


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