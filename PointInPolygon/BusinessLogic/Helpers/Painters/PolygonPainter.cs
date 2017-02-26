using BusinessLogic.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace BusinessLogic.Helpers.Painters
{
    public class PolygonPainter
    {
        static IList<string> _filePathToDeleteList = new List<string>();

        public string DrawPolygonWhileCrating(IEnumerable<Point> polygonVertices, string FileNameToDelete)
        {
            var pen = new Pen(Color.Green);

            if (polygonVertices == null || polygonVertices.Count() <= 0)
                return PolygonPainterSettings.BaseImageFileName;
            else if (polygonVertices.Count() == 1)
            {
                var point = polygonVertices.FirstOrDefault();
                return BaseDrawPoint(point, pen, Folder.CreatingPolygon, PolygonPainterSettings.BaseImageFilePath);
            }
            else if (polygonVertices.Count() == 2)
            {
                return BaseDrawLine(polygonVertices, pen, Folder.CreatingPolygon, PolygonPainterSettings.BaseImageFilePath);
            }
            else
                return BaseDrawPolygon(polygonVertices, pen, Folder.CreatingPolygon, PolygonPainterSettings.BaseImageFilePath);

        }

        string BaseDrawPolygon(IEnumerable<Point> polygonVertices, Pen pen, Folder folderToSave, string filePathToChange)
        {
            var fileName = GetRandomFileName();
            var filePath = GetFilePath(folderToSave, fileName);
            _filePathToDeleteList.Add(filePath);
            using (Bitmap image = new Bitmap(filePathToChange))
            {
                using (Graphics graphic = Graphics.FromImage(image))
                {
                    graphic.SmoothingMode = SmoothingMode.AntiAlias;
                    graphic.DrawPolygon(pen, polygonVertices.ToArray());
                }
                image.Save(filePath, ImageFormat.Png);
            }
            return fileName;
        }
        
        public string DrawPoint(Point point, string fileNameToChange)
        {
            var filePathToChange = GetFilePath(Folder.CreatingPolygon, fileNameToChange);
            var pen = new Pen(Color.Red);
            DeleteAllImages(filePathToChange);

            return BaseDrawPoint(point, pen, Folder.PolygonWithPoint, filePathToChange);
            
        }

        string BaseDrawPoint(Point point, Pen pen, Folder folderToSave, string filePathToChange)
        {
            var fileName = GetRandomFileName();
            var filePath = GetFilePath(folderToSave, fileName);
            _filePathToDeleteList.Add(filePath);
            using (Bitmap image = new Bitmap(filePathToChange))
            {
                using (Graphics graphic = Graphics.FromImage(image))
                {
                    graphic.DrawRectangle(pen, point.X, point.Y, 1, 1);
                }

                image.Save(filePath, ImageFormat.Png);
            }
            return fileName;
        }

        string BaseDrawLine(IEnumerable<Point> points, Pen pen, Folder folderToSave, string filePathToChange)
        {
            var fileName = GetRandomFileName();
            var filePath = GetFilePath(folderToSave, fileName);
            _filePathToDeleteList.Add(filePath);
            var point1 = points.FirstOrDefault();
            var point2 = points.LastOrDefault();
            using (Bitmap image = new Bitmap(filePathToChange))
            {
                using (Graphics graphic = Graphics.FromImage(image))
                {
                    graphic.SmoothingMode = SmoothingMode.AntiAlias;
                    graphic.DrawLine(pen, point1, point2);
                }
                image.Save(filePath, ImageFormat.Png);
            }
            return fileName;
        }

        void DeleteImage(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        void DeleteAllImages()
        {
            foreach (var filePath in _filePathToDeleteList)
            {
                DeleteImage(filePath);
            }
            _filePathToDeleteList.Clear();
        }

        void DeleteAllImages(string exceptFilePath)
        {
            if (_filePathToDeleteList.Contains(exceptFilePath))
                _filePathToDeleteList.Remove(exceptFilePath);

            DeleteAllImages();
        }

        string GetFilePath(Folder folder, string fileName)
        {
            return HostingEnvironment.MapPath(PolygonPainterSettings.FilePath + folder + "/" + fileName);
        }

        string GetRandomFileName()
        {
            return Guid.NewGuid() + PolygonPainterSettings.FileExtention;
        }
    }
}
