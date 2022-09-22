using RailwayStationProject.Interfaces;
using RailwayStationProject.Graphics;

namespace RailwayStationProject.Module
{
    internal class Director : IModulating
    {
        public string Name { get; } = "Директор";

        private IModulating[] _modulesDirector;
        

        public Director(params IModulating[] modules)
        { 
            _modulesDirector = modules; 
        }

        public bool MenuThisModule()
        {
            DrawModule.Draw(_modulesDirector);
            return false;
        }
    }
}
