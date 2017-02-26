using BusinessLogic.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace BusinessLogic.Helpers.Painters
{
    public static class PolygonPainterSettings
    {
        const int marginPoint = 10;

        public static int MinNumberOfVertices { get; } = 3;

        public static string FileExtention { get; } = ".png";
        public static string BaseImageFilePath { get; } = HostingEnvironment.MapPath("~/images/Base/BaseImage.png");
        public static string BaseImageFileName { get; } = "BaseImage.png";
        public static string FilePath { get; } = "~/images/";

        public static int ImageSize0X { get; } = 320;
        public static int ImageSize0Y { get; } = 240;

        public static int ImageSize0XForPoint { get { return ImageSize0X - marginPoint; } }
        public static int ImageSize0YForPoint { get { return ImageSize0Y - marginPoint; } }

        public static string GetFullFileName(Folder folder, string fileName)
        {
            return HostingEnvironment.MapPath(FilePath + folder + fileName + FileExtention);
        }
        

    }
}
