using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerOrganizer.Data.Model;

namespace VolunteerOrganizer.Adapter.Interfaces
{
    public interface IOrganizationAdapter
    {
        List<Organization> GetAllOrganizations();
     
        List<Organization> GetOrganizations(string id);
        Organization GetMyOrganization(int id);
        void EditOrganization(string id, Organization organization);
        List<User_Event> GetVolunteers(int id);
    }
}
