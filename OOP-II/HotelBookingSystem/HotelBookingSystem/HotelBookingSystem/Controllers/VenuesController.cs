namespace HotelBookingSystem.Controllers
{
    using Contracts;
    using Infrastructure;
    using Models;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.Venues.GetAll();
            return this.View(venues);
        }

        public IView Details(int id)
        {
            this.Authorize(Role.User, Role.VenueAdmin);
            var venue = this.Data.Venues.Get(id);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
            }

            return this.View(venue);
        }

        public IView Rooms(int id)
        {
            var venue = this.Data.Venues.Get(id);
            if (venue == null)
            {
                return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
            }

            return this.View(venue);
        }

        public IView Add(string name, string address, string description)
        {
            this.Authorize(Role.VenueAdmin);
            var newVenue = new Venue(name, address, description, this.CurrentUser);
            this.Data.Venues.Add(newVenue);
            return this.View(newVenue);
        }
    }
}