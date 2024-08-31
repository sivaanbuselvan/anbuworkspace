using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using CrudOperations.Data_Access_layer;
using CrudOperations.Models;



namespace CrudOperations.Controllers
{
    public class userController : Controller
    {
        // GET: User
        public ActionResult SelectUser(int id)
        {
            return View();  
        }

        // GET: Usert/Details/5
        // used to select all the data from the database
        public ActionResult SelectAllUser(Model objectmodel)
        {
            LoginRepository repository = new LoginRepository();
            var userdata   =    repository.GetUsers();
            return View( userdata);
        }

        // GET: Usert/Create
        
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Usert/Create
        // it is used to insert a data to the table
        [HttpPost]
        public ActionResult CreateUser(Model objectmodel)
        {
            bool isInserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    LoginRepository loginrepository = new LoginRepository();
                    isInserted = loginrepository.AddUser(objectmodel);
                    if (isInserted == true)
                    {
                        TempData["SuccessMessage"] = "Data entered successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Data not entered ";
                    }
                    return RedirectToAction("DataBaseConnectionString");
                }
            }
            catch (Exception e1)
            {
                       TempData["ErrorMessage"] = e1.Message;
                       return View();
            }
            return View();

        }



        // GET: Usert/Edit/5
        public ActionResult EditUser(int id)
        {
            LoginRepository loginRepository = new LoginRepository();
            return View(loginRepository.GetUsers().Find(user => user.login_id == id));
           
        }
        // POST: Usert/Edit/5
        [HttpPost]
        public ActionResult EditUser(int id, Model objectmodel)
        {
            try
            {
                LoginRepository loginrepository = new LoginRepository();
                loginrepository.EditUser(objectmodel);
                return RedirectToAction("SelectAllUser");
            }
           
            catch
            {
                return View();
            }
        }

        // GET: Usert/Delete/5
        public ActionResult DeleteUser(int id)
        {
            try
            {
                LoginRepository loginrepository = new LoginRepository();
                if (loginrepository.DeleteUser(id))
                {
                    ViewBag.Message("data deleted successfully");
                }
                return RedirectToAction("SelectAllUser");
            }
            catch
            {
                return View();
            }

        }


        // POST: Usert/Delete/5
        [HttpPost]
        public ActionResult DeleteUser(int id, Model objectmodel)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
