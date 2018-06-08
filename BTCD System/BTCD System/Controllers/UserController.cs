﻿using BTCD_System.BTCD_DL.User;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BTCD_System.Controllers
{
    public class UserController : Controller
    {
        clsU_User clsuser = new clsU_User();
        // GET: User
        [Authorize(Roles = "User - List")]
        public ActionResult Index()
        {
            List<UserU> lstEmsUser = clsuser.GetUserActiveAll();
            return View(lstEmsUser);
        }

        // GET: User/Details/5
        [Authorize(Roles = "User - Details")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        [Authorize(Roles = "User - Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserU users)
        {
            try
            {
                clsuser.createUser(users);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        [Authorize(Roles = "User - Edit")]
        public ActionResult Edit(int id)
        {
            UserU emsUserU = new UserU();
            emsUserU = clsuser.GetUserById(id);
            return View(emsUserU);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserU users)
        {
            try
            {
                clsuser.editUser(id, users);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/EditPassword/5
        [Authorize(Roles = "User - ChangePassword")]
        public ActionResult EditPassword(int id)
        {
            UserU emsUserU = new UserU();
            emsUserU = clsuser.GetUserById(id);
            return View(emsUserU);
        }

        // POST: User/EditPassword/5
        [HttpPost]
        public ActionResult EditPassword(int id, UserU users)
        {
            try
            {
                clsuser.changeUserPassword(id, users);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "User - User Roles")]
        public ActionResult UserRoles(int id, string username)
        {
            List<UserRoleTUview> emsUserRoles = new List<UserRoleTUview>();
            emsUserRoles = clsuser.getUserRoleByUserID(id);

            TempData["keyUser"] = username;
            TempData["userid"] = id;


            return View(emsUserRoles);


        }

        [Authorize(Roles = "User - User Roles")]
        public ActionResult AllRoles(string username)
        {
            List<UserRoleU> roles = clsuser.getRolesNotAssignedForUser(username);
            return PartialView(roles);

        }

        [Authorize(Roles = "User - User Roles Add")]
        public ActionResult AddUserRoles(string RoleID, string username, int userid)
        {
            try
            {
                clsuser.addUserRoleToUser(RoleID, username);

                return RedirectToAction("UserRoles", new { id = userid, username = username });
            }
            catch
            {
                return RedirectToAction("UserRoles", new { id = userid, username = username });
            }
        }


        [Authorize(Roles = "User - User Roles Delete")]
        public ActionResult DeleteUserRoles(string RoleID, string username, int userid)
        {
            try
            {
                clsuser.deleteUserRoleToUser(RoleID, username);

                return RedirectToAction("UserRoles", new { id = userid, username = username });
            }
            catch
            {
                return RedirectToAction("UserRoles", new { id = userid, username = username });
            }
        }
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
