using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DAH_FIMS.Services
{
    public class FileUpload:IFileUpload
    {
        private readonly IWebHostEnvironment _environment;
        public FileUpload (IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task UploadAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "Upload", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file=new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
             
        }
    }
}
