using RailwayStationProject.Interfaces;

namespace RailwayStationProject.Module
{
    internal class Exit : IModulating
    {
        public string Name { get; } = "Выход";

        public bool MenuThisModule()
        {
            return true;
        }
    }
}
