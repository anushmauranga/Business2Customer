﻿using BTCD_System.BTCD_DL.Master;
using BTCD_System.BTCD_DL.Transaction;
using BTCD_System.Common;
using BTCD_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTCD_System.Controllers
{
    public class RequestController : Controller
    {
        private clsT_Stock clsT_Stock = new clsT_Stock();
        private List<StockM> lstStock;
        private StockM Stock;


        private List<SelectListItem> ListItem;
        private List<LocationM> lstLocation;
        private List<ItemGradeM> lstItemGrade;
        private List<UnitofMeasurementM> lstUnitofMeasurement;


        private string RequestNo = "";
        private string ErrorMsg = "";

        // GET: Request
        [HttpPost]
        public ActionResult Create(int StockId)
        {
            
            Stock = new clsT_Stock().GetStockDetailByStockId(StockId);

            ViewBag.Location = getLocation();
            ViewBag.Grade = GetItemGrade(Stock.ItemId);
            ViewBag.UOM = getUOM();

            return View(Stock);
        }


        [HttpPost]
        public ActionResult SaveRequest()
        {
            StockM stock = new StockM();

            TryUpdateModel(stock);

            if (ModelState.IsValid)
            {
                stock.UserCode = commonFunctions.GetTransactionUserCode();

                ErrorMsg = clsT_Stock.SaveStock(stock, out RequestNo);


                if (!string.IsNullOrEmpty(ErrorMsg))
                {
                    TempData["Message"] = new MessageBox { CssClassName = ".alert-danger", Title = "Error!", Message = "Transaction was rollback.Try again." };

                    ViewBag.Location = getLocation();
                    ViewBag.Grade = GetItemGrade(stock.ItemId);
                    ViewBag.UOM = getUOM();

                    return View(stock);
                }
                else
                {

                    ViewBag.Location = getLocation();
                    ViewBag.Grade = GetItemGrade(stock.ItemId);
                    ViewBag.UOM = getUOM();

                    TempData["Message"] = new MessageBox { CssClassName = ".alert-success", Title = "Success!", Message = "Your Request No: " + RequestNo };

                    return RedirectToAction("Create", stock.StockId);
                }
            }

            return View();

        }



        [NonAction]
        private List<SelectListItem> getLocation(string SelectedItem = null, string DisabledItem = null)
        {
            ListItem = new List<SelectListItem>();
            lstLocation = new clsM_Location().GetAllLocations();

            foreach (LocationM Location in lstLocation)
            {
                ListItem.Add(new SelectListItem { Value = Location.LocationId.ToString(), Text = Location.LocationName, Selected = Location.LocationId.ToString() == SelectedItem ? true : false, Disabled = Location.LocationId.ToString() == DisabledItem ? true : false });

            }

            return ListItem;
        }


        [NonAction]
        private List<SelectListItem> GetItemGrade(int ItemId)
        {
            ListItem = new List<SelectListItem>();
            lstItemGrade = new clsM_Grade().GetItemGradeByItemId(ItemId);

            foreach (ItemGradeM ItemGrade in lstItemGrade)
            {
                ListItem.Add(new SelectListItem { Value = ItemGrade.GradeId.ToString(), Text = ItemGrade.GradeDescription });

            }

            return ListItem;
        }

        [NonAction]
        private List<SelectListItem> getUOM(string SelectedItem = null, string DisabledItem = null)
        {
            ListItem = new List<SelectListItem>();
            lstUnitofMeasurement = new clsM_UOM().GetAllUnitofMeasurement();

            foreach (UnitofMeasurementM UnitofMeasurement in lstUnitofMeasurement)
            {
                ListItem.Add(new SelectListItem { Value = UnitofMeasurement.UOMId.ToString(), Text = UnitofMeasurement.UOMName, Selected = UnitofMeasurement.UOMId.ToString() == SelectedItem ? true : false, Disabled = UnitofMeasurement.UOMId.ToString() == DisabledItem ? true : false });

            }

            return ListItem;
        }
    }
}