using BTCD_System.BTCD_DL.Master;
using BTCD_System.Common;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTCD_System.Controllers
{
    public class EmployeeController : Controller
    {
        private List<SelectListItem> ListItem;
        private List<BankM> lstBank;
        private List<BankBranchM> lstBankBranch;
        private List<AutoComplete> lstAutoComplete;

        // GET: Employee
        public ActionResult Create()
        {
            ViewBag.Bank = getBank();

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            EmployeeM Employee = new EmployeeM();

            TryUpdateModel(Employee);

            if (ModelState.IsValid)
            {

            }

            return View();
        }


        [NonAction]
        private List<SelectListItem> getBank(string SelectedItem = null, string DisabledItem = null)
        {
            ListItem = new List<SelectListItem>();
            lstBank = new clsM_Bank().GetAllBanks();

            foreach (BankM Bank in lstBank)
            {
                ListItem.Add(new SelectListItem { Value = Bank.BankCode.ToString(), Text = Bank.BankName, Selected = Bank.BankCode.ToString() == SelectedItem ? true : false, Disabled = Bank.BankCode.ToString() == DisabledItem ? true : false });

            }

            return ListItem;
        }


        [HttpPost]
        public JsonResult getBankBranch(string BankCode)
        {
            lstAutoComplete = new clsM_Bank().GetBranchInBank(BankCode);

            return Json(lstAutoComplete);
        }
    }
}