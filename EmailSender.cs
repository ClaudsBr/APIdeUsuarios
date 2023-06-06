using System;
using System.Net;
using System.Net.Mail;

namespace DesafioAPI
{
    public static class EmailSender
    {
        public static void Send(string email)
        {
            MailMessage emailMessage = new MailMessage();

            try{

                var smtpClient= new SmtpClient("smtp.gmail.com",587);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 60*60;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("claudiogft2022@gmail.com","gft@1234");
                emailMessage.From = new MailAddress("claudiogft2022@gmail.com", "Claudio Oliveira");
                emailMessage.Body = "Você acabou de logar na minha Rest API ";
                emailMessage.Subject = "Serviço de Email SMTP da API ";
                emailMessage.IsBodyHtml = true;
                emailMessage.Priority = MailPriority.Normal;
                emailMessage.To.Add(email);

                smtpClient.Send(emailMessage);

            }catch (Exception e){
                return;
            }

        }
    }
        
    
}