using BusinessLogic.Helpers.Painters;
using BusinessLogic.Services;
using PointInPolygon.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace PointInPolygon.Controllers
{
    public class HomeController : Controller
    {
        PolygonPainter _polygonPainter;
        PolygonService _polygonService;

        public HomeController()
        {
            _polygonService = PolygonService.GetInstance();
            _polygonPainter = new PolygonPainter();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePolygon(string polygonFileName)
        {
            ViewBag.PolygonFileName = polygonFileName;
            _polygonService.CreatePolygon();

            return View("Polygon");
        }

        public ActionResult CreatePolygonManually()
        {
            return View();
        }

        public ActionResult CheckPoint(PointViewModel point, bool isRandomPoint, string baseImageFileName)
        {
            bool result;
            Point pointToCheck;
            if (isRandomPoint)
                result = _polygonService.CheckPoint(out pointToCheck);

            else
            {
                pointToCheck = new Point(point.X, point.Y);
                result = _polygonService.CheckPoint(pointToCheck);
            }

            ViewBag.FileName = _polygonPainter.DrawPoint(pointToCheck, baseImageFileName);
            ViewBag.PointName = pointToCheck.ToString();

            return PartialView("_Result", result);
        }

        public ActionResult AddPoint(PointViewModel pointToAdd, string fileNameToDelete)
        {
            _polygonService.AddPoint(new Point(pointToAdd.X, pointToAdd.Y));
            var points = _polygonService.Points;
            string _fileName = _polygonPainter.DrawPolygonWhileCrating(points, fileNameToDelete);
            ViewBag.FileName = _fileName;
            return PartialView("_PointList", _polygonService.Points);
        }

        public ActionResult DeletePoint(PointViewModel pointToAdd, string fileNameToDelete)
        {
            _polygonService.DeletePoint();
            var points = _polygonService.Points;
            string _fileName = _polygonPainter.DrawPolygonWhileCrating(points, fileNameToDelete);
            ViewBag.FileName = _fileName;
            return PartialView("_PointList", _polygonService.Points);
        }
    }
}