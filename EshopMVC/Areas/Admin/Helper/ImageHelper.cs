using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EshopMVC.Areas.Admin.Helper
{
    public class ImageHelper
    {
        public string GetImage(HttpPostedFileBase file)
        {
            string ImageName = Path.GetFileName(file.FileName);
            string FolderPath = HttpContext.Current.Server.MapPath("~/Content/Image/" + ImageName);
            file.SaveAs(FolderPath);
            return ImageName;
        }
    }
}