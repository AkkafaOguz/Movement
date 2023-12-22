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
            var movement = new Movement();
            var human = new Human();
            var alien = new Alien();
            
            movement.GetMapDimensionsFromUser();
            var movementCoordinates = movement.GetMovementCoordinatesFromUser();
            var lifeForm = movement.GetLifeFormFromUser();

            if (lifeForm == 1)
            {
                var movementPath = human.GenerateRootCoordinates(movementCoordinates,movement.Width,movement.Height);
                movement.ReportPathAndActualCoordinate(movementPath);
            }
            else
            {
                var movementPath = alien.GenerateRootCoordinates(movementCoordinates, movement.Width, movement.Height);
                movement.ReportPathAndActualCoordinate(movementPath);
            }
            



        }
    }
}
