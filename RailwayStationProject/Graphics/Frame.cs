using System;
using System.Collections.Generic;

namespace RailwayStationProject
{
    /// <summary>
    /// Инструменты работы с таблицей в консоли
    /// </summary>
    public class Frame
    {
        protected int _x;
        protected int _y;
        protected int _width;
        protected int _height;

        private static List<int> _posColumns = new List<int>();
        private static List<int> _posStrings = new List<int>();

        public Frame(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            SimpleFrame();
        }

        /// <summary>
        /// Создает простую рамку сразу, после инициализации обьекта
        /// </summary>
        private void SimpleFrame()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write("╔");
            for (int i = 0; i < _width; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");

            for (int i = 0; i < _height; i++)
            {
                Console.SetCursorPosition(_x, _y + i + 1);
                Console.Write("║");
                Console.SetCursorPosition(_x + _width + 1, _y + i + 1);
                Console.Write("║");
            }

            Console.SetCursorPosition(_x, _y + _height + 1);
            Console.Write("╚");
            for (int i = 0; i < _width; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
        }

        /// <summary>
        /// Создает столбец в пределах созданной таблицы
        /// </summary>
        /// <param name="posColumn">Позиция столбца</param>
        /// <exception cref="FrameLimitsException">Указанная позиция за пределами таблицы</exception>
        public void SubColumn(int posColumn)
        {
            if (posColumn <= 0 || posColumn > _width)
                throw new FrameLimitsException();

            posColumn += _x;
            Console.SetCursorPosition(posColumn, _y);
            Console.Write("╤");
            for (int i = 0; i < _height; i++)
            {
                Console.SetCursorPosition(posColumn, _y + i + 1);
                Console.Write("│");
            }
            Console.SetCursorPosition(posColumn, _y + _height + 1);
            Console.Write("╧");

            _posColumns.Add(posColumn);

            if (_posStrings.Count != 0)
            {
                for (int i = 0; i < _posStrings.Count; i++)
                {
                    Console.SetCursorPosition(posColumn, _posStrings[i]);
                    Console.Write("┼");
                }
            }
        }

        /// <summary>
        /// Создает строку в таблице
        /// </summary>
        /// <param name="posString">Позиция строки</param>
        /// <exception cref="FrameLimitsException">Указанная позиция за пределами таблицы</exception>
        public void SubString(int posString)
        {
            if (posString <= 0 || posString > _height)
                throw new FrameLimitsException();

            posString += _y;
            Console.SetCursorPosition(_x, posString);
            Console.Write("╟");
            for (int i = 0; i < _width; i++)
            {
                Console.SetCursorPosition(_x + i + 1, posString);
                Console.Write("─");
            }
            Console.Write("╢");

            _posStrings.Add(posString);

            if (_posColumns.Count != 0)
            {
                for (int i = 0; i < _posColumns.Count; i++)
                {
                    Console.SetCursorPosition(_posColumns[i], posString);
                    Console.Write("┼");
                }
            }
        }
    }
}
