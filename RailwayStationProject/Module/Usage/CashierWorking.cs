using System;
using System.IO;
using System.Collections.Generic;
using RailwayStationProject.Data;

namespace RailwayStationProject.Module.Usage
{
    internal class CashierWorking
    {
        private const int PLACE_OCCUPIED = 999;
        private const int NO_PLACES = -1;
        private DataRepositories _workFile = new DataRepositories();

        public void Use()
        {
            if (File.Exists("DataRoute.txt"))
            {
                Console.Write("Введите название остановки: ");
                string busStop = Console.ReadLine();
                Route foundRouteByStop = RouteSearch(busStop);

                if (foundRouteByStop == null)
                {
                    Choise.ErrorChoise("Ни один маршрут не найден");
                    return;
                }

                Console.WriteLine($"Маршрут: {foundRouteByStop.NameRoute}");

                Console.WriteLine("----------|РЕЙСЫ|----------");
                List<Trip> existTrips = ExistTripsByRoute(foundRouteByStop.NameRoute);

                if(existTrips == null)
                {
                    Choise.ErrorChoise("РЕЙСОВ НЕТ!");
                    return;
                }

                DisplayingListTrip(existTrips);

                Console.Write("Какой рейс(номер по списку): ");
                int choisedTrip = int.Parse(Console.ReadLine()) - 1;

                if(choisedTrip < 0 && choisedTrip > existTrips.Count - 1)
                {
                    Choise.ErrorChoise("Неверный номер!");
                    return;
                }

                int indexFreePlace = StillFreePlace(existTrips[choisedTrip].BusTrip);

                if(indexFreePlace == NO_PLACES)
                {
                    Choise.ErrorChoise("Мест нет!");
                    return;
                }

                existTrips[choisedTrip].BusTrip.Places[indexFreePlace] = PLACE_OCCUPIED;
                _workFile.SaveData(existTrips[choisedTrip].BusTrip.Places, $"{existTrips[choisedTrip].FilePlacesInBus}.txt");

                Console.Clear();
                Console.WriteLine
                    (
                      $"Маршрут: {existTrips[choisedTrip].RouteTrip.NameRoute}\n" +
                      $"Номер рейса: {existTrips[choisedTrip].NameTrip}\n" +
                      $"Остановка: {busStop}\n" +
                      $"Дата отправления: {existTrips[choisedTrip].DepartureTime}\n" +
                      $"Место: {indexFreePlace + 1}"
                    );
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Choise.ErrorChoise("Данных нет");
                return;
            }
        }

        private Route RouteSearch(string nameStop)
        {
            foreach (Route route in _workFile.Routes)
            {
                for (int i = 0; i < route.Stops.Length; i++)
                {
                    if (nameStop == route.Stops[i])
                        return route;
                }
            }

            return null;
        }

        private List<Trip> ExistTripsByRoute(string nameRouteSearch)
        {
            List<Trip> existTrips = new List<Trip>();

            foreach(Trip trip in _workFile.Trips)
            {
                if(trip.RouteTrip.NameRoute == nameRouteSearch)
                {
                    existTrips.Add(trip);
                }
            }

            return existTrips.Count == 0 ? null : existTrips;
        }

        private void DisplayingListTrip(List<Trip> trips)
        {
            int numbering = 0;

            foreach(Trip trip in trips)
            {
                numbering++;
                Console.WriteLine($"{numbering}. № {trip.NameTrip}\t{trip.DepartureTime}\t{trip.BusTrip.NameBrand}");
            }
        }

        private int StillFreePlace(Bus bus)
        {
            for (int i = 0; i < bus.Places.Length; i++)
            {
                if (bus.Places[i] != PLACE_OCCUPIED)
                    return i;
            }

            return NO_PLACES;
        }
    }
}
