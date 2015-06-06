using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerOrganizer.Data.Model
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        [DisplayName("Organization Name")]
        public string OrganizationName { get; set; }
        [DisplayName("Organization Picture")]
        public string OrganizationPicture { get; set; }
        [DisplayName("About Organization")]
        public string OrganizationAbout { get; set; }
        public virtual List<Event> Events { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string ApplicationUserId { get; set; }
       



    }
}
