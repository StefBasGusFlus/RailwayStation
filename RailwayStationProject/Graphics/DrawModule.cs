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
                Choise ch = new Choise(modules);
                int choisedModule = ch.ChoiseInVerticalMenu();
                isExit = modules[choisedModule].MenuThisModule();
            }
        }
    
    }
}

