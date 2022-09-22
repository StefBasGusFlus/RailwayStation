using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayStationProject.Module;
using RailwayStationProject.Interfaces;

namespace RailwayStationProject.Data
{
    internal class Trip : IStorable
    {
        public int NameTrip { get; init; }
        public Bus BusTrip { get; init; }
        public Route RouteTrip { get; init; }
        public DateTime DepartureTime { get; init; }
        public string FilePlacesInBus { get; init; }
    }
}
