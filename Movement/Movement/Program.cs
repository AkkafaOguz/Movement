using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var map = new Map();
            map.GetMapDimensionsFromUser();

            var movement = new Movement(map);
            movement.GetMovementCoordinatesFromUser();
            movement.GetLifeFormFromUser();

        }
    }
}
