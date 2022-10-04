using System;
using RailwayStationProject.Interfaces;


namespace RailwayStationProject
{
    internal class Navigation
    {
        private IModulating[] _elementsMenu;

        public event Action<int> OrientationMenuChoose;

        public Navigation(IModulating[] elementsMenu)
        {
            _elementsMenu = elementsMenu;
        }

        public int ChoiseInVerticalMenu()
        {
            Console.CursorVisible = false;

            int activeElement = 0;
            bool isVisible = true;

            while (isVisible)
            {
                OrientationMenuChoose?.Invoke(activeElement);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch(key.Key)
                {
                    case ConsoleKey.W: if(activeElement > 0) activeElement--; break;
                    case ConsoleKey.S: if(activeElement < _elementsMenu.Length - 1) activeElement++; break;
                    case ConsoleKey.Enter: isVisible = false; break;
                }    
            }
            Console.ResetColor();
            Console.Clear();

            return activeElement;
        }

        public int ChoiseInHorizontalMenu()
        {
            Console.CursorVisible = false;

            int activeElement = 0;
            bool isWorking = true;

            while (isWorking)
            {
                OrientationMenuChoose?.Invoke(activeElement);

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.A: if (activeElement > 0) activeElement--; break;
                    case ConsoleKey.D: if (activeElement < _elementsMenu.Length - 1) activeElement++; break;
                    case ConsoleKey.Enter: isWorking = false; break;
                }
            }
            Console.ResetColor();
            Console.Clear();

            return activeElement;
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
