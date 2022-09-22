using System;
using RailwayStationProject.Interfaces;

namespace RailwayStationProject.Data
{
    internal class Route : IStorable
    {
        public string NameRoute { get; init; }
        public TimeSpan TravelTime { get; init; }
        public string[] Stops { get; init; }
        
    }
}
