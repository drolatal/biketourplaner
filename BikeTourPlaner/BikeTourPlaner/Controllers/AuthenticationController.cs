using BikeTourPlaner.Models;
using BikeTourPlaner.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Linq;

namespace BikeTourPlaner.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Logout()
        {
            ViewData["_LoggedInUId"] = null;
            ViewData["_LoggedInUNN"] = null;
            HttpContext.Session.Remove("_LoggedInUId");
            HttpContext.Session.Remove("_LoggedInUNN");

            return RedirectToAction("Index","Home");
        }

        public IActionResult Login(LoginUserMV lu) {
            if (ModelState.IsValid)
            {
                BikeTourData btd = new BikeTourData();
                var linq = btd.Creditentials.Where(e=>e.NickName == lu.NickName).ToList();
                if (!linq.IsNullOrEmpty() && linq.Count() == 1)
                {
                    if (linq[0].Password.Equals(lu.Password))
                    {
                        HttpContext.Session.SetString("_LoggedInUId", linq[0].Uid.ToString());
                        HttpContext.Session.SetString("_LoggedInUNN", linq[0].NickName); //UNN = User Nickname
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewData["_LoginError"] = "Failed to sign in! Unexisting user or wrong password!";
                    }
                }
                else {
                    ViewData["_LoginError"] = "Failed to sign in! Unexisting user or wrong password!";
                }
            }   
            return View(lu);
        }

        public IActionResult Register(RegisterUserMV ru)
        {
            if (ModelState.IsValid)
            {
                string nickName = ru.NickName;
                BikeTourData bikeTourData = new BikeTourData();
                var linq = bikeTourData.Creditentials.Where(e => e.NickName == nickName).Select(x=>x).ToList();
                if (linq.IsNullOrEmpty())
                {
                    string passWord = ru.Password;
                    Creditential nc = new Creditential();
                    nc.NickName = nickName;
                    nc.Password = passWord;
                    bikeTourData.Add<Creditential>(nc);
                    bikeTourData.SaveChanges();

                    Udatum nud = new Udatum();
                    nud.Uid = bikeTourData.Creditentials.Where(e => e.NickName == nickName).Select(x => x).ToList()[0].Uid;
                    nud.Name = ru.Name;
                    nud.Email = ru.Email;
                    nud.BirthDate = ru.BirthDate;
                    bikeTourData.Add<Udatum>(nud);
                    bikeTourData.SaveChanges();

                }
                else {
                    ViewData["_RegisterError"] = "Failed to register!Already existing Nickname!";
                }

                return RedirectToAction("Index", "Home");
            }
            return View(ru);
        }
    }
}
