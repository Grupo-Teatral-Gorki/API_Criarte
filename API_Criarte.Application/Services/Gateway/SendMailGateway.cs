using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API_Criarte.Application.Interfaces;
using API_Criarte.Domain;

namespace API_Criarte.Application.Services.Gateway
{
    public class SendMailGateway : ISendMailGateway
    {
        public ApiResponse<string> SendRecoveryMail(string email)
        {
            string token = codigoRecuperacao();
            MailMessage mail = new MailMessage("joaovitorsousamendes@gmail.com", email);

            mail.From = new MailAddress("joaovitorsousamendes@gmail.com");
            mail.Subject = "Recuperação de Senha";
            string Body = "<h2>Email de recuperação de senha, clique no link abaixo para alterar sua senha</h2></b><a href='www.kabum.com.br'>Clique aqui e será redirecionado</a> " + token;
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("joaovitorsousamendes@gmail.com", "kjzkrawlfwrvnjmw");

            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mail);

                return new ApiResponse<string> (false, "Email de recuperação enviado!", token );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResponse<string>( true, ex.Message );
            }
        }

        public static string codigoRecuperacao()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
