using Package.Core.DTO.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Package.Service.Application
{
    public interface IApplicationSettingService
    {
        string GetLogFolderPath();
        string GetViewFolderPath();
        string GetLocalizeFolderPath();
        string GetSiteUrl();
        string GetDefaultLanguage();
        string GetEmailTemplateFolderPath();
        string GetRootPath();
        string GetImagesImportPath();
        string GetImagesUrl();
        string GetStringValue(string key);
        int GetIntValue(string key);
        bool GetBoolValue(string key);
        string GetTimeZone();
        AboutUsViewModel GetAboutUs();
        ContactUsViewModel GetContactUs();
    }
}
