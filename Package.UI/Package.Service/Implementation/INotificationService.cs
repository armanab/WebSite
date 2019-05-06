using System;
using System.Collections.Generic;

namespace Package.Service.Implementation
{
    public interface INotificationService
    {
        void SendEmail(string to, string subject, string message);

        void SendEmail(string to, string subject, string language, string templateName,
            IDictionary<string, string> tokens);
    }
}