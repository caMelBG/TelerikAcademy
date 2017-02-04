using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace CalendarSystem
{
    public class EventsManager : IEventsManager
    {
        private readonly MultiDictionary<string, Event> eventByTitle =
            new MultiDictionary<string, Event>(true);

        private readonly OrderedMultiDictionary<DateTime, Event> eventByDate =
            new OrderedMultiDictionary<DateTime, Event>(true);

        public void AddEvent(Event currentEvent)
        {
            string eventTitleLowerCase = currentEvent.Title.ToLowerInvariant();
            this.eventByTitle.Add(eventTitleLowerCase, currentEvent);
            this.eventByDate.Add(currentEvent.Date, currentEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleLowerCase = title.ToLowerInvariant();
            var eventsToDelete = this.eventByTitle[titleLowerCase];
            int count = eventsToDelete.Count;

            foreach (var currentEvent in eventsToDelete)
            {
                this.eventByDate.Remove(currentEvent.Date, currentEvent);
            }

            this.eventByTitle.Remove(titleLowerCase);

            return count;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var dates =
                from e in this.eventByDate.RangeFrom(date, true).Values
                select e;
            var events = dates.Take(count);
            return events;
        }
    }
}
