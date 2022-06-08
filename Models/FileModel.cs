using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FileModel.Models
{
    public class FileModel
    {
        public String FileName { get; set; }

        public HttpPostedFileBase[] Files { get; set; } 

    }
}