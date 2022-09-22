using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStationProject.Interfaces
{
    internal interface IModulating
    {
        string Name { get; }

        bool MenuThisModule();
    }
}
