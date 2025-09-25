using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.UnitOfWork;
using DataLayer.Interfaces;
using DataLayer.Context;
using DataLayer.Repository;
using System.Runtime.Caching;
using System.Threading.Tasks;
using DataLayer.Models;

namespace CosmeticsStore.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly ObjectCache _cache = MemoryCache.Default;
        private const string CacheKey = "CategoriesTree";
        private MyProjectContext db = new MyProjectContext();

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(db);

        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Category(int section = 0)
        {
            ViewBag.Section = section;
            if (_cache.Contains(CacheKey))
            {
                return View(_cache.Get(CacheKey) as IEnumerable<Category>);
            }


            var categories = Task.Run(async () => await _unitOfWork.Categories.GetCategoryTreeAsync()).Result;
            var cachePolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(30)
            };

            _cache.Add(CacheKey, categories, cachePolicy);

            return View(_cache.Get(CacheKey) as IEnumerable<Category>);
        }

    }
}