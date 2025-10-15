using CosmeticsStore.Utilitis;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CosmeticsStore.Areas.Admin.Controllers
{
    [CustomAuthorize(Admin = true)]
    public class AdminDashboardController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private MyProjectContext db = new MyProjectContext();
        private PersianDate _persianDate = new PersianDate();

        public AdminDashboardController()
        {
            _unitOfWork = new UnitOfWork(db);
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageOrder()
        {
            var PersianYearRange = _persianDate.GetPersianYearRange();
            ViewBag.AllOrderCount = Task.Run(async () => await _unitOfWork.Orders.GetAllOrdersCountAsync()).Result;
            ViewBag.PaidOrderCount = Task.Run(async () => await _unitOfWork.Orders.GetPaidOrdersCountAsync()).Result;
            ViewBag.ProccessOrderCount = Task.Run(async () => await _unitOfWork.Orders.GetProccessOrdersCountAsync()).Result;
            ViewBag.SentOrderCount = Task.Run(async () => await _unitOfWork.Orders.GetSentOrdersCountAsync()).Result;
            ViewBag.Chart = Task.Run( async () => await _unitOfWork.Orders.GetOrderCountPerMonthAsync(PersianYearRange.start, PersianYearRange.end)).Result.ToList();
            return PartialView();
        }

        public ActionResult Order()
        {
            var model = Task.Run(async () => await _unitOfWork.Orders.GetLastOrderAsync(5)).Result;
            return PartialView(model);
        }

        public ActionResult Product()
        {
            var model = Task.Run(async () => await _unitOfWork.Products.GetLastProductRegisterAsync(5)).Result;
            return PartialView(model);
        }

        public ActionResult Users()
        {
            var model = Task.Run(async () => await _unitOfWork.Users.GetLastRegisterUserAsync(5)).Result;
            return PartialView(model);
        }
    }
}