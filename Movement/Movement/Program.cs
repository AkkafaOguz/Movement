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
            List <int> coordinates = movement.GetMovementCoordinatesFromUser();
            movement.GetLifeFormFromUser();

            var human = new Human();
            human.GenerateRootCoordinates(coordinates);


        }
    }
}
