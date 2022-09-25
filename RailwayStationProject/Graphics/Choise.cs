using System;
using RailwayStationProject.Interfaces;


namespace RailwayStationProject
{
    internal class Choise : Menu
    {
        private bool _isWipe = true;

        public Choise(params IModulating[] elementsMenu) :base(elementsMenu) { }

        public Choise(bool isWipe, params IModulating[] elementsMenu) : base(elementsMenu) => _isWipe = isWipe;

        public Choise(int x, int y, params IModulating[] elementsMenu) : base(x, y, elementsMenu) { }

        public Choise(int x, int y, bool isWipe, params IModulating[] elementsMenu) : base(x, y, elementsMenu) => _isWipe = isWipe;

        public int ChoiseInVerticalMenu()
        {
            Frame frame = new Frame(_x - 2, _y - 1, MaxLengthElementMenu() + 3, _elementsMenu.Length);
            Console.CursorVisible = false;
            int activeElement = 0;
            bool isVisible = true;
            while (isVisible)
            {
                VerticalMenu(activeElement);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch(key.Key)
                {
                    case ConsoleKey.W: if(activeElement > 0) activeElement--; break;
                    case ConsoleKey.S: if(activeElement < _elementsMenu.Length - 1) activeElement++; break;
                    case ConsoleKey.Enter: isVisible = false; break;
                }    
            }
            Console.ResetColor();

            if (_isWipe)
                Console.Clear();

            return activeElement;
        }

        public int ChoiseInGorizontalMenu()
        {
            Console.CursorVisible = false;
            int active = 0;
            bool isWorking = true;
            while (isWorking)
            {
                DrawingGorizontalMenu(active);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.A: if (active > 0) active--; break;
                    case ConsoleKey.D: if (active < _elementsMenu.Length - 1) active++; break;
                    case ConsoleKey.Enter: isWorking = false; break;
                }
            }
            Console.ResetColor();

            if (_isWipe)
                Console.Clear();

            return active;
        }

        public static void ErrorChoise(string error)
        {
            Console.Clear();
            Frame frame = new Frame(MenuPosition.X - 2, MenuPosition.Y - 2, error.Length + 2, 3);
            Console.SetCursorPosition(MenuPosition.X, MenuPosition.Y);
            Console.Write(error);
            Console.ReadLine();
            Console.Clear();

        }
    }
}
