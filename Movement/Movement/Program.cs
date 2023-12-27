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
            var lifeForm = new LifeForm();
            var movement = new Movement(lifeForm.GetLifeFormFromUser());
            movement
                .GetMapDimensionsFromUser()
                .GetMovementCoordinatesFromUser()
                .GenerateCoordinates()
                .ReportPathAndActualCoordinate();
        }
    }
}
