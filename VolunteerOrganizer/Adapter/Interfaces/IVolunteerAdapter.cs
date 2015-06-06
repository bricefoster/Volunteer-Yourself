using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerOrganizer.Data.Model;

namespace VolunteerOrganizer.Adapter.Interfaces
{
    public interface IVolunteerAdapter
    {
        List<User_Event> GetUserEvents(string id);

        Event GetMyEvent(int id);

        void SaveEvent(Event myEvent, string id);

        
      
    }
}
