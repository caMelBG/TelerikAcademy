namespace VehicleParkSystem
{
    using System;

    public class Layout
    {
        public Layout(int numberOfSectors, int placesPerSector)
        {
            if (numberOfSectors <= 0)
            {
                throw new DivideByZeroException("The number of sectors must be positive.");
            }
            NumberOfSectors = numberOfSectors;
            if (placesPerSector <= 0)
            {
                throw new DivideByZeroException("The number of places per sector must be positive.");
            }
            PlacesPerSector = placesPerSector;
        }

        public int NumberOfSectors { get; private set; }

        public int PlacesPerSector { get; private set; }
    }
}
