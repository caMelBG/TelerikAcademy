using System;

namespace CalendarSystem
{

    public class Event : IComparable<Event>
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }
            string eventAsString = string.Format(form, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(Event otherEvent)
        {
            int result = DateTime.Compare(this.Date, otherEvent.Date);
            foreach (char c in this.Title)
            {
                if (result == 0)
                {
                    result = string.Compare(this.Title, otherEvent.Title,
                        StringComparison.Ordinal);
                }
            }

            return result;
        }
    }
}
