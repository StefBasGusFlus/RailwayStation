using System;


namespace RailwayStationProject
{
    public class FrameLimitsException : Exception
    {
        private string _text = "Столбец выходит за пределы рамки";

        public override string Message => _text;

        public FrameLimitsException() { }

        public FrameLimitsException(string text)
        {
            _text = text;
        }
    }
}
