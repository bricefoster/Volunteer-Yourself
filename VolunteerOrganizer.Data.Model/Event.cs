using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerOrganizer.Data.Model
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [DisplayName("Event Name")]
        public string EventName { get; set; }
        public string About { get; set; }
        public string Date { get; set; }
        [DisplayName("Start Time")]
        public string StartTime { get; set; }
        [DisplayName("End Time")]
        public string EndTime { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }
        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }
        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }
        public string Info { get; set; }
        public bool IsDeleted { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ApplicationUser user { get; set; }
     
       

    }
}
