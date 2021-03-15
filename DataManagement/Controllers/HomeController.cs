using DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.QueryProcessor;

namespace DataManagement.Controllers
{
    public class HomeController : Controller
    {

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

        public ActionResult ViewUser()
        {
            ViewBag.Message = "User List";

            var data = LoadUser();
            List<UsersModel> listuser = new List<UsersModel>();

            foreach (var row in data)
            {
                listuser.Add(new UsersModel
                {
                    Id = row.Id,
                    User_ID = row.User_ID,
                    UserName = row.UserName,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    MiddleName = row.MiddleName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                });
            }

            return View(listuser);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UsersModel model)
        {
            var data = LoadUser();
            var dataID = data.FirstOrDefault(i => i.User_ID == model.User_ID);
            var dataUN = data.FirstOrDefault(i => i.UserName == model.UserName);
            var dataED = data.FirstOrDefault(i => i.EmailAddress == model.EmailAddress);

            string iid ="", uun ="", eed ="";

            if (dataID != null)
            {
                iid = "*Your user id is already exist <br />";
            }

            if(dataUN != null)
            {
                uun = "*Your username is already exist <br />";
            }

            if (dataED != null)
            {
                eed = "*Your username is already exist <br />";
            }

            ViewBag.Message = iid + uun + eed;

            if (dataID == null && dataUN == null && dataED == null)
            {

                if (ModelState.IsValid)
                {
                    int recordsCreated = CreateUsers(model.User_ID,
                        model.UserName,
                        model.FirstName,
                        model.LastName,
                        model.MiddleName,
                        model.EmailAddress,
                        model.UserPassword);

                    Variables.warning = "success";

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public ActionResult SaveEditInfo(int id)
        {
            DataLibrary.Models.Variables.UID = id;

            var data = LoadUser();
            var model = new UsersModel();

            var dataID = data.FirstOrDefault(i => i.Id == id);

                model.User_ID = dataID.User_ID;
                model.UserName = dataID.UserName;
                model.FirstName = dataID.FirstName;
                model.LastName = dataID.LastName;
                model.MiddleName = dataID.MiddleName;
                model.EmailAddress = dataID.EmailAddress;
                model.ConfirmEmail = dataID.EmailAddress;

            Usernum = dataID.User_ID;
            strusername = dataID.UserName;
            stremail = dataID.EmailAddress;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEditInfo( UsersModel model)
        {
            var data = LoadUser();
            string iid = "", uun = "", eed = "";
            var dataID = data.FirstOrDefault(i => i.User_ID == model.User_ID);
            var dataUN = data.FirstOrDefault(i => i.UserName == model.UserName);
            var dataED = data.FirstOrDefault(i => i.EmailAddress == model.EmailAddress);

            if (dataID != null)
            {
                if(dataID.User_ID == Usernum)
                {
                    dataID = null;
                }
                else
                {
                    iid = "*Your new user id is already exist on other's account <br />";
                }
            }

            if (dataUN != null)
            {
                if (dataUN.UserName == strusername)
                {
                    dataUN = null;
                }
                else
                {
                    uun = "*Your new user id is already exist on other's account <br />";
                }
            }

            if (dataED != null)
            {
                if (dataED.EmailAddress == stremail)
                {
                    dataED = null;
                }
                else
                {
                    eed = "*Your new user id is already exist on other's account <br />";
                }
            }

            ViewBag.Message = iid + uun + eed;

            if (dataID == null && dataUN == null && dataED == null)
            {
                if (ModelState.IsValid)
                {
                    int recordsEdited = EditAccount(
                        model.User_ID,
                        model.UserName,
                        model.FirstName,
                        model.LastName,
                        model.MiddleName,
                        model.EmailAddress,
                        model.UserPassword);
                    return RedirectToAction("ViewUser");
                }
            }

            return View();
        }



        public ActionResult DeleteInfo(int id)
        {
            DataLibrary.Models.Variables.UID = id;


            ViewBag.Message = "Delete List";

            DeleteUser();

            return RedirectToAction(nameof(ViewUser));
        }



    }
}