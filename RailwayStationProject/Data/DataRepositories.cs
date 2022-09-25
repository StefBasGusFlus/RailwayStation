using System;
using System.Collections.Generic;
using System.IO;
using RailwayStationProject.Interfaces;
using RailwayStationProject.Module.Editors;

namespace RailwayStationProject.Data
{
    internal static class PathsFiles
    {
        public static string PathFileRoute { get; } = "DataRoute.txt";

        public static string PathFileTrip { get; } = "DataTrip.txt";
    }

    internal class DataRepositories
    {
        private delegate IStorable LoadingElement(string[] data, ref int index);

        public List<Route> Routes { get; private set; }

        public List<Trip> Trips { get; private set; }

        public DataRepositories()
        {
            Routes = LoadData<Route>(PathsFiles.PathFileRoute, InstructionsDownloadingRoute);
            Trips = LoadData<Trip>(PathsFiles.PathFileTrip, InstructionsDownloadingTrip);
        }

        public void SaveData(string[] data, string path)
        {
            for (int i = 0; i < data.Length; i++)
                 File.AppendAllText(path, data[i] + "\n");
        }

        public void SaveData(int[] data, string path)
        {
            if (!Directory.Exists("Places"))
                Directory.CreateDirectory("Places");

            FileStream fs = new FileStream("Places\\" + path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < data.Length; i++)
                sw.WriteLine(data[i]);

            sw.Close();
            fs.Close();
        }

        private static List<T> LoadData<T>(string path, LoadingElement loading)
            where T : IStorable
        { 
            if(!File.Exists(path))
                File.Create(path).Close();

            List<T> elements = new List<T>();
            string[] data = File.ReadAllLines(path);
            for (int i = 0; i < data.Length; i++)
            {
                T element = (T)loading(data, ref i);
                elements.Add(element);
            }

            return elements;
        }

        private Route InstructionsDownloadingRoute(string[] data, ref int index)
        {
            Route route = new Route
            {
                NameRoute = data[index++],
                TravelTime = TimeSpan.Parse(data[index++]),
                Stops = data[index].Split(',')
            };

            return route;
        }

        private Trip InstructionsDownloadingTrip(string[] data, ref int index)
        {
            Trip trip = new Trip
            {
                RouteTrip = SearchRouteByName(data[index++]),
                NameTrip = int.Parse(data[index++]),
                BusTrip = new Bus 
                { 
                    NameBrand = data[index++], 
                    Places = new int[int.Parse(data[index++])] 
                },
                DepartureTime = DateTime.Parse(data[index++]),
                FilePlacesInBus = data[index]
            };
            
            if(File.Exists($"Places\\{trip.FilePlacesInBus}.txt"))
               trip.BusTrip.Places = ExtractingPlaces($"{trip.FilePlacesInBus}.txt");
        
            return trip;
        }

        private int[] ExtractingPlaces(string nameFile)
        {
            string[] text = File.ReadAllLines("Places\\" + nameFile);
            int[] dataPlaces = new int[text.Length];

            for (int i = 0; i < text.Length; i++)
               dataPlaces[i] = int.Parse(text[i]);
            
            return dataPlaces;
        }

        private Route SearchRouteByName(string name)
        {
            foreach(Route route in Routes)
            {
                if(name == route.NameRoute)
                    return route;
            }

            return null;
        }
    }
}
