using RailwayStationProject.Module;
using RailwayStationProject.Module.Editors;
using RailwayStationProject.Interfaces;
using RailwayStationProject.Graphics;

namespace RailwayStationProject
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            IModulating[] subModules = { new EditorRoute(), new EditorTrip(), new Exit() };
            IModulating[] mainModules = 
            { 
                new Director(subModules), 
                new Cashier(), 
                new Info(),
                new Exit()
            };

            DrawModule.Draw(mainModules);
        }
    }
}
