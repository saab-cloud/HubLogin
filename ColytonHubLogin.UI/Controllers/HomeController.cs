using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ColytonHubLogin.UI.Models;
using ColytonHubLogin.UI.Models.Home;
using ColytonHubLogin.BusinessLayer;
using ColytonHubLogin.DataAccessLayer.Models;

namespace ColytonHubLogin.UI.Controllers
{
    public class HomeController : Controller
    {
        private LoginService _loginService;
        private bool flagSignOut;

        public HomeController(LoginService loginService)
        {
            _loginService = loginService;
            //flagSignOut = false;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SignInViewModel> signInVMList = new List<SignInViewModel>();
            var loginDets = _loginService.GetLoginDetails();
            foreach(var loginDet in loginDets)
            {
                SignInViewModel signInVM = new SignInViewModel();
                signInVM.Id = loginDet.Id;
                signInVM.FirstName = loginDet.FirstName;
                signInVM.LastName = loginDet.LastName;
                signInVM.CardNum = loginDet.CardNum;
                signInVM.Reason = loginDet.Reason;
                signInVM.SignInDateTime = loginDet.SignInDateTime;
                //if (flagSignOut == true)
                //{
                //    signInVM.FlagSignOut = true;
                //}
                signInVM.SignOutDateTime = loginDet.SignOutDateTime;
                signInVMList.Add(signInVM);
            }
            
            return View(signInVMList);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            SignInViewModel signInVM = new SignInViewModel();
            return View(signInVM);
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel signInVM)
        {
            if (ModelState.IsValid)
            {
                LoginDetail loginDet = new LoginDetail();
                loginDet.FirstName = signInVM.FirstName;
                loginDet.LastName = signInVM.LastName;
                loginDet.CardNum = signInVM.CardNum;
                loginDet.Reason = signInVM.Reason;
                if (signInVM.IsSignature == false)
                {
                    signInVM.ErrorSignature = "Please select Signature checkbox";
                    return View(signInVM);
                }
                else
                {
                    loginDet.Signature = signInVM.IsSignature;
                }
                
                loginDet.SignInDateTime = DateTime.Now;
                //loginDet.SignOutDateTime = null;
                _loginService.CreateLoginDet(loginDet);
                return RedirectToAction("Index");
            }
            
            return View(signInVM);
        }

        [HttpGet]
        public IActionResult SignOut(int id)
        {
            bool flagSOut = false;
            if (ModelState.IsValid)
            {

                flagSOut = _loginService.SignOutFromHub(id);
                //flagSignOut = true;
                return RedirectToAction("Index");
                

            }
            return View();
        }

        //[HttpGet]
        //public IActionResult SignOut()
        //{
        //    SignOutViewModel signOutVM = new SignOutViewModel();
        //    return View(signOutVM);
        //}

        //[HttpPost]
        //public IActionResult SignOut(SignOutViewModel signOutVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (signOutVM.CardNum.ToString().Equals("") || signOutVM.CardNum == 0)
        //        {
        //            signOutVM.ErrorStr = "Please enter Card Number";
        //            return View(signOutVM);
        //        }
        //        else
        //        {
        //            _loginService.SignOutFromHub(signOutVM.CardNum);
        //            return RedirectToAction("Index");
        //        }

        //    }
        //    return View(signOutVM);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
