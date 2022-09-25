using System;
using RailwayStationProject.Interfaces;
using RailwayStationProject.Data;

namespace RailwayStationProject.Module
{
    internal class Info : IModulating
    {
        public string Name { get; } = "Информер";

        private DataRepositories data = new DataRepositories();

        public bool MenuThisModule()
        { 
            foreach(var route in data.Routes)
            {
                Console.WriteLine($"Маршрут: {route.NameRoute}");

                Console.WriteLine("!!!РЕЙСЫ!!!");
                foreach(var trip in data.Trips)
                {
                    if(route.NameRoute == trip.RouteTrip.NameRoute)
                    {
                        Console.WriteLine($"№{trip.NameTrip}" +
                        $" Автобус: {trip.BusTrip.NameBrand}" +
                        $" Кол-во мест: {trip.BusTrip.Places.Length}" +
                        $" Дата отправления: {trip.DepartureTime}");
                    }
                }
            }
            Console.ReadLine();

            return false;
        }
    }
}
