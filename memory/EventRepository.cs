

using ChipIn.models;

namespace ChipIn
{
    public class EventRepository : IEventRepository
    {
        public List<Event> GetAllUserEventByPartName(string partname)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllUserEventsById(int id)
        {
            List<Event> events = new List<Event>();
            Event @event = new Event();
            @event.CreditorName = "Jack";
            @event.Deadline = DateTime.Now;
            @event.Id = id;
            events.Add(@event);

            return events;
        }

        public Event GetUserEventById(int id)
        {
            throw new NotImplementedException();
        }

        public void SetEvent(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}