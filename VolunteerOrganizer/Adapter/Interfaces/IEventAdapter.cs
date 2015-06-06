using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerOrganizer.Data;
using VolunteerOrganizer.Data.Model;

namespace VolunteerOrganizer.Adapter.Interfaces
{
    public interface IEventAdapter
    {
        List<Event> GetEvents(int id);
        Event GetMyEvent(int id);
        void EditEvent(Event myEvent);
        void AddEvent(Event myEvent);
         Event GetOrganizationId(int id);
         void DeleteEvent(int id);
         List<User_Event> SendMessage(int id);
        
         List<User_Event> SendMessageToAll(int id, string message);
         List<User_Event> ConfirmMessage(int id);
    }

}
