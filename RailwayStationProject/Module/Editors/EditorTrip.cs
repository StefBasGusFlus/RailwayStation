using System;
using System.Linq;
using RailwayStationProject.Interfaces;
using RailwayStationProject.Data;

namespace RailwayStationProject.Module.Editors
{
    internal class EditorTrip : IModulating
    {
        public string Name { get; } = "Рейс";

        private string[] _subMenu =
        {
           "Маршрут рейса: ",
           "Номер рейса: ",
           "Название автобуса: ",
           "Количество мест в автобусе: ",
           "Дата и время отправления(дд.мм.гггг чч:мм): "
        };

        private DataRepositories _workFile = new DataRepositories();

        public bool MenuThisModule()
        {
            Editor();

            return false;
        }

        public void Editor()
        {
            string[] data = new string[_subMenu.Length + 1];

            for (int i = 0; i < _subMenu.Length; i++)
            {
                Console.Write(_subMenu[i]);
                data[i] = Console.ReadLine();

                if (data[i] == "")
                    return;

                switch (i)
                {
                    case 0:
                        if (!isExistRoute(data[i]))
                        {
                            Navigation.ErrorChoise("Маршрут не существует!");
                            return;
                        }
                        break;
                    case 1:
                    case 3:
                        try
                        {
                            int.Parse(data[i]);
                        }
                        catch
                        {
                            Navigation.ErrorChoise("Некорректный ввод данных!");
                            return;
                        }
                        break;
                    case 4:
                        try
                        {
                            DateTime.Parse(data[i]);
                        }
                        catch
                        {
                            Navigation.ErrorChoise("Некорректное время!");
                            return;
                        }
                        break;
                }
            }

            Console.Clear();
            data[data.Length - 1] = Guid.NewGuid().ToString();
            _workFile.SaveData(new int[int.Parse(data[3])], $"{data[data.Length - 1]}.txt");
            _workFile.SaveData(data, "DataTrip.txt");
        }

        private bool isExistRoute(string nameRoute)
        {
            foreach(var route in _workFile.Routes)
            {
                if (route.NameRoute == nameRoute)
                    return true;
            }

            return false;
        }

        
    }
}
