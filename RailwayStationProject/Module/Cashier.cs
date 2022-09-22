using RailwayStationProject.Interfaces;
using RailwayStationProject.Graphics;
using RailwayStationProject.Module.Usage;

namespace RailwayStationProject.Module
{
    internal class Cashier : IModulating
    {
        public string Name { get; } = "Кассир";

       

        public bool MenuThisModule()
        {
            CashierWorking work = new CashierWorking();
            work.Use();
            return false;
        }
    }
}
