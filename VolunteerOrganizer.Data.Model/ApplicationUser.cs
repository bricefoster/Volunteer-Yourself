using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerOrganizer.Data.Model
{
    public class ApplicationUser : IdentityUser
    {
         [DisplayName("First Name")]
        public string FirstName { get; set; }
         [DisplayName("Last Name")]
        public string LastName { get; set; }
         [DisplayName("Contact Number")]
        public string ContactNumber { get; set;}
         [Required]
         [Display(Name = "Type of User")]
         public string TypeOfUser { get; set; }


      
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
