using Package.Core.Domain.Media;
using Package.EntityFrameworkCore;
using Package.EntityFrameworkCore.EF;
using Package.Service.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Package.Service.Media
{
    public class PictureService : BaseService<Picture>, IPictureService
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Picture> Repository;
        private readonly IApplicationSettingService applicationSettingsService;
        private string absolutePath;
        private int folderCountLimit = 250;
        private int[] importLevel = { 0, 0 };

        public PictureService(IRepository<Picture> repository,IApplicationSettingService _applicationSettingsService) : base(repository)
        {
            Repository = repository;
            applicationSettingsService = _applicationSettingsService;

        }
        public void DeleteNotUsedPictures()
        {
            for (var i = 0; i < folderCountLimit; i++)
            {
                for (var j = 0; j < folderCountLimit; j++)
                {
                    var childPath = Path.Combine(absolutePath, i.ToString(), j.ToString());
                    var relPath = "/" + i + "/" + j + "/";
                    var records = Repository.GetPagedList(predicate: x => x.RelativePath == relPath).Items.ToList();
                    var existingFiles = Directory.GetFiles(childPath, "*", SearchOption.TopDirectoryOnly);

                    foreach (var existingFile in existingFiles)
                    {
                        var filename = Path.GetFileNameWithoutExtension(existingFile);
                        if (records.FirstOrDefault(x => x.FileName == filename || x.ThumbnailFileName == filename) == null) //File is unused
                        {
                            File.Delete(existingFile);
                        }
                    }
                }
            }
        }

        public void Initialize()
        {
            CheckBasePathExists();
            var startingPointSet = false;

            for (var i = 0; i < folderCountLimit; i++)
            {
                var path = Path.Combine(absolutePath, i.ToString());
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                for (var j = 0; j < folderCountLimit; j++)
                {
                    var childPath = Path.Combine(absolutePath, i.ToString(), j.ToString());
                    if (!Directory.Exists(childPath))
                    {
                        Directory.CreateDirectory(childPath);
                    }

                    if (Directory.GetFiles(childPath, "*", SearchOption.TopDirectoryOnly).Length < folderCountLimit && !startingPointSet)
                    {
                        importLevel[0] = i;
                        importLevel[1] = j;
                        startingPointSet = true;
                    }
                }
            }
        }


        public void ImportToLocal(out bool importingFinished, ref int lastId)
        {
            var id = lastId;
            var records = Repository.GetPagedList(predicate: x => x.RelativePath == null && x.Id > id, orderBy: Repository<Picture>.GetOrderBy("Id", "asc")).Items.Take(5);

            if (!records.Any())
            {
                importingFinished = true;
                return;
            }

            var webClient = new WebClient();

            foreach (var record in records)
            {

                lastId = record.Id;

                var localFileName = Guid.NewGuid().ToString();
                var thumbnailFilename = GetThumbnailFileName(localFileName);

                var dir = Path.Combine(absolutePath, importLevel[0].ToString(), importLevel[1].ToString());

                while (Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly).Length >= folderCountLimit)
                {
                    importLevel[1]++;
                    if (importLevel[1] >= folderCountLimit)
                    {
                        importLevel[0]++;
                        importLevel[1] = 0;
                    }

                    dir = Path.Combine(absolutePath, importLevel[0].ToString(), importLevel[1].ToString());
                }


                var filePath = GetFullPath(localFileName, importLevel);
                var thumbnailPath = GetFullPath(thumbnailFilename, importLevel);

                webClient.DownloadFile(record.Url, filePath);
                webClient.DownloadFile(record.ThumbnailUrl, thumbnailPath);

                record.ThumbnailFileName = thumbnailFilename;
                record.FileName = localFileName;
                record.RelativePath = "/" + importLevel[0] + "/" + importLevel[1] + "/";
            }

            Update(records);

            importingFinished = false;
        }

        public string GetFullPath(string fileName, int[] level)
        {
            return applicationSettingsService.GetImagesImportPath() + "/" + level[0] + "/" + level[1] + "/" + fileName + ".jpg";
        }

        public string GetThumbnailFileName(string fileName)
        {
            return fileName + "-Th";
        }

        public string GetImageUrl(Picture picture)
        {
            if (!string.IsNullOrEmpty(picture.FileName) && !string.IsNullOrEmpty(picture.RelativePath))
            {
                return applicationSettingsService.GetImagesUrl() + picture.RelativePath + picture.FileName + ".jpg";
            }
            else
            {
                //InsertImage()
                return picture.Url;
            }
        }

        public string GetThumbnailImageUrl(Picture picture)
        {
            if (!string.IsNullOrEmpty(picture.FileName) && !string.IsNullOrEmpty(picture.RelativePath))
            {
                return applicationSettingsService.GetImagesUrl() + picture.RelativePath + GetThumbnailFileName(picture.FileName) + ".jpg";
            }
            else
            {
                return picture.ThumbnailUrl;
            }
        }

        private void CheckBasePathExists()
        {
            var imagesFolderPath = applicationSettingsService.GetImagesImportPath();
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }
        }

        public IEnumerable<Picture> Get(Expression<Func<Picture, bool>> p)
        {
            return base.Repository.GetPagedList(predicate: p).Items;
        }
    }
}
