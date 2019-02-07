using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVC_AddressBook.Models;
using ASPNETMVC_AddressBook.ViewModels;

namespace ASPNETMVC_AddressBook.Controllers
{
  /// <summary>
  /// Contains actions to maniplate Addressbook data
  /// </summary>
  [RoutePrefix("AddressBook")]
  public class AddressBookController : AsyncController
  {
    private IDCEntities IDCEntities = new IDCEntities();
    // GET: AddressBook

    [Route("Index")]
    public ActionResult Index()
    {
      //If user is not logged in or if session has expired
      if (Session["UserName"] == null)
      {
        return RedirectToAction("Index", "Account");
      }
      return View("Index");
    }


    [HttpGet]
   
    public JsonResult GetContacts()
    {
      List<Contact> contacts = GetAddressBookAsync().Result;

      return Json(contacts, JsonRequestBehavior.AllowGet);
    }


    //[HttpGet]
    
    //public Task<JsonResult> GetAddressBookContactsAsync()
    //{
    //  return Task.Factory.StartNew(() =>
    //  {
    //    List<Contact> contacts = GetAddressBookAsync().Result;
    //    return Json(contacts, JsonRequestBehavior.AllowGet);
    //  });     
    //}


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [NonAction]
    private Task<List<Contact>> GetAddressBookAsync()
    {
      return Task.Factory.StartNew(() =>
      {
        List<Contact> contacts = IDCEntities.Contacts.ToList();
        return contacts;
      });
    }
  }
}
