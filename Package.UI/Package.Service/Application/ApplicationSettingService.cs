using AutoMapper;
using Package.Core.Domain.Application;
using Package.Core.DTO.Application;
using Package.EntityFrameworkCore.EF;
using Package.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Package.Service.Application
{
    internal class ApplicationSettingService : IApplicationSettingService
    {
        private readonly IRepository<ApplicationSetting> applicationSettingRepository;
        private readonly IRepository<ContactUs> contactUsRepository;
        private readonly IRepository<AboutUs> aboutUsRepository;
        protected readonly ICacheService cacheService;

       
        public ApplicationSettingService(IRepository<ApplicationSetting> applicationSettingRepository, ICacheService cacheService)
        {
            this.applicationSettingRepository = applicationSettingRepository;
            this.cacheService = cacheService;
        }

        private Dictionary<string, string> _items;

        private Dictionary<string, string> Items
        {
            get
            {
                if (_items == null)
                    Setup();
                return _items;
            }
        }

        private void Setup()
        {
            _items = new Dictionary<string, string>();
            var currentAppSetting = cacheService.Get<List<ApplicationSetting>>("CurrentAppSetting");
            if (currentAppSetting == null)
            {
                currentAppSetting = applicationSettingRepository.GetPagedList().Items.ToList();
                cacheService.Set<IEnumerable<ApplicationSetting>>("CurrentAppSetting", currentAppSetting);
            }
            foreach (var appSetting in currentAppSetting)
            {

                _items.Add(appSetting.Key.ToLower(), appSetting.Value);

            }
        }

        private string GetSetting(string key)
        {
            return GetSetting(key);
        }



        public string GetTimeZone()
        {
            return GetSetting("TimeZoneId");
        }

        public string GetLogFolderPath()
        {
            return GetSetting("LogFolderPath");
        }

        public string GetViewFolderPath()
        {
            return GetSetting("ViewFolderPath");
        }


        public string GetSiteUrl()
        {
            return GetSetting("SiteUrl");
        }

        public string GetDefaultLanguage()
        {
            return GetSetting("DefaultLanguage");
        }


        public string GetEmailTemplateFolderPath()
        {
            return GetSetting("EmailTemplateFolderPath");
        }

        public string GetRootPath()
        {
            return GetSetting("RootPath");
        }

        public string GetImagesImportPath()
        {
            return GetSetting("ImagesImportPath");
        }

        public string GetImagesUrl()
        {
            return GetSetting("ImagesUrl");
        }

        //private static int maxRoomPrice = 0;


        public string GetLocalizeFolderPath()
        {
            return GetSetting("LocalizeFolderPath");
        }

        public string GetStringValue(string key)
        {
            return GetSetting(key);
        }


        public int GetIntValue(string key)
        {
            int value = 0;
            int.TryParse(GetStringValue(key), out value);
            return value;
        }

        public bool GetBoolValue(string key)
        {
            bool value = false;
            string _value = GetStringValue(key);
            switch (_value.ToLower())
            {
                case "1":
                case "true":

                    value = true;
                    break;
                case "0":
                case "false":
                    value = false;
                    break;

                default:
                    value = false;
                    break;
            }
            return value;
        }

        public AboutUsViewModel GetAboutUs()
        {
            AboutUsViewModel result = new AboutUsViewModel();
            AboutUs _model = aboutUsRepository.GetFirstOrDefault();
            result = Mapper.Map<AboutUsViewModel>(_model);
            return result;
        }

        public ContactUsViewModel GetContactUs()
        {
            ContactUsViewModel result = new ContactUsViewModel();
            ContactUs _model = contactUsRepository.GetFirstOrDefault();
            result = Mapper.Map<ContactUsViewModel>(_model);
            return result;
        }
    }
}
