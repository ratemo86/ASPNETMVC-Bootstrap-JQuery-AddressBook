using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVC_AddressBook.Models;
using ASPNETMVC_AddressBook.ViewModels;
namespace ASPNETMVC_AddressBook.Controllers
{
  public class AccountController : Controller
  {

    //Database: EF entities
    private IDCEntities IDCEntities = new IDCEntities();

   /// <summary>
   /// login view
   /// </summary>
   /// <returns></returns>
    public ActionResult Index()  {
       
      AccountViewModel accountViewModel = new AccountViewModel();
      accountViewModel.Account = new Account();
      return View("Index", accountViewModel);
      // return View("Index");
    }


    /// <summary>
    /// TODO: Logic to reset password
    /// </summary>
    /// <returns></returns>
    public ActionResult ResetPassword()
    {    
      return View("ResetPassword");
      // return View("Index");
    }

    /// <summary>
    /// TODO: Logic redirect user to request for new password
    /// </summary>
    /// <returns></returns>
    public ActionResult ForgotPassword()
    {

      return View("ForgotPassword");
      // return View("Index");
    }

    /// <summary>
    /// TODO: Logic to update existing user with new password
    /// </summary>
    /// <returns></returns>
    public ActionResult UpdateResetPassword()
    {     
      return View("Index");
    }


    /// <summary>
    /// Not implemented
    /// </summary>
    /// <returns></returns>
    public ActionResult RegisterNewUser()
    {
      return View("Index");
    }


    /// <summary>
    /// Update Acccount attributes other than password
    /// </summary>
    /// <returns></returns>
    public ActionResult UpdateUser()
    {
      return View("Index");
    }

    [HttpGet]
    public ActionResult Login()
    {
      AccountViewModel accountViewModel = new AccountViewModel();
      accountViewModel.Account = new Account();
      return View("Index", accountViewModel);
     
    }

    [HttpPost]
    public ActionResult Login(AccountViewModel accountViewModel)
    {
      Account existingAccount = IDCEntities.Accounts.Find(accountViewModel.Account.UserName);
      if (existingAccount != null)
      {
        Session["UserName"] = existingAccount.UserName;
        return Json(accountViewModel);
      }
      else
      {
        ViewBag.ErrorMessage = "This is a valid account";
        return View("Index");
      }

     // return View("Index");
    }

    [HttpPost]
    public ActionResult Register(AccountViewModel accountViewModel)
    {
      if(ModelState.IsValid)
      {
        // accountViewModel.Account.Password = PasswordHelper.ComputeHash(accountViewModel.Account.Password, "SHAH512", GetBytes("myDemoPass"));
        accountViewModel.Account.Password = PasswordHelper.sha256_hash(accountViewModel.Account.Password);
        IDCEntities.Accounts.Add(accountViewModel.Account);
        IDCEntities.SaveChanges();

        return RedirectToAction("Index");
      }else
      {
        return View("Register");
      }
     
    }

    [HttpGet]
    public ActionResult Register()
    {
     
      AccountViewModel accountViewModel = new AccountViewModel();
      accountViewModel.Account = new Account();
      return View("Register", accountViewModel);
    }

    [NonAction]
    private static byte[] GetBytes(string str)
    {
      byte[] bytes = new byte[str.Length * sizeof(char)];
      System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
      return bytes;

    }
  }
}
