using ASPNETMVC_AddressBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNETMVC_AddressBook.Models
{
  public class AccountViewModel
  {
    public Account Account { get; set; }
  }

  [MetadataType(typeof(AccountMetaData))]
  public partial class Account
  {
    
  }

  public partial class AccountMetaData
  {
    [Display(Name = "Use Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required")]
    [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
    public string UserName { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
    public string Password { get; set; }

    [Display(Name = "Email")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
    public string Email { get; set; }
    [Display(Name = "First Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
    public string LastName { get; set; }
    //public bool IsAdminUser { get; set; }
  }
}
