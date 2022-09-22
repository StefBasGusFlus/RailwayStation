using System;
using System.IO;
using System.Collections.Generic;
using RailwayStationProject.Module;
using RailwayStationProject.Interfaces;
using RailwayStationProject.Data;

namespace RailwayStationProject.Module.Editors
{
    internal class EditorRoute : IModulating
    {
        public string Name { get; } = "Маршрут";

        private string[] _subMenu =
        {
            "Введите название маршрута: ",
            "Время в пути(дд:чч:мм): ",
            "Остановки(в порядке, через запятую): "
        };

        public bool MenuThisModule()
        {
            Editor();

            return false;
        }

        public void Editor()
        {
            string[] data = new string[_subMenu.Length];
            for (int i = 0; i < _subMenu.Length; i++)
            {
                Console.Write(_subMenu[i]);
                data[i] = Console.ReadLine();
                if (data[i] == null)
                    return;
            }

            Console.Clear();
            DataRepositories workFile = new DataRepositories();
            workFile.SaveData(data, "DataRoute.txt");
        }
    }
}
