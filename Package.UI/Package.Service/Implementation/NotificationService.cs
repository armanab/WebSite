using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Package.Service.Application;

namespace Package.Service.Implementation
{
    public class NotificationService : INotificationService
    {
    
        protected readonly IApplicationSettingService applicationSettingService;

        public NotificationService(IApplicationSettingService applicationSettingService)
        {
         
            this.applicationSettingService = applicationSettingService;
        }

        public void SendEmail(string to, string subject, string message)
        {
            //var smtpSetting = agencyService.GetActiveSmtpSetting();
            //using (var client = new SmtpClient(smtpSetting.Host, smtpSetting.Port))
            //{
            //    client.EnableSsl = smtpSetting.EnableSsl;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.Credentials = new System.Net.NetworkCredential(smtpSetting.UserName, smtpSetting.Password);

            //    var mailMessage = new MailMessage();
            //    mailMessage.Subject = subject;
            //    mailMessage.Body = message;
            //    mailMessage.IsBodyHtml = true;
            //    mailMessage.From = new MailAddress(smtpSetting.UserName, smtpSetting.DisplayName, UTF8Encoding.UTF8);
            //    mailMessage.To.Add(new MailAddress(to));
            //    mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            //    mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            //    client.Send(mailMessage);
            //}
        }


        public void SendEmail(string to, string subject, string language, string templateName,
            IDictionary<string, string> tokens)
        {
            //if (tokens == null) tokens = new Dictionary<string, string>();

            //var agency = agencyService.GetById(agencyId);

            //tokens["Agency.Url"] = agencyService.GetDefaultUrl(agencyId);
            //tokens["Agency.Language"] = "fa";

            //var layout = LoadTemplate(agencyId, "layout", language);
            //var template = LoadTemplate(agencyId, templateName, language);
            //layout = layout.Replace("[Layout:Content]", template);
            //foreach (var item in tokens)
            //{
            //    layout = layout.Replace(string.Format("[{0}]", item.Key), item.Value);
            //}
            //SendEmail(agencyId, to, subject, layout);
        }

        private string LoadTemplate(string templateName, string language)
        {
            var baseFolderPath = applicationSettingService.GetEmailTemplateFolderPath();
            var filePath = string.Format(@"{0}\{1}.{2}.html", baseFolderPath, templateName, language);
            bool exist = System.IO.File.Exists(filePath);
            if (exist)
                return System.IO.File.ReadAllText(filePath);
            filePath = string.Format(@"{0}\{1}.html", baseFolderPath, templateName);
            return System.IO.File.ReadAllText(filePath);
        }
    }
}