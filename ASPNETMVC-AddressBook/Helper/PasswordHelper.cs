using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;


//namespace ASPNETMVC_AddressBook.Helper
namespace ASPNETMVC_AddressBook.Controllers
{
  public class PasswordHelper
  {
    public static String sha256_hash(String value)
    {
      using (SHA256 hash = SHA256Managed.Create())
      {
        return String.Concat(hash
          .ComputeHash(Encoding.UTF8.GetBytes(value))
          .Select(item => item.ToString("x2")));
      }
    }



    //public static string ComputeHash(string plainText, string hashAlgorithim, byte[] saltBytes)
    //{
    //  if (saltBytes == null)
    //  {

    //  }
    //  return "";
    //}
  }
}
