﻿using System;

namespace HotelBookingSystem
{
    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var чепеларскиЕнджин = Activator.CreateInstance(typeof(Engine)) as Engine;
            чепеларскиЕнджин.StartOperation();
        }
    }
}
