using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerOrganizer.Data.Model
{
    public class User_Event
    {
        [Key]
        public int User_EventId { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser user { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }


        

      

    }
}
