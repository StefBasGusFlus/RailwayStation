using System;
using RailwayStationProject.Interfaces;

namespace RailwayStationProject
{

    internal static class MenuPosition
    {
        public const int X = 5;
        public const int Y = 5;
    }

    internal class Menu
    {
        protected readonly IModulating[] _elementsMenu;
        protected readonly int _x;
        protected readonly int _y;
        protected readonly Navigation _choise;

        public Menu(IModulating[] elementsMenu) 
        {
            _elementsMenu = elementsMenu;

            _choise = new Navigation(_elementsMenu);

            _x = MenuPosition.X;
            _y = MenuPosition.Y;
        }

        public Menu(int x, int y, IModulating[] elementsMenu) : this(elementsMenu)
        {
            _x = x;
            _y = y;
        }

        public int UseVerticalMenu()
        {
            Frame frame = new Frame(_x - 2, _y - 1, MaxLengthElementMenu() + 3, _elementsMenu.Length);

            _choise.OrientationMenuChoose += VerticalMenu;

            int active = _choise.ChoiseInVerticalMenu();

            _choise.OrientationMenuChoose -= VerticalMenu;

            return active;
        }

        public int UseHorizontalMenu()
        {
            _choise.OrientationMenuChoose += HorizontalMenu;

            int active = _choise.ChoiseInHorizontalMenu();

            _choise.OrientationMenuChoose -= HorizontalMenu;

            return active;
        }

        public void VerticalMenu(int active)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < _elementsMenu.Length; i++)
            {
                Console.SetCursorPosition(_x, _y + i);
                Console.Write(_elementsMenu[i].Name);
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(_x, _y + active);
            Console.WriteLine(_elementsMenu[active].Name);
        }
        
        public void HorizontalMenu(int active)
        {
            int total = 0;
            int activeX = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < _elementsMenu.Length; i++)
            {
                if (i == active)
                    activeX = total;
                Console.SetCursorPosition(_x + total, _y);
                Console.Write(_elementsMenu[i].Name);
                total += _elementsMenu[i].Name.Length;
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(_x + activeX, _y);
            Console.WriteLine(_elementsMenu[active].Name);
            
        }

        public int MaxLengthElementMenu()
        {
            int total = int.MinValue;

            foreach (IModulating i in _elementsMenu)
            {
                if(i.Name.Length > total)
                    total = i.Name.Length;
            }

            return total;
        }
    }
}
