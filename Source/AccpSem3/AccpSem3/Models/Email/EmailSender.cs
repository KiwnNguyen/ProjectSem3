using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Net.NetworkInformation;

namespace AccpSem3.Models.Email
{
    public class EmailSender
    {
        private static EmailSender instance;
        private EmailSender() { }
        public static EmailSender Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmailSender();
                }
                return instance;
            }
        }
        public int SendEmail(string from, string to, string subject, string body)
        {
            //Khởi tạo email 
            MailMessage mail = new MailMessage(from, to, subject, body);
            mail.IsBodyHtml = true;//khai báo nội dụng email là html
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(from, "zrvmmxicqqaklyqq");
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(mail);
                Console.WriteLine("Email send success");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to send email. Error message: " + e.Message);
            }
            return 0;

        }
    }
}