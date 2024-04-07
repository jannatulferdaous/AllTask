using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace REST_API.Models
 
{
    public class Login
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
