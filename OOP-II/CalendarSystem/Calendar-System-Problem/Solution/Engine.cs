using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem
{
    public class Engine
    {
        private readonly IEventsManager eventsManager;

        public Engine(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }
        public IEventsManager EventsManager
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(Command command)
        {
            if (command.Name == "AddEvent")
            {
                var date = DateTime.ParseExact(command.Paramms[0],
                    "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

                var location = command.Paramms.Length == 2
                    ? null
                    : command.Paramms[2];

                var currentEvent = new Event(date, command.Paramms[1], location);

                this.eventsManager.AddEvent(currentEvent);

                return "Event added";
            }

            else if (command.Name == "DeleteEvents")
            {
                int count = this.eventsManager.DeleteEventsByTitle(command.Paramms[0]);

                if (count == 0)
                {
                    return "No events found.";
                }

                return count + " events deleted";
            }

            else if (command.Name == "ListEvents")
            {
                var date = DateTime.ParseExact(command.Paramms[0],
                    "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var count = int.Parse(command.Paramms[1]);
                var events = this.eventsManager.ListEvents(date, count).ToList();
                var result = new StringBuilder();

                if (!events.Any())
                {
                    return "No events found";
                }

                foreach (var currentEvent in events)
                {
                    result.AppendLine(currentEvent.ToString());
                }

                return result.ToString().Trim();
            }

            throw new Exception("WTF " + command.Name + " is?");
        }
    }
}
