using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BillingSystem.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using BillingSystem.Repository;
using Utility;

namespace BillingSystem.Controllers
{
    public class BillingController : Controller
    {
        //
        // GET: /Billing/
        BillingRepository _allBilling = new BillingRepository();
        public ActionResult Index()
        {
            var model = new BillingModels();
            model.Line = new BillingLineModels();
            return View(model);
        }

        public ActionResult GetClientDetails(long UniqueID = 0)
        {
            var clientList = _allBilling.GetClientDetailsByAll(0).Where(x => x.UniqueID == UniqueID).FirstOrDefault();
            return Json(clientList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PopulateBillingItems(BillingModels model)
        {
            if (model.BillLines == null)
            {
                model.BillLines = new List<BillingLineModels>();
            }
            var line = new BillingLineModels();
            line.DescriptionOfGoods = model.Line.DescriptionOfGoods;
            line.Description = model.Line.Description;
            line.HSNCode = model.Line.HSNCode;
            line.Quantity = model.Line.Quantity;
            line.Unit = model.Line.Unit;
            line.Rate = model.Line.Rate;
            model.BillLines.Add(line);
            return View("~/Views/Billing/PartialViews/_loadBillLinePartialView.cshtml", model);
        }

        public ActionResult loadBillingLinesView(BillingModels model)
        {
            if (model.BillLines == null)
            {
                model.BillLines = new List<BillingLineModels>();
            }
            model.BillLines.Add(new BillingLineModels() { DescriptionOfGoods = "", Description = "", HSNCode = "", Quantity = 0, Unit = "", Rate = 0 });
            return View("~/Views/Billing/PartialViews/_loadDynamicBillLinePartialView.cshtml", model);
        }

        public ActionResult loadBillingLinesEdit(BillingModels model)
        {
            var lines = _allBilling.BillingLineDetailsGetByAll(Convert.ToInt64(model.UniqueID));
            model.BillLines = lines;
            return View("~/Views/Billing/PartialViews/_loadDynamicBillLinePartialView.cshtml", model);
        }

        public ActionResult AddBillingDetails(BillingModels model)
        {
            model.IsActive = true;
            model.CreatedBy = SessionWrapper.User.UniqueID;
            var result = _allBilling.BillingDetailsInsertUpdateDelete(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewBills()
        {
            return View();
        }

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            var results = _allBilling.BillingDetailsGetByAll();
            return Json(results.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditingLinesRead(string UniqueID, [DataSourceRequest] DataSourceRequest request)
        {
            var lines = _allBilling.BillingLineDetailsGetByAll(Convert.ToInt64(UniqueID));
            return Json(lines.ToDataSourceResult(request));
        }

        public ActionResult PrintBill(long UniqueID)
        {
            var model = new BillingModels();
            model.UniqueID = UniqueID;
            return View(model);
        }

        public ActionResult loadBillTextDetailsPartial(string UniqueID = "0")
        {
            var bill = _allBilling.GetBillTextDetailsByUniqueID(Convert.ToInt64(UniqueID)).FirstOrDefault();
            bill.CompanyLogo = bill.CompanyLogo == null ? new byte[0] : bill.CompanyLogo;
            bill.BillLines = _allBilling.GetBillLineTextDetailsByUniqueID(bill.UniqueID);
            return View("~/Views/Billing/PartialViews/_viewBillDetailsForPrint.cshtml", bill);
        }

        public ActionResult CalculateTotalWordsValues(decimal Value)
        {
            var result = ConvertToWords(Convert.ToString(((decimal)(Value) * 9 / 100))) + "$" + ConvertToWords(Convert.ToString(((decimal)(Value) * 9 / 100))) + "$" + ConvertToWords(Convert.ToString(((decimal)(Value) * 18 / 100))) + "$" +
                ConvertToWords(Convert.ToString(Value)); ;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CalculateTotalValues(decimal Value)
        {
            var result = (decimal)(((decimal)(Value) * 9 / 100)) + "$" + (decimal)(((decimal)(Value) * 9 / 100)) + "$" + (decimal)(((decimal)(Value) * 18 / 100)) + "$" +
                Convert.ToDecimal(Value);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public static string NumberToText(int number, bool isUK)
        {
            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
            "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
            "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }


        private static String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "Only";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";// just to separate whole numbers from points/cents  
                        endStr = "Paisa " + endStr;//Cents  
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }
        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros
                        //if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }

        public ActionResult PopulateBillingDetailsForEdit(long UniqueID)
        {
            var results = _allBilling.BillingDetailsGetByAll().Where(x => x.UniqueID == UniqueID).FirstOrDefault();
            return View("~/Views/Billing/PartialViews/_editBilling.cshtml", results);
        }
    }
}
