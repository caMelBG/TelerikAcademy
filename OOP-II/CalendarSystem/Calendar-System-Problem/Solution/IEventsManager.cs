using System;
using System.Collections.Generic;

namespace CalendarSystem
{
    public interface IEventsManager
    {
        void AddEvent(Event eventToAdd);

        int DeleteEventsByTitle(string title);

        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}
