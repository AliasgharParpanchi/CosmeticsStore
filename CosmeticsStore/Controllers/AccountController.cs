using CosmeticsStore.Utilitis;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CosmeticsStore.Controllers
{
    public class AccountController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private MyProjectContext db = new MyProjectContext();

        public AccountController()
        {
            _unitOfWork = new UnitOfWork(db);
        }
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Check(User model)
        {
            if (ModelState.IsValidField("Email"))
            {
                var users = _unitOfWork.Users.GetByEmail(model.Email);

                if (users == null)
                {
                    return View("Register", model);
                }
                else
                {
                    return View("Login", model);
                }
            }

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User model)
        {
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                try
                {
                    // تنظیم مقادیر پیش‌فرض
                    model.RegistrationDate = DateTime.Now;
                    model.IsAdmin = false; // کاربر عادی

                    // Hash کردن رمز عبور
                    model.Password = PasswordHelper.HashPassword(model.Password);

                    // ذخیره در دیتابیس
                    _unitOfWork.BeginTransaction();

                    // اضافه کردن کاربر
                    _unitOfWork.Users.Add(model);

                    // ذخیره تغییرات
                    await _unitOfWork.CompleteAsync();

                    // تایید تراکنش
                    _unitOfWork.CommitTransaction();

                    //// لاگین خودکار پس از ثبت‌نام
                    AutoLogin(model);

                    TempData["SuccessMessage"] = "ثبت‌نام با موفقیت انجام شد";
                    return RedirectToAction("Index", "Home");
                }
                catch
                {

                }
            }
            return View(model);
        }

        // متد کمکی برای لاگین خودکار
        private void AutoLogin(User user)
        {
            // ایجاد authentication cookie
            FormsAuthentication.SetAuthCookie(user.Email, false);

            // ذخیره اطلاعات در Session
            Session["UserId"] = user.UserId;
            Session["Email"] = user.Email;
            Session["IsAdmin"] = user.IsAdmin;
            Session["FullName"] = $"{user.FirstName} {user.LastName}";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User model)
        {
            var hashedPassword = PasswordHelper.HashPassword(model.Password);
            var user = await _unitOfWork.Users.GetUserByCredentialsAsync(model.Email, hashedPassword);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                // ذخیره اطلاعات در Session
                Session["UserId"] = user.UserId;
                Session["Email"] = user.Email;
                Session["IsAdmin"] = user.IsAdmin;
                Session["FullName"] = $"{user.FirstName} {user.LastName}";

                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.Error = "رمز عبور مطابقت ندارد";
            }

            return View(model);
        }
    }
}