using System;
using System.Linq;
using System.Web.Mvc;
using WorldPayDotNet.Common;
using WorldPayDotNet.Hosted;
using PolleySport.Models;
using System.Configuration;
using System.Web;

namespace PolleySport.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    public class CheckoutController : Controller
    {
        PolleySportEntities storeDB = new PolleySportEntities();
        const string PromoCode = "FREE";

        #region -- Global Properties --
        private static int _installationId;
   
        private decimal _FeeTotal;
        #endregion --

        //Retrieve the InstallationID, MD5SecretKey and SiteBaseURL values from the web.config
        int installationID = _installationId;
        string MD5secretKey = ConfigurationManager.AppSettings["MD5secretKey"];
        string WebsiteURL = ConfigurationManager.AppSettings["WebsiteURL"];

        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {

                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();

                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    ProcessTransaction(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

        //
        // POST: /WorldPay/API

        public void ProcessTransaction(Order order)
        {
            HostedTransactionRequest PRequest = new HostedTransactionRequest();

            PRequest.instId = installationID;
            //amount - A decimal number giving the cost of the purchase in terms of the major currency unit e.g. 12.56
            PRequest.amount = (double)order.Total;  //450.00;
            //cartId - If your system has created a unique order/cart ID, enter it here.
            PRequest.cartId = Guid.NewGuid().ToString();
            //desc - enter the description for this order.
            PRequest.desc = "Test Order from my .net site word";
            //currency - 3 letter ISO code for the currency of this payment.
            PRequest.currency = "GBP";
            //If passing delivery details, set withDelivery = true.
            PRequest.withDelivery = false;
            //name, address1/2/3, town, region, postcode & country - Billing address fields
            PRequest.name = order.FirstName + ' ' + order.LastName;
            PRequest.address1 = TxtAddress1.Text;
            PRequest.address2 = TxtAddress2.Text;
            PRequest.address3 = TxtAddress3.Text;
            PRequest.town = order.Town;
            PRequest.region = order.County;
            PRequest.postcode = order.PostalCode;
            PRequest.country = order.Country;
            //tel - Shopper's telephone number
            PRequest.tel = order.Phone;
            //fax - Shopper's fax number
            //PRequest.fax = TxtFax.Text;
            //email - Shopper's email address
            PRequest.email = order.Email;
            //If passing delivery details, set withDelivery = true.
            PRequest.withDelivery = false;
            //delvName, delvAddress1/2/3, delvTown, delvRegion, delvPostcode & delvCountry - Delivery address fields (NOTE: do not need to be passed/set if "withDelivery" set to false.
            //PRequest.delvName = TxtdelvName.Text;
            //PRequest.delvAddress1 = TxtdelvAddress1.Text;
            //PRequest.delvAddress2 = TxtdelvAddress2.Text;
            //PRequest.delvAddress3 = TxtdelvAddress3.Text;
            //PRequest.delvTown = TxtdelvTown.Text;
            //PRequest.delvRegion = TxtdelvRegion.Text;
            //PRequest.delvPostcode = TxtdelvPostcode.Text;
            //PRequest.delvCountry = DdldelvCountry.SelectedValue;
            //authMode - set to TransactionType.A for Authorise & Capture, set to TransactionType.E for Pre-Auth Only.
            PRequest.authMode = TransactionType.A;
            //testMode - set to 0 for Live Mode, set to 100 for Test Mode.
            PRequest.testMode = 100;
            //hideCurrency - Set to true to hide currency drop down on the hosted payment page.
            PRequest.hideCurrency = true;
            //fixContact - Set to true to stop a shopper from changing their billing/shipping addresses on the hosted payment page.
            PRequest.fixContact = true;
            //hideContact - set to true to hide the billing/shipping address fields on the hosted payment page.
            PRequest.hideContact = false;
            //MC_callback - the URL of the Callback.aspx file. SiteBaseURL is set in the web.config file.
            PRequest.MC_callback = WebsiteURL + "/Callback.aspx";

            HttpContext httpa = default(HttpContext);
            //httpa = HttpContext.Current;
            httpa = System.Web.HttpContext.Current;
            HostedPaymentProcessor process = new HostedPaymentProcessor(httpa);
            process.SubmitTransaction(PRequest, MD5secretKey);
        }
    }
}
