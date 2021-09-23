using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Common
{
    public static class HelperClass
    {
        public static byte[] PostedImageToByte(HttpPostedFileBase image)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(image.InputStream))
            {
                bytes = br.ReadBytes(image.ContentLength);
            }
            return (bytes);
        }

        public static string GetFileName(HttpPostedFileBase image)
        {
            string FileName = Path.GetFileNameWithoutExtension(image.FileName);
            string FileExtension = Path.GetExtension(image.FileName);
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            return FileName;
        }

        //public static void GenericValidaitonChecks(string testItem, ModelStateDictionary ModelState)
        //{
        //    if (String.IsNullOrEmpty(testItem))
        //    {
        //        return new ModelState.AddModelError(nameof(testItem), "The {0} field is required");
        //    }
            
        //    if (testItem.Length <= 100)
        //    {
        //        return new ModelState.AddModelError(nameof(testItem), "The {0} filed has too many characters");
        //    }
        //}









    }
}