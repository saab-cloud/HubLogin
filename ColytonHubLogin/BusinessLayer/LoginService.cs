using ColytonHubLogin.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ColytonHubLogin.BusinessLayer
{
    public class LoginService
    {
        private LoginDBContext _context;

        public LoginService(LoginDBContext context)
        {
            _context = context;
        }

        public void CreateLoginDet(LoginDetail logDet)
        {
            _context.LoginDetails.Add(logDet);
            _context.SaveChanges();

        }

        public bool SignOutFromHub(int id)
        {
            //var loggedInDet = _context.LoginDetails.Where(c => (c.CardNum == cardNumber
            //                        && c.SignInDateTime.Date == DateTime.Now.Date)).FirstOrDefault();
            var loggedInDet = _context.LoginDetails.Where(c => c.Id == id).FirstOrDefault();
            loggedInDet.SignOutDateTime = DateTime.Now;
            _context.LoginDetails.Update(loggedInDet);
            _context.SaveChanges();
            return true;
        }

        public List<LoginDetail> GetLoginDetails()
        {
            var loginDetsToday = _context.LoginDetails.Where(c => c.SignInDateTime.Date == DateTime.Now.Date);
            return loginDetsToday.ToList();
            //return _context.LoginDetails;
        }
    }
}
