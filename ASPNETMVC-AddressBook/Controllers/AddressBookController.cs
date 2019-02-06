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
  
  public class AddressBookController : AsyncController
  {
    private IDCEntities IDCEntities = new IDCEntities();
    // GET: AddressBook
    public ActionResult Index()
    {
      
      return View("Index");
    }


    [HttpGet]
    public JsonResult GetContacts()
    {
      List<Contact> contacts = GetAddressBookAsync().Result;

      return Json(contacts, JsonRequestBehavior.AllowGet);
    }


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
