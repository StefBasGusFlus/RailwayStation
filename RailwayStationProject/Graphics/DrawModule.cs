using RailwayStationProject.Interfaces;

namespace RailwayStationProject.Graphics
{
    internal static class DrawModule
    {
        public static void Draw(IModulating[] modules)
        {
            bool isExit = false;

            while (!isExit)
            {
                Menu menu = new Menu(modules);
                int choisedModule = menu.UseVerticalMenu();
                isExit = modules[choisedModule].MenuThisModule();
            }
        }
    
    }
}

