using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace Association_Managment.Models
{
    public class MessageGmail
    {
        public Dictionary<string, string> ToList { get; set; } = new Dictionary<string, string>();
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = false;
        public List<Attachment> ListFileAttachment { get; set; } = new List<Attachment>();

    }

    public static class SendMail
    {
        private static string senderName = "avital";
        private static string senderEmailId = "avital89982@gmail.com";
        private static string password = "A318358769";
        private static MailAddress fromAddress = new MailAddress(senderEmailId, senderName);


        public static bool SendEMail(MessageGmail message)
        {
            var success = false;
            var msg = createMessage(message);
            msg = addFilesToMessage(message, msg);

            var client = createClient();
            try
            {
                client.Send(msg);
                success = true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return success;
        }

        private static MailMessage createMessage(MessageGmail message)
        {
            MailMessage msg = new MailMessage()
            {
                From = fromAddress,
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = message.IsBodyHtml,
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8
            };
            //מצרף את כתובות המייל לשליחה
            foreach (var address in message.ToList)
            {
                var ToAddress = new MailAddress(address.Value, address.Key);
                msg.To.Add(ToAddress);
            }
            return msg;
        }

        private static SmtpClient createClient()
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(fromAddress.Address, password);
            return client;
        }

        private static MailMessage addFilesToMessage(MessageGmail originalMessage, MailMessage msg)
        {
            if (originalMessage.ListFileAttachment != null)
            {
                foreach (var file in originalMessage.ListFileAttachment)
                {
                    ContentType mimeType = new ContentType("text/html");
                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(msg.Body, mimeType);
                    msg.Attachments.Add(file);
                    msg.AlternateViews.Add(alternate);
                }
            }
            return msg;
        }
    }
}